using Class10.Models;

namespace Class10.Classes
{
    public class BlogManagement
    {
        public static void DisplayBlogs()
        {
            using (var db = new BloggingContext())
            {
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine($"{blog.BlogId}| {blog.Name}");
                }
            }
        }

        public static void AddBlog()
        {
            Console.WriteLine("\n---------------Blog Creation---------------");
            Console.Write("Enter Blog Name: ");
            var blogName = Console.ReadLine();

            // Create new Blog
            var blog = new Blog();
            blog.Name = blogName;

            // Save blog object to database
            using (var db = new BloggingContext())
            {
                db.Add(blog);
                db.SaveChanges();

            }
        }
    }
}