namespace Photon74.Calculator.Services.Interfaces;

public interface IOutputService
{
    public void Print(string message)
    {
        ArgumentNullException.ThrowIfNull(message);
    }
}
