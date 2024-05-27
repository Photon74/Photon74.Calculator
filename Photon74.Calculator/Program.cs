using Calabonga.Utils;
using Photon74.Calculator.Providers;
using Photon74.Calculator.Services;
using Photon74.Calculator.Services.Interfaces;

namespace Photon74.Calculator;

internal class Program
{
    static void Main(string[] args)
    {
        //var outputService = ProcessArguments(args);

        var container = new SimpleIoc();
        container.Register<IOutputService, ConsoleOutputService>();
        container.Register<InputStringService>();
        container.Register<InputFloatProvider>();
        container.Register<InputOperandProvider>();
        container.Register<CalculateProvider>();

        // Services
        var outputService = container.Resolve<IOutputService>();
        var inputFloatProvider = container.Resolve<InputFloatProvider>();
        var inputOperandProvider = container.Resolve<InputOperandProvider>();
        var calculateProvider = container.Resolve<CalculateProvider>();

        //Welcome
        outputService.Print("Calculator v4.0.0 \n");

        //Getting first number
        outputService.Print("Введите первое число (float): ");
        var number1 = inputFloatProvider.GetNumber();

        //Getting second number
        outputService.Print("Введите второе число (float): ");
        var number2 = inputFloatProvider.GetNumber();

        //Getting operand type
        var operand = inputOperandProvider.GetOperandType();

        //Calculation
        var result = calculateProvider.Calculate(number1, number2, operand);
        if (result is not null)
        {
            outputService.Print($"Результат: {result:F}");
        }
        else
        {
            outputService.Print($"Результата нет!");
        }
    }

    private static IOutputService ProcessArguments(string[] args)
    {

        if (args.Length == 0)
        {
            throw new ArgumentNullException(nameof(args));
        }

        var values = args[0].Split('=');
        return values[1] == "console"
            ? new ConsoleOutputService()
            : new MessageBoxOutputService();
    }
}
