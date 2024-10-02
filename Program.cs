using ControllersExample.Controllers;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<NoInterfaceController>(); // for adding controllers as a service (without using IController interface), other words, for adding a custom controller to a service class, so it will participate in dependency injection (an instance of the class will be created
builder.Services.AddControllers(); // adds all action methods as endpoints (instead of adding each controller)
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();   // this can be used instead of defining multiple statements: app.UseRouting() and app.UseEndpoints(endpoints => {endpoints.Map(...)})

app.Run();
