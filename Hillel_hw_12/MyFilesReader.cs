namespace Hillel_hw_12
{
    internal partial class Program
    {
        public static class MyFilesReader
        {
            public static async Task ReadFileAndLength(List<string> filesPath, CancellationToken token)
            {
                int[] results = new int[filesPath.Count];
                try
                {
                    List<Task<int>> tasks = new();
                    foreach (string path in filesPath)
                    {
                        tasks.Add(ReadFileAndReturnReadedLength(path, token));
                    }
                    results = await Task.WhenAll(tasks);
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    foreach (var rez in results)
                    {
                        Console.WriteLine($"Chars readed: {rez}");
                    }
                }
            }

            //Не понимаю как обработать IOException не из метода чтения файла, так чтобы не использовать заглушку в виде ещё одного метода
            //между основным методом и Task.WhenAll. Потому что Task.WhenAll выкидывает ошибку сразу как она случается в одном из Task`ов.
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
                    //Количество считываемых символов за цикл.
                    //int charsToRead = 50;
                    //while (fileStream.Position < fileStream.Length)
                    //{
                    //    token.ThrowIfCancellationRequested();
                    //    if (fileStream.Length - fileStream.Position < charsToRead)
                    //    {
                    //        charsToRead = (int)(fileStream.Length - fileStream.Position);
                    //    }
                    //    char[] chars = new char[charsToRead];
                    //    var readed = await streamReader.ReadBlockAsync(chars, 0, charsToRead);
                    //    charsReaded += readed;
                    //    //Не могу вкурить чего Position переходит в конец после первого же считывания, хотя я и указываю читать только 50 байт. 
                    //    //Пришлось указывать позицию вручную.
                    //    //fileStream.Position = charsReaded;
                    //    Console.WriteLine(chars);
                    //    await Task.Delay(100);
                    //}

                    //ReadBlock читает по char, а не по байтам, поэтому как прочитать именно по 50 байт хз (латиницу считает за 1 байт и кирилицу за 2).
                    int charsToRead = 50;
                    char[] chars = new char[charsToRead];
                    int readed = 0;
                    while ((readed = await streamReader.ReadBlockAsync(chars, 0, charsToRead)) != 0)
                    {
                        //В задании указано исупользовать этот метод, но особого смысла (конкретно тут) я не вижу. Считывание происходит слишком быстро
                        //и найболее вероятной точкой вызова OperationCanceledException будет Task.Delay.
                        token.ThrowIfCancellationRequested();
                        Console.WriteLine(new string(chars, 0, readed));
                        charsReaded += readed;
                        await Task.Delay(1000, token);
                    }



                    //int charsToRead = 50;
                    //int readed = 0;
                    //char[] chars = new char[charsToRead];
                    //while ((readed = await streamReader.ReadBlockAsync(chars, 0, charsToRead)) != 0)
                    //{
                    //    Console.WriteLine(chars);
                    //    await Task.Delay(1000);
                    //}




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