using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kavita.API.Database;
using Kavita.API.Services;
using Kavita.Models.DTOs.Reader;
using Kavita.Models.Entities.User;
using Microsoft.Extensions.Logging;

namespace Kavita.Services;

public class PageCensorService(
    ILogger<PageCensorService> logger,
    IUnitOfWork unitOfWork)
    : IPageCensorService
{
    public async Task<List<PageCensorDto>> GetForChapterAsync(int chapterId, CancellationToken ct = default)
    {
        return await unitOfWork.PageCensorRepository.GetForChapterAsync(chapterId, ct);
    }

    public async Task<PageCensorDto> UpsertAsync(PageCensorDto dto, CancellationToken ct = default)
    {
        var existing = await unitOfWork.PageCensorRepository.GetForPageAsync(dto.ChapterId, dto.PageIndex, ct);

        if (existing != null)
        {
            existing.Regions = dto.Regions;
            await unitOfWork.CommitAsync(ct);

            return new PageCensorDto
            {
                Id = existing.Id,
                ChapterId = existing.ChapterId,
                PageIndex = existing.PageIndex,
                Regions = existing.Regions,
            };
        }

        var censor = new AppUserPageCensor
        {
            ChapterId = dto.ChapterId,
            PageIndex = dto.PageIndex,
            Regions = dto.Regions,
        };

        unitOfWork.PageCensorRepository.Add(censor);
        await unitOfWork.CommitAsync(ct);

        return new PageCensorDto
        {
            Id = censor.Id,
            ChapterId = censor.ChapterId,
            PageIndex = censor.PageIndex,
            Regions = censor.Regions,
        };
    }

    public async Task DeleteAsync(int chapterId, int pageIndex, CancellationToken ct = default)
    {
        var existing = await unitOfWork.PageCensorRepository.GetForPageAsync(chapterId, pageIndex, ct);
        if (existing == null) return;

        unitOfWork.PageCensorRepository.Remove(existing);
        await unitOfWork.CommitAsync(ct);
    }
}
