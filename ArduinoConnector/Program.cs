using System;
using System.IO.Ports;
using System.Threading;

namespace ArduinoConnector
{
    public class Program
    {
        private static string[] ports;
        public static SerialPort port;

        private static void Main(string[] args)
        {
            Console.WriteLine("############################################\n");
            Console.WriteLine("             Arduino Connector \n");
            Console.WriteLine("############################################\n");

            Console.WriteLine("With this panel you can :");
            Console.WriteLine("\t - Type ON or OFF to switch power on the LED");
            Console.WriteLine("\t - Type READ to start listening the Device");
            Console.WriteLine("\t - Type some text to display on the LCD screen");
            Console.WriteLine("\n");
            //Service.ProcessData("T25");

            while (true)
            {

                Console.Write("Command : ");
                var text = Console.ReadLine();
                Console.WriteLine("Connection to Device....");
                if (!ConnectToArduino())
                {
                    Console.WriteLine("Error : Device cannot connect.....");
                    continue;
                }
                Console.WriteLine("Device is connected.....");
                if (text == "OFF" || text == "ON")
                {
                    port.Write("#LED0" + text + "\n");
                }
                else if (text == "READ")
                {
                    Console.WriteLine("Device is sending data....\n");
                    Console.WriteLine("Press Enter to End the Data Stream....");
                    Console.ReadLine();
                }
                else
                {
                    port.Write("#TEXT" + text + "\n");
                }

                Console.WriteLine("Disconnection of the Device....");
                port.Close();
                Console.WriteLine("Device is disconnected.....\n");
            }

        }

        /// <summary>
        /// Send a text command to the Arduino. See Github for more info on the command.
        /// </summary>
        /// <param name="text">Text to send</param>
        /// <returns>Error Handling</returns>
        public static bool SendCommandToDevice(string text)
        {
            Console.WriteLine("Connection to Device....");
            if (!ConnectToArduino()) return false;
            Console.WriteLine("Device is connected.....");
            port.Write(text);
            Thread.Sleep(800);
            Console.WriteLine("Disconnection of the Device....");
            port.Close();
            Console.WriteLine("Device is disconnected.....\n");
            return true;
        }

        /// <summary>
        /// Get the name of each plug in Serial Port 
        /// </summary>
        /// <returns>Error Handling</returns>
        private static bool GetAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
            Console.WriteLine("Serial Port : ");
            foreach (var p in ports)
                Console.WriteLine("\t" + p);
            if (ports.Length == 0) return false;
            port = new SerialPort(ports[0], 9600, Parity.None, 8, StopBits.One);
            return true;
        }

        /// <summary>
        /// Open a connection between the Gateway and the Arduino
        /// </summary>
        /// <returns>Error Handling</returns>
        public static bool ConnectToArduino()
        {
            Console.WriteLine("Searching For Available Serial Port.....");
            if (!GetAvailableComPorts())    return false;
            Console.WriteLine("");
            port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            try
            {
                port.Open();
            }
            catch
            {
                return false;
            }
            Console.WriteLine("Port {0} is Open", ports[0]);
            port.Write("#STAR\n");
            return true;
        }

        /// <summary>
        /// Event that trigger every time the SerialPort receive a data drom the Arduino
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string indata = port.ReadLine();
            Service.ProcessData(indata);
            //Console.WriteLine(indata);
        }
    }
}
