using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;

public class TestAppDbContext : AppDbContext
{
    private readonly DbContextOptions<AppDbContext> _options;

    public TestAppDbContext(DbContextOptions<AppDbContext> options)
    {
        _options = options;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseInMemoryDatabase("TestDatabase");
        }
    }
}

public class EmployeeTests
{
    [Fact]
    public async Task CreateEmployee()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using var context = new TestAppDbContext(options);
        await context.Database.EnsureCreatedAsync();
        var controller = new EmployeesController(context);

        var employee = new Employee { Name = "John", Position = "Dev", Salary = 50000 };
        var result = await controller.PostEmployee(employee);

        Assert.IsType<CreatedAtActionResult>(result.Result);
        var created = (CreatedAtActionResult)result.Result!;
        var createdEmployee = (Employee)created.Value!;
        Assert.True(createdEmployee.Id > 0); // Just verify ID was assigned
        Assert.Equal("John", createdEmployee.Name);
        Assert.Equal("Dev", createdEmployee.Position);
        Assert.Equal(50000, createdEmployee.Salary);
    }

    [Fact]
    public async Task GetEmployee()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using var context = new TestAppDbContext(options);
        await context.Database.EnsureCreatedAsync();
        context.Employees.Add(new Employee { Id = 1, Name = "John", Position = "Dev", Salary = 50000 });
        await context.SaveChangesAsync();

        var controller = new EmployeesController(context);
        var result = await controller.GetEmployee(1);

        Assert.IsType<ActionResult<Employee>>(result);
        Assert.Equal("John", result.Value!.Name);
    }

    [Fact]
    public async Task GetAllEmployees()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using var context = new TestAppDbContext(options);
        await context.Database.EnsureCreatedAsync();
        
        // Agregar varios empleados
        context.Employees.AddRange(
            new Employee { Id = 1, Name = "John", Position = "Dev", Salary = 50000 },
            new Employee { Id = 2, Name = "Jane", Position = "Manager", Salary = 75000 },
            new Employee { Id = 3, Name = "Bob", Position = "Analyst", Salary = 45000 }
        );
        await context.SaveChangesAsync();

        var controller = new EmployeesController(context);
        var result = await controller.GetEmployees();

        Assert.IsType<ActionResult<IEnumerable<Employee>>>(result);
        var employees = result.Value!.ToList();
        Assert.Equal(3, employees.Count);
        Assert.Contains(employees, e => e.Name == "John");
        Assert.Contains(employees, e => e.Name == "Jane");
        Assert.Contains(employees, e => e.Name == "Bob");
    }

    // Agrega pruebas para update y delete usando InMemoryDatabase para mocking
}