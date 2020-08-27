using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoSender
{
    public partial class Form2 : Form
    {
        private DiscordSocketClient _client;

        private static string _token;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            textBox1.PasswordChar = '*';
            _client = new DiscordSocketClient();

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            _token = textBox1.Text;
            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();
            System.Threading.Thread.Sleep(3000);
            MessageBox.Show("Bot : " + _client.CurrentUser.Username + "#" + _client.CurrentUser.Discriminator);
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            ulong guildid = Convert.ToUInt64(textBox3.Text);
            var guild = _client.GetGuild(guildid);
            label4.Visible = true;
            int number;
            number = 0;
            label4.Text = " /" + guild.MemberCount.ToString();
            var t = MessageBox.Show("Lets go sned message to " + guild.MemberCount.ToString() + " user, woaw", "not very good guy");
            foreach (SocketGuild guilduser in _client.Guilds)
                {
                    foreach (SocketUser user in guild.Users)
                    {
                        try
                        {

                            label4.Text = "/" + guild.MemberCount;
                            
                        
                        await user.SendMessageAsync(textBox2.Text);

                    }
                        catch (Exception)
                        {

                        }

                    }



                }
            



        }
    }
}
