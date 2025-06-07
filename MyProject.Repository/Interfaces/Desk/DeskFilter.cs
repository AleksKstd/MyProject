using System.Data.SqlTypes;

namespace MyProject.Repository.Interfaces.Desk
{
    public class DeskFilter
    {
        public SqlInt32? Floor { get; set; }
        public SqlBoolean? HasMonitor { get; set; }
        public SqlBoolean? HasDock { get; set; }
        public SqlBoolean? HasWindow { get; set; }
        public SqlBoolean? HasPrinter { get; set; }
    }
}
