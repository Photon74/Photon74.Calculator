using Photon74.Calculator.Services;

namespace Photon74.Calculator.Providers;
internal class CalculateProvider
{
    private readonly OutputService _outputService;

    public CalculateProvider(OutputService outputService)
    {
        _outputService = outputService;
    }

    /// <summary>
    /// Возвращает результат вычисления
    /// </summary>
    /// <param name="number1">Первое число</param>
    /// <param name="number2">Второе число</param>
    /// <param name="operand">Операнд (действие)</param>
    /// <returns>float</returns>
    public float? Calculate(float number1, float number2, OperandType operand)
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
                    _outputService.ConsolePrint("Делить на ноль нельзя! Прощайте!");
                    return null;
                }
                return number1 / number2;
        }
        return null;
    }
}
