namespace DelegatesBasicExample1
{
    internal class Program
    {
        delegate void LogDel(string text, DateTime dateTime);
        static void Main(string[] args)
        {
            Log log=new Log();
            LogDel textToScreenDel, textToFileDel;
            textToScreenDel=new LogDel(log.TextToScreen);
            textToFileDel=new LogDel(log.TextToFile);
            LogDel logDel=new LogDel(textToScreenDel);

            LogDel multiCastDel = textToScreenDel + textToFileDel;
            Console.WriteLine("Please Enter a name");
            var name=Console.ReadLine();
           logToText(multiCastDel,name,DateTime.Now);

        }
        static void logToText(LogDel logDel,string text,DateTime dateTime)
        {
            logDel(text,dateTime);
        }
        static void TextToScreen(string text,DateTime dateTime)
        {
            Console.WriteLine($"{dateTime}: {text}");
        }
        static void TextToFile(string text,DateTime dateTime)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "text.txt"), true))
            {
            writer.WriteLine($"{dateTime}: {text}");}
        }
    }
    public class Log
    {
        public void TextToScreen(string text,DateTime dateTime) {
            Console.WriteLine($"{dateTime}: {text}");

        }
        public void TextToFile(string text,DateTime dateTime)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "text1.txt"), true))
            {
                sw.WriteLine($"{dateTime}: {text}");
            }
        }
    }
}