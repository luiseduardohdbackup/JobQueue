using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main start");


            Console.WriteLine("Main end");
            Console.ReadLine();
        }
        public void testSqlite()
        {

            // Get an absolute path to the database file
            //var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");
            var databasePath = "MyData.db";

            var db = new SQLiteConnection(databasePath);
            //db.CreateTable<Stock>();
            //db.CreateTable<Valuation>();
        }
        public void testJobQueue()
        {
            JobQueue.define("test", () => { Console.WriteLine("Test"); });
            JobQueue.define("test", () => { Console.WriteLine("Test"); }, () => { Console.WriteLine("Test"); });
            JobQueue.define("test with data", 
                (data) => 
                {
                    Console.WriteLine("Test" + JsonConvert.SerializeObject(data));
                }
            );

            JobQueue.start();
            //Job without name
            JobQueue.enqueue(() => { Console.WriteLine("Test-Job without name");  });
            //Parameterless call
            JobQueue.enqueue("test");
            //call with parameters
            JobQueue.enqueue("test with data", new { algo ="algo" });
            //call with parameters and callback
            JobQueue.enqueue("test with data", new { algo = "algo" }, () => { Console.WriteLine("Test-call with parameters and callback"); });
        }
        public void testTaskQueue()
        {
            var queue = new TaskQueue();// define a new task
            queue
            .on("error", (job) => { }) // queue error handler
            .on("complete", (job) => { }); // queue success handler

            queue
              .define("my-task")
              .online() // check that navigator is online before attempting to process job
              .interval("10s") // replay a failed job every 10sec (default is 2sec)
              .retry(5) // retry up to 5 times
              .delay("5ms") // start task after a 5ms delay
              .timeout("10ms") // task fail if it lasts more than 10ms
              .lifetime("5m") // stop retrying if job is more than 5min old
              .action((job, done) => {
                  // ...
                  done("err"); // pass an error to the callback if task failed
              });
            var data = new { };
            // load and process jobs persisted in the localstorage
            queue.start();
            // process a new job
            var jobTask = queue
              .create("my-task", data)
              .on("error", () => { }) // job error handler
              .on("complete", () => { }) // job success handler
            ;


        }
        public void testLocalStorage()
        {

        }
        //public static void AddStock(SQLiteConnection db, string symbol)
        //{
        //    var stock = new Stock()
        //    {
        //        Symbol = symbol
        //    };
        //    db.Insert(stock);
        //    Console.WriteLine("{0} == {1}", stock.Symbol, stock.Id);
        //}
    }
    

    
    
    
    
    
    
    

    

    //public class Stock
    //{
    //    [PrimaryKey, AutoIncrement]
    //    public int Id { get; set; }
    //    public string Symbol { get; set; }
    //}

    //public class Valuation
    //{
    //    [PrimaryKey, AutoIncrement]
    //    public int Id { get; set; }
    //    [Indexed]
    //    public int StockId { get; set; }
    //    public DateTime Time { get; set; }
    //    public decimal Price { get; set; }
    //}
}
