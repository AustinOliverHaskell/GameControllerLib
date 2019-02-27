using System;
using System.Collections.Generic;
using System.Threading;

using GameControllerLib.Interfaces;
using GameControllerLib.Listeners.Interfaces;
using GameControllerLib.InputReaders;
using GameControllerLib.InputReaders.Interfaces;

namespace GameControllerLib
{
    public class Controller : IController
    {
    	private IInputReader Reader { get; set; }
        private Thread InputThread { get; set; }
        
    	private Dictionary<int, List<IButtonListener>> Buttons { get; set; }
    	private Dictionary<int, List<IAnalogListener>> Analogs { get; set; }

    	public Controller(IInputReader reader)
    	{
    		Reader = reader;

            Buttons = new Dictionary<int, List<IButtonListener>>();
            Analogs = new Dictionary<int, List<IAnalogListener>>();

            // This might be hard to unit test
            InputThread = new Thread(this.ReadInput);
            InputThread.Start();
    	}

    	// Runs in its own thread
    	private void ReadInput()
    	{
            Console.WriteLine("Reader Thread Started.");
            // The input for this could be threaded instead
            //  I really want to avoid having to poll the 
            //  controller so that it updates its input.
            // On the other hand making it do it Automagically
            //  will require an init method OR inputs could be 
            //  missed if the program hasent added the listener
            //  yet. 
            // I guess missing input at the very start of the 
            //  program isnt too bad, just because these 
            //  will be created and added (in most use cases)
            //  very quickly. 
    		while(true)
    		{
    			Input input = Reader.Read();

                if (input != null)
                {
    			     ApplyInput(input);
                }
    		}
    	}

    	private void ApplyInput(Input i)
    	{
            if (i == null) { return; }

    		if (i.Type == InputTypes.ANALOG) 
    		{
                List <IAnalogListener> listenerList = null;
    			if(Analogs.TryGetValue(i.Id, out listenerList))
    			{
                    foreach (IAnalogListener listener in listenerList)
                    {
        				// This one might be a problem, the X and Y
        				//  Axis of a controller in linux are mapped as 
        				//  two different inputs. Doesnt apply here as 
        				//  this is an abstraction but getting these 
        				//  values will be tricky.
    				    listener.OnChange(i.Value);
                    }
    			}
    		}
    		else // Digital 
    		{
                List<IButtonListener> listenerList = null;
    			if(Buttons.TryGetValue(i.Id, out listenerList))
    			{
                    foreach (IButtonListener listener in listenerList)
                    {
        				if (i.Value == 0)
        				{
        					listener.OnRelease();
        				}
        				else
        				{
        					listener.OnClick();
        				}
                    }
    			}
    		}
    	}

    	// --- Interface methods --- 
    	public void AddButtonListener(IButtonListener buttonListener, int buttonID)
    	{
            List<IButtonListener> value = null;
    		if(Buttons.TryGetValue(buttonID, out value))
    		{
    			value.Add(buttonListener);
    		}
    		else
    		{
    			List<IButtonListener> listenList = new List<IButtonListener>();
    			listenList.Add(buttonListener);
    			Buttons.Add(buttonID, listenList);
    		}
    	}

		public void AddAnalogListener(IAnalogListener analogListener, int analogID)
		{
            List<IAnalogListener> value = null;
			if(Analogs.TryGetValue(analogID, out value))
    		{
    			value.Add(analogListener);
    		}
    		else
    		{
    			List<IAnalogListener> listenList = new List<IAnalogListener>();
    			listenList.Add(analogListener);
    			Analogs.Add(analogID, listenList);
    		}
		}

    }
}
