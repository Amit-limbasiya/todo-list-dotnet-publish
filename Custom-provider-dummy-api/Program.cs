var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
List<string> todoList = new();

app.MapGet("/get", () =>
{
    Console.WriteLine("get endpoint hit from version 1");
    return todoList;
})
.WithName("GetToDoList")
.WithOpenApi();


app.MapPost("/create", (List<string> things) =>
{
    todoList = new List<string>(things);
    //{
    //    "extra"
    //};
    Console.WriteLine("create endpoint hit from version 1");
    return todoList;
})
.WithName("MakeToDoList")
.WithOpenApi();

app.MapPut("/update", (List<string> things) =>
{
    todoList = new List<string>(things.Select(x => x.ToString()));
    Console.WriteLine("update endpoint hit from version 1");
    return todoList;
})
.WithName("UpdateToDoList")
.WithOpenApi();

app.MapDelete("/delete", () =>
{
    Console.WriteLine("delete endpoint hit from version 1");
    todoList = new List<string>();
    return todoList;
})
.WithName("DeleteToDoList")
.WithOpenApi();


app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
