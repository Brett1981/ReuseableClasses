using System;

namespace Re_useable_Classes.Threading
{
    public class MyThread
    {
        // This method will be called when the thread is started.
        private volatile bool _shouldStop;

        public void DoWork()
        {
            while (!_shouldStop)
            {
                Console.WriteLine(@"worker thread: working...");
            }
            Console.WriteLine(@"worker thread: terminating gracefully.");
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }
    }

    //EXAMPLE HOW TO USE
    //public class WorkerThreadExample
    //{
    //    public static void MainThread()
    //    {
    //        // Create the thread object. This does not start the thread.
    //        var workerObject = new MyThread();
    //        var workerThread = new Thread(workerObject.DoWork);

    //        // Start the worker thread.
    //        workerThread.Start();
    //        Console.WriteLine(@"main thread: Starting worker thread...");

    //        // Loop until worker thread activates.
    //        while (!workerThread.IsAlive) ;

    //        // Put the main thread to sleep for 1 millisecond to
    //        // allow the worker thread to do some work:
    //        Thread.Sleep(1);

    //        // Request that the worker thread stop itself:
    //        workerObject.RequestStop();

    //        // Use the Join method to block the current thread
    //        // until the object's thread terminates.
    //        workerThread.Join();
    //        Console.WriteLine(@"main thread: Worker thread has terminated.");
    //    }
    //}
}