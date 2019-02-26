using System.Linq;
using System.IO;

using GameControllerLib.InputReaders.Interfaces;
using GameControllerLib.InputReaders;

namespace GameControllerLib.InputReaders
{
	public class LinuxInputReader : IInputReader
	{
		private FileStream Reader {get; set; }

		LinuxInputReader(string fd)
		{
			Reader = new FileStream(fd, FileMode.Open);
		}

		public Input Read()
		{
			byte[] input = new byte[8];

			Reader.Read(input, 0, input.Length);

			return new Input(0, 0, 0, InputTypes.DIGITAL);
		}
	}
}