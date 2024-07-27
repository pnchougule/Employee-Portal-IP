using EmployeeManagerAPI.Models;
using Microsoft.Extensions.Options;

namespace EmployeeManagerAPI.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private EmployeeManagerDbContext _context;
        public IEmployeeRepository empRepo { get; private set; }

        public UnitOfWorkRepository(EmployeeManagerDbContext context)
        {
            _context = context;
            empRepo = new EmployeeRepository(_context);

        }
    }
}
