namespace MyProject.Services.DTOs.Desk
{
    public class GetAllDesksResponse
    {
        public List<DeskInfo> Desks { get; set; }
        public int TotalCount { get; set; }
    }
}
