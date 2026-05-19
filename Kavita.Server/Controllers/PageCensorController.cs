using System.Collections.Generic;
using System.Threading.Tasks;
using Kavita.API.Services;
using Kavita.Models.DTOs.Reader;
using Microsoft.AspNetCore.Mvc;

namespace Kavita.Server.Controllers;

public class PageCensorController(IPageCensorService pageCensorService) : BaseApiController
{
    [HttpGet("chapter/{chapterId:int}")]
    public async Task<ActionResult<List<PageCensorDto>>> GetForChapter(int chapterId)
    {
        return Ok(await pageCensorService.GetForChapterAsync(UserId, chapterId));
    }

    [HttpPut]
    public async Task<ActionResult<PageCensorDto>> Upsert(PageCensorDto dto)
    {
        return Ok(await pageCensorService.UpsertAsync(UserId, dto));
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] int chapterId, [FromQuery] int pageIndex)
    {
        await pageCensorService.DeleteAsync(UserId, chapterId, pageIndex);

        return Ok();
    }
}
