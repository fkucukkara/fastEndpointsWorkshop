using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Employees;

public record AddEmployeeRequest(Employee body);

public class AddEmployeesEndpoint : Endpoint<AddEmployeeRequest, Results<Created<Employee>, BadRequest>>
{
    public override void Configure()
    {
        Post("/employees");
        AllowAnonymous();
    }

    public override async Task<Results<Created<Employee>, BadRequest>> ExecuteAsync(AddEmployeeRequest req, CancellationToken ct)
    {
        await Task.CompletedTask;

        if (req.body is null)
            return TypedResults.BadRequest();


        InMemoryRepository.InMemoryEmployeeRepository.Add(req.body);
        return TypedResults.Created($"/employees/{req.body.Id}", req.body);
    }
}
