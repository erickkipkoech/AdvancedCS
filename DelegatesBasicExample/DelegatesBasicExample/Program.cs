using System.Diagnostics;

namespace DelegatesBasicExample
{

     class Program
    {
        //a delegate that references a method that does not return a value(calling static methods)
        delegate void LogDel(string text);
        static void Main(string[] args)
        {
            //an instance of the log type from Log Class
            Log log = new Log();

            LogDel LogTextToScreenDel, LogTextToFileDel;

            LogTextToScreenDel=new LogDel(log.LogTextToScreen);

            LogTextToFileDel=new LogDel(log.LogTextToFile);

            //Multicast object call
            LogDel multiLogDel=LogTextToScreenDel+LogTextToFileDel;

           // LogDel logDel=new LogDel(log.LogTextToFile);
            Console.WriteLine("Please Enter your name");
            var name=Console.ReadLine();
           logText(LogTextToFileDel,name);
        }
        //passing a delegate as an argument to a method and invoking it there
        static void logText(LogDel logDel,string text)
        {
            logDel(text);
        }

        //static methods
        static void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }
        //using streamwriter to create a file on our path and save the passed in data
        static void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "text.txt"), true)) {
            sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }
    }
    public class Log
    {
        //instance methods
        public void LogTextToScreen(string text )
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }
        public void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "text.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
            
        }
    }
}