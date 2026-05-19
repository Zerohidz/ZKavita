using System.Collections.Generic;
using System.Threading.Tasks;
using Kavita.API.Services;
using Kavita.Models.Constants;
using Kavita.Models.DTOs.Reader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kavita.Server.Controllers;

[Route("api/page-censor")]
public class PageCensorController(IPageCensorService pageCensorService) : BaseApiController
{
    [HttpGet("chapter/{chapterId:int}")]
    public async Task<ActionResult<List<PageCensorDto>>> GetForChapter(int chapterId)
    {
        return Ok(await pageCensorService.GetForChapterAsync(chapterId));
    }

    [Authorize(Policy = PolicyGroups.AdminPolicy)]
    [HttpPut]
    public async Task<ActionResult<PageCensorDto>> Upsert(PageCensorDto dto)
    {
        return Ok(await pageCensorService.UpsertAsync(dto));
    }

    [Authorize(Policy = PolicyGroups.AdminPolicy)]
    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] int chapterId, [FromQuery] int pageIndex)
    {
        await pageCensorService.DeleteAsync(chapterId, pageIndex);

        return Ok();
    }
}
