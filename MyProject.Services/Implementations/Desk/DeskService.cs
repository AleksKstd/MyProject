using MyProject.Repository.Interfaces.Desk;
using MyProject.Services.DTOs.Desk;
using MyProject.Services.Interfaces.Desk;

namespace MyProject.Services.Implementations.Desk
{
    public class DeskService : IDeskService
    {
        private readonly IDeskRepository _deskRepository;
        public DeskService(IDeskRepository deskRepository)
        {
            _deskRepository = deskRepository;
        }

        public async Task<GetDeskByIdResponse> GetDeskByIdAsync(int deskId)
        {
            var desk = await _deskRepository.RetrieveAsync(deskId);

            if (desk == null)
            {
                throw new KeyNotFoundException($"Desk with ID {deskId} not found.");
            }

            return (GetDeskByIdResponse)MapToDeskInfo(desk);
        }
        public async Task<GetAllDesksResponse> GetAllDesksAsync()
        {
            var desks = await _deskRepository.RetrieveCollectionAsync(new DeskFilter()).ToListAsync();
            var allDesks = new GetAllDesksResponse
            {
                Desks = desks.Select(d => MapToDeskInfo(d)).ToList(),
                TotalCount = desks.Count
            };
            
            return allDesks;
        }
        private DeskInfo MapToDeskInfo(Models.Desk desk)
        {
            return new DeskInfo
            {
                DeskId = desk.DeskId,
                Floor = desk.Floor,
                Zone = desk.Zone,
                HasMonitor = desk.HasMonitor,
                HasDock = desk.HasDock,
                HasWindow = desk.HasWindow,
                HasPrinter = desk.HasPrinter
            };
        }
    }
}
