using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20240725_ExceptionsHandlingDemo
{
    public class MyDivByZerroException : Exception
    {
        public int FirstArgument { get; private set; }
        public int SecondArgument { get; private set; }

        public MyDivByZerroException()
        {
                
        }

        public MyDivByZerroException(string message)
            : base(message)
        {

        }

        public MyDivByZerroException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public MyDivByZerroException(int firstArgument, int secondArgument)
            : base("My Div By Zerro Exception")
        {
            FirstArgument = firstArgument;
            SecondArgument = secondArgument;
        }
    }
}
