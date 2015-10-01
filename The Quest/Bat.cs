using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Quest
{
    class Bat: Enemy
    {
        public Bat(Game game, Point location): base(game, location, 8)
        { }

        public override void Move(Random random)
        {
            if (random.Next(1, 2) == 1)
            {
                location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            }
            else
            {
                location = Move((Direction)random.Next(1, 4), game.Boundaries);
            }
            if (NearPlayer())
            {
                game.HitPlayer(2, random);
            }
        }
    }
}
