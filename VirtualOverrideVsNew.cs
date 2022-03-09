using System;

namespace ConsoleApp1
{
    public class VirtualOverrideVsNew
    {
        public static void Execute()
        {
            A a1 = new A();
            A a2 = new B();
            B b1 = new B();

            a1.Print(); // 
            a2.Print(); // 
            b1.Print(); // 

        }

        public class A
        {
            public int MyProperty { get; set; }

            public void Print()
            {
                Console.WriteLine($"{nameof(A)}");
            }
        }

        public class B : A
        {
            public void Print()
            {
                Console.WriteLine($"{nameof(B)}");
            }
        }

    }
}