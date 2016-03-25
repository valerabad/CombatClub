using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CombatClub
{
    public partial class Form1 : Form
    {      
        Game game;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // использовать сендер
            buttonHead.Enabled = true;
            buttonBody.Enabled = true;
            buttonLegs.Enabled = true;

            game = new Game("Валерий", "Компьютер", 
                listBox1, 
                labelPlayer, labelCompPlayer,
                labelPlayerHP, labelCompPlayerHP,
                buttonHead, buttonBody, buttonLegs);

//            game.form1 = this.Form1;
            game.player.Block += new Player.Del(game.EventMessage1);
            game.player.Wound += new Player.Del(game.EventMessage2);
            game.player.Death += new Player.Del(game.EventMessage3);

            //game.computerPlayer.Block += new ComputerPlayer.Del(game.EventMessage1);
            //game.computerPlayer.Wound += new ComputerPlayer.Del(game.EventMessage2);
            //game.computerPlayer.Death += new ComputerPlayer.Del(game.EventMessage3);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {           
            buttonHead.Enabled = false;
            buttonBody.Enabled = false;
            buttonLegs.Enabled = false;
        }
        
        private void buttonHead_Click(object sender, EventArgs e)
        {
            game.GameProc(BodyParts.head);           
        }

        private void buttonBody_Click(object sender, EventArgs e)
        {
            game.GameProc(BodyParts.body);
        }

        private void buttonLegs_Click(object sender, EventArgs e)
        {
            game.GameProc(BodyParts.legs);
        }        
    }
}
