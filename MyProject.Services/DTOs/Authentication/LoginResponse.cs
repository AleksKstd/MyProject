namespace MyProject.Services.DTOs.Authentication
{
    public class LoginResponse : BaseResponse
    {
        public string? Username { get; set; }
        public string? Name { get; set; }
    }
}
