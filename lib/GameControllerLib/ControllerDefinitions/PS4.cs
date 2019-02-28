namespace GameControllerLib.Definitions
{
	public class PS4
	{
		public static readonly int Cross = 0;
		public static readonly int Circle = 1;
		public static readonly int Triangle = 2;
		public static readonly int Square = 3;

		public static readonly int LeftJoystickClick = 11;
		public static readonly int RightJoystickClick = 12;

		public static readonly int Share = 8;
		public static readonly int Options = 9;

		public static readonly int R1 = 5;
		public static readonly int L1 = 4;

		// These are tricky because they have both digital values
		//  and an analog ones
		public static readonly int R2 = 7;
		public static readonly int L2 = 6;
		public static readonly int R2Analog = 5;
		public static readonly int L2Analog = 2;

		public static readonly int DPadHorizontal = 6;
		public static readonly int DPadVertical = 7;

		public static readonly int RightJoystickHorizontal = 4;
		public static readonly int RightJoystickVertical = 3;
		public static readonly int LeftJoystickHorizontal = 0;
		public static readonly int LeftJoystickVertical = 1;
	}
}