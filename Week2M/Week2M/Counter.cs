using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2M
{
    public class Counter
    {
        private int amount = 1;
        private int top;

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public Counter() { }

        public Counter(int initialAmount)
        {
            amount = initialAmount;
        }

        public void Display()
        {
            Console.WriteLine($"Counter amount: {amount}");
        }

        public void Increment()
        {
            amount++;
        }

        public void Decrement()
        {
            amount--;
        }

        public void ResetToTop()
        {
            top = amount;
            amount = 0;
        }

        public void DisplayBoth()
        {
            Console.WriteLine($"Amount: {amount}, Top: {top}");
        }

        public void ShowInstanceMessage()
        {
            Console.WriteLine("An Object is an Instance of a Class");
            Increment();
        }
    }
}
