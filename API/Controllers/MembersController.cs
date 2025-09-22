using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class MembersController(AppDbContext context) : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public ActionResult<IReadOnlyList<AppUser>> GetMembers()
    {
        var members = context.Users.ToList();

        return members;
    }

    [AllowAnonymous]
    [HttpGet("{id}")] // http://localhost:5001/api/members/bob-id
    public async Task<ActionResult<AppUser>> GetMember(string id)
    {
        var member = await context.Users.FindAsync(id);

        if (member == null) return NotFound();

        return member;
    }
}

