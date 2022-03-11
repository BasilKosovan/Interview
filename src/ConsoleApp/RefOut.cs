using System;

namespace Interview
{
    public class RefOut
    {
        public static void Execute()
        {
            var instanceVariable = new TestClass { MyProperty = 1 };
            DoSmthQ3(ref instanceVariable); // 10
            
            
            //DoSmthQ2(instanceVariable);
            //DoSmthQ3(instanceVariable);

            instanceVariable.Print();
        }

        public static void DoSmthQ3(ref TestClass instanceVariableInMethod)
        {
            instanceVariableInMethod = new TestClass { MyProperty = 10 };
        }

        public static void DoSmthQ2(TestClass instanceVariableInMethod)
        {
            instanceVariableInMethod = new TestClass { MyProperty = 10 };
        }

        public static void DoSmthQ1(TestClass instanceVariableInMethod)
        {
            instanceVariableInMethod.MyProperty = 10;
        }

        public class TestClass
        {
            public int MyProperty { get; set; }

            public void Print()
            {
                Console.WriteLine($"MyProperty = {MyProperty }");
            }
        }





        //Stack: instanceVariable, instanceVariableInMethod
        //Heap: object for instanceVariable and object ...
    }
}