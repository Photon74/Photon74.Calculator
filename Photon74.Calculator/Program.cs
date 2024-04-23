using Photon74.Calculator.Providers;
using Photon74.Calculator.Services;

namespace Photon74.Calculator;

internal class Program
{
    static void Main(string[] args)
    {
        // Services
        var outputService = new OutputService();
        var inputStringService = new InputStringService();
        var inputService = new InputFloatProvider(outputService, inputStringService);
        var parseOperandService = new InputOperandProvider(outputService, inputStringService);

        //Welcome
        outputService.ConsolePrint("Calculator v1.0.0 \n");

        //Program
        outputService.ConsolePrint("Введите первое число (float): ");
        var number1 = inputService.GetNumber();

        outputService.ConsolePrint("Введите второе число (float): ");
        var number2 = inputService.GetNumber();

        var operand = parseOperandService.GetOperandType();
        if (operand == OperandType.None)
        {
            outputService.ConsolePrint("Неправильный операнд! Прощайте!");
            return;
        }

        var result = Calculate(number1, number2, operand);
        if (result is not null)
        {
            outputService.ConsolePrint($"Результат: {result}");
        }
        else
        {
            outputService.ConsolePrint($"Результата нет!");
        }
    }

    /// <summary>
    /// Возвращает результат вычисления
    /// </summary>
    /// <param name="number1">Первое число</param>
    /// <param name="number2">Второе число</param>
    /// <param name="operand">Операнд (действие)</param>
    /// <returns>float</returns>
    private static float? Calculate(float number1, float number2, OperandType operand)
    {
        switch (operand)
        {
            case OperandType.Addition:
                return number1 + number2;
            case OperandType.Subtraction:
                return number1 - number2;
            case OperandType.Multiplication:
                return number1 * number2;
            case OperandType.Division:
                if (number2 == 0)
                {
                    Console.WriteLine("Делить на ноль нельзя! Прощайте!");
                    return null;
                }
                return number1 / number2;
        }
        return null;
    }
}
