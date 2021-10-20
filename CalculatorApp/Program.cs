using System;

namespace CalculatorApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            calculator.Calculation();
        }
    }
    public class Calculator
    {
        Operation operation = new Operation();
       
        public string Convertation(string value, int from, int to)
        {
            string result = Convert.ToString(Convert.ToInt32(value, from), to);
            return result;
        }
        public void PrintBinaryAnswer(string _binaryResult)
        {
            Console.WriteLine($"binary={Convertation(_binaryResult, 10,2)}");
        }
        public void PrintDecimalAnswer(string _decimalResult)
        {
            Console.WriteLine($"deciaml={_decimalResult}");
        }
        public void PrintHexAnswer(string _hexResult)
        {
            Console.WriteLine($"hex={Convertation(_hexResult,10,16)}");
        }

        public  void Calculation()
        {
            Console.WriteLine("Please select mode");
            string mode = Convert.ToString(Console.ReadLine());
            switch (mode.ToLower())
            {
                case ("binary"):
                    Console.WriteLine("please insert binary numbers");
                    string firstBinary = Convert.ToString(Console.ReadLine());
                    string secondBinary = Convert.ToString(Console.ReadLine());
                    int firstDecimal=int.Parse(Convertation(firstBinary, 2, 10));
                    int secondDecimal=int.Parse(Convertation(secondBinary, 2, 10));
                    Console.WriteLine("Please select one of this operations +,-,*,/");
                    string decimalResult = operation.OperationSelect(firstDecimal, secondDecimal).ToString();
                    PrintDecimalAnswer(decimalResult);
                    PrintHexAnswer(Convertation(decimalResult, 10, 16));
                    PrintBinaryAnswer(Convertation(decimalResult, 10, 2));
                    break;


                case "decimal":
                    Console.WriteLine("Please insert decimal numbers");
                    int _firstDecimal = Convert.ToInt32(Console.ReadLine());
                    int _secondDecimal = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please select one of this operations +,-,*,/");
                    string result= operation.OperationSelect(_firstDecimal, _secondDecimal)
                                            .ToString();
                    PrintBinaryAnswer(Convertation(result, 10, 2));
                    PrintDecimalAnswer(result);
                    PrintHexAnswer(Convertation(result, 10, 16));
                    break;


                case "hex":
                    Console.WriteLine("please insert hex numbers");
                    string firstHex = Convert.ToString(Console.ReadLine());
                    string secondHex = Convert.ToString(Console.ReadLine());
                    int firstDecimal_ = int.Parse(Convertation(firstHex, 16, 10));
                    int secondDecimal_ = int.Parse(Convertation(secondHex, 16, 10));
                    Console.WriteLine("Please select one of this operations +,-,*,/");
                    string _result = operation.OperationSelect(firstDecimal_, secondDecimal_)
                                              .ToString();
                    PrintBinaryAnswer(Convertation(_result, 10, 2));
                    PrintDecimalAnswer(_result);
                    PrintHexAnswer(Convertation(_result, 10, 16));
                    break;
            }
            
        }

    }
    public class Operation
    {
        public int Add(int first, int second)
        {
            return first + second;
        }
        public int Subtract(int first, int second)
        {
           
            if (first<second)
            {

                int temp = first;
                first = second;
                second = temp;

            }
            return first - second;
        }
        public int Multipy(int first, int second)
        {
            return first * second;
        }
        public int Divide(int first, int second)
        {
            if (second != 0)
            {
                return first / second;
            }
            else
            {
                throw new Exception("Can not divide by zero");
            }
        }
        
           
        public int OperationSelect(int first, int second)
        {

            string mode = Convert.ToString(Console.ReadLine());
           
            switch (mode)
            {
                case "+":

                  return  Add(first, second);

                case "-":
                    return Subtract(first, second);                  

                case "*":
                    return Multipy(first, second);

                case "/":
                    return Divide(first, second);
             }
            throw new Exception("You did not selected any correct operation");
        }
    }
}
