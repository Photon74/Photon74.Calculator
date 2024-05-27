using Photon74.Calculator.Services;
using Photon74.Calculator.Services.Interfaces;

namespace Photon74.Calculator.Providers;

internal class InputOperandProvider
{
    private readonly IOutputService _outputService;
    private readonly InputStringService _inputStringService;

    public InputOperandProvider(IOutputService outputService, InputStringService inputStringService)
    {
        _outputService = outputService;
        _inputStringService = inputStringService;
    }

    /// <summary>
    /// Возвращает тип операнда
    /// </summary>
    /// <returns>Операнд</returns>
    public OperandType GetOperandType()
    {
        OperandType operand;

        do
        {
            _outputService.Print("Введите оператор [+] [-] [*] [/] :");
            var operandString = _inputStringService.GetStringFromUser();

            operand = operandString switch
            {
                "+" => OperandType.Addition,
                "-" => OperandType.Subtraction,
                "/" => OperandType.Division,
                "*" => OperandType.Multiplication,
                _ => OperandType.None
            };
        } while (operand == OperandType.None);

        return operand;
    }
}
