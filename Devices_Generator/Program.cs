using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices_Generator
{
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("############################################");
            Arduino arduino = new Arduino();
            Console.WriteLine("      Connection to Device Initialized \n");
            arduino.ConnectToArduino();
            Console.WriteLine("Device is listening.....");
            while (true)
            {
                Console.Write("\nCommand : ");
                var text = Console.ReadLine();
                if(text == "OFF" || text == "ON")
                {
                    arduino.port.Write("#LED0" + text + "\n");
                }
                else
                {
                    arduino.port.Write("#TEXT" + text + "\n");
                }
            }


            
        }

        private List<Device> CreatePoolDevice()
        {
            return null;
        }

    }
}
