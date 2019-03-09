using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestConsole
{
    //LocalStorage Synchronous Sqlite implementation
    //https://developer.mozilla.org/es/docs/Web/API/Storage/setItem
    public class LocalStorage
    {
        public SQLiteConnection connection;
        public string path;
        private static string dbName = "LocalStorage.db";

        //Default Constructor with LocalApplicationData Folder
        public LocalStorage()
            : this(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbName))
        {
        }
        public LocalStorage(string path )
        {
            Console.WriteLine("Hello World!");
            this.path = path;
            var databasePath = path;
            connection = new SQLiteConnection(databasePath);
            connection.CreateTable<KeyValue>();
        }
        public void setItem(string key, string data)
        {
            connection.InsertOrReplace(new KeyValue() { key = key, value = data });
        }

        public string getItem(string key)
        {
            string result = "";

            try
            {
                result = connection.Find<KeyValue>(key).value;
            }
            catch(Exception e)
            {
                return "";
            }

            return result;
        }

        public void removeItem(string key)
        {
            connection.Delete<KeyValue>(key);
        }

        public void clear(object p)
        {
            connection.DeleteAll<KeyValue>();
        }

        public object key(int n)
        {
            var list = connection.Table<KeyValue>().ToList();
            return list[n].key;
        }
    }
    class KeyValue
    {
        [PrimaryKey]
        public string key { get; set; }
        public string value { get; set; }
    }

    //TODO: check if change for another implementation like:
    //https://github.com/Microsoft/FASTER
    //Add a checkpoint functionality.
    //TODO: do i need to chang it to async methods to avoid freeze the thread ?
    //TODO: use and id property on  KeyValue for key() method
}