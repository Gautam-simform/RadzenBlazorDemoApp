using Bogus;
using EFCore.BulkExtensions;
using RadzenBlazorDemo.Data;
using RadzenBlazorDemo.Models;

namespace RadzenBlazorDemoApp.Data;

public class DbInitializer
{
    public async static Task SeedAsync(ApplicationDbContext context)
    {
        if (context.Employees.Any())
        {
            return;
        }

        var faker = new Faker<Employee>()
           .RuleFor(e => e.Id, f => f.IndexFaker + 1)
           .RuleFor(e => e.FirstName, f => f.Name.FirstName())
           .RuleFor(e => e.LastName, f => f.Name.LastName())
           .RuleFor(e => e.Email, f => f.Internet.Email())
           .RuleFor(e => e.PhoneNumber, f => f.Phone.PhoneNumber())
           .RuleFor(e => e.DateOfBirth, f => f.Date.Past(30, DateTime.Now.AddYears(-18)))
           .RuleFor(e => e.Salary, f => f.Finance.Amount(30000, 120000));

        var employees = faker.Generate(1000000).Select(x => new Employee()
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Email = x.Email,
            PhoneNumber = x.PhoneNumber,
            Salary = x.Salary,
            DateOfBirth = x.DateOfBirth
        });

        await context.BulkInsertAsync(employees);
        await context.BulkSaveChangesAsync();
    }
}
