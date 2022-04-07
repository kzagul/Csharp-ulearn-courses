using System;
using System.Collections.Generic;

namespace func.brainfuck
{
	public class VirtualMachine : IVirtualMachine
	{
		public string Instructions { get; }
		public int InstructionPointer { get; set; }
		public byte[] Memory { get; }
		public int MemoryPointer { get; set; }

		private Dictionary<char, Action<IVirtualMachine>> commandList; 

		public VirtualMachine(string program, int memorySize)
		{
			Instructions = program;
			InstructionPointer = 0;
			Memory = new byte[memorySize];
			MemoryPointer = 0;
			commandList = new Dictionary<char, Action<IVirtualMachine>>();
		}

		public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
		{
			commandList.Add(symbol, execute);
		}

		public void Run()
		{
			while (InstructionPointer < Instructions.Length)
            {
				if (commandList.ContainsKey(Instructions[InstructionPointer]))
					commandList[Instructions[InstructionPointer]](this);
				InstructionPointer++;
			}
		}
	}
}