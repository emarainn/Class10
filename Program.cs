using Class10.Classes;

namespace Class10
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            Console.Write("\n-------------------------------------------" +
                    "\nWelcome to Ema's Blogging World of Wonder!");

            do
            {
                Console.Write("\n-------------------------------------------" +
                        "\n~ You Have The Following Options ~" +
                        "\n\t1. Display Bloggers" +
                        "\n\t2. Add Blog" +
                        "\n\t3. Display Posts" +
                        "\n\t4. Add Post" +
                        "\n\t0. Exit Application" +
                        "\nEnter Menu Option Here: ");

                while (!int.TryParse(Console.ReadLine(), out option) || option < 0 || option > 4)
                {
                    Console.WriteLine("\n** Must Enter Number between 0 and 4 **");
                    Console.Write("Enter Menu Option Here: ");
                }

                if (option >= 0 && option <= 4)
                {
                    UserMenuOption(option);
                }
            } while (option != 0);
        }

        public static void UserMenuOption(int option)
        {
            if (option == 1)
            {
                Console.WriteLine("\n-----------------Bloggers------------------");
                BlogManagement.DisplayBlogs();
            }
            else if (option == 2)
            {
                BlogManagement.AddBlog();
            }
            else if (option == 3)
            {
                PostManagement.DisplayPosts();
            }
            else if (option == 4)
            {
                PostManagement.AddPost();
            }
            else if (option == 0)
            {
                Console.WriteLine("Exiting Application..." +
                    "\nBye Sucka");
            }
        }
    }
}