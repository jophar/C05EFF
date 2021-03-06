using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D02_EF6_CF
{
    internal class Operations
    {
        internal static void InsertBlog()
        {
            using (var db = new BlogContext())
            {
                Console.Write("Insert blog's name: ");
                var name = Console.ReadLine();
                var blog = new Blog();

                blog.Name = name;

                db.Blog.Add(blog);
                int success = db.SaveChanges();

                InsertTest(success, "blog");

                Console.ReadKey();
            }

        }

        internal static void InsertTest(int value, string type)
        {
            if (value > 0)
                Console.WriteLine($"{type} successfully inserted");
            else
                Console.WriteLine($"No {type}s have been created");
        }



        internal void BlogMenu()
        {
        }
    }
}
