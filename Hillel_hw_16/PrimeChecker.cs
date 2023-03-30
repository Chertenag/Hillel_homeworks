namespace Hillel_hw_16
{
    public static class PrimeChecker
    {
        /// <summary>
        /// Проверка на простые числа. 
        /// https://en.wikipedia.org/wiki/Primality_test
        /// </summary>
        /// <param name="value">Число для проверки.</param>
        /// <returns>true если число простое.</returns>
        public static bool Check(double value)
        {
            //Проверка на целочисельное
            if (value != (int)value)
                return false;

            if (value == 2 || value == 3)
            {
                return true;
            }

            if (value <= 1 || value % 2 == 0 || value % 3 == 0)
                return false;

            for (int i = 5; i * i <= value; i += 6)
            {
                if (value % i == 0 || value % (i + 2) == 0)
                    return false;
            }
            {
                return true;
            }
        }
    }

}