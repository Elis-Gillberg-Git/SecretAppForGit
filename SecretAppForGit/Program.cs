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
                Console.WriteLine("1. Logga in\r\n2. Lägg till användare\r\n3. Ändra lösenord\r\n4. vissa använadrlista \r\n0. Avsluta\r\n");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("riktig sifra");
                    if (choice == 0)
                    {
                        run = false;
                    }
                    else if (choice == 1)
                    {
                        Login();
                    }
                    else if (choice == 2)
                    {
                        AddUser();
                    }
                    else if (choice == 3)
                    {
                        ChangePassword();
                    }
                    else if (choice == 4)
                    {
                        ShowUsers();
                    }
                    else
                    {
                        Console.WriteLine("välj från menyn");
                    }
                }
                
            }
            Console.WriteLine("hej då");

        }
        static void Login()
        {
            Console.WriteLine("hello from Login");
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
