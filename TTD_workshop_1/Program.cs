namespace Calculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            int a = int.Parse(numbers.Split(',')[0]);
            int b = int.Parse(numbers.Split(',')[1]);

            return a + b;
        }

        public static void Main(String[] args)
        {
            //Calculator c = new Calculator();
        }
    }
}
