using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.MapObjects
{
    public class Dwelling
    {
        public int Owner { get; set; }
    }

    public class Mine
    {
        public int Owner { get; set; }
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }
    }

    public class Creeps
    {
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }
    }

    public class Wolves
    {
        public Army Army { get; set; }
    }

    public class ResourcePile
    {
        public Treasure Treasure { get; set; }
    }

    public static class Interaction
    {
        public static void Make(Player player, object mapObject)
        {
            //Здесь и далее используйте следующий сокращенный синтаксис преобразования типа
            if (mapObject is Dwelling dwellingObj)
            {
                //Он более короткий и позволяет не производить множественных преобразований таких, как
                //((Dwelling)mapObject).Owner = player.Id;

                //а сразу обращаться к объекту, если он является каким-то классом.
                dwellingObj.Owner = player.Id;

                return;
            }

            //Перед выполнение задания потренируйтесь и замените неправильное использование is ниже
            if (mapObject is Mine)
            {
                if (player.CanBeat(((Mine)mapObject).Army))
                {
                    ((Mine)mapObject).Owner = player.Id;
                    player.Consume(((Mine)mapObject).Treasure);
                }
                else player.Die();
                return;
            }

            if (mapObject is Creeps)
            {
                if (player.CanBeat(((Creeps)mapObject).Army))
                    player.Consume(((Creeps)mapObject).Treasure);
                else
                    player.Die();
                return;
            }

            if (mapObject is ResourcePile)
            {
                player.Consume(((ResourcePile)mapObject).Treasure);
                return;
            }

            if (mapObject is Wolves)
            {
                if (!player.CanBeat(((Wolves)mapObject).Army))
                    player.Die();
            }
        }
    }
}
