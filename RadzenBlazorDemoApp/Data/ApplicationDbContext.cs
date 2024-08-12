using Bogus;
using Microsoft.EntityFrameworkCore;
using RadzenBlazorDemo.Models;

namespace RadzenBlazorDemo.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //var faker = new Faker<Employee>()
        //   .RuleFor(e => e.Id, f => f.IndexFaker + 1)
        //   .RuleFor(e => e.FirstName, f => f.Name.FirstName())
        //   .RuleFor(e => e.LastName, f => f.Name.LastName())
        //   .RuleFor(e => e.Email, f => f.Internet.Email())
        //   .RuleFor(e => e.PhoneNumber, f => f.Phone.PhoneNumber())
        //   .RuleFor(e => e.DateOfBirth, f => f.Date.Past(30, DateTime.Now.AddYears(-18)))
        //   .RuleFor(e => e.Salary, f => f.Finance.Amount(30000, 120000));

        //faker.Generate(50);

        //var employees = faker.Generate(50).Select(x => new Employee()
        //{
        //    Id = x.Id,
        //    FirstName = x.FirstName,
        //    LastName = x.LastName,
        //    Email = x.Email,
        //    PhoneNumber = x.PhoneNumber,
        //    Salary = x.Salary,
        //    DateOfBirth = x.DateOfBirth
        //}).ToArray();

        //modelBuilder.Entity<Employee>().HasData(employees);
    }

    public DbSet<Employee> Employees { get; set; }
}
