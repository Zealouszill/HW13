using Ooui;
using System;
using SharedLogic.ViewModel;
using Xamarin.Forms;
using SharedLogic;

namespace OouiHW11
{
    class Program
    {
        static void Main(string[] args)
        {
            Forms.Init();
            var vm = new MainViewModel();

            UI.Publish("/", new Page1() { BindingContext = vm }.GetOouiElement());

#if DEBUG
            UI.Port = 12345;
            UI.Host = "localhost";
            Console.ReadLine();
#endif
        }
    }
}
