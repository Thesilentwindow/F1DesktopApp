using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Sockets;
using System.Net;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace F1DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int listeningPort = 20777; //designated port from F1 2021
        //private readonly string ipAddress = "127.0.0.1";
        private string str_x = "test";
        private string str_y = "test";
        private uint SpeedValue; //Ingame speed value

        struct CarTelemetryData
        {
            uint m_speed;                    // Speed of car in kilometres per hour
            float m_throttle;                 // Amount of throttle applied (0.0 to 1.0)
            float m_steer;                    // Steering (-1.0 (full lock left) to 1.0 (full lock right))
            float m_brake;                    // Amount of brake applied (0.0 to 1.0)
            //uint8 m_clutch;                   // Amount of clutch applied (0 to 100)
            //int8 m_gear;                     // Gear selected (1-8, N=0, R=-1)
            //uint16 m_engineRPM;                // Engine RPM
            //uint8 m_drs;                      // 0 = off, 1 = on
            //uint8 m_revLightsPercent;         // Rev lights indicator (percentage)
            //uint16 m_revLightsBitValue;        // Rev lights (bit 0 = leftmost LED, bit 14 = rightmost LED)
            //uint16 m_brakesTemperature[4];     // Brakes temperature (celsius)
            //uint8 m_tyresSurfaceTemperature[4]; // Tyres surface temperature (celsius)
            //uint8 m_tyresInnerTemperature[4]; // Tyres inner temperature (celsius)
            //uint16 m_engineTemperature;        // Engine temperature (celsius)
            //float m_tyresPressure[4];         // Tyres pressure (PSI)
            //uint8 m_surfaceType[4];           // Driving surface, see appendices
        };

        public MainWindow()
        {
            InitializeComponent();

            SpeedValue = 160;
            Angular_Gauge1.Value = SpeedValue;

            //Starting Udpclient


        }

        private uint speed()
        {
            UdpClient listener = new UdpClient();
            IPEndPoint group = new IPEndPoint(IPAddress.Any, listeningPort);

            try
            {
                while (true)
                {
                    byte[] bytes = listener.Receive(ref group);
                    Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ChangeValueOnClick(object sender, RoutedEventArgs e)
        {
            //SpeedValue = new Random().Next(50, 250);
            //Angular_Gauge1.Value = SpeedValue;
            //lbl_test1.Content = SpeedValue.ToString();
        }

    }

}
