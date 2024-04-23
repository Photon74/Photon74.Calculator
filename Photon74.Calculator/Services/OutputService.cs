namespace Photon74.Calculator.Services;

internal class OutputService
{
    /// <summary>
    /// Выводит на консоль сообщение
    /// </summary>
    /// <param name="message"></param>
    internal void ConsolePrint(string message)
    {
        ArgumentNullException.ThrowIfNull(message);
        Console.WriteLine(message);
    }
}
