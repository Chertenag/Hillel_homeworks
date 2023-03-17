namespace Hillel_hw_12
{
    internal partial class Program
    {
        public static class MyFilesReader
        {
            public static async Task ReadFileAndLength(List<string> filesPath, CancellationToken token)
            {
                //Создаём список задач для каждого файла.
                List<Task<int>> tasks = new();
                foreach (string path in filesPath)
                {
                    tasks.Add(ReadFileBy50Bytes_Async(path, token));
                }
                try
                {
                    await Task.WhenAll(tasks);
                }
                catch
                {
                    //Вывод в консоль результата выполнения каждой задачи.
                    foreach (var task in tasks)
                    {
                        if (task.IsCompletedSuccessfully)
                        {
                            Console.WriteLine($"Chars readed: {task. Result}");
                        }
                        else if (task.IsCanceled)
                        {
                            Console.WriteLine($"Task was canceled.");
                        }
                        else if (task.IsFaulted)
                        {
                            string message = "Task was faulted. ";
                            if (task.Exception != null)
                            {
                                message += " " + task.Exception.Message;
                            }
                            Console.WriteLine(message);
                        }
                    }
                }
            }

            private static async Task<int> ReadFileBy50Bytes_Async(string fileFullName, CancellationToken token)
            {
                //Инициализация переменной для хранения общего числа считаных байтов.
                int charsReaded = 0;
                FileStream fileStream = new(fileFullName, FileMode.Open);
                if (fileStream.Length == 0)
                {
                    throw new IOException();
                }
                StreamReader streamReader = new(fileStream, System.Text.Encoding.UTF8);
                //ReadBlock читает по char, а не по байтам, поэтому как прочитать именно по 50 байт хз (латиницу считает за 1 байт а кирилицу за 2).
                //Количество чаров которые мы пытаемся прочитать.
                int charsToRead = 50;
                //Массив прочитаных чаров.
                char[] chars = new char[charsToRead];
                //Реальное количество прочитаных чаров.
                int readed;
                while ((readed = await streamReader.ReadBlockAsync(chars, 0, charsToRead)) != 0)
                {
                    //В задании указано исупользовать этот метод, но особого смысла (конкретно тут) я не вижу. Считывание происходит слишком быстро
                    //и найболее вероятной точкой вызова OperationCanceledException будет Task.Delay.
                    token.ThrowIfCancellationRequested();
                    //Конвертим в строку с указанием точного количества чаров, которые нам нужны, т.к. в конце считывание файла,
                    //массив не полность будет перезаписан и в конце останутся чары с прошлой иттерации.
                    Console.WriteLine(new string(chars, 0, readed));
                    charsReaded += readed;
                    await Task.Delay(1000, token);
                }
                return charsReaded;
            }
        }
    }
}