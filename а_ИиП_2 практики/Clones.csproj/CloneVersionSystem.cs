using System;
using System.Collections.Generic;

namespace Clones
{
	public class CloneVersionSystem : ICloneVersionSystem
	{
		public List<Clone> Clones = new List<Clone> { new Clone (1, new ProgramStack(), new ProgramStack()) };


		public string Execute(string query)
		{
			string[] strs = query.Split(); // 1 элемент массива строк - то есть название команды
			int ci = int.Parse(strs[1]) - 1; // номер клона
			//pi - название программы

			if (strs[0] == "learn")
            {
				int pi = int.Parse(strs[2]); //pi
				Clones[ci].Learn(pi);
			}
			else if (strs[0] == "rollback")
			{
				Clones[ci].Rollback();
			}
			else if (strs[0] == "relearn")
			{
				Clones[ci].Relearn();
			}
			else if (strs[0] == "clone")
			{
				Clones.Add(Clones[ci].Copy());
			}
			else if (strs[0] == "check")
			{
				return Clones[ci].Check();
			}
			return null;
		}
	}

	public class Clone
    {
		public int Ci { get; set; }
		public ProgramStack KnownProgrammes { get; set; }
		public ProgramStack UnlearnedProgrammes { get; set; }
		public Clone(int ci, ProgramStack knownProgrammes, ProgramStack unlearnedProgrammes)
		{
			KnownProgrammes = knownProgrammes;
			UnlearnedProgrammes = unlearnedProgrammes;
			Ci = ci;
		}

		public void Learn(int pi)
        {
			KnownProgrammes.Push(pi);
        }

		public void Rollback()
		{
			UnlearnedProgrammes.Push(KnownProgrammes.Pop());
		}

		public void Relearn()
		{
			KnownProgrammes.Push(UnlearnedProgrammes.Pop());
		}

        public Clone Copy()
        {
			return new Clone(Ci, new ProgramStack(KnownProgrammes), new ProgramStack(UnlearnedProgrammes));
        }

        public string Check()
        {
			return KnownProgrammes.Tail == null ? "basic" : KnownProgrammes.Tail.Pi.ToString();
        }
    }

    public class ProgramStack
    {
		public Programme Tail { get; set; }

		public ProgramStack()
        {

        }
		public ProgramStack(ProgramStack other)
		{
			Tail = other.Tail;
		}

		public void Push(int pi)
        {
			Tail = new Programme(pi, Tail);
        }

		public int Pop()
        {
			if (Tail == null) throw new InvalidOperationException();
			int pi = Tail.Pi;
			Tail = Tail.Previous;
			return pi;
        }
	}

	public class Programme
    {
		public int Pi { get; private set; }
		public Programme Previous { get; private set; }

		public Programme(int pi, Programme previous)
        {
			Pi = pi;
			Previous = previous;
		}
    }
}
