namespace Hillel_hw_12
{
    internal partial class Program
    {
        public static class MyFilesReader
        {
            public static async Task ReadFileAndLength(List<string> filesPath, CancellationToken token)
            {
                List<Task<int>> tasks = new();
                foreach (string path in filesPath)
                {
                    tasks.Add(ReadFileAndReturnReadedLength(path, token));
                }
                var results = await Task.WhenAll(tasks);
                foreach (var rez in results)
                {
                    Console.WriteLine($"Chars readed: {rez}");
                }
            }

            //Не понимаю как обработать IOException не из метода чтения файла, так чтобы не использовать заглушку в виде ещё одного метода
            //между основным методом и Task.WhenAll. Потому что Task.WhenAll выкидывает ошибку сразу как она случается в одном из Task`ов.
            //Ещё у меня был вариант формировать строку с количеством прочитаных символов (или инфой об ошибке) в этом методе и уже её (строку) передавать дальше.
            //Таким образом вывод результата в WhenAll мог бы включать и инфу об ошибке, а не просто 0 в кол-ве прочитаного. Но хз нужно ли это.
            private static async Task<int> ReadFileAndReturnReadedLength(string fileFullName, CancellationToken token)
            {
                int rez = -1;
                try
                {
                    rez = await ReadFileBy50Bytes_Async(fileFullName, token);
                }
                catch (IOException ex)
                {
                    //В задании сказано, что метод должен выкинуть эту ошибку если файл пустой, но не указано что с ней делать дальше.
                    //Console.WriteLine(ex.Message);
                    return 0;
                }
                catch
                {
                    return 0;
                }

                return rez;
            }

            private static async Task<int> ReadFileBy50Bytes_Async(string fileFullName, CancellationToken token)
            {
                //Инициализация переменной для хранения общего числа считаных байтов.
                int charsReaded = 0;
                try
                {
                    FileStream fileStream = new FileStream(fileFullName, FileMode.Open);
                    if (fileStream.Length == 0)
                    {
                        throw new IOException();
                    }
                    StreamReader streamReader = new StreamReader(fileStream, System.Text.Encoding.UTF8);
                    //ReadBlock читает по char, а не по байтам, поэтому как прочитать именно по 50 байт хз (латиницу считает за 1 байт а кирилицу за 2).
                    //Количество чаров которые мы пытаемся прочитать.
                    int charsToRead = 50;
                    //Массив прочитаных чаров.
                    char[] chars = new char[charsToRead];
                    //Реальное количество прочитаных чаров.
                    int readed = 0;
                    while ((readed = await streamReader.ReadBlockAsync(chars, 0, charsToRead)) != 0)
                    {
                        //В задании указано исупользовать этот метод, но особого смысла (конкретно тут) я не вижу. Считывание происходит слишком быстро
                        //и найболее вероятной точкой вызова OperationCanceledException будет Task.Delay.
                        token.ThrowIfCancellationRequested();
                        //Конвертим в строку с указание точного количества чаров, которые нам нужны, т.к. в конце считывание файла,
                        //массив не полность будет перезаписан и в конце останутся чары с прошлой иттерации.
                        Console.WriteLine(new string(chars, 0, readed));
                        charsReaded += readed;
                        await Task.Delay(1000, token);
                    }
                    return charsReaded;
                }
                catch (OperationCanceledException)
                {
                    return charsReaded;
                }
            }
        }
    }
}