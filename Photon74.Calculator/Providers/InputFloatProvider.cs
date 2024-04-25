using Photon74.Calculator.Services;
using Photon74.Calculator.Services.Interfaces;

namespace Photon74.Calculator.Providers;

internal class InputFloatProvider
{
    private readonly IOutputService _outputService;
    private readonly InputStringService _inputStringService;

    public InputFloatProvider(IOutputService outputService, InputStringService inputStringService)
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
                _outputService.Print("Неправильное число! Попробуйте ещё (float): ");
                isNumberValide = true;
            }
            else
            {
                isNumberValide = false;
            }

        } while (isNumberValide);

        return number;
    }
}
