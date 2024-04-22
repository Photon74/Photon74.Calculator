namespace Photon74.Calculator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Calculator v1.0.0 \n");

        Console.Write("Введите первое число: ");
        var number1 = GetNumber();
        if (number1 is null)
        {
            Console.WriteLine("Неправильное число! Прощайте!");
            return;
        }

        Console.Write("Введите второе число: ");
        var number2 = GetNumber();
        if (number2 is null)
        {
            Console.WriteLine("Неправильное число! Прощайте!");
            return;
        }

        var operand = GetOperandType();
        if (operand == OperandType.None)
        {
            Console.WriteLine("Неправильный операнд! Прощайте!");
            return;
        }

        var result = Calculate(number1.Value, number2.Value, operand);

        Console.WriteLine($"Результат: {result}");
    }

    private static float? GetNumber()
    {
        return !Single.TryParse(Console.ReadLine(), out float number) 
            ? null 
            : number;
    }

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




