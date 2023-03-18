namespace Hillel_hw_11
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Генерируем массив случайных чисел от 0 до 50 длиной от 11 до 101.
            int[] array1 = new int[Random.Shared.Next(11, 101)];
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = Random.Shared.Next(0, 50);
            }

            // Создаем источник и токен отмены.
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            // Запуск в новом потоке метода сортировки слиянием.
            Console.WriteLine($"Start sorting {array1.Length} elements array.");
            Task task = Task.Run(
                () =>
                {
                    try
                    {
                        int[] rez1 = MultiThreadMergeSorter.DivideAndMergeSort(array1, token);
                        token.ThrowIfCancellationRequested();
                        Console.WriteLine("Task completed.");
                    }
                    catch (OperationCanceledException)
                    {
                        Console.WriteLine("Task was not completed.");
                    }
                }, token);

            // Отмена задачи сортровки после 100 мс.
            cts.CancelAfter(100);

            Console.ReadLine();
        }
    }
}