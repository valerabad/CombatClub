using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatClub
{
    class ComputerPlayer : Player
    {
        new public static int Hp;
        private Random rndm = new Random();
        private int numberBodyPart;
        public ComputerPlayer() { }
        public ComputerPlayer(string name) 
             : base (name)
        {            
            numberBodyPart = rndm.Next(3);
            Blocked = (BodyParts)numberBodyPart;
            ComputerPlayer.Hp = 100;
        }

        
        public void GetHit()
        {
            numberBodyPart = rndm.Next(3);
            if (((BodyParts)numberBodyPart == this.Blocked))
                BlockEvent(new PlayerEventArgs(this.Name, Player.Hp));
            else
                if ((BodyParts)numberBodyPart != this.Blocked)
                {
                    if (Player.Hp > 0)
                    {
                        Player.Hp--;
                        WoundEvent(new PlayerEventArgs(this.Name, Player.Hp));
                    }
                    else DeathEvent(new PlayerEventArgs(this.Name, Player.Hp));
                }
        }

        // рандомный выбор защищаемой части тела
        public void SetBlock()
        {
            numberBodyPart = rndm.Next(3);
            Blocked = (BodyParts)numberBodyPart;
        }
    }
}
