using System;

using GameControllerLib;
using GameControllerLib.InputReaders.Interfaces;
using GameControllerLib.Listeners.Interfaces;
using GameControllerLib.InputReaders;

namespace example
{
    class Program
    {
        static void Main(string[] args)
        {
        	// TODO: Make this a command line arg with validation, My mouse keeps 
        	//  mapping to js0 
            string filepath = "/dev/input/js1";

            LinuxInputReader reader = new LinuxInputReader(filepath);

            Controller controller = new Controller(reader);

            // Future work will replace the number with an enum so that its
            //  MUCH more readable
            controller.AddButtonListener(new PrintingButtonTest("CROSS    Pressed"), 0);
            controller.AddButtonListener(new PrintingButtonTest("CIRCLE   Pressed"), 1);
            controller.AddButtonListener(new PrintingButtonTest("TRIANGLE Pressed"), 2);
            controller.AddButtonListener(new PrintingButtonTest("SQUARE   Pressed"), 3);

            while(true)
            {
            	// Wait for input prints
            }
        }
    }

    public class PrintingButtonTest : IButtonListener
    {
    	private string Message { get; set; }

    	public PrintingButtonTest(string message)
    	{
    		Message = message;
    	}

    	public void OnClick()
    	{
    		Console.WriteLine(Message + " CLICKED");
    	}

		public void OnRelease()
		{
			Console.WriteLine(Message + " RELEASED");
		}

    }
}
