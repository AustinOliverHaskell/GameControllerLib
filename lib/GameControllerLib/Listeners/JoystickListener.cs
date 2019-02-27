namespace GameControllerLib.Listeners.Interfaces
{
	public class JoystickListener : IJoystickListener
	{
		private IAnalogListener XListener { get; set; }
		private IAnalogListener YListener { get; set; }

		public int X { get; private set; }
		public int Y { get; private set; }

		public JoystickListener()
		{

		}

		public void OnChange(int x, int y)
		{

		}

		public void DirectionChanged()
		{

		}

		public void IntensityChanged()
		{

		}
	}
}