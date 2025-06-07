using MyProject.Repository.Base;

namespace MyProject.Repository.Interfaces.Desk
{
    public interface IDeskRepository : IBaseRepository<Models.Desk, DeskFilter, DeskUpdate>
    {
    }
}
