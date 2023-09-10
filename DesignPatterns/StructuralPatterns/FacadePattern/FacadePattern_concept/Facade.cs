using System;

namespace FacadePattern
{
    /// <summary>
    /// The 'Facade' class
    /// </summary>
    internal class Facade
    {
        private readonly SubSystemOne _one;
        private readonly SubSystemTwo _two;
        private readonly SubSystemThree _three;
        private readonly SubSystemFour _four;

        public Facade()
        {
            _one = new SubSystemOne();
            _two = new SubSystemTwo();
            _three = new SubSystemThree();
            _four = new SubSystemFour();
        }

        public void MethodA()
        {
            Console.WriteLine("\nMethodA() ---- ");
            _one.MethodOne();
            _two.MethodTwo();
            _four.MethodFour();
        }

        public void MethodB()
        {
            Console.WriteLine("\nMethodB() ---- ");
            _two.MethodTwo();
            _three.MethodThree();
        }
    }
}