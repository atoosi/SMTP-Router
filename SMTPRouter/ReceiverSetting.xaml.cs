using System;
using System.Collections.Generic;
using System.IO;
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

namespace SMTPRouter
{
    /// <summary>
    /// Interaction logic for ReceiverSetting.xaml
    /// </summary>
    /// 

    public partial class ReceiverSetting : Window
    {
    


        public ReceiverSetting()
        {
            InitializeComponent();

        }


        #region "settings"
        // loads/parses the config values
        public void loadConfig()
        {
            // listen address
            IPAddress listenIP = IPAddress.Loopback;
            string listenAddress = ListenAddresstextBox.Text;
            if (String.IsNullOrEmpty(listenAddress)) listenAddress = "127.0.0.1";
            if (false == IPAddress.TryParse(listenAddress, out listenIP))
            {
                listenAddress = "127.0.0.1";
                listenIP = IPAddress.Loopback;
            }

            // listen port
            int listenPort = int.Parse(ListenPorttextBox.Text);
            if ((listenPort < 1) || (listenPort > 65535))
                listenPort = 25;

            // receive timeout
            int receiveTimeout = int.Parse(ReceiveTimeOuttextBox.Text);
            if (receiveTimeout < 0)
                receiveTimeout = 0;

            // hostname (for the banner)
            string hostName = HostNametextBox.Text;
            if (string.IsNullOrEmpty(hostName))
                hostName = System.Net.Dns.GetHostEntry("").HostName;

            // true=emits a "tempfail" when receiving the DATA command
            bool doTempFail =  DoTempFailcheckBox.IsChecked.GetValueOrDefault();

            // true=stores the email envelope and data into files
            bool storeData = StoreDatacheckBox.IsChecked.GetValueOrDefault();

            // max size for a given email message
            long storeSize = long.Parse(MaxDataSizetextBox.Text);
            if (storeSize < 0) storeSize = 0;

            // max # of messages for a session
            int maxMsgs = int.Parse(MaxMessagestextBox.Text);
            if (maxMsgs < 1) maxMsgs = 10;

            // path for the email storage
            string storePath = StorePathtextBox.Text;
            if (String.IsNullOrEmpty(storePath))
                storePath = Path.GetTempPath();
            if (!storePath.EndsWith("\\"))
                storePath = storePath + "\\";

            // max # of parallel sessions, further requests will be rejected
            long maxSessions = long.Parse(MaxSessionstextBox.Text);
            if (maxSessions < 1) maxSessions = 16;

            // path for the log file
            string logPath = LogPathtextBox.Text;
            if (String.IsNullOrEmpty(logPath))
                logPath = Path.GetTempPath();
            if (!logPath.EndsWith("\\"))
                logPath = logPath + "\\";

            // verbose logging
            bool verboseLog = VerboseLoggingcheckBox.IsChecked.GetValueOrDefault();

            // early talker detection
            bool earlyTalk = DoEarlyTalkcheckBox.IsChecked.GetValueOrDefault();

            // DNS whitelist providers, empty to not perform the check
            string whiteLists = RWLproviderstextBox.Text;
            string[] RWL = null;
            if (!string.IsNullOrEmpty(whiteLists))
            {
                RWL = whiteLists.Split(',');
            }

            // DNS blacklist providers, empty to not perform the check
            string blackLists = RBLproviderstextBox.Text;
            string[] RBL = null;
            if (!string.IsNullOrEmpty(blackLists))
            {
                RBL = blackLists.Split(',');
            }

            // hardlimits for errors, noop etc..
            int maxErrors = int.Parse(MaxSmtpErrorstextBox.Text);
            if (maxErrors < 1) maxErrors = 5;
            int maxNoop = int.Parse(MaxSmtpNooptextBox.Text);
            if (maxNoop < 1) maxNoop = 7;
            int maxVrfy = int.Parse(MaxSmtpVrfytextBox.Text);
            if (maxVrfy < 1) maxVrfy = 10;
            int maxRcpt = int.Parse(MaxSmtpRcpttextBox.Text);
            if (maxRcpt < 1) maxRcpt = 100;

            // delays (tarpitting)
            int bannerDelay = int.Parse(BannerDelaytextBox.Text);
            if (bannerDelay < 0) bannerDelay = 0;
            int errorDelay = int.Parse(ErrorDelaytextBox.Text);
            if (errorDelay < 0) errorDelay = 0;

            // local domains and mailboxes
            List<string> domains = new List<string>();
            List<string> mailboxes = new List<string>();
            string fileName = LocalDomainstextBox.Text;
            if (!string.IsNullOrEmpty(fileName))
                domains = AppGlobals.loadFile(fileName);
            fileName = LocalMailBoxestextBox.Text;
            if (!string.IsNullOrEmpty(fileName))
                mailboxes = AppGlobals.loadFile(fileName);

            // set the global values
            AppGlobals.listenIP = listenIP;
            AppGlobals.listenAddress = listenAddress;
            AppGlobals.listenPort = listenPort;
            AppGlobals.receiveTimeout = receiveTimeout;
            AppGlobals.hostName = hostName.ToLower();
            AppGlobals.doTempFail = doTempFail;
            AppGlobals.storeData = storeData;
            AppGlobals.maxDataSize = storeSize;
            AppGlobals.maxMessages = maxMsgs;
            AppGlobals.storePath = storePath;
            AppGlobals.maxSessions = maxSessions;
            AppGlobals.logPath = logPath;
            AppGlobals.logVerbose = verboseLog;
            AppGlobals.earlyTalkers = earlyTalk;
            AppGlobals.whiteLists = RWL;
            AppGlobals.blackLists = RBL;
            AppGlobals.maxSmtpErr = maxErrors;
            AppGlobals.maxSmtpNoop = maxNoop;
            AppGlobals.maxSmtpVrfy = maxVrfy;
            AppGlobals.maxSmtpRcpt = maxRcpt;
            AppGlobals.bannerDelay = bannerDelay;
            AppGlobals.errorDelay = errorDelay;
            AppGlobals.LocalDomains = domains;
            AppGlobals.LocalMailBoxes = mailboxes;
        }

        // dump the current settings
        public void dumpSettings()
        {
            // base/network
            AppGlobals.writeConsole("Host name..................: {0}", AppGlobals.hostName);
            AppGlobals.writeConsole("listen IP..................: {0}", AppGlobals.listenAddress);
            AppGlobals.writeConsole("listen port................: {0}", AppGlobals.listenPort);
            AppGlobals.writeConsole("Receive timeout............: {0}", AppGlobals.receiveTimeout);
            // hardlimits
            AppGlobals.writeConsole("Max errors.................: {0}", AppGlobals.maxSmtpErr);
            AppGlobals.writeConsole("Max NOOP...................: {0}", AppGlobals.maxSmtpNoop);
            AppGlobals.writeConsole("Max VRFY/EXPN..............: {0}", AppGlobals.maxSmtpVrfy);
            AppGlobals.writeConsole("Max RCPT TO................: {0}", AppGlobals.maxSmtpRcpt);
            // sessions
            AppGlobals.writeConsole("Max messages per session...: {0}", AppGlobals.maxMessages);
            AppGlobals.writeConsole("Max parallel sessions......: {0}", AppGlobals.maxSessions);
            // messages
            AppGlobals.writeConsole("Store message data.........: {0}", AppGlobals.storeData);
            AppGlobals.writeConsole("Storage path...............: {0}", AppGlobals.storePath);
            AppGlobals.writeConsole("Max message size...........: {0}", AppGlobals.maxDataSize);
            // logs
            AppGlobals.writeConsole("Logfiles path..............: {0}", AppGlobals.logPath);
            AppGlobals.writeConsole("Verbose logging............: {0}", AppGlobals.logVerbose);
            // tarpitting
            AppGlobals.writeConsole("Initial banner delay.......: {0}", AppGlobals.bannerDelay);
            AppGlobals.writeConsole("Error delay................: {0}", AppGlobals.errorDelay);
            // filtering/rejecting
            AppGlobals.writeConsole("Do tempfail (4xx) on DATA..: {0}", AppGlobals.doTempFail);
            AppGlobals.writeConsole("Check for early talkers....: {0}", AppGlobals.earlyTalkers);
            // DNS filtering
            AppGlobals.writeConsole("DNS Whitelists.............: {0}", AppGlobals.whiteLists.Length);
            AppGlobals.writeConsole("DNS Blacklists.............: {0}", AppGlobals.blackLists.Length);
            // local domains/mailboxes
            AppGlobals.writeConsole("Local domains..............: {0}", AppGlobals.LocalDomains.Count);
            AppGlobals.writeConsole("Local mailboxes............: {0}", AppGlobals.LocalMailBoxes.Count);
        }


        public void dumpSettingsLive()
        {
            // base/network
              AppGlobals.writeSettingUI("Host name..................: {0}",  AppGlobals.hostName);
              AppGlobals.writeSettingUI("listen IP..................: {0}",  AppGlobals.listenAddress);
              AppGlobals.writeSettingUI( "listen port................: {0}", AppGlobals.listenPort);
              AppGlobals.writeSettingUI( "Receive timeout............: {0}", AppGlobals.receiveTimeout);
            // hardlimits
              AppGlobals.writeSettingUI( "Max errors.................: {0}", AppGlobals.maxSmtpErr);
              AppGlobals.writeSettingUI( "Max NOOP...................: {0}", AppGlobals.maxSmtpNoop);
              AppGlobals.writeSettingUI( "Max VRFY/EXPN..............: {0}", AppGlobals.maxSmtpVrfy);
              AppGlobals.writeSettingUI( "Max RCPT TO................: {0}", AppGlobals.maxSmtpRcpt);
            // sessions
              AppGlobals.writeSettingUI( "Max messages per session...: {0}", AppGlobals.maxMessages);
              AppGlobals.writeSettingUI( "Max parallel sessions......: {0}", AppGlobals.maxSessions);
            // messages
              AppGlobals.writeSettingUI( "Store message data.........: {0}", AppGlobals.storeData);
              AppGlobals.writeSettingUI( "Storage path...............: {0}", AppGlobals.storePath);
              AppGlobals.writeSettingUI( "Max message size...........: {0}", AppGlobals.maxDataSize);
            // logs
              AppGlobals.writeSettingUI( "Logfiles path..............: {0}", AppGlobals.logPath);
              AppGlobals.writeSettingUI( "Verbose logging............: {0}", AppGlobals.logVerbose);
            // tarpitting
              AppGlobals.writeSettingUI( "Initial banner delay.......: {0}", AppGlobals.bannerDelay);
              AppGlobals.writeSettingUI( "Error delay................: {0}", AppGlobals.errorDelay);
            // filtering/rejecting
              AppGlobals.writeSettingUI( "Do tempfail (4xx) on DATA..: {0}", AppGlobals.doTempFail);
              AppGlobals.writeSettingUI( "Check for early talkers....: {0}", AppGlobals.earlyTalkers);
            // DNS filtering
              AppGlobals.writeSettingUI( "DNS Whitelists.............: {0}",AppGlobals.whiteLists!=null? AppGlobals.whiteLists.Length:0);
              AppGlobals.writeSettingUI( "DNS Blacklists.............: {0}", AppGlobals.blackLists!=null?AppGlobals.blackLists.Length:0);
            // local domains/mailboxes
              AppGlobals.writeSettingUI( "Local domains..............: {0}", AppGlobals.LocalDomains.Count);
              AppGlobals.writeSettingUI( "Local mailboxes............: {0}", AppGlobals.LocalMailBoxes.Count);
          
        }





        #endregion



        private void okbutton_Click(object sender, RoutedEventArgs e)
        {
            loadConfig();
            this.Hide();

        }

     

        private void browse2_Click(object sender, RoutedEventArgs e)
        {
            Gat.Controls.OpenDialogView openDialog = new Gat.Controls.OpenDialogView();
            Gat.Controls.OpenDialogViewModel vm = (Gat.Controls.OpenDialogViewModel)openDialog.DataContext;
            vm.IsDirectoryChooser = true;
            vm.Show();
            if (vm.SelectedFilePath != null)
            LogPathtextBox.Text=vm.SelectedFilePath.ToString();

        }

        private void browse1_Click(object sender, RoutedEventArgs e)
        {
            Gat.Controls.OpenDialogView openDialog = new Gat.Controls.OpenDialogView();
            Gat.Controls.OpenDialogViewModel vm = (Gat.Controls.OpenDialogViewModel)openDialog.DataContext;
            vm.IsDirectoryChooser = true;
            vm.Show();
            if(vm.SelectedFilePath!=null)
            StorePathtextBox.Text = vm.SelectedFilePath.ToString();

       
        }
    }
}
