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
        var calculateService = new CalculateService(outputService);

        //Welcome
        outputService.ConsolePrint("Calculator v2.0.0 \n");

        //Program
        outputService.ConsolePrint("Введите первое число (float): ");
        var number1 = inputService.GetNumber();

        outputService.ConsolePrint("Введите второе число (float): ");
        var number2 = inputService.GetNumber();

        var operand = parseOperandService.GetOperandType();

        var result = calculateService.Calculate(number1, number2, operand);
        if (result is not null)
        {
            outputService.ConsolePrint($"Результат: {result}");
        }
        else
        {
            outputService.ConsolePrint($"Результата нет!");
        }
    }
}
