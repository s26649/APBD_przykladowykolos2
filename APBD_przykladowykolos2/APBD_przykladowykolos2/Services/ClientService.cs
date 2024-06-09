using APBD_przykladowykolos2.Entities;
using APBD_przykladowykolos2.RequestModels;
using Microsoft.EntityFrameworkCore;

namespace APBD_przykladowykolos2.Services;

public class ClientService : IClientService
{
    private readonly BoatReservationDbContext _dbContext;

    public ClientService(BoatReservationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Client GetClientWithReservations(int id)
    {
        return _dbContext.Clients.Include(c => c.Reservations)
                                 .ThenInclude(r => r.BoatStandard)
                                 .FirstOrDefault(c => c.IdClient == id);
    }

    public bool AddReservation(ReservationRequest request, out int reservationId)
    {
        reservationId = 0;

        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            var client = _dbContext.Clients.Include(c => c.Reservations).FirstOrDefault(c => c.IdClient == request.IdClient);
            if (client == null)
            {
                throw new Exception("nie znaleziono klienta");
            }

            var activeReservation = client.Reservations.FirstOrDefault(r => !r.Fulfilled);
            if (activeReservation != null)
            {
                throw new Exception("klient juz ma rezerwacje");
            }

            var availableBoats = _dbContext.Sailboats
                                           .Where(s => s.IdBoatStandard == request.IdBoatStandard && !s.Sailboat_Reservations.Any(sr => sr.Reservation.DateFrom <= request.DateTo && sr.Reservation.DateTo >= request.DateFrom))
                                           .ToList();

            if (availableBoats.Count < request.NumOfBoats)
            {
                var higherStandardBoats = _dbContext.Sailboats
                                                    .Where(s => s.BoatStandard.Level > _dbContext.BoatStandards.Find(request.IdBoatStandard).Level && !s.Sailboat_Reservations.Any(sr => sr.Reservation.DateFrom <= request.DateTo && sr.Reservation.DateTo >= request.DateFrom))
                                                    .ToList();

                if (higherStandardBoats.Count < request.NumOfBoats - availableBoats.Count)
                {
                    var reservationToUpdate = new Reservation
                    {
                        IdClient = request.IdClient,
                        DateFrom = request.DateFrom,
                        DateTo = request.DateTo,
                        IdBoatStandard = request.IdBoatStandard,
                        Capacity = 0,
                        NumOfBoats = request.NumOfBoats,
                        Fulfilled = false,
                        Price = 0,
                        CancelReason = "nie ma wysrtarczajaco lodek"
                    };
                    _dbContext.Reservations.Add(reservationToUpdate);
                    _dbContext.SaveChanges();

                    transaction.Rollback();
                    throw new Exception("nie ma wysrtarczajaco lodek");
                }

                availableBoats.AddRange(higherStandardBoats.Take(request.NumOfBoats - availableBoats.Count));
            }

            var reservation = new Reservation
            {
                IdClient = request.IdClient,
                DateFrom = request.DateFrom,
                DateTo = request.DateTo,
                IdBoatStandard = request.IdBoatStandard,
                Capacity = availableBoats.Sum(b => b.Capacity),
                NumOfBoats = request.NumOfBoats,
                Fulfilled = true,
                Price = availableBoats.Sum(b => b.Price * (1 - (client.ClientCategory?.DiscountPerc ?? 0) / 100.0m))
            };
            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();

            foreach (var boat in availableBoats)
            {
                _dbContext.Sailboat_Reservations.Add(new Sailboat_Reservation { IdSailboat = boat.IdSailboat, IdReservation = reservation.IdReservation });
            }
            _dbContext.SaveChanges();

            transaction.Commit();
            reservationId = reservation.IdReservation;
            return true;
        }
        catch (Exception)
        {
            transaction.Rollback();
            return false;
        }
    }
}
