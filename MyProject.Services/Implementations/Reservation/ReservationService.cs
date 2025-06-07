using MyProject.Models;
using MyProject.Repository.Interfaces.Reservation;
using MyProject.Services.DTOs.Reservation;
using MyProject.Services.Interfaces.Reservation;

namespace MyProject.Services.Implementations.Reservation
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<GetAllReservationsForUserResponse> GetAllUserReservations(int userId)
        {
            await UpdateAllReservationsStatus();
            if (userId <= 0)
            {
                return new GetAllReservationsForUserResponse
                {
                    Reservations = new List<ReservationInfo>(),
                    TotalCount = 0
                };
            }
            var reservations = await _reservationRepository.RetrieveCollectionAsync(new ReservationFilter { UserId = userId }).ToListAsync();
            reservations.OrderByDescending(a => a.IsActive);

            return new GetAllReservationsForUserResponse
            {
                Reservations = reservations.Select(MapToReservationInfo).ToList(),
                TotalCount = reservations.Count
            };
        }
        public async Task<CreateReservationResponse> CreateReservation (CreateReservationRequest request)
        {
            if (request == null || request.UserId <= 0 || request.DeskId <= 0 || request.Date == default)
            {
                return new CreateReservationResponse
                {
                    Success = false,
                    ErrorMessage = "Invalid reservation request."
                };
            }
            if(request.Date.Date < DateTime.UtcNow || request.Date.Date > DateTime.UtcNow.AddDays(14))
            {
                return new CreateReservationResponse
                {
                    Success = false,
                    ErrorMessage = "Reservation date must be within the next 14 days."
                };
            }

            var existingReservation = await _reservationRepository.RetrieveCollectionAsync(new ReservationFilter
            {
                UserId = request.UserId,
                Date = request.Date
            }).FirstOrDefaultAsync();

            if (existingReservation != null)
            {
                return new CreateReservationResponse
                {
                    Success = false,
                    ErrorMessage = "You already have a reservation for this date."
                };
            }

            var deskReservations = await _reservationRepository.RetrieveCollectionAsync(new ReservationFilter
            {
                DeskId = request.DeskId,
                Date = request.Date
            }).ToListAsync();

            if (deskReservations.Any())
            {
                return new CreateReservationResponse
                {
                    Success = false,
                    ErrorMessage = "This desk is already reserved for the selected date."
                };
            }

            var reservation = new Models.Reservation
            {
                UserId = request.UserId,
                DeskId = request.DeskId,
                Date = request.Date,
                IsActive = true
            };
            int reservationId = await _reservationRepository.CreateAsync(reservation);
            return new CreateReservationResponse
            {
                Success = true
            };
        }
        private async Task UpdateAllReservationsStatus()
        {
            var allReservations = await _reservationRepository.RetrieveCollectionAsync(new ReservationFilter()).ToListAsync();
            foreach (var reservation in allReservations)
            {
                if (reservation.Date < DateTime.UtcNow)
                {
                    reservation.IsActive = false;
                    await _reservationRepository.UpdateAsync(reservation.ReservationId, new ReservationUpdate { IsActive = reservation.IsActive });
                }
            }
        }
        private ReservationInfo MapToReservationInfo(Models.Reservation reservation)
        {
            return new ReservationInfo
            {
                ReservationId = reservation.ReservationId,
                UserId = reservation.UserId,
                DeskId = reservation.DeskId,
                Date = reservation.Date,
                IsActive = reservation.IsActive
            };
        }
    }
}
