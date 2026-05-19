using System.Collections.Generic;

namespace Kavita.Models.DTOs.Reader;

public class PageCensorDto
{
    public int Id { get; set; }
    public int ChapterId { get; set; }
    public int PageIndex { get; set; }
    public List<CensorRegion> Regions { get; set; } = [];
}

public class CensorRegion
{
    public float XPct { get; set; }
    public float YPct { get; set; }
    public float WPct { get; set; }
    public float HPct { get; set; }
    public string Style { get; set; } = "blur";
    public int Blur { get; set; } = 20;
    public string Shape { get; set; } = "rect";
    public List<FreehandPoint>? Points { get; set; }
}

public class FreehandPoint
{
    public float XPct { get; set; }
    public float YPct { get; set; }
}
