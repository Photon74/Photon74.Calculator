using Photon74.Calculator.Providers;
using Photon74.Calculator.Services;
using Photon74.Calculator.Services.Interfaces;

namespace Photon74.Calculator;

internal class Program
{
    static void Main(string[] args)
    {

        if(args.Length == 0)
        {
            throw new ArgumentNullException(nameof(args));
        }

        IOutputService outputService;

        var values = args[0].Split('=');
        outputService = values[1] == "console" 
            ? new ConsoleOutputService() 
            : new MessageBoxOutputService();

        // Services
        var inputStringService = new InputStringService();
        var inputProvider = new InputFloatProvider(outputService, inputStringService);
        var parseOperandProvider = new InputOperandProvider(outputService, inputStringService);
        var calculateProvider = new CalculateProvider(outputService);

        //Welcome
        outputService.Print("Calculator v3.0.0 \n");

        //Program
        outputService.Print("Введите первое число (float): ");
        var number1 = inputProvider.GetNumber();

        outputService.Print("Введите второе число (float): ");
        var number2 = inputProvider.GetNumber();

        var operand = parseOperandProvider.GetOperandType();

        var result = calculateProvider.Calculate(number1, number2, operand);
        if (result is not null)
        {
            outputService.Print($"Результат: {result}");
        }
        else
        {
            outputService.Print($"Результата нет!");
        }
    }
}
