namespace Hillel_hw_12
{
    internal partial class Program
    {
        private static void Main(string[] _)
        {
            //Инициализируем источник токена отмены и сам токен.
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            //Создаем список файлов для чтения. Сами файлы включены в проект и копируются в папку при билде.
            //Test1-3 на латинице, Test4 - пустой, Test6 - на кирилице.
            List<string> filesPath = new()
            {
                @"Testfiles\Test_1.txt",
                @"Testfiles\Test_2.txt",
                @"Testfiles\Test_3.txt",
                @"Testfiles\Test_4.txt",
                @"Testfiles\Test_6.txt",
            };

            //Запускаем задачу чтения файлов и вывода на екран содержимого.
            Task.Run(() => MyFilesReader.ReadFileAndLength(filesPath, token));

            //Т.к. никаких доп. условий касательно прерывания операции чтения файлов нет, то попытка у пользователя будет всего одна)
            if (Console.ReadLine() == "Interrupt")
            {
                cts.Cancel();
            }
            Console.ReadLine();
        }
    }
}