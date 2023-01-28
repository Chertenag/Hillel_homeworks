using System;
using System.Text.RegularExpressions;

namespace Hillel_hw_5
{
    public static class RemoveDublicates
    {
        static Regex _dublFinder = new Regex(
            @"
            \b          #граница слова (начало или конец)
            (?<dubl1>   #начало новой группы - dubl1
            \w+         #поиск 1 или более символов слова (word characters)
            )           #конец группы
            \b          #граница слова (начало или конец)
            (?<dubl2>   #начало новой группы - dubl2
            \s          #символ пробела
            \b          #граница слова (начало или конец)
            \<dubl1>    #поиск группы dubl1
            )           #конец группы (тут ищем повторения группы dubl1 и заключаем в группу dubl2 вместе с пробелом)
            \b          #граница слова (начало или конец)
            ", 
            RegexOptions.IgnorePatternWhitespace  //флаг игнора пробелов в составлении патерна и разрешения комментов
            | 
            RegexOptions.IgnoreCase     //флаг игнора регистра           
            );

        public static string Remove(string inputText)
        {
            return _dublFinder.Replace(inputText, "${dubl1}");
        }
    }
}