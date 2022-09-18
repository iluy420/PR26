using System;
using System.Threading.Tasks;
using ModelDB.Core;
using ModelDB.Core.Enum;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Random random = new Random();
            Array values = Enum.GetValues(typeof(Role));

            int password = 111110;
            for(int i = 1; i < 11; i++)
            {
                User user = new User()
                {
                    UserId = Guid.NewGuid(),
                    Login = $"root{i}",
                    Password = Convert.ToString(password+1),
                    UserRole = (Role)values.GetValue(random.Next(values.Length))
                };
                SaveObjectsAsync(user).Wait();
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
