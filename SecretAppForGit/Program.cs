namespace SecretAppForGit
{
    internal class Program
    {
        static string[] userNames = { "Pelle", "Stina", "Ali" };
        static string[] userPasswords = { "1234", "abcd", "qwerty" };

        static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("tryck 0 för att sluta");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("riktig sifra");
                    if(choice == 0)
                    {
                        run = false;
                    }
                }
                else
                {
                    Console.WriteLine("välj från menyn");
                }
            }
            Console.WriteLine("hej då");
            Thread.Sleep(3000);
        }

        static void AddUser()
        {
            Console.WriteLine("Hello from AddUser");
        }
        static void ChangePassword()
        {
            Console.WriteLine("Hello from ChangePassword");
        }
        static void ShowUsers()
        {
            int i = 0;
            while (i < userNames.Length)
            {
                
                Console.WriteLine("Hello " + userNames[i].ToLower());
                i++;
            }
        }
        static void EndApplication()
        {
            Console.WriteLine("Hello from EndApplication");
        }
    }
}
