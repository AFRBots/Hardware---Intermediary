using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Net.WebSockets;

namespace Hardware___Intermetiary.CarClasses
{
    class Car
    {
        public Sensor proximity;
        public Sensor direction;
        public SerialPort Port;
        public string Name;
        ClientWebSocket _ws;
        string test = "";
        public Car(string name,string portName, ClientWebSocket ws)
        {
            //Port = new SerialPort(portName, 9600);
            //Port.Open();
            Name = name;
            proximity = new Sensor("proximity");
            direction = new Sensor("direction");
            _ws = ws;
            Task.Run(getCommandsAsync);
            //Thread t = new Thread(updateSensors);
            //t.IsBackground = true;
            //t.Start();

        }
        public void moveForward()
        {
            Port.Write("<1>");
        }
        public void moveBack()
        {
            Port.Write("<2>");
        }
        public void moveRight()
        {
            Port.Write("<3>");
        }
        public void moveLeft()
        {
            Port.Write("<4>");
        }
        public void moveStop()
        {
            Port.Write("<0>");
        }
        private async void updateSensorsAsync()
        {
            await Task.Run(updateSensors);
        }
        public void updateSensors()
        {
            while (true)
            {
                char[] recievedChar = new char[32];
                bool inProgress = false;
                int index = 0;
                //Sensor reading = new Sensor("reading");
                char readChar;

                while (Port.BytesToRead > 0 || inProgress == true)
                {
                    readChar = Convert.ToChar(Port.ReadChar());
                    if (readChar == '{')
                    {
                        inProgress = true;
                        //reading = proximity;
                    }
                    else if (inProgress)
                    {
                        if (readChar != '}')
                        {
                            recievedChar[index] = readChar;
                            index++;
                            if (index >= 32) index = 31;
                        }
                        else
                        {
                            recievedChar[index] = '\0';
                            inProgress = false;
                            index = 0;
                            string s = new string(recievedChar);
                            string[] results = s.Split(',');
                            int.TryParse(results[0], out proximity.value);
                            int.TryParse(results[1], out direction.value);
                        }
                    }
                }
            }
        }
        private async Task getCommandsAsync()
        {
            byte[] buffer = new byte[1024];
            while (true)
            {
                await _ws.ReceiveAsync(buffer, CancellationToken.None);
                var response = System.Text.Encoding.UTF8.GetString(buffer);
                new Action(()=>Port.Write($"<{response}>")).Invoke();
                
            }
        }

        
    }
}
