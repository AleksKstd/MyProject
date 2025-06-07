using Microsoft.Data.SqlClient;
using MyProject.Repository.Base;
using MyProject.Repository.Helpers;
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
        public async Task<int> CreateAsync(Models.Reservation entity)
        {
            return await base.CreateAsync(entity, "ReservationId");
        }

        public async Task<bool> DeleteAsync(int objectId)
        {
            return await base.DeleteAsync("ReservationId", objectId);
        }

        public async Task<Models.Reservation> RetrieveAsync(int objectId)
        {
            return await base.RetrieveAsync("ReservationId", objectId);
        }

        public IAsyncEnumerable<Models.Reservation> RetrieveCollectionAsync(ReservationFilter filter)
        {
            Filter commandFilter = new Filter();

            if (filter.UserId is not null)
            {
                commandFilter.AddCondition("UserId", filter.UserId.Value);
            }
            if (filter.Date is not null)
            {
                commandFilter.AddCondition("Date", filter.Date.Value);
            }
            if (filter.IsActive is not null)
            {
                commandFilter.AddCondition("IsActive", filter.IsActive.Value);
            }
            if (filter.DeskId is not null)
            {
                commandFilter.AddCondition("DeskId", filter.DeskId.Value);
            }

            return base.RetrieveCollectionAsync(commandFilter);
        }

        public async Task<bool> UpdateAsync(int objectId, ReservationUpdate update)
        {
            using SqlConnection connaction = await ConnectionFactory.CreateConnectionAsync();

            Update updateCommand = new Update(
                connaction,
                GetTableName(),
                "ReservationId", objectId);

            updateCommand.AddSetClause("IsActive", update.IsActive);

            return await updateCommand.ExecuteNonQueryAsync() > 0;
        }
    }
}
