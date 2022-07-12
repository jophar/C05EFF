using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D02_EF6_CF
{
    class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Contente { get; set; }
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }

        internal static void InsertPost()
        {
            using (var db = new BlogContext())
            {
                Console.Write("Insert Post's name: ");
                var name = Console.ReadLine();

                Console.Write("Insert Blog's name: ");
                var bName = Console.ReadLine();


                if (db.Blog.Any(c => c.Name.Equals(bName)))
                {
                    Console.WriteLine("Insert Post's content: ");
                    var pContent = Console.ReadLine();

                    var post = new Post();
                    post.Title = name;
                    post.Contente = pContent;
                    post.BlogId = db.Blog.First(c => c.Name.Equals(bName)).BlogId;

                    db.Post.Add(post);
                    int success = db.SaveChanges();
                    Operations.InsertTest(success, "post");
                }

                else
                {
                    Console.WriteLine("O blog escolhido não exite\n");
                }
                Console.ReadKey();
            }
        }

        internal static void ListPosts(string blog)
        {
            using (var db = new BlogContext())
            {
                var query = db.Post.Select(b => b).
                                    Where(b => b.BlogId.Equals(db.Blog.Where(c => c.Name.Equals(blog)))).
                                    OrderBy(b => b.PostId);

                Console.WriteLine("\n\n------------\nTodos os Posts\n-------------");

                foreach (var item in query)
                {
                    Console.WriteLine(item.Title);
                    Console.WriteLine();
                    Console.WriteLine(item.Blog);
                    Console.WriteLine();
                    Console.WriteLine(item.Contente);
                    Console.WriteLine();
                }

                Console.ReadKey();
            }

        }
    }
}
