using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace SecretAppForGit
{
    internal class Program
    {
        static string[] userNames = { "Pelle", "Stina", "Ali" };
        static string[] userPasswords = { "1234", "abcd", "qwerty" };
        
        static void Main(string[] args)
        {
            Menu();

            bool run = true;
            while (run)
            {

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
                        Menu();
                    }
                    else if (choice == 3)
                    {
                        ChangePassword();
                        Menu();
                    }
                    else if (choice == 4)
                    {
                        ShowUsers();
                        Menu();
                    }
                    else if (choice == 9)
                    {
                        Menu();
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
            Console.WriteLine("Inloggning");
            Console.Write("Namn: ");
            string name = Console.ReadLine();
            Console.Write("Lösenord: ");
            string password = Console.ReadLine();

            int i = 0;
            while (i < userNames.Length)
            {
                if (userNames[i] == name)
                {
                    if (userPasswords[i] == password)
                    {
                        Console.WriteLine("välkommen " + name);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("fel namn");
                    }
                }
                else 
                {

                }
                i++;
            }
            if (Array.IndexOf(userNames, name) == 1)
            {
                Console.WriteLine("fel namn eller lösenord");
            }
            Menu();
        }
        //TODO addUser inte klar
        static void AddUser()
        {
            Console.WriteLine("Här kan du lägga till en användare");
            Console.WriteLine("Skriv användarens namn");
            string name = Console.ReadLine();
            Console.WriteLine($"skriv lösenordert för {name}");
            string password = Console.ReadLine();

            string[] tempNames = new string [userNames.Length];
            string[] tempPassword = new string[userPasswords.Length];

        }
        //TODO ChangePassword inte klar
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
        static void Menu()
        {
            Console.WriteLine(
                "****************************" +
                "\r\n1. Logga in" +
                "\r\n2. Lägg till användare" +
                "\r\n3. Ändra lösenord" +
                "\r\n4. vissa använadrlista " +
                "\r\n9. visa menyn" +
                "\r\n0. Avsluta\r\n");
        }
    }
}
