using Framework;
using System;

namespace LoggingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomLogging log = new CustomLogging(true, false);

            try
            {
                Boolean login = false;
                int retries = 0;
                //While the user is not loged or number max of retries reached
                while (login == false && retries < 3)
                {
                    //The user introduce his username and password
                    Console.WriteLine("Enter your username:");
                    String username = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    String password = Console.ReadLine();
                    
                    if (username.Equals("Admin") && password.Equals("1234"))
                    {
                        Console.WriteLine("You have been loged succesfully as:" + username);
                        log.Info("The user " + username + " have been loged succesfully");
                        login = true;
                    }
                    else
                    {
                        retries++;
                        log.Warning(CustomLogging.code.USER, "Login error, n of attemps = " + retries);
                        Console.WriteLine("Wrong username or passsword");
                    }
                }
                if (retries == 3)
                {
                    log.Error(CustomLogging.code.USER, "Session expired due the max of retries have been reached");
                    Console.WriteLine("Session expired due the max of retries have been reached");
                }
            }
            //Aplication error
            catch (Exception e)
            {
                log.Fatal(CustomLogging.code.APPLICATION, e.Message);
            }
        }
    }
}