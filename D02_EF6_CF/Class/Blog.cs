using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D02_EF6_CF
{
    class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }

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

                Operations.InsertTest(success);

                Console.ReadKey();
            }
        }

        internal static void ListBlogs()
        {
            using (var db = new BlogContext())
            {
                var query = db.Blog.Select(b => b).OrderBy(b => b.Name);
                Console.WriteLine("\n\n------------\nTodos os Blogs\n-------------");

                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.ReadKey();
            }
        }
    }
}
