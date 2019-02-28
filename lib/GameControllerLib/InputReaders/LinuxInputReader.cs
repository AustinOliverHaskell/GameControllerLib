using System;
using System.Linq;
using System.IO;

using GameControllerLib.InputReaders.Interfaces;
using GameControllerLib.InputReaders;

namespace GameControllerLib.InputReaders
{
	public class LinuxInputReader : IInputReader
	{
		private FileStream Reader {get; set; }

		public LinuxInputReader(string fd)
		{
			Reader = new FileStream(fd, FileMode.Open);
		}

		public Input Read()
		{
			byte[] input = new byte[8];

			Reader.Read(input, 0, input.Length);

			int time;
                  short val;
                  InputTypes type;
                  byte id;

                  time = input[3];
                  time += ( time << 8 ) | input[2];
                  time += ( time << 8 ) | input[1];
                  time += ( time << 8 ) | input[0];

                  val = input[4];
                  val += (short)(( val << 8 ) + input[5]);

                  type = Input.ConvertByteToType(input[6]);
                  id = input[7];

                  // TODO: Better handling on this
                  if (type == InputTypes.UNKNOWN)
                  {
                        Console.WriteLine("Got a value but it was Unknown. Discarded");
                        return null;
                  }

                  Input retVal = new Input(time, val, id, type);
                  //Console.WriteLine(retVal.ToString());
                  return retVal;
		}
	}
}