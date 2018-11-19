using System;
using System.Collections.Generic;
using System.Threading;

namespace Re_useable_Classes.Threading
{
    public static class Program
    {
        private static void Mainpool()
        {
            using (var pool = new Pool(5))
            {
                var random = new Random();
                Action<int> randomizer = (index =>
                                          {
                                              Console.WriteLine
                                                  (
                                                      "{0}: Working on index {1}",
                                                      Thread.CurrentThread.Name,
                                                      index);
                                              Thread.Sleep
                                                  (
                                                      random.Next
                                                          (
                                                              20,
                                                              400));
                                              Console.WriteLine
                                                  (
                                                      "{0}: Ending {1}",
                                                      Thread.CurrentThread.Name,
                                                      index);
                                          });

                for (int i = 0;
                     i < 40;
                     ++i)
                {
                    int i1 = i;
                    pool.QueueTask(() => randomizer(i1));
                }
            }
        }
    }

    public sealed class Pool : IDisposable
    {
        private readonly LinkedList<Action> _tasks = new LinkedList<Action>();
        private readonly LinkedList<Thread> _workers;

        // queue of worker threads ready to process actions
        private bool _disallowAdd;

        // set to true when disposing queue but there are still tasks pending
        private bool _disposed;

        public Pool(int size)
        {
            _workers = new LinkedList<Thread>();
            for (int i = 0;
                 i < size;
                 ++i)
            {
                var worker = new Thread(Worker)
                             {
                                 Name = string.Concat
                                     (
                                         "Worker ",
                                         i)
                             };
                worker.Start();
                _workers.AddLast(worker);
            }
        }

        // set to true when disposing queue and no more tasks are pending
        public void Dispose()
        {
            bool waitForThreads = false;
            lock (_tasks)
            {
                if (!_disposed)
                {
                    GC.SuppressFinalize(this);

                    _disallowAdd = true;
                    // wait for all tasks to finish processing while not allowing any more new tasks
                    while (_tasks.Count > 0)
                    {
                        Monitor.Wait(_tasks);
                    }

                    _disposed = true;
                    Monitor.PulseAll(_tasks);
                    // wake all workers (none of them will be active at this point; disposed flag will cause then to finish so that we can join them)
                    waitForThreads = true;
                }
            }
            if (!waitForThreads)
            {
                return;
            }
            foreach (Thread worker in _workers)
            {
                worker.Join();
            }
        }

        // actions to be processed by worker threads
        public void QueueTask(Action task)
        {
            lock (_tasks)
            {
                if (!_disallowAdd)
                {
                    if (!_disposed)
                    {
                        _tasks.AddLast(task);
                        Monitor.PulseAll(_tasks); // pulse because tasks count changed
                    }
                    else
                    {
                        throw new ObjectDisposedException("This Pool instance has already been disposed");
                    }
                }
                else
                {
                    throw new InvalidOperationException
                        (
                        "This Pool instance is in the process of being disposed, can't add anymore");
                }
            }
        }

        private void Worker()
        {
            while (true) // loop until threadpool is disposed
            {
                Action task;
                lock (_tasks) // finding a task needs to be atomic
                {
                    while (true) // wait for our turn in _workers queue and an available task
                    {
                        if (!_disposed)
                        {
                            if (null == _workers.First || !ReferenceEquals
                                                               (
                                                                   Thread.CurrentThread,
                                                                   _workers.First.Value) ||
                                _tasks.Count <= 0)
                            {
                                Monitor.Wait(_tasks); // go to sleep, either not our turn or no task to process
                            }
                            else
                            {
                                task = _tasks.First.Value;
                                _tasks.RemoveFirst();
                                _workers.RemoveFirst();
                                Monitor.PulseAll(_tasks);
                                // pulse because current (First) worker changed (so that next available sleeping worker will pick up its task)
                                break; // we found a task to process, break out from the above 'while (true)' loop
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                task(); // process the found task
                lock (_tasks)
                {
                    _workers.AddLast(Thread.CurrentThread);
                }
            }
        }
    }
}