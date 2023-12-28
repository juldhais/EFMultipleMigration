using EFMultipleMigration.Databases;
using EFMultipleMigration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFMultipleMigration.Controllers;
[ApiController]
[Route("person")]
public class PersonController(DataContext dataContext) : ControllerBase
{
    private readonly DataContext _dataContext = dataContext;

    [HttpGet]
    public async Task<ActionResult<Person>> GetAll(CancellationToken ct)
    {
        var persons = await _dataContext.Set<Person>().ToListAsync(ct);
        return Ok(persons);
    }

    [HttpPost]
    public async Task<ActionResult<Person>> Create(Person person, CancellationToken ct)
    {
        person.Id = Guid.NewGuid();
        _dataContext.Add(person);
        await _dataContext.SaveChangesAsync(ct);
        return Ok(person);
    }
}
