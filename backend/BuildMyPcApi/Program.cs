using BuildMyPcApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BuildMyPcApi",
        Version = "v1",
        Description = "API per ndertimin dhe porositjen e kompjuterit"
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath)) c.IncludeXmlComments(xmlPath);
});

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("BuildMyPcApiDatabase");

builder.Services/*punson stafin per rolet qe ju takojn(dependency injection)*/.AddDbContext<BuildMyPcDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BuildMyPcApi v1"));
}

app.UseHttpsRedirection();//dera e sigurt

app.UseAuthorization();//roja

app.MapControllers();//kamarjeri

app.Run();//hapja e deres per musafir me hi me perdor lokalin