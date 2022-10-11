using ConsimpleTestTask;
using System.Net;

public class TestApp
{

    public static void Main()
    {
        bool isActiveCircle = true;
        while (isActiveCircle)
        {
            Console.WriteLine("Press \"1\" to send request or press \"0\" to exit");
            switch (Console.ReadLine())
            {
                case "0": isActiveCircle = false;
                    break;
                case "1": RequestToAPI.Execute();
                    break;
                default: Console.WriteLine("Wrong button");
                    break;
            }
        }

    }
}