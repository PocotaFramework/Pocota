using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EFLearning;

internal class Program
{
    static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(sc =>
                {
                    sc.AddDbContext<ApplicationContext>(o => o.UseSqlite("Data Source=helloapp.db"));
                    sc.AddTransient<User, UserImpl>();
                    sc.AddTransient<Company, CompanyImpl>();
                }
            )
            //.ConfigureLogging(o => o.ClearProviders())
            .Build();

        ApplicationContext db = host.Services.GetRequiredService<ApplicationContext>();

        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        Company translog = host.Services.GetRequiredService<Company>();
        translog.Name = "Trans-Log";
        translog.Code = "123";

        User tom = host.Services.GetRequiredService<User>();
        tom.Name = "Tom";
        tom.Age = 33;
        tom.Company = translog;

        translog.Director = tom;

        User alice = host.Services.GetRequiredService<User>();
        alice.Name = "Alice";
        alice.Age = 26;
        alice.Manager = tom;

        Console.WriteLine(tom.GetHashCode());
        Console.WriteLine(alice.GetHashCode());

        // добавляем их в бд
        db.Companies.Add(translog);
        db.Users.Add(tom);
        db.Users.Add(alice);
        db.SaveChanges();
        Console.WriteLine("Объекты успешно сохранены");

        // получаем объекты из бд и выводим на консоль
        for(int i = 0; i < 2; ++i)
        {
            var users = db.Users.ToList();

            Console.WriteLine("Список объектов:");
            foreach (User u in users)
            {
                Console.WriteLine($"{u.Id}.{u.Name} - {u.Age} ({u.GetHashCode()}) (manager: {u.Manager?.Name}, company: {u.Company?.Name}/{u.Company?.Code})");
            }
        }
    }
}