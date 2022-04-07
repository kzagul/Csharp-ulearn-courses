using System.Collections.Generic;

namespace func.brainfuck
{
	public class BrainfuckLoopCommands
	{
		public static void RegisterTo(IVirtualMachine vm)
		{
			Stack<int> stack = new Stack<int>();
			Dictionary<int, int> positions = new Dictionary<int, int>();
			int i = 0;
			foreach (var instruction in vm.Instructions)
            {
				if (instruction == '[') stack.Push(i);
				else if (instruction == ']')
                {
					int index = stack.Pop();
					positions[index] = i;
					positions[i] = index;
                }
				i++;
            }
			vm.RegisterCommand('[', b => { if (b.Memory[b.MemoryPointer] == 0) 
					b.InstructionPointer = positions[b.InstructionPointer]; });
			vm.RegisterCommand(']', b => {if (b.Memory[b.MemoryPointer] != 0)
					b.InstructionPointer = positions[b.InstructionPointer];
			});
		}
	}
}