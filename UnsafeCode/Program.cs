using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnsafeCode
{
    class Program
    {
        static unsafe void Main(string[] args)
        {

            int myInt = 10;
            SquareIntPointer(&myInt);
            Console.WriteLine("myInt: {0}", myInt);
            PrintValueAndAddress();

            Console.WriteLine("***** Calling method with unsafe code *****");
            int i = 10, j = 20;

            Console.WriteLine("\n**** Safe swap *****");
            Console.WriteLine("Value befor safe swap: i = {0}, j = {1}", i, j);
            SafeSwap(ref i, ref j);
            Console.WriteLine("Value after safe swap: i = {0}, j = {1}", i, j);

            Console.WriteLine("\n**** Unsafe swap *****");
            Console.WriteLine("Value befor unsafe swap: i = {0}, j = {1}", i, j);
            unsafe { UnsafeSwap(&i, &j); }
            Console.WriteLine("Value after unsafe swap: i = {0}, j = {1}", i, j);
        }
        static unsafe void SquareIntPointer(int* myIntPointer)
        {
            *myIntPointer *= *myIntPointer;
        }
        static unsafe void PrintValueAndAddress()
        {
            int myInt;
            int* ptrToMyInt = &myInt;
            *ptrToMyInt = 123;
            Console.WriteLine("Value of myInt {0}", myInt);
            Console.WriteLine("Adress of myInt {0:X}", (int)&ptrToMyInt);
        }
        public unsafe static void UnsafeSwap(int* i, int* j)
        {
            int temp = *i;
            *i = *j;
            *j = temp;
        }
        public static void SafeSwap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }
    }
}
