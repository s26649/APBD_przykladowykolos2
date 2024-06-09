using APBD_przykladowykolos2.Entities;
using APBD_przykladowykolos2.RequestModels;

namespace APBD_przykladowykolos2.Services;

public interface IClientService
{
    Client GetClientWithReservations(int id);
    bool AddReservation(ReservationRequest request, out int reservationId);
}
