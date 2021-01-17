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


namespace Hardware___Intermetiary
{
    public partial class Form1 : Form
    {
        Car _Car;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PortForm p = new PortForm();
            if (p.ShowDialog() == DialogResult.OK)
            {
                _Car = new Car("Car1", p._Port);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Car.moveForward();
        }
    }
}
