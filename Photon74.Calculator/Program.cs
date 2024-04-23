namespace Photon74.Calculator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Calculator v1.0.0 \n");

        Console.Write("Введите первое число (float): ");
        var number1 = GetNumber();

        Console.Write("Введите второе число (float): ");
        var number2 = GetNumber();

        var operand = GetOperandType();
        if (operand == OperandType.None)
        {
            Console.WriteLine("Неправильный операнд! Прощайте!");
            return;
        }

        var result = Calculate(number1, number2, operand);

        Console.WriteLine($"Результат: {result}");
    }

    /// <summary>
    /// Возвращает число (float)
    /// </summary>
    /// <returns>float</returns>
    private static float GetNumber()
    {
        float number;
        bool isNumberValide;
        do
        {
            if (!Single.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Неправильное число! Попробуйте ещё (float): ");
            }
            isNumberValide = true;

        } while (isNumberValide);

        return number;
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

    /// <summary>
    /// Возвращает тип операнда
    /// </summary>
    /// <returns>Операнд</returns>
    private static OperandType GetOperandType()
    {
        Console.Write("Введите оператор + - * / :");
        var operandString = Console.ReadLine();

        return operandString switch
        {
            "+" => OperandType.Addition,
            "-" => OperandType.Subtraction,
            "/" => OperandType.Division,
            "*" => OperandType.Multiplication,
            _ => OperandType.None
        };
    }
}




