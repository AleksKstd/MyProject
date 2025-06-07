using Microsoft.Data.SqlClient;
using MyProject.Repository.Base;
using MyProject.Repository.Interfaces.Reservation;

namespace MyProject.Repository.Implementations.Reservation
{
    public class ReservationRepository : BaseRepository<Models.Reservation>, IReservationRepository
    {
        protected override string[] GetColumns()
        {
            return new[]
            {
                "ReservationId",
                "UserId",
                "DeskId",
                "Date",
                "IsActive"
            };
        }

        protected override string GetTableName()
        {
            return "Reservations";
        }

        protected override Models.Reservation MapToEntity(SqlDataReader reader)
        {
            return new Models.Reservation
            {
                ReservationId = Convert.ToInt32(reader["ReservationId"]),
                UserId = Convert.ToInt32(reader["UserId"]),
                DeskId = Convert.ToInt32(reader["DeskId"]),
                Date = Convert.ToDateTime(reader["Date"]),
                IsActive = Convert.ToBoolean(reader["IsActive"])
            };
        }
        public Task<int> CreateAsync(Models.Reservation entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Reservation> RetrieveAsync(int objectId)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<Models.Reservation> RetrieveCollectionAsync(ReservationFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int objectId, ReservationUpdate update)
        {
            throw new NotImplementedException();
        }
    }
}
