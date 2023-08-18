namespace Giraffe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Movie movie1 = new Movie("Avengers", "Tom", "Great");
            Movie movie2 = new Movie("Legacies", "Mark", "PG-13");

            Console.WriteLine(movie1.Rating);
            Console.WriteLine(movie2.Rating);
        }

        static decimal GetPow(int baseNum,int powNum)
        {
            int result = 1;
            for(int i = 0; i < powNum; i++)
            {
                result *= baseNum;
            }
            return result;
        }
    }
}