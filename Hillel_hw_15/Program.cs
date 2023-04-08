namespace Hillel_hw_15
{
    internal class Program
    {
        private static Semaphore semaphore;
        private static EventWaitHandle eventWH = new(false, EventResetMode.AutoReset, "Hillel_hw_15_EventWaitHandle");

        static void Main(string[] args)
        {
            Task.Run(CheckForNewInstance);
            Run();
          
        }

        private static void Run()
        {
            Semaphore semaphore = new(3, 3, "Hillel_hw_15_Semaphore", out bool createdNew);
            if (createdNew)
            {
                Console.WriteLine("First instance started.");
                semaphore.WaitOne();
            }
            else if (semaphore.WaitOne(100))
            {
                eventWH.Set();
            }
            else
            {
                Console.WriteLine("Maximum number of instances reached.");
                return;
            }



            Console.WriteLine("Work simulation. Press enter to exit.");
            Console.ReadLine();

            semaphore.Release();

        }

        private static void CheckForNewInstance()
        {
            while (true)
            {
                eventWH.WaitOne();
                Console.WriteLine("New instance created.");
            }
        }
    }
}