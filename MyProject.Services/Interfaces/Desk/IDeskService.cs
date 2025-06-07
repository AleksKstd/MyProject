using MyProject.Services.DTOs.Desk;

namespace MyProject.Services.Interfaces.Desk
{
    public interface IDeskService
    {
        Task<GetAllDesksResponse> GetAllDesksAsync();
        Task<GetDeskByIdResponse> GetDeskByIdAsync(int deskId);
    }
}
