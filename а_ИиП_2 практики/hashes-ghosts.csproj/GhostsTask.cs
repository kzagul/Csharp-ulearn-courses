using System;
using System.Text;

namespace hashes
{
	public class GhostsTask : 
		IFactory<Document>, IFactory<Vector>, IFactory<Segment>, IFactory<Cat>, IFactory<Robot>, 
		IMagic
	{
		Vector vector = new Vector(2, 2);
		Segment segment = new Segment(new Vector(1, 3), new Vector(1, 4));

		byte[] array = { 1, 2, 4 };

		Document doc;

		Cat cat = new Cat("Alex", "Ordinary", new DateTime(2021, 5, 21));
		Robot robot = new Robot("01");



		public GhostsTask()
        {
			doc = new Document("file", UTF8Encoding.ASCII, array);
        }

        public Document Create()
        {
			return doc;
        }

        public void DoMagic()
		{
			vector.Add(vector);
			segment.End.Add(segment.End);
			array[2] = 7;
			cat.Rename("Dog");
			Robot.BatteryCapacity += 3;
		}

		Vector IFactory<Vector>.Create()
		{
			return vector;
		}

		Segment IFactory<Segment>.Create()
		{
			return segment;
		}

        Cat IFactory<Cat>.Create()
        {
			return cat;
        }

        Robot IFactory<Robot>.Create()
        {
			return robot;
        }

    }
}