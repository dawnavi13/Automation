using Automation.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Automation.Controllers.Stocks
{
    public class StockController : ControllerBase
    {
        public readonly IStockDetailsService _stockDetailsService;
        public StockController(IStockDetailsService stockDetailsService)
        {
            _stockDetailsService = stockDetailsService;
        }
    }
}
