using Chat_Client.ServiceChat;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chat_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IServiceChatCallback
    {
        bool IsConnected = false;
        ServiceChatClient client;
        int ID;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        void ConnectUser()
        {
            if (!IsConnected) 
            {
                client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));

                ID = client.Connect(tbUserName.Text);
                tbUserName.IsEnabled = false;
                bConnDiscon.Content = "Disconnect";
                IsConnected = true;
            }
        }
        void DisconnectUser() 
        {
            if (IsConnected) 
            {
                client.Disconnect(ID);
                client = null;
                tbUserName.IsEnabled = true;
                bConnDiscon.Content = "Connect";
                IsConnected = false;
            } 
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsConnected)
            {
                DisconnectUser();
            }
            else
            {
                ConnectUser();
            }
        }

        public void MessageCallback(string message)
        {
            lbChat.Items.Add(message);
            lbChat.ScrollIntoView(lbChat.Items[lbChat.Items.Count - 1]);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectUser();

        }

        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter && !string.IsNullOrEmpty(tbMessage.Text))
            {
                if (client != null)
                {
                    client.SendMessage(tbMessage.Text, ID);
                    tbMessage.Text = string.Empty;
                    
                }
            }
        }
    }
}
