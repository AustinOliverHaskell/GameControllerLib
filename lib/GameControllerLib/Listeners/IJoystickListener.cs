namespace GameControllerLib.Listeners.Interfaces
{
	public interface IJoystickListener
	{
		void OnChange(int x, int y);

		// TODO: Add parameters
		void DirectionChanged();
		void IntensityChanged();
	}
}