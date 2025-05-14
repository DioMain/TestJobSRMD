using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestJobSRMD.Entity;
using TestJobSRMD.Entity.Models;
using TestJobSRMD.Entity.Repository;
using TestJobSRMD.Exceptions;
using TestJobSRMD.Models;

namespace TestJobSRMD.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ContactRepository _contact;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _contact = new ContactRepository(dbContext);
    }

    public IActionResult Index()
    {
        return View(_contact.GetAll());
    }

    [HttpGet]
    public async Task<IResult> GetContact([FromQuery] Guid id)
    {
        try
        {
            var contact = await _contact.GetAsync(id) ?? throw new ServerException("contact not found!", 404);

            return Results.Json(contact);
        }
        catch (ServerException exp)
        {
            return Results.Problem(detail: exp.Message, statusCode: exp.Code);
        }
    }

    [HttpPut]
    public async Task<IResult> UpdateContact([FromBody] ContactModel model, [FromQuery] Guid id)
    {
        try
        {
            var contact = await _contact.GetAsync(id) ?? throw new ServerException("contact not found!", 404);

            contact.Name = model.Name;
            contact.MobilePhone = model.MobilePhone;
            contact.JobTitle = model.JobTitle;
            contact.BirthDate = model.BirthDate;

            _contact.Update(contact);

            _contact.SaveChanges();

            return Results.Ok();
        }
        catch (ServerException exp)
        {
            return Results.Problem(detail: exp.Message, statusCode: exp.Code);
        }
    }

    [HttpPost]
    public IResult CreateContact([FromBody] ContactModel model)
    {
        try
        {
            var contact = new Contact
            {
                Name = model.Name,
                MobilePhone = model.MobilePhone,
                JobTitle = model.JobTitle,
                BirthDate = model.BirthDate
            };

            _contact.Create(contact);

            _contact.SaveChanges();

            return Results.Ok();
        }
        catch (Exception exp)
        {
            return Results.Problem(detail: exp.Message, statusCode: 400);
        }
    }

    [HttpDelete]
    public async Task<IResult> DeleteContact([FromQuery] Guid id)
    {
        try
        {
            var contact = await _contact.GetAsync(id) ?? throw new ServerException("contact not found!", 404);

            _contact.Delete(contact);

            _contact.SaveChanges();

            return Results.Ok();
        }
        catch (ServerException exp)
        {
            return Results.Problem(detail: exp.Message, statusCode: exp.Code);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
