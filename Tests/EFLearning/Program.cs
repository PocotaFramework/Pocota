namespace EFLearning;

internal class Program
{
    static void Main(string[] args)
    {
        using (ApplicationContext db = new())
        {
            User tom = new UserImpl { Name = "Tom", Age = 33 };
            User alice = new UserImpl { Name = "Alice", Age = 26 };

            // добавляем их в бд
            db.Users.Add((UserImpl)tom);
            db.Users.Add((UserImpl)alice);
            db.SaveChanges();
            Console.WriteLine("Объекты успешно сохранены");

            // получаем объекты из бд и выводим на консоль
            var users = db.Users.ToList();
            Console.WriteLine("Список объектов:");
            foreach (User u in users)
            {
                Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            }
        }
    }
}