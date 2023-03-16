internal partial class Program
{
    public static class MultiThreadMergeSorter
    {
        /// <summary>
        /// Разделяет пополам массив пока не останется 1 элемент, после чего постепенно объединяет обратно с сортировкой.
        /// </summary>
        /// <param name="inputArray">Массив для сортировки.</param>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Отсортированый массив.</returns>
        public static int[] DivideAndMergeSort(int[] inputArray, CancellationToken token)
        {
            try
            {
                token.ThrowIfCancellationRequested();

                int count = inputArray.Count();
                if (count > 1)
                {
                    int leftCount = count / 2;
                    int rightCount = count - leftCount;

                    //Дальнейшее деление левой половины массива в новом таске.
                    int[] leftArray = new int[leftCount];
                    Array.Copy(inputArray, 0, leftArray, 0, leftCount);
                    Task leftTask = Task.Run(() =>
                    {
                        //Вот хз, нужна ли тут тоже конструкция с try/catch, проверкой токена и выводом сообщения об отмене задачи.
                        leftArray = DivideAndMergeSort(leftArray, token);
                    }, token);

                    Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}. Left divide {leftCount}.");

                    token.ThrowIfCancellationRequested();

                    //Дальнейшее деление правой половины массива в новом таске.
                    int[] rightArray = new int[rightCount];
                    Array.Copy(inputArray, leftCount, rightArray, 0, rightCount);
                    Task rightTask = Task.Run(() =>
                    {
                        rightArray = DivideAndMergeSort(rightArray, token);
                    }, token);

                    Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}. Right divide {rightCount}.");

                    //Ожидание тасков.
                    leftTask.Wait(token);
                    rightTask.Wait(token);

                    token.ThrowIfCancellationRequested();

                    return Merge(leftArray, rightArray, token);
                }
                else
                {
                    return inputArray;
                }

            }
            catch (OperationCanceledException)
            {
                Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}. Task was canceled.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}. {ex.Message}");
                return null;
            }
        }

        private static int[] Merge(int[] left, int[] right, CancellationToken token)
        {
            try
            {
                Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}. Merge {left.Length + right.Length}.");
                //Индексы массивов для итерации.
                int l = 0, r = 0;
                int[] rez = new int[left.Length + right.Length];
                //Главный цикл в котором последовательно выбираем меньший элемент из масивов и записываем в новый.
                while (l < left.Length && r < right.Length)
                {
                    token.ThrowIfCancellationRequested();
                    if (left[l] <= right[r])
                    {
                        rez[l + r] = left[l];
                        l++;
                    }
                    else
                    {
                        rez[l + r] = right[r];
                        r++;
                    }
                }
                //Два цикла, один из которых запустится, когда все элементы другого будут использованы в передыдущем цикле.
                //Дозапишет оставшиеся элементы в результат.
                while (l < left.Length)
                {
                    rez[l + r] = left[l];
                    l++;
                }
                while (r < right.Length)
                {
                    rez[l + r] = right[r];
                    r++;
                }
                return rez;

            }
            catch (OperationCanceledException)
            {
                Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}. Task was canceled.");
                return null;
            }
        }
    }
}