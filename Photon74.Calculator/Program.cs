using Microsoft.Extensions.DependencyInjection;
using Photon74.Calculator.Providers;
using Photon74.Calculator.Services;
using Photon74.Calculator.Services.Interfaces;

namespace Photon74.Calculator;

internal class Program
{
    static void Main(string[] args)
    {

        var services = new ServiceCollection();
        services.AddTransient<IOutputService, ConsoleOutputService>();
        services.AddTransient<InputStringService>();
        services.AddTransient<InputFloatProvider>();
        services.AddTransient<InputOperandProvider>();
        services.AddTransient<CalculateProvider>();

        var serviceProvider = services.BuildServiceProvider();

        // Services
        var outputService = serviceProvider.GetRequiredService<IOutputService>();
        var inputFloatProvider = serviceProvider.GetRequiredService<InputFloatProvider>();
        var inputOperandProvider = serviceProvider.GetRequiredService<InputOperandProvider>();
        var calculateProvider = serviceProvider.GetRequiredService<CalculateProvider>();

        //Welcome
        outputService.Print("Calculator v5.0.0 \n");

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

    private static IOutputService ProcessArguments(string[] args, IEnumerable<IOutputService> outputServices)
    {

        if (args.Length == 0)
        {
            throw new ArgumentNullException(nameof(args));
        }

        var values = args[0].Split('=');
        return values[1] == "console"
            ? outputServices.First(s => s.GetType() == typeof(ConsoleOutputService))
            : outputServices.First(s => s.GetType() == typeof(MessageBoxOutputService));
    }
}
