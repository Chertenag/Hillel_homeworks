using System.Text;

namespace Hillel_hw_5
{
    public class ConsoleInputOutput : IInputOutput
    {
        public string ReadOneLine()
        {
            return Console.ReadLine();
        }

        public void WriteOneLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}