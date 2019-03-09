using System;
using System.Collections.Generic;

namespace TestConsole
{
    // 1 queue per application
    // TODO: try to implement multiples queues trying to have que same api structure.
    public class JobQueue : IJobQueue
    {
        //Queue.prototype.create = function(type, data)

        //static JobQueue()
        //{
        //    JobQueue.start();
        //}

        //params object[] args
        //public List<Func<object, object[]>> queue = new List<Func<object, object[]>>();
        //public static List<FuncParams> queue = new List<FuncParams>();
        public static Queue<FuncParams> queue = new Queue<FuncParams>();

        public static bool ExecuteExpirated = true;

        //Multiple queues create/new
        //public static void create()
        //{
        //    throw new NotImplementedException();
        //}
        public static void start()
        {
            throw new NotImplementedException();
        }
        public static void define(string name, Action action)
        {
            throw new NotImplementedException();
        }
        public static void define(string name, Action action, Action callback)
        {
            throw new NotImplementedException();
        }
        public static void define(string name, Action<object> action)
        {
            throw new NotImplementedException();
        }
        public static void define<T>(string name, Action<T> p)
        {
            throw new NotImplementedException();
        }

        //public static void define(string v, Action p)
        //{
        //    throw new NotImplementedException();
        //}


        public static void enqueue(Action action)
        {
            enqueue(null, null, action);
        }
        public static void enqueue(string jobName)
        {
            enqueue(jobName, null, null);
        }
        public static void enqueue(string jobName, object data = null)
        {
            enqueue( jobName, data, null);
        }
        public static void enqueue(string jobName, Action action = null)
        {
            enqueue(jobName, null, action);
        }
        public static void enqueue(string jobName = null,object data=null, Action action = null)
        {
            //throw new NotImplementedException();
            var func = new Func<object, object[]>( 
                (args) => 
                {
                    action();
                    return null;
                }
            );
            //queue.Add();
            enqueue(func);
        }

        public static void enqueue(Func<object, object[]> func, params object[] args )
        {
            //throw new NotImplementedException();
            //var func = new Func<object, object[]>()
            FuncParams FuncParams = new FuncParams() { func = func , parameters = args};
            //queue.Add(FuncParams);
            queue.Enqueue(FuncParams);
            //TODO:Use sqlite
        }
    }
    class JobQueueItem
    {
        public long id { get; set; }
        public long time { get; set; }

        public string name { get; set; }
    }
    
}