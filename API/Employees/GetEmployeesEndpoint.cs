using FastEndpoints;

namespace API.Employees;

public class GetEmployeesEndpoint : EndpointWithoutRequest<List<Employee>>
{
    public override void Configure()
    {
        Get("/employees");
        AllowAnonymous();
    }

    public override async Task<List<Employee>> ExecuteAsync(CancellationToken ct)
    {
        await Task.CompletedTask;
        return InMemoryRepository.InMemoryEmployeeRepository;
    }
}
