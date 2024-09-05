var builder = WebApplication.CreateBuilder(args);

/*
 * Ana Domain               
 * https://www.contos.com 
 * Origin                                   Sonuç
 *   
 * https://www.contoso.com/page/3           Baþarýlý bir istek
 *                                          prptpcol ayný, host ayný
 *
 * https://contoso.com/images/upload.png     Baþarýlý bir istek
 *                                           protocol ayn, host ayný
 *                                          
 * https://www.contoso.com:88               Baþarýsýz bir istek
 *                                          protocol ve host ayný fakat port farklý
 *                                          
 *                                                            
 * http://www.contoso.com                   Baþarýsýz bir istek                                                             protocol farklý, host port ayný
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
