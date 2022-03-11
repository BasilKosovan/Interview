using System;

namespace Interview
{
    public class VirtualOverrideVsNew
    {
        public static void Execute()
        {
            A a1 = new A();
            A a2 = new B();
            B b1 = new B();

            a1.Print(); //  A
            a2.Print(); //  B
            b1.Print(); //  B

        }

        public class A
        {
            public int MyProperty { get; set; }

            public virtual void Print()
            {
                Console.WriteLine($"{nameof(A)}");
            }
        }

        public class B : A
        {
            public override void Print()
            {
                Console.WriteLine($"{nameof(B)}");
            }
        }

    }
}