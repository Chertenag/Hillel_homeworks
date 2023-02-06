namespace Hillel_hw_6_ClassLibrary
{
    public static class SomeRefAndOut
    {
        //Меняет местами значения двух целочисельных переменных.
        public static void SwapTwoNumbers(ref int a, ref int b)
        {
            (b, a) = (a, b); //Студия сама предложила использовать кортеж.
        }

        //Меняет местами значения двух переменных.
        public static void SwapTwoValues<T>(ref T a, ref T b)
        {
            (b, a) = (a, b);
        }

        //Возвращает количество цифр в числовой переменной.
        public static void OutDigitsCountInANumber(double numb, out int digits)
        {
            digits = numb.ToString().Count(char.IsDigit);
        }

        //Возвращает символ строки в указанной позиции (если под "позицией" подразумевался именно индекс).
        public static void OutCharByIndex(string text, int index, out char character)
        {
            character = text[index];
        }
    }
}