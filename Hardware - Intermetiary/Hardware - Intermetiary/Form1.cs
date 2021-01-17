using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hardware___Intermetiary.CarClasses;
using System.Net.WebSockets;


namespace Hardware___Intermetiary
{
    public partial class Form1 : Form
    {
        Car _Car;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            _Car.moveStop();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W)
            {
                _Car.moveForward();
            }
            if (e.KeyCode == Keys.S)
            {
                _Car.moveBack();
            }
            if (e.KeyCode == Keys.A)
            {
                _Car.moveLeft();
            }
            if (e.KeyCode == Keys.D)
            {
                _Car.moveRight();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PortForm p = new PortForm();
            if (p.ShowDialog() == DialogResult.OK)
            {
                _Car = new Car("Car1", p._Port);
            }
        }

        //Moves UP
        private void button1_Click(object sender, EventArgs e)
        {
            _Car.moveForward();
        }

        //Moves DOWN
        private void button2_Click(object sender, EventArgs e)
        {
            _Car.moveBack();
        }

        //Moves Left
        private void button3_Click(object sender, EventArgs e)
        {
            _Car.moveLeft();
        }

        //Moves Right
        private void button4_Click(object sender, EventArgs e)
        {
            _Car.moveRight();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            lblDirection.Text = _Car.direction.value.ToString();
            lblProximity.Text = _Car.proximity.value.ToString();
        }
    }
}
