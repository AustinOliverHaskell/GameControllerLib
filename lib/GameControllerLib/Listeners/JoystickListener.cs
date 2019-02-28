namespace GameControllerLib.Listeners.Interfaces
{
	public enum Joystick
	{
		Horizontal,
		Vertical
	}

	public abstract class JoystickListener
	{
		// 
		public IAnalogListener XListener { get; protected set; }
		public IAnalogListener YListener { get; protected set; }

		protected int X { get; set; }
		protected int Y { get; set; }

		// These joystick IDs will need to be abstracted, I cant think of a scnario where
		//  you would want to listen to two axies on different joysticks
		public JoystickListener(int xAxisID, int yAxisID)
		{
			// I really want to hide the fact that this is made from two AnalogListeners from the
			//  consumer of this API
			XListener = new JoystickUpdater(Joystick.Horizontal, this);
			YListener = new JoystickUpdater(Joystick.Vertical, this);
		}

		public void UpdateAxis(Joystick j, int value)
		{
			if (j.Equals(Joystick.Horizontal))
			{
				X = value;
			}
			else
			{
				Y = value;
			}

			OnChange(X, Y);
		}

		public abstract void OnChange(int x, int y);

	}

	public class JoystickUpdater : IAnalogListener
	{
		private Joystick Axis { get; set; }
		private JoystickListener _parent { get; set; }

		public JoystickUpdater(Joystick axis, JoystickListener parent)
		{
			Axis = axis;
			_parent = parent;
		}

		public void OnChange(int value)
		{
			_parent.UpdateAxis(Axis, value);
		}
	}
}