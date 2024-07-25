using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20240725_ExceptionsHandlingDemo
{
    internal class Program
    {
        const int ITERATIONS_COUNT = 100;

        static void Main(string[] args)
        {
            Stopwatch sw1 = Stopwatch.StartNew();
            for (int i = 0; i < ITERATIONS_COUNT; i++)
            {
                int a = 10;
                int b = 0;

                //int c = 0;

                if (DoDiv(a, b, out int c) == 0)
                {
                    //Console.WriteLine("{0} / {1} = {2}", a, b, c);
                }
                else
                {
                    //Console.WriteLine(":( Error!");
                }
            }
            sw1.Stop();
            Console.WriteLine("Time DoDiv(): {0}msec ({1}tikcs)", sw1.ElapsedMilliseconds, sw1.ElapsedTicks);


            Stopwatch sw2 = Stopwatch.StartNew();
            for (int i = 0; i < ITERATIONS_COUNT; i++)
            {
                int a = 10;
                int b = 0;

                //int c = 0;

                if (DoDivWithExceptions(a, b, out int c) == 0)
                {
                    //Console.WriteLine("{0} / {1} = {2}", a, b, c);
                }
                else
                {
                    // Console.WriteLine(":( Error!");
                }
            }
            sw2.Stop();
            Console.WriteLine("Time DoDivWithExceptions(): {0}msec ({1}tikcs)", sw2.ElapsedMilliseconds, sw2.ElapsedTicks);

            Stopwatch sw3 = Stopwatch.StartNew();
        //    for (int i = 0; i < ITERATIONS_COUNT; i++)
            {
                int a = 10;
                int b = 0;

                try
                {
                    int d = DoDiv(a, b);
                    Console.WriteLine("{0} / {1} = {2}", a, b, d);
                }
                catch (MyDivByZerroException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Exception: {0}", ex);
                }
            }
            sw3.Stop();
            Console.WriteLine("Time DoDiv(): {0}msec ({1}tikcs)", sw3.ElapsedMilliseconds, sw3.ElapsedTicks);

            //try
            //{
            //    DoRecurs();
            //}
            //catch (StackOverflowException ex)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine($"Exception: {ex}");
            //}

            try
            {
                int n = InputNumber();
            }            
            catch (OverflowException ex)
            {
                Console.WriteLine("Wrong Size!!!!");
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                Console.WriteLine("finally in Main()");
            }


            Console.ReadKey();
        }

        private static int InputNumber()
        {
            int n = 0;

            bool fExit = false;
            do
            {
                Console.Write("Enter n? : ");
                string s = Console.ReadLine();

                try
                {
                    n = int.Parse(s);

                    fExit = true;

                    Console.WriteLine("n = {0}", n);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Wrong Format!!!!");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(":(");

                    throw;
                }
                finally
                {
                    Console.WriteLine("finally in InputNumber()");
                }
            } while (!fExit);

            return n;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <returns>0 - Ok, 1 - Error</returns>
        private static int DoDiv(int arg1, int arg2, out int result)
        {
            int ok = 1;
            result = 0;

            if (arg2 != 0)
            {
                result = arg1 / arg2;
                ok = 0;
            }

            return ok;
        }

        private static int DoDiv(int arg1, int arg2)
        {
            int result = 0;

            if (arg2 == 0)
            {
                // !!! throw
                throw new MyDivByZerroException(arg1, arg2);
            }

            result = arg1 / arg2;

            return result;
        }


        private static int DoDivWithExceptions(int arg1, int arg2, out int result)
        {
            int ok = 1;
            result = 0;

            try
            {
                result = arg1 / arg2;
                ok = 0;
            }
            catch (DivideByZeroException ex)
            {
               // Console.WriteLine($"Exception: {ex}");
            }

            return ok;
        }

        public static void DoRecurs()
        {
            DoRecurs();
        }
    }
}
