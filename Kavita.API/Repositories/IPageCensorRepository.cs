using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kavita.Models.DTOs.Reader;
using Kavita.Models.Entities.User;

namespace Kavita.API.Repositories;

public interface IPageCensorRepository
{
    Task<List<PageCensorDto>> GetForChapterAsync(int userId, int chapterId, CancellationToken ct = default);
    Task<AppUserPageCensor?> GetForPageAsync(int userId, int chapterId, int pageIndex, CancellationToken ct = default);
    void Add(AppUserPageCensor censor);
    void Remove(AppUserPageCensor censor);
}
