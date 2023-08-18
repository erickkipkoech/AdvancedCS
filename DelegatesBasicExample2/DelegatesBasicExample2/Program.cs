namespace DelegatesBasicExample2
{
     class Program
    {
        delegate void LogDel(string text);
        static void Main(string[] args)
          
        {

            Log log = new Log();
            //LogDel logDel = new LogDel(TextToScreen);
            LogDel TextToScreenDel, TextToFileDel;

            TextToScreenDel=new LogDel(log.TextToScreen);

            TextToFileDel = new LogDel(log.TextToFile);

            LogDel multicastDel = TextToScreenDel + TextToFileDel;

            Console.WriteLine("Please Enter your name");

            var name=Console.ReadLine();

            logText(TextToScreenDel,name);

        }
        static void logText(LogDel logDel, string text)
        {
            logDel(text);
        }
        static void TextToScreen(string text)
        {
            Console.WriteLine(text);
        }
        static void TextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "newText.txt"), true)) {
                sw.WriteLine(text);
            }
        }
    }
    public class Log
    {
        public void TextToScreen(string text)
        {
            Console.WriteLine(text);
        }
        public void TextToFile(string text)
        {
           using (StreamWriter streamWriter = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "newText1.txt"), true))
            {
                streamWriter.WriteLine(text);
            }
        }
    }
}