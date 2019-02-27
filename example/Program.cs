using System;

using GameControllerLib;
using GameControllerLib.InputReaders.Interfaces;
using GameControllerLib.Listeners.Interfaces;
using GameControllerLib.InputReaders;
using GameControllerLib.Definitions;

namespace example
{
    class Program
    {
        static void Main(string[] args)
        {
        	// TODO: Make this a command line arg with validation, My mouse keeps 
        	//  mapping to js0 
            string filepath = "/dev/input/js0";

            LinuxInputReader reader = new LinuxInputReader(filepath);

            Controller controller = new Controller(reader);

            // Future work will replace the number with an enum so that its
            //  MUCH more readable
            controller.AddButtonListener(new PrintingTest("CROSS"), PS4.Cross);
            controller.AddButtonListener(new PrintingTest("CIRCLE"), PS4.Circle);
            controller.AddButtonListener(new PrintingTest("TRIANGLE"), PS4.Triangle);
            controller.AddButtonListener(new PrintingTest("SQUARE"), PS4.Square);

            controller.AddButtonListener(new PrintingTest("Left Joystick"), PS4.LeftJoystickClick);
            controller.AddButtonListener(new PrintingTest("Right Joystick"), PS4.RightJoystickClick);

            controller.AddButtonListener(new PrintingTest("R1"), PS4.R1);
            controller.AddButtonListener(new PrintingTest("L1"), PS4.L1);

            controller.AddButtonListener(new PrintingTest("Share"), PS4.Share);
            controller.AddButtonListener(new PrintingTest("Options"), PS4.Options);

            

            while(true)
            {
            	// Wait for input prints
            }
        }
    }

    public class PrintingTest : IButtonListener, IAnalogListener
    {
    	private string Message { get; set; }

    	public PrintingTest(string message)
    	{
    		Message = message;
    	}

    	public void OnClick()
    	{
    		Console.WriteLine(Message + " CLICKED");
    	}

		public void OnRelease()
		{
			//Console.WriteLine(Message + " RELEASED");
		}

		public void OnChange(int val)
		{
			Console.WriteLine(Message + "[" + val + "]");
		}

    }
}
