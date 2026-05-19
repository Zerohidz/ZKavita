using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kavita.Models.DTOs.Reader;

namespace Kavita.API.Services;

public interface IPageCensorService
{
    Task<List<PageCensorDto>> GetForChapterAsync(int userId, int chapterId, CancellationToken ct = default);
    Task<PageCensorDto> UpsertAsync(int userId, PageCensorDto dto, CancellationToken ct = default);
    Task DeleteAsync(int userId, int chapterId, int pageIndex, CancellationToken ct = default);
}
