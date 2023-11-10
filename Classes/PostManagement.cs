using Class10.Models;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Class10.Classes
{
    public class PostManagement
    {
        public static void DisplayPosts()
        {
            /*
               Prompt user to select Blog they want
               all Posts related to selected blog should display as well as num of Posts
               For each Post, display the Blog name, Post title and Post content
             */

            int bloggerId;
            var db = new BloggingContext();
            var maxId = db.Blogs.Count();

            Console.WriteLine($"\n------------------Posts--------------------" +
                $"\nAvalable Blogs" +
                $"\nID | Blogs");
            BlogManagement.DisplayBlogs();

            Console.Write("\nEnter Blog ID to View Posts: ");

            while (!int.TryParse(Console.ReadLine(), out bloggerId) || bloggerId < 1 || bloggerId > maxId)
            {
                Console.WriteLine("\n** Invalid Blogger ID **");
                Console.Write("Enter Blogger ID: ");
            }

            using (db)
            {
                var blog = db.Blogs.Where(x => x.BlogId == bloggerId).FirstOrDefault();

                System.Console.WriteLine($"\n\n_________________WELCOME_________________" +
                    $"\n\t  ~~~~ {blog.Name} ~~~~" +
                    $"\n\t  ---> Posts: {blog.Posts.Count()}  <---" +
                    $"\n\nPosts....................................");

                foreach (var post in blog.Posts)
                {
                    System.Console.WriteLine($"\n--- {post.Title} ---" +
                        $"\n{post.Content}");
                }
            }

            Console.WriteLine("\n\n** Hit Any Key To Return To Main Manu **");
            var ans = Console.ReadLine();
        
        }
        public static void AddPost()
        {
            int bloggerId;
            var db = new BloggingContext();
            var maxId = db.Blogs.Count();

            Console.WriteLine($"\n------------------Add Post-----------------" +
                $"\n  ** NOTE: OBVIOUSLY This is NOT Secure **" +
                $"\n  (My Version Of Security...)" +
                $"\n--> Populated IDs: 1 - {maxId}" +
                $"\n-------------------------------------------");

            Console.Write("\nEnter Blogger ID: ");

            //I know this code is reused and I shouldn't reuse code
            while (!int.TryParse(Console.ReadLine(), out bloggerId) || bloggerId < 1 || bloggerId > maxId)
            {
                Console.WriteLine("\n** Must Enter Valid Blogger ID **");
                Console.Write("Enter Blogger ID: ");
            }

            string postTitle = "";

            do {
                Console.Write("Enter Post's Title: ");
                postTitle = Console.ReadLine();

                if (postTitle == "") 
                {
                    Console.WriteLine("** Must Enter Title **");
                }

            } while (postTitle == "");

            string content = "";
            do
            {
                Console.Write("Enter Content: ");
                content = Console.ReadLine();

                if (content == "")
                {
                    Console.WriteLine("** Must Enter Content **");
                }

            } while (content == "");

            var post = new Post();
            post.BlogId = bloggerId;
            post.Title = postTitle;
            post.Content = content;

            using (db)
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }
    }
}
