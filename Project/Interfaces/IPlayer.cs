using System.Collections.Generic;

namespace CastleGrimtol.Game
{
    public interface IPlayer
    {
        int Health { get; set; }
        List<Item> Inventory { get; set; }

    }
}