using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Hardware___Intermetiary
{
    public partial class PortForm : Form
    {
        public string _Port;
        public PortForm()
        {
            InitializeComponent();
        }

        private void PortForm_Load(object sender, EventArgs e)
        {
            string[] Ports = SerialPort.GetPortNames();


            foreach (string s in Ports)
            {
                lbxPorts.Items.Add(s);
            }
        }

        private void btnSetPort_Click(object sender, EventArgs e)
        {
            _Port = lbxPorts.SelectedItem.ToString();
            DialogResult = DialogResult.OK;
        }

    }
}
