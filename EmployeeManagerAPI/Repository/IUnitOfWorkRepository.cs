
namespace EmployeeManagerAPI.Repository
{
    public interface IUnitOfWorkRepository
    {
        IEmployeeRepository empRepo { get; }
    }
}
