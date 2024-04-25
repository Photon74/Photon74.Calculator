using System.Windows.Forms;
using Photon74.Calculator.Services.Interfaces;

namespace Photon74.Calculator.Services;
internal class MessageBoxOutputService : IOutputService
{
    /// <summary>
    /// Выводит сообщение в MessageBox
    /// </summary>
    /// <param name="message">Текст сообщения</param>
    public void Print(string message)
    {
        MessageBox.Show(message);
    }
}
