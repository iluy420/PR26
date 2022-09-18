using ModelDB.Core;
using System;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Threading.Tasks;

namespace DeleteAllUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (DataContext db = new DataContext())
            {
                foreach (User user in db.Users)
                {
                    Console.WriteLine($"Удаление пользователя: {user.Login}");
                    db.Users.Remove(user);
                    Console.WriteLine($"Пользователь: {user.Login} удален!");
                }
                Console.WriteLine("Все пользователи удалены!");
                db.SaveChanges();
                Console.ReadLine();
            }
        }
    }
}
