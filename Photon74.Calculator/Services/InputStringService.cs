namespace Photon74.Calculator.Services;

internal class InputStringService
{
    /// <summary>
    /// Возвращает ввод пользователя с консоли
    /// </summary>
    /// <returns>string</returns>
    public string? GetStringFromUser()
    {
        return Console.ReadLine();
    }
}
