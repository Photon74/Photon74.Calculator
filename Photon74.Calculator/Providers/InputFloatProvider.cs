using Photon74.Calculator.Services;

namespace Photon74.Calculator.Providers;

internal class InputFloatProvider
{
    private readonly OutputService _outputService;
    private readonly InputStringService _inputStringService;

    public InputFloatProvider(OutputService outputService, InputStringService inputStringService)
    {
        _outputService = outputService;
        _inputStringService = inputStringService;
    }

    /// <summary>
    /// Возвращает число (float)
    /// </summary>
    /// <returns>float</returns>
    public float GetNumber()
    {
        float number;
        bool isNumberValide;
        do
        {
            if (!float.TryParse(_inputStringService.GetStringFromUser(), out number))
            {
                _outputService.ConsolePrint("Неправильное число! Попробуйте ещё (float): ");
            }
            isNumberValide = true;

        } while (isNumberValide);

        return number;
    }

}
