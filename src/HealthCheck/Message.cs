namespace HealthCheck;

internal class Message
{
    internal static void ShowInfo()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Required address was not provided.");
        Console.ResetColor();
        Console.WriteLine(
@"Description:
  Program to check application health checks endpoint and return health status as exit code.

Usage:
  healthcheck <ADDRESS> [options]

Arguments:
  <ADDRESS> Address, e.g. 'http://localhost:8080/hc'

Options:
  --silent  Do not show any messages. [default: False]");
    }

    internal static void ShowAddressError()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("<ADDRESS> argument is not valid uri.");
        Console.ResetColor();
    }
}