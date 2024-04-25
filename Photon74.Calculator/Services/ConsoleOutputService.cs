using Photon74.Calculator.Services.Interfaces;

namespace Photon74.Calculator.Services;

internal class ConsoleOutputService : IOutputService
{
    /// <summary>
    /// Выводит на консоль сообщение
    /// </summary>
    /// <param name="message">Сообщение</param>
    public void Print(string message)
    {
        Console.WriteLine(message);
    }
}
