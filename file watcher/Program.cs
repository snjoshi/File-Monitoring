using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file_watcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var folderpath = @"E:\fw";

            // Create a new FileSystemWatcher and set its properties.
            FileSystemWatcher watcher = new FileSystemWatcher(folderpath);
           
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
            watcher.Changed += watcher_Changed;
            watcher.Created += OnChanged;
            watcher.Deleted += watcher_Deleted;
            watcher.Renamed += watcher_Renamed;
            Console.Read();
            // Wait for the user to quit the program.
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q')
            {
            }
        }

         static void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("File: {0} renamed to {1} at time : {2}", e.OldName, e.Name, DateTime.Now.ToLocalTime());
           // throw new NotImplementedException();
        }

        private static void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File; {0} deleted at time: {1}", e.Name, DateTime.Now.ToLocalTime());
          //  throw new NotImplementedException();
        }

        private static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File; {0} changed at time: {1}", e.Name, DateTime.Now.ToLocalTime());
          //  throw new NotImplementedException();
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File; {0} created at time: {1}", e.Name, DateTime.Now.ToLocalTime());
            
        }
    }
}
