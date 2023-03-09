namespace Calculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            int result = 0;
            if (!String.IsNullOrEmpty(numbers))
            {
                List<string> delimiters = new List<string>();
                List<string> summands = new List<string>();

                // parsing custom delimiter setting string
                if (numbers.StartsWith("//"))
                {
                    numbers = numbers.Remove(0, 2);
                    // parsing multiple custom delimiters
                    if(numbers.ElementAt(0) == '[')
                    {

                        while(numbers.ElementAt(0) == '[')
                        {
                            numbers = numbers.Remove(0, 1);
                            delimiters.Add(numbers.Substring(0, numbers.IndexOf(']')));
                            numbers = numbers.Remove(0, numbers.IndexOf(']') + 1);
                        }

                        // remove '\n' after the setting delimiters line
                        numbers = numbers.Remove(0, 1);

                    }
                    else
                    {
                        delimiters.Add(numbers.Substring(0, numbers.IndexOf('\n')));
                        numbers = numbers.Remove(0, numbers.IndexOf('\n') + 1);
                    }

                    summands = numbers.Split(delimiters.ToArray(), StringSplitOptions.None).Where(summand => int.Parse(summand) <= 1000).ToList();
                }
                else
                {
                    summands = numbers.Split(new char[] { ',', '\n' }).Where(summand => int.Parse(summand) <= 1000).ToList();
                }

                foreach (var summand in summands)
                {
                    if (int.Parse(summand) < 0)
                        throw new NegativeArgumentsException(summands.Where(summand => int.Parse(summand) < 0).Select(int.Parse).ToArray());
                    result += int.Parse(summand);

                }
            }
            return result;
        }

        public static void Main(String[] args) { }
    }

    public class NegativeArgumentsException : Exception
    {
        public NegativeArgumentsException() { }

        public NegativeArgumentsException(int[] negativeArgs) : base(CreateMessage(negativeArgs)) { }

        private static string CreateMessage(int[] negativeArgs)
        {
            string message = "Negative arguments provided:";
            foreach(int arg in negativeArgs)
            {
                message = message + " " + arg.ToString();
            }
            return message;
        }
    }
}
