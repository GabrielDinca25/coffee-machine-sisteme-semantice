using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var coffeeMachine = new DeluxeCoffeeMachine(20, 30, 40);

            coffeeMachine.Run();

            //var carRepairShop = new CarRepairShop();

            //carRepairShop.Run();
        }
    }
}
