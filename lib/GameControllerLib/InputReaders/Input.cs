namespace GameControllerLib.InputReaders
{
	public enum InputTypes
	{
		ANALOG,
		DIGITAL
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
	}
}