using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TcpSharp;

namespace ClientApp
{
    public partial class frmChat : Form
    {
        private static frmChat? _instance;

        public static frmChat Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new frmChat();
                }
                return _instance;
            }
        }

        private TcpSharpSocketClient _client;

        public frmChat()
        {
            InitializeComponent();
            _client = new TcpSharpSocketClient("127.0.0.1", 9000);
        }

        private void AppendLog(string message)
        {
            if (rtfLog.InvokeRequired)
            {
                rtfLog.Invoke(new Action<string>(AppendLog), message);
            }
            else
            {
                rtfLog.AppendText(message + Environment.NewLine);
                rtfLog.ScrollToCaret();
            }
        }

        private void frmChat_Load(object sender, EventArgs e)
        {
            this.Text = $"Joined as {AppSession.Username}";
            _client.OnConnected += _client_OnConnected;
            _client.OnDisconnected += _client_OnDisconnected;
            _client.OnDataReceived += _client_OnDataReceived;
            _client.Connect();
        }

        private void _client_OnDataReceived(object? sender, OnClientDataReceivedEventArgs e)
        {
            var msg = Encoding.UTF8.GetString(e.Data);
            AppendLog("RAW => " + msg);
            if (msg.StartsWith("USERLIST|"))
            {
                var users = msg.Substring("USERLIST|".Length).Split(',');
                Invoke(new Action(() =>
                {
                    lstUsers.Items.Clear();
                    foreach (var user in users)
                    {
                        if (user != AppSession.Username)
                        {
                            lstUsers.Items.Add(user);
                        }
                    }

                }));
            }
            else if (msg.StartsWith("MSG|"))
            {
                var message = msg.Substring("MSG|".Length);
                AppendLog(message);
            }
        }

        private void _client_OnDisconnected(object? sender, OnClientDisconnectedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                AppendLog("Disconnected from server.");
                btnSend.Enabled = false;
            }));
        }

        private void _client_OnConnected(object? sender, OnClientConnectedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                AppendLog("Connected to server.");
                _client.SendString($"JOIN|{AppSession.Username}");
                btnSend.Enabled = true;
            }));
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(lstUsers.SelectedItem == null)
            {
                MessageBox.Show("Please select a user to send the message to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var targetUser = lstUsers.SelectedItem.ToString();
            var message = txtMessage.Text.Trim();
            if(string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Please enter a message to send.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _client.SendString($"MSG|{targetUser}|{message}");
            AppendLog($"To {targetUser}: {message}");
            txtMessage.Clear();
        }
    }
}
