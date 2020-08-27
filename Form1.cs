using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discord;
using Discord.REQ;
using Discord.Rest;
using Discord.WebSocket;

namespace AutoSender
{
    public partial class Form1 : Form
    {
        private DiscordSocketClient _client;

        private static string _token;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            ulong chanid = Convert.ToUInt64(textBox4.Text);

            var channel = _client.GetChannel(chanid) as ITextChannel;

                foreach (var item in textBox2.Lines)
                {
                    var botMsg = await channel.SendMessageAsync(item.ToString());
                    botMsg.DeleteAsync();
                    int wait = Convert.ToInt32(textBox3.Text);
                    System.Threading.Thread.Sleep(wait * 1000);
                }
            


        }

        private async void button2_Click(object sender, EventArgs e)
        {
            _token = textBox1.Text;
            await _client.LoginAsync(TokenType.User, _token);
            await _client.StartAsync();
            System.Threading.Thread.Sleep(3000);
            MessageBox.Show("User : " + _client.CurrentUser.Username + "#" + _client.CurrentUser.Discriminator);
            label7.Text = "User : " + _client.CurrentUser.Username + "#" + _client.CurrentUser.Discriminator;
            label8.Text = "ID : " + _client.CurrentUser.Id;
            label8.Visible = true;
            pictureBox1.Load(_client.CurrentUser.GetAvatarUrl().ToString());
            label7.Visible = true;
            label9.Text = "Created at : " + _client.CurrentUser.CreatedAt;
            label9.Visible = true;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            label9.Visible = false;
            label8.Visible = false;
            label7.Visible = false;
            textBox1.PasswordChar = '*';
            _client = new DiscordSocketClient();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label6.Text = textBox2.Lines.Count().ToString() + " phrase loaded";

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 Mytwoformlol = new Form2();
            Mytwoformlol.Show();
        }
    }
}
