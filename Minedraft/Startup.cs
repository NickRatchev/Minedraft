using System;
using System.Linq;

public class Program
{
    static void Main()
    {
        DraftManager draftManager = new DraftManager();
        string command;

        do
        {
            var arguments = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            command = arguments[0];
            arguments.RemoveAt(0);

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(draftManager.RegisterHarvester(arguments));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(draftManager.RegisterProvider(arguments));
                    break;
                case "Day":
                    Console.WriteLine(draftManager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(draftManager.Mode(arguments));
                    break;
                case "Check":
                    Console.WriteLine(draftManager.Check(arguments));
                    break;
                case "Shutdown":
                    Console.WriteLine(draftManager.ShutDown());
                    break;
            }

        } while (command != "Shutdown");
    }
}