using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

namespace SMTPRouter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region "privatedata"

        private static TcpListener listener = null;
        #endregion
        int task;
        IPAddress listenAddr;
        int listenPort;

        public ReceiverSetting settingClass;

        public MainWindow()
        {


            InitializeComponent();

            settingClass = new ReceiverSetting();

            listenAddr = IPAddress.Loopback;
            listenPort = 25;



            this.DataContext = this;


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            button1.IsEnabled = false;
            button2.IsEnabled = true;
            button3.IsEnabled = true;
            if (null != listener)
            {
                try { listener.Stop(); }
                catch { }
            }
        }

        private async void button2_Click(object sender, RoutedEventArgs e)
        {

            button1.IsEnabled = true;
            button2.IsEnabled = false;
            button3.IsEnabled = false;


            // load the config
            settingClass.loadConfig();

            // tell we're starting up and, if verbose, dump config parameters

            AppGlobals.writeConsole("{0} {1} starting up (NET {2})", AppGlobals.appName, AppGlobals.appVersion, AppGlobals.appRuntime);
            if (AppGlobals.logVerbose)
                settingClass.dumpSettings();

            // setup the listening IP:port
            listenAddr = AppGlobals.listenIP;
            listenPort = AppGlobals.listenPort;


            // try starting the listener
            try
            {
                listener = new TcpListener(listenAddr, listenPort);
                listener.Start();
            }
            catch (Exception ex)
            {
                AppGlobals.writeConsole("Listener::Error: " + ex.Message);

            }

            // tell we're ready to accept connections
            AppGlobals.writeConsole("Listening for connections on {0}:{1}", listenAddr, listenPort);

            // run until interrupted (Ctrl-C in our case)
            await Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                         // wait for an incoming connection, accept it and spawn a thread to handle it
                         SMTPsession handler = new SMTPsession(listener.AcceptTcpClient());
                        Thread thread = new System.Threading.Thread(new ThreadStart(handler.handleSession));

                        thread.Start();

                    }
                    catch (Exception ex)
                    {
                         // we got an error

                         AppGlobals.writeConsole("Handler::Error: " + ex.Message);
                         //timeToStop = true;
                         break;
                    }
                }


            });

            // finalize
            if (null != listener)
            {
                try { listener.Stop(); }
                catch { }
            }

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            settingClass.Show();
        }

        public static async Task Method1()
        {
        }
    }
}
