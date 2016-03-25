using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatClub
{     
    enum BodyParts {head, body, legs};

    public class PlayerEventArgs : EventArgs
    {
        public string name { get; set; }
        public int Hp { get; set; }
        public PlayerEventArgs(string name, int hp)
        {
            this.name = name;
            this.Hp = hp;
        }
    }

    class Player
    {
        

        public delegate void Del(object sender, PlayerEventArgs args);
        //public delegate void Del(object sender, PlayerEventArgs args);
        const int startHp = 10;

        public string Name { get; set; }
        public BodyParts Blocked { get; set; }
        public static int Hp {get; set;}      
        int Damage { get; set; }
        public bool Attacker { get; set; }

        public Player() { }

        public Player(string name)
        {
            this.Name = name;
            Player.Hp = startHp;
            //this.Blocked = BodyParts.body;
            this.Attacker = true;
        }

        public void BlockEvent(PlayerEventArgs e)
        {
            if (Block != null)
                Block(this,e);
        }

        public void WoundEvent(PlayerEventArgs e)
        {
            if (Wound != null)
                Wound(this, e);
        }

        public void DeathEvent(PlayerEventArgs e)
        {
            if (Death != null)
               Death(this, e);
        }

        public bool CompareParts(Player player, ComputerPlayer compPlayer)
        {
            return player.Blocked == compPlayer.Blocked;
        }

        public void GetHit(BodyParts bodyPartAttack)
        {
            if ((bodyPartAttack == this.Blocked) && (Block != null))
                BlockEvent(new PlayerEventArgs(this.Name, Player.Hp));
            else
                if (bodyPartAttack != this.Blocked)
                {
                    if (ComputerPlayer.Hp > 0)
                    {
                        ComputerPlayer.Hp--;
                        WoundEvent(new PlayerEventArgs(this.Name, ComputerPlayer.Hp));
                    }
                    else DeathEvent(new PlayerEventArgs(this.Name, ComputerPlayer.Hp));
                }
        }

        public void SetBlock(BodyParts bodyPartBlock)
        {
            Blocked = bodyPartBlock;            
        }

        // должны возвращаять имена игрков и текущие HP
        public event Del Block;
        public event Del Wound;
        public event Del Death;

        //public static int Handler(string name)
        //{ return 0; }
        

    }
}
