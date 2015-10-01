using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Quest
{
    abstract class Weapon: Mover
    {
        
        private bool pickedUp;
        public bool PickedUp { get { return pickedUp; } }


        public Weapon(Game game, Point location)
            : base(game, location)
        {
            pickedUp = false;
        }

        public void PickUpWeapon() { pickedUp = true; }
        public abstract string Name { get; }
        public abstract void Attack(Direction direction, Random random);

        protected bool DamageEnemy(Direction direction, int radius, int damage, Random random) 
        {
            Point target = game.PlayerLocation;
            for (int distance = 0; distance < radius; distance++) 
           {
            foreach (Enemy enemy in game.Enemies) 
            {
                if (Nearby(target, radius)) 
                {
                    enemy.Hit(damage, random);
                    return true;
                }
            }
            target = Move(direction, game.Boundaries);
            }
        return false;
        }

        protected Direction ClockWiseDirection(Direction direction)
        {
            Direction clockWiseDirection = direction;

            switch (direction)
            {
                case Direction.Up:
                    clockWiseDirection = Direction.Right;
                    break;
                case Direction.Right:
                    clockWiseDirection = Direction.Down;
                    break;
                case Direction.Down:
                    clockWiseDirection = Direction.Left;
                    break;
                case Direction.Left:
                    clockWiseDirection = Direction.Up;
                    break;
            }

            return clockWiseDirection;
        }

        protected Direction CounterClockWiseDirection(Direction direction)
        {
            Direction counterClockWiseDirection = direction;

            switch (direction)
            {
                case Direction.Up:
                    counterClockWiseDirection = Direction.Left;
                    break;
                case Direction.Right:
                    counterClockWiseDirection = Direction.Up;
                    break;
                case Direction.Down:
                    counterClockWiseDirection = Direction.Right;
                    break;
                case Direction.Left:
                    counterClockWiseDirection = Direction.Down;
                    break;
            }

            return counterClockWiseDirection;
        }
    }
}
