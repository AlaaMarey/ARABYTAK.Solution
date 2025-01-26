
using Arabytak.Core.Repositories.Contract;
using Arabytak.Repository.Data;
using Arabytak.Repository.Repository.Contract;
using ARABYTAK.APIS.Errors;
using ARABYTAK.APIS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

    namespace ARABYTAK.APIS
    {
        public class Program
        {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ArabytakContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));// second Step to connection db , to use AddDbContext We need use take reference from Repository To read library
            builder.Services.AddAutoMapper(typeof(MappingProfiles));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(p => p.Value.Errors.Count() > 0)
                                                         .SelectMany(p => p.Value.Errors)
                                                         .Select(E => E.ErrorMessage)
                                                         .ToList();
                    var Response = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(Response);
                };
            });

                var app = builder.Build();
                var scope=app.Services.CreateScope();//AddScope(PerRequest)
                var Services=scope.ServiceProvider;// That mean This service work in scoped(peer Request)
                var _dbContext= Services.GetRequiredService<ArabytakContext>();

                var LoggerFactory=Services.GetRequiredService<ILoggerFactory>();
                try
                {
                    await _dbContext.Database.MigrateAsync();//update DataBase
                    await ArabytakContextSeed.SeedAsync(_dbContext);// SeedData
                }
                catch (Exception ex) 
                {
                    var logger= LoggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An Error Occurred during migration");
                }


                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();
                app.UseStaticFiles();


            app.MapControllers();

                app.Run();
            }
        }
    }
