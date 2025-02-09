using FastEndpoints;

namespace API.Employees;

public class GetEmployeeEndpoint : EndpointWithoutRequest<Employee>
{
    public override void Configure()
    {
        Get("/employee/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        var employee = InMemoryRepository.InMemoryEmployeeRepository.FirstOrDefault(e => e.Id == id);

        if (employee is null)
            await SendNotFoundAsync();

        await SendOkAsync(employee!);
    }
}
