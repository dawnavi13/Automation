using System;
using System.Collections.Generic;

namespace Automation.Data;

public partial class StockTable
{
    public string Code { get; set; } = null!;

    public string? Name { get; set; }

    public string? BatchNo { get; set; }

    public DateOnly? MfgDt { get; set; }

    public DateOnly? ExpDt { get; set; }

    public decimal? Price { get; set; }

    public decimal? Units { get; set; }

    public string? Category { get; set; }
}
