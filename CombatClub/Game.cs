using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CombatClub
{
    class Game
    {
        public Form form1;
        public Player player;
        public ComputerPlayer computerPlayer;
        public ListBox lstBox { get; set; }
        public Label labelPlayerName { get; set; }
        public Label labelCompName { get; set; }
        public Label labelPlayerHp { get; set; }
        public Label labelCompHp { get; set; }
        public Button b1 { get; set; }
        public Button b2 { get; set; }
        public Button b3 { get; set; }



        public Game(string playerName, string compName,
            ListBox listBox,
            Label labelPlayerName, Label labelCompName,
            Label labelPlayerHp, Label labelCompHp,
            Button b1, Button b2, Button b3)
        {
                     
            player = new Player(playerName);
            computerPlayer = new ComputerPlayer(compName);
            this.lstBox = listBox;
            this.labelPlayerName = labelPlayerName;
            this.labelPlayerHp = labelPlayerHp;
            this.labelCompName = labelCompName;
            this.labelCompHp = labelCompHp;
            this.b1 = b1;
            this.b2 = b2;
            this.b3 = b3;

            this.labelPlayerName.Text = this.player.Name;
            this.labelPlayerHp.Text = Convert.ToString(Player.Hp);
            this.labelCompName.Text = this.computerPlayer.Name;
            this.labelCompHp.Text = Convert.ToString(ComputerPlayer.Hp);
            this.b1.Text = "Head attack";
            this.b2.Text = "Body attack";
            this.b3.Text = "Legs attack"; 
        }

        public void PrintToLabel(object sender)
        {
            string typePlayer = sender.GetType().ToString();
            if (typePlayer.Equals("CombatClub.Player"))
            {
                //labelPlayerName.Text = player.Name; // не обязательно
                labelCompHp.Text = Convert.ToString(ComputerPlayer.Hp);                
            }
            else
                if (typePlayer.Equals("CombatClub.ComputerPlayer"))
                {                    
                    labelPlayerHp.Text = Convert.ToString(Player.Hp);
                }
        }

        public void EventMessage1(object sender, PlayerEventArgs args)
        {
            lstBox.Items.Add(args.name+ ": ваш удар заблокирован. ");
            PrintToLabel(sender);            
        }

        public void EventMessage2(object sender, PlayerEventArgs args)
        {
            lstBox.Items.Add(args.name+ ": удар успешен");
            PrintToLabel(sender);            
        }

        public void EventMessage3(object sender, PlayerEventArgs args)
        {
            lstBox.Items.Add(args.name+"ваш игрок убит :(");
            PrintToLabel(sender);

        }

        public void GameProc(BodyParts bodyPart)
        {
            if (player.Attacker)
            {
                computerPlayer.SetBlock();
                player.GetHit(BodyParts.head);
                player.Attacker = false;
                b1.Text = "Block head";
                b2.Text = "Block body";
                b3.Text = "Block legs";
            }
            else
            {
                player.SetBlock(bodyPart);
                computerPlayer.GetHit();
                player.Attacker = true;
                b1.Text = "Head attack";
                b2.Text = "Body attack";
                b3.Text = "Legs attack";
            }
        }
            

    }
}
