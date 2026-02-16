using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace SecretAppForGit
{
    internal class Program
    {
        static string[] userNames = { "Pelle", "Stina", "Ali" };
        static string[] userPasswords = { "1234", "abcd", "qwerty" };
        static bool userLoggin = false;
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
                    }
                    else if (choice == 3)
                    {
                        ChangePassword();
                    }
                    else if (choice == 4)
                    {
                        ShowUsers();
                    }
                    else if (choice == 5)
                    {
                        DeletUser();
                    }
                    else if (choice == 6)
                    {
                        MethodWithDictionary();
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
                        userLoggin = true;
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
        static void AddUser()
        {
            Console.WriteLine("Här kan du lägga till en användare");
            Console.WriteLine("Skriv användarens namn");
            string name = Console.ReadLine();
            Console.WriteLine($"skriv lösenordert för {name}");
            string password = Console.ReadLine();

            string[] tempNames = new string [userNames.Length + 1];
            string[] tempPassword = new string[userPasswords.Length + 1];

            int i = 0;
            while (i < userNames.Length) 
            {
                tempNames[i] = userNames[i];
                i++;
            }

            tempNames[tempNames.Length - 1] = name;

            userNames = tempNames;

            int j = 0;
            while (j < userNames.Length)
            {
                tempPassword[j] = userNames[j];
                j++;
            }


            tempPassword[tempPassword.Length - 1] = password;

            userPasswords = tempPassword;

            foreach(var post in userNames)
            {
                Console.WriteLine(post);
            }

            foreach(var post in userPasswords)
            {
                Console.WriteLine(post);
            }

        }
        //TODO ChangePassword inte klar
        static void ChangePassword()
        {
            string[] tempNames = new string[userNames.Length - 1];
            string[] tempPassword = new string[userPasswords.Length - 1];
            Console.WriteLine("Skriv namnet vars lösenord du vill ändra: ");
            string password = Console.ReadLine();


            int changePassword = Array.IndexOf(userNames, password);

            if(changePassword == -1)
            {
                Console.WriteLine("lösenordet finns inte.");
                return;
            }

            Console.WriteLine("skriv det nya lösenordet");
            string newPassword = Console.ReadLine();

            userPasswords[changePassword] = newPassword;
        }
        static void ShowUsers()
        {
            int i = 0;
            while (i < userNames.Length)
            {
                Console.WriteLine("Hello " + userNames[i].ToLower() + " " + userPasswords[i]);
                i++;
            }
        }
        static void DeletUser()
        {
            string[] tempNames = new string[userNames.Length - 1];
            string[] tempPassword = new string[userPasswords.Length - 1];
            Console.WriteLine("Skriv namnet på den du vill ta bort: ");
            string name = Console.ReadLine();


            int hit = Array.IndexOf(userNames, name);

            if (hit == -1)
            {
                Console.WriteLine("Namnet finns inte i listan");
                return;
            }

            int i = 0;
            int j = 0;

            while (i < userNames.Length)
            {
                if (hit == i)
                {
                    i++;
                    continue;
                }
                tempNames[j] = userNames[i];
                i++;
                j++;
            }

            userNames = tempNames;

            i = 0;
            j = 0;

            while (i < userNames.Length)
            {
                if (hit == i)
                {
                    i++;
                    continue;
                }
                tempNames[j] = userNames[i];
                i++;
                j++;
            }

            userNames = tempNames;
        }

        static void Menu()
        {
            Console.WriteLine(
                "****************************" +
                "\r\n1. Logga in" +
                "\r\n2. Lägg till användare" +
                "\r\n3. Ändra lösenord" +
                "\r\n4. vissa använadrlista " +
                "\r\n5. Ta bort ett namn ur listan" +
                "\r\n6. visa MethodWithDictionary()" +
                "\r\n9. visa menyn" +
                "\r\n0. Avsluta\r\n");
        }

        private static void MethodWithDictionary()
        {
            Dictionary<string, string> userList = new Dictionary<string, string>();

            userList.Add("Pelle", "1234");
            userList.Add("Stina", "abcd");
            userList.Add("Ali", "qwery");
            userList.Add("Bob", "12345");
            userList.Add("Melissa", "123456");

            userList.Remove("Bob");

            int i = 0;

            foreach (var rad in userList)
            {
                Console.WriteLine(rad.Key);
            }
        }
    }
}