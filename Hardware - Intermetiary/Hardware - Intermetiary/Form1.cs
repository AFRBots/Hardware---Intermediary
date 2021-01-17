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
using System.Threading;

namespace Hardware___Intermetiary
{
    public partial class Form1 : Form
    {
        Car _Car;
        ClientWebSocket ws;

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

        private async void Form1_Load(object sender, EventArgs e)
        {
            PortForm p = new PortForm();
            if (p.ShowDialog() == DialogResult.OK)
            {
                
                ws = new ClientWebSocket();
                await ws.ConnectAsync(new Uri("wss://bots.rafee.me"), CancellationToken.None);
                _Car = new Car("Car1", p._Port);
                getCommands();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[1024];
            await ws.ReceiveAsync(buffer, CancellationToken.None);
            var response = System.Text.Encoding.UTF8.GetString(buffer);
            _Car.Port.Write($"<{response}>");
            Invoke(new Action(() => lblDirection.Text = response));
        }
        private async Task getCommands()
        {
            while (true)
            {
                byte[] buffer = new byte[1024];
                await ws.ReceiveAsync(buffer, CancellationToken.None);
                var response = System.Text.Encoding.UTF8.GetString(buffer);
                _Car.Port.Write($"<{response}>");
                Invoke(new Action(() => lblDirection.Text = response));
            }
        }
    }
}
