namespace SecretAppForGit
{
    internal class Program
    {
        static string[] userNames = { "Pelle", "Stina", "Ali" };
        static string[] userPasswords = { "1234", "abcd", "qwerty" };

        static void Main(string[] args)
        {
            int count = 0;
            while (count < userNames.Length)
            {
                Console.WriteLine("Hell World!");
                count++;
            }
        }

        static void AddUser()
        {
            Console.WriteLine("Hello, from AddUser");
        }
        static void ChangePassword()
        {
            Console.WriteLine("Hello, from ChangePassword");
        }
        static void ShowUsers()
        {
            Console.WriteLine("Hello, from ShowUsers");
        }
        static void EndApplication()
        {
            Console.WriteLine("Hello, from EndApplication");
        }
    }
}
