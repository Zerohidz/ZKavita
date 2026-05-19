using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kavita.API.Repositories;
using Kavita.Models.DTOs.Reader;
using Kavita.Models.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Kavita.Database.Repositories;

public class PageCensorRepository(DataContext context, IMapper mapper) : IPageCensorRepository
{
    public async Task<List<PageCensorDto>> GetForChapterAsync(int userId, int chapterId, CancellationToken ct = default)
    {
        return await context.AppUserPageCensor
            .AsNoTracking()
            .Where(c => c.AppUserId == userId && c.ChapterId == chapterId)
            .Select(c => new PageCensorDto
            {
                Id = c.Id,
                ChapterId = c.ChapterId,
                PageIndex = c.PageIndex,
                Regions = c.Regions,
            })
            .ToListAsync(ct);
    }

    public async Task<AppUserPageCensor?> GetForPageAsync(int userId, int chapterId, int pageIndex, CancellationToken ct = default)
    {
        return await context.AppUserPageCensor
            .FirstOrDefaultAsync(c => c.AppUserId == userId && c.ChapterId == chapterId && c.PageIndex == pageIndex, ct);
    }

    public void Add(AppUserPageCensor censor)
    {
        context.AppUserPageCensor.Add(censor);
    }

    public void Remove(AppUserPageCensor censor)
    {
        context.AppUserPageCensor.Remove(censor);
    }
}
