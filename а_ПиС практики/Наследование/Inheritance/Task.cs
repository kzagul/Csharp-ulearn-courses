using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.MapObjects
{
    public interface IOwnerable
    {
        int Owner { get; set; }
    }

    public interface IObjectable
    {
        void InteractionMethod(Player player);
    }

    public interface IArmyable
    {
        Army Army { get; set; }
    }

    public interface ITreasureable
    {
        Treasure Treasure { get; set; }
    }

    public class Dwelling : IObjectable
    {
        public int Owner { get; set; }

        public void InteractionMethod(Player player) => Owner = player.Id;
    }

    public class Mine : IObjectable, IOwnerable, IArmyable
    {
        public int Owner { get; set; }
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }

        public void InteractionMethod(Player player)
        {
            if (!player.CanBeat(Army))
                player.Die();
            else
            {
                Owner = player.Id;
                player.Consume(Treasure);
            }
        }
    }

    public class Creeps : IObjectable, IArmyable
    {
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }

        public void InteractionMethod(Player player)
        {
            if (!player.CanBeat(Army))
                player.Die();
            else
                player.Consume(Treasure);
        }
    }

    public class Wolves : IObjectable
    {
        public Army Army { get; set; }

        public void InteractionMethod(Player player)
        {
            if (player.CanBeat(Army))
                return;
            player.Die();
        }
    }

    public class ResourcePile : IObjectable
    {
        public Treasure Treasure { get; set; }

        public void InteractionMethod(Player player) => player.Consume(Treasure);
    }

    public static class Interaction
    {
        public static void Make(Player player, IObjectable mapObject) => mapObject.InteractionMethod(player);
    }
}
