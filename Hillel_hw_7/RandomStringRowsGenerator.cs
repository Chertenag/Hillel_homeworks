using System.Text;

namespace Hillel_hw_7
{
    public static class RandomStringRowsGenerator
    {
        private static readonly Random _randomChar = new Random();

        public static List<string> Generate(int rowsCount, int minRowLength, int maxRowLength)
        {
            List<string> rowsList = new List<string>();
            for (int i = 0; i < rowsCount; i++)
            {
                int rowLength = new Random().Next(minRowLength, maxRowLength);
                StringBuilder stringBuilder = new(rowLength);
                for (int j = 0; j < rowLength; j++)
                {
                    stringBuilder.Append((char)_randomChar.Next(48, 122));
                }
                rowsList.Add(stringBuilder.ToString());
            }
            return rowsList;
        }
    }
}