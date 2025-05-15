using Application.Extensions;
using Domain.Entities;
using Infrastructure.DBContext;
using Infrastructure.Extensions;
using Microsoft.OpenApi.Models;

namespace EediTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.RegisterApplicationServices();
            builder.Services.RegisterInfrastructureExtensions();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Improve API V1");
                c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            SeedData(app.Services.CreateScope().ServiceProvider);

            app.Run();

            static void SeedData(IServiceProvider services)
            {
                using var scope = services.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var topic = new Topic { Id = 1, Name = "Mathematics" };
                var subTopic = new SubTopic { Id = 1, Name = "Algebra", Topic = topic };
                var question = new Question { Id = 1, Text = "Solve 2x=4", SubTopic = subTopic };
                topic.SubTopics.Add(subTopic);
                subTopic.Questions.Add(question);
                subTopic.Topic = topic;

                var student = new Student { Id = 1, Name = "John Doe" };
                var answer = new Answer
                {
                    Id = 1,
                    Student = student,
                    Question = question,
                    GivenAnswer = "x=1",
                    IsCorrect = false
                };

                db.Topics.Add(topic);
                db.SubTopics.Add(subTopic);
                db.Questions.Add(question);
                db.Students.Add(student);
                db.Answers.Add(answer);
                db.SaveChanges();
            }
        }
    }
}
