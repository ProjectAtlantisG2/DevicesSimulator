using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices_Generator
{
    public class Arduino
    {
        private bool IsConnected = false;
        public string[] ports;
        public SerialPort port;

        public void GetAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
            Console.WriteLine("Serial Port : ");
            foreach (var p in ports)
                Console.WriteLine("\t" + p);
        }

        public void ConnectToArduino()
        {
            Console.WriteLine("Searching For Available Serial Port.....");
            GetAvailableComPorts();
            IsConnected = true;
            port = new SerialPort(ports[0], 9600, Parity.None, 8, StopBits.One);
            port.DataReceived += new SerialDataReceivedEventHandler(dataReceivedHandler);
            port.Open();
            Console.WriteLine("Port {0} is Open", ports[0]);
            port.Write("#STAR\n");
        }

        private void dataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string indata = port.ReadLine();
            //Console.WriteLine(indata);
        }
        
    }
}
