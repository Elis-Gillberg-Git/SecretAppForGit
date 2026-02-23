using System.Data;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace SecretAppForGit
{
    internal class Program
    {
        static string[] userNames = { "Pelle", "Stina", "Ali" };
        static string[] userPasswords = { "1234", "abcd", "qwerty" };
        static string adminPassword = "wasd";
        static bool userLoggin = false;
        static string currentUser;
        static void Main(string[] args)
        {
        
            Menu();

            bool run = true;
            while (run)
            {

                if (int.TryParse(Console.ReadLine(), out int choice)) // TODO man kan skriva vad som helst i menyn. Ändra så att man endast kan välja numrena i menyn
                {
                    Console.WriteLine("riktig sifra");
                    if (choice == 0)
                    {
                        run = false;
                    }
                    else if (choice == 1)
                    {
                        Console.Clear();
                        Menu();
                        Login();
                    }
                    else if (choice == 2)
                    {
                        Console.Clear();
                        Menu();
                        AddUser();
                    }
                    else if (choice == 3)
                    {
                        Console.Clear();
                        Menu();
                        ChangePassword();

                    }
                    else if (choice == 4)
                    {
                        Console.Clear();
                        Menu();
                        ShowUsers();
                    }
                    else if (choice == 5)
                    {
                        Console.Clear();
                        Menu();
                        DeletUser();
                    }
                    else if (choice == 6)
                    {
                        Console.Clear();
                        Menu();
                        MethodWithDictionary();
                    }
                    else if (choice == 7)
                    {
                        Console.Clear();
                        Menu();
                        LogOut();
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
                        currentUser = name;
                        return;
                    }
                    else
                    {
                        
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
            Console.WriteLine("fel namn eller lösenord");
        }
        static void AddUser()
        {
            Console.WriteLine("Här kan du lägga till en användare");
            if (userLoggin == false)
            {
                Console.WriteLine("Logga in först innan du lägger till en användare");
                return;
            }
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
        static void ChangePassword()
        {
            string[] tempNames = new string[userNames.Length - 1];
            string[] tempPassword = new string[userPasswords.Length - 1];
            Console.WriteLine("Skriv namnet vars lösenord du vill ändra: ");
            string password = Console.ReadLine();


            int changePassword = Array.IndexOf(userNames, password);

            Console.WriteLine("Skriv det nuvarande lösenordet");
            string oldPassword = Console.ReadLine();

            int oldPasswordIndex = Array.IndexOf(userPasswords, oldPassword);

            if(userLoggin == false)
            {
                Console.WriteLine("Du måste logga in för att ändra lösenordet");
                return;
            }
            else if (changePassword == -1)
            {
                Console.WriteLine("lösenordet finns inte.");
                return;
            }
            else if (oldPasswordIndex == -1)
            {
                Console.WriteLine("lösenordet finns inte.");
                return;
            }

            if(oldPasswordIndex == changePassword)
            {
                Console.WriteLine("skriv det nya lösenordet");
                string newPassword = Console.ReadLine();
                userPasswords[changePassword] = newPassword;
            }
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
            bool userTheSame = false; //gör inget
            //TODO Man behöver inte skriva in användarens lösenord för att ta bort en användare.
            if (userLoggin == false)
            {
                Console.WriteLine("Du måste logga in för att ta bort en användare");
                return;
            }
            else 
            {
                Console.WriteLine("Skriv namnet på den du vill ta bort: ");
                string nameDelet = Console.ReadLine();
                if (currentUser == nameDelet)
                {
                    userTheSame = true; //gör inget
                    LogOut();
                    Console.WriteLine("Du har tagit bort dig själv från listan, du är nu utloggad");
                }
                else if (currentUser != nameDelet)
                {

                    Console.WriteLine("skriv Admin lösenordet för att ta bort en användare");
                    string userAdminPassword = Console.ReadLine();


                    if (userAdminPassword != adminPassword)
                    {
                        Console.WriteLine("du är inte Admin, sluta försöka ta bort folk");
                        return;
                    }
                }

                int hit = Array.IndexOf(userNames, nameDelet);

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
        }

        static void LogOut()
        {
             if (userLoggin == true)
            {
                userLoggin = false;
            }
            else
            {
                Console.WriteLine("Du är inte inloggad");
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
                "\r\n5. Ta bort ett namn ur listan" +
                "\r\n6. visa MethodWithDictionary()" +
                "\r\n9. visa menyn" +
                "\r\n7. Logga ut" +
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

            foreach (var rad in userList)
            {
                Console.WriteLine(rad.Key);
            }
        }
    }
}