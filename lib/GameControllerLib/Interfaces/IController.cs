using GameControllerLib.Listeners.Interfaces;

namespace GameControllerLib.Interfaces
{
	interface IController
	{
		void AddButtonListener(IButtonListener buttonListener, int buttonID);
		void AddJoystickListener(IAnalogListener analogListener, int analogID);

		// TODO: Future work, might be nice to be able to remove a listener.
	}
}