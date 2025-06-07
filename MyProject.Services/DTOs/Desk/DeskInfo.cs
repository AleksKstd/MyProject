namespace MyProject.Services.DTOs.Desk
{
    public class DeskInfo
    {
        public int DeskId { get; set; }
        public int Floor { get; set; }
        public string Zone { get; set; }
        public bool HasMonitor { get; set; }
        public bool HasDock { get; set; }
        public bool HasWindow { get; set; }
        public bool HasPrinter { get; set; }
    }
}
