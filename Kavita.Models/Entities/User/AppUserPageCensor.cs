using System;
using System.Collections.Generic;
using Kavita.Models.DTOs.Reader;
using Kavita.Models.Entities.Interfaces;

namespace Kavita.Models.Entities.User;

public class AppUserPageCensor : IEntityDate
{
    public int Id { get; set; }
    public required int ChapterId { get; set; }
    public Chapter Chapter { get; set; } = null!;
    public required int PageIndex { get; set; }
    public List<CensorRegion> Regions { get; set; } = [];
    public required int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime LastModified { get; set; }
    public DateTime LastModifiedUtc { get; set; }
}
