namespace GameControllerLib.InputReaders
{
	public enum InputTypes
	{
		ANALOG,
		DIGITAL,
		UNKNOWN
	}

	public class Input
	{
		public int Timestamp { get; set; }
		public short Value { get; set; }
		public byte Id { get; set; }
		public InputTypes Type { get; set; }

		public Input(int t, short v, byte i, InputTypes y)
		{
			Timestamp = t;
			Value = v;
			Id = i;
			Type = y;
		}

		public static InputTypes ConvertByteToType(byte b)
		{
			switch (b)
			{
				case 1: 
					return InputTypes.DIGITAL;
				case 2:
					return InputTypes.ANALOG;
				default:
					return InputTypes.UNKNOWN;
			}
		}

		public override string ToString()
		{
			return "Time: " + Timestamp + "  Value: " + Value + "  ID: " + Id + "  Type: " + Type.ToString("g");
		}
	}
}