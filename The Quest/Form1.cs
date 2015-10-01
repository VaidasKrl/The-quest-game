using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Quest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private Game game;
        private Random random = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(new Rectangle(78, 57, 420, 155));
            game.NewLevel(random);
            UpdateCharacters();
        }


        public void UpdateCharacters()
        {
            PlayerPicture.Location = game.PlayerLocation;
            playerHitPoints.Text = game.PlayerHitPoints.ToString();
            PlayerPicture.Visible = true;

            batPicture.Visible = false;
            ghostPicture.Visible = false;
            ghoulPicture.Visible = false;
            int enemiesShown = 0;

            foreach (Enemy enemy in game.Enemies)
            {
                if(enemy is Bat)
                {
                    batPicture.Location = enemy.Location;
                    batHitPoints.Text = enemy.HitPoints.ToString();
                    if(enemy.HitPoints > 0)
                    {
                        batPicture.Visible = true;
                        enemiesShown++;
                    }
                }
                if(enemy is Ghost)
                {
                    ghostPicture.Location = enemy.Location;
                    ghostHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        ghostPicture.Visible = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghoul)
                {
                    ghoulPicture.Location = enemy.Location;
                    ghoulHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        ghoulPicture.Visible = true;
                        enemiesShown++;
                    }
                }
                if(enemy is Bat && enemy.Dead)
                {
                    batPicture.Visible = false;
                }
                if(enemy is Ghost && enemy.Dead)
                {
                    ghostPicture.Visible = false;
                }
                if(enemy is Ghoul && enemy.Dead)
                {
                    ghoulPicture.Visible = false;
                }
            }
            swordPicture.Visible = false;
            bowPicture.Visible = false;
            macePicture.Visible = false;
            redPotionPicture.Visible = false;
            bluePotionPicture.Visible = false;
            Control weaponControl = null;
            switch(game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = swordPicture;
                    break;
                case "Bow":
                    weaponControl = bowPicture;
                    break;
                case "Mace":
                    weaponControl = macePicture;
                    break;
                case "BluePotion":
                    weaponControl = bluePotionPicture;
                    break;
                case "RedPotion":
                    weaponControl = redPotionPicture;
                    break;
            }
            weaponControl.Visible = true;

            if(game.CheckPlayerInventory("Sword"))
            {
                swordPicture.Visible = true;
            }
            if (game.CheckPlayerInventory("Bow"))
            {
                bowPicture.Visible = true;
            }
            if (game.CheckPlayerInventory("Mace"))
            {
                macePicture.Visible = true;
            }
            if (game.CheckPlayerInventory("BluePotion"))
            {
                bluePotionPicture.Visible = true;
            }
            if (game.CheckPlayerInventory("redPotion"))
            {
                redPotionPicture.Visible = true;
            }

            weaponControl.Location = game.WeaponInRoom.Location;
            if (game.WeaponInRoom.PickedUp) 
            {
                weaponControl.Visible = false;
            } 
            else 
            {
                weaponControl.Visible = true;
            }
            if (game.PlayerHitPoints <= 0) 
            {
                MessageBox.Show("You died");
                Application.Exit();
            }
            if (enemiesShown < 1) 
            {
                MessageBox.Show("You have defeated the enemies on this level");
                game.NewLevel(random);
                UpdateCharacters();
            }
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void MoveRightButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void MoveLeftButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void AttackUpButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Up, random);
            UpdateCharacters();
        }

        private void AttackRightButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
            UpdateCharacters();
        }

        private void AttackDownButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }

        private void AttackLeftButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }

        private void swordInventoryPicture_Click(object sender, EventArgs e)
        {
            if(game.CheckPlayerInventory("Sword"))
            {
                game.Equip("Sword");
                swordInventoryPicture.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void bluePotionInventoryPicture_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("BluePotion"))
            {
                game.Equip("BluePotion");
                bluePotionInventoryPicture.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void redPotionInventoryPicture_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("RedPotion"))
            {
                game.Equip("RedPotion");
                redPotionInventoryPicture.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void bowInventoryPicture_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Bow"))
            {
                game.Equip("Bow");
                bowInventoryPicture.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void maceInventoryPicture_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Mace"))
            {
                game.Equip("Mace");
                maceInventoryPicture.BorderStyle = BorderStyle.FixedSingle;
            }
        }
    }
}
