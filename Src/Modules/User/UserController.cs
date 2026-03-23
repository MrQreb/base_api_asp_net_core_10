using Microsoft.AspNetCore.Mvc;
using WepAPI.Src.Modules.Users.Dtos;

namespace WepAPI.Src.Modules.Users;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly UsersService _usersService;

    public UsersController(UsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet]
    public async Task<IActionResult> FindAll()
    {
        var users = await _usersService.FindAllAsync();
        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> FindOne(Guid id)
    {
        var user = await _usersService.FindOneAsync(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
    {
        var user = await _usersService.CreateAsync(dto);
        return CreatedAtAction(nameof(FindOne), new { id = user.Id }, user);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto dto)
    {
        var user = await _usersService.UpdateAsync(id, dto);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        var removed = await _usersService.RemoveAsync(id);
        return removed ? NoContent() : NotFound();
    }
}