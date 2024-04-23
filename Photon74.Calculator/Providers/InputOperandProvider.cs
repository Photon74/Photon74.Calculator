using Photon74.Calculator.Services;

namespace Photon74.Calculator.Providers;

internal class InputOperandProvider
{
    private readonly OutputService _outputService;
    private readonly InputStringService _inputStringService;

    public InputOperandProvider(OutputService outputService, InputStringService inputStringService)
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
        OperandType operand = OperandType.None;


        do
        {
            _outputService.ConsolePrint("Введите оператор + - * / :");
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
