using System;
namespace Наследование
{
    interface IUser
    {
        void Method();
    }
    interface IAdmin
    {
        
    }
    public class Person
    {

    }
    public class User : IUser
    {
        public void Method()
        {
            throw new NotImplementedException();
        }
    }
    public class Admin : User, IAdmin
    {

    }






    interface IInterface1
    {
        void Method()
        {
        }
    }
    interface IInterface2
    {
        void Method()
        {
        }
    }


    public class Class : IInterface1, IInterface2
    {
        public void Method()
        {
            Console.WriteLine("1");
        }
        void IInterface2.Method()
        {
            Console.WriteLine("2");
        }
    }
}
