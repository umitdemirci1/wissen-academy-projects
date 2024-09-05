var builder = WebApplication.CreateBuilder(args);

/*
 * Ana Domain               
 * https://www.contos.com 
 * Origin                                   Sonu�
 *   
 * https://www.contoso.com/page/3           Ba�ar�l� bir istek
 *                                          prptpcol ayn�, host ayn�
 *
 * https://contoso.com/images/upload.png     Ba�ar�l� bir istek
 *                                           protocol ayn, host ayn�
 *                                          
 * https://www.contoso.com:88               Ba�ar�s�z bir istek
 *                                          protocol ve host ayn� fakat port farkl�
 *                                          
 *                                                            
 * http://www.contoso.com                   Ba�ar�s�z bir istek                                                             protocol farkl�, host port ayn�
 *                                                       
 * 
 * 
 * 
 */


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddCors(x => x.AddDefaultPolicy
//(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

//builder.Services.AddCors();


//builder.Services.AddCors(x => x.AddPolicy("ClientDomains",
//    x => x.WithOrigins("www.contoso.com", "www.test.com").AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseCors("ClientDomains");
//app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//app.UseCors();

app.MapControllers();

app.Run();
