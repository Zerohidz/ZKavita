using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kavita.Models.DTOs.Reader;

namespace Kavita.API.Services;

public interface IPageCensorService
{
    Task<List<PageCensorDto>> GetForChapterAsync(int chapterId, CancellationToken ct = default);
    Task<PageCensorDto> UpsertAsync(PageCensorDto dto, CancellationToken ct = default);
    Task DeleteAsync(int chapterId, int pageIndex, CancellationToken ct = default);
}
