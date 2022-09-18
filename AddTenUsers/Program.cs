using ModelDB.Core.Enum;
using ModelDB.Core;
using System;
using System.Threading.Tasks;
using PR26.Extensions;

namespace AddTenUsers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Random random = new Random();
                Array values = Enum.GetValues(typeof(Role));

                int password = 111110;
                for (int i = 1; i < 11; i++)
                {
                    User user = new User()
                    {
                        UserId = Guid.NewGuid(),
                        Login = $"root{i}",
                        Password = GetHashSHA.GetHash(Convert.ToString(++password)),
                        UserRole = (Role)values.GetValue(random.Next(values.Length))
                    };
                    Console.WriteLine($"Загрузка пользователя: {user.Login} c поролем: {password} в бд начата");
                    SaveObjectsAsync(user).Wait();
                    Console.WriteLine($"Загрузка пользователя: {user.Login} в бд завершена");
                }
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine($"Не удалось записать в бд повторяющийся логин!");
                Console.ReadLine();
            }
            
        }

        private static async Task SaveObjectsAsync(User user)
        {
            using (DataContext db = new DataContext())
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
            }
        }
    }
}
