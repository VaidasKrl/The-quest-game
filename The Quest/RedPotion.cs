using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Quest
{
    class RedPotion: Weapon, IPotion
    {
         public RedPotion(Game game, Point location): base(game, location) { Used = false; }

        public bool Used { get; private set; }


        public override string Name
        {
            get { return "RedPotion"; }
        }

        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(10, random);
            Used = true;
        }
    }
}
