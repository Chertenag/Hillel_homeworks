namespace Hillel_hw_5
{
    internal class Program
    {
        static void Main(string[] _)
        {
            Console.WriteLine("Enter text to remove duplicate words from it, which are separated by space.");
            IInputOutput inputOutput = new ConsoleInputOutput();

            while (true)
            {
                inputOutput.WriteOneLine(RemoveDublicates.Remove(inputOutput.ReadOneLine()));
                inputOutput.WriteOneLine($"#################################{Environment.NewLine}Enter new text.");
            }
        }
    }
}