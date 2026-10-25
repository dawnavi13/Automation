using Automation.Data;
using Automation.Interfaces;

namespace Automation.Services
{
    public class StockDetailsService : IStockDetailsService
    {
        private readonly ApplicationDbContext _context;

        public StockDetailsService(ApplicationDbContext context)
        {
            _context = context;
        }

    }
}
