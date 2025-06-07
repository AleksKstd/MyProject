using MyProject.Services.DTOs.Reservation;

namespace MyProject.Services.Interfaces.Reservation
{
    public interface IReservationService
    {
        Task<GetAllReservationsForUserResponse> GetAllUserReservations(int userId);
        Task<CreateReservationResponse> CreateReservation(CreateReservationRequest request);
    }
}
