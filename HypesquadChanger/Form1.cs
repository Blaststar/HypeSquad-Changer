using System;
using System.Text;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace HypesquadChanger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string hype = "";

        static Random rd = new Random();

        internal static string cookie(int stringLength)
        {
            const string allowedChars = "abcdefghijklmnopqrstuvwxyz123456789";
            char[] chars = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
        private void label1_Click(object sender, EventArgs e)
        {
            return;
        }

        private void token_TextChanged(object sender, EventArgs e)
        {
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            hype = "1";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            hype = "2";
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            hype = "3";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user_token = token.Text;
            string body = $"{{\"house_id\":\"{hype}\"}}";
            if (user_token == "" || user_token == " ")
            {
                MessageBox.Show("A valid token must be provided!", "HypeSquad Changer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                token.Text = "";
            } else if(hype == "")
            {
                MessageBox.Show("A hype must be chosen!", "HypeSquad Changer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            } else
            {
                try
                {
                    string oreo = "__cfduid=" + cookie(43) + ';' + " __dcfduid=" + cookie(32) + "; locale=en-US";
                    var request = new HttpClient();
                    request.DefaultRequestHeaders.Clear();
                    request.DefaultRequestHeaders.TryAddWithoutValidation("accept", "*/*");
                    request.DefaultRequestHeaders.TryAddWithoutValidation("accept-language", "en-US");
                    request.DefaultRequestHeaders.TryAddWithoutValidation("authorization", user_token);
                    request.DefaultRequestHeaders.TryAddWithoutValidation("content-type", "application/json");
                    request.DefaultRequestHeaders.TryAddWithoutValidation("cookie", oreo);
                    request.DefaultRequestHeaders.TryAddWithoutValidation("origin", "https://discord.com");
                    request.DefaultRequestHeaders.TryAddWithoutValidation("pragma", "no-cache");
                    request.DefaultRequestHeaders.TryAddWithoutValidation("referer", "https://discord.com/channels/@me");
                    request.DefaultRequestHeaders.TryAddWithoutValidation("sec-ch-ua", "\"Chromium\";v=\"94\", \"Google Chrome\";v=\"94\", \";Not A Brand\";v=\"99\"");
                    request.DefaultRequestHeaders.TryAddWithoutValidation("sec-ch-ua-mobile", "?1");
                    request.DefaultRequestHeaders.TryAddWithoutValidation("sec-ch-ua-platform", "\"Android\"");
                    request.DefaultRequestHeaders.TryAddWithoutValidation("sec-fetch-dest", "empty");
                    request.DefaultRequestHeaders.TryAddWithoutValidation("sec-fetch-mode", "cors");
                    request.DefaultRequestHeaders.TryAddWithoutValidation("sec-fetch-site", "same-origin");
                    request.DefaultRequestHeaders.TryAddWithoutValidation("user-agent", "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.127 Mobile Safari/537.36");
                    request.DefaultRequestHeaders.TryAddWithoutValidation("x-debug-options", "bugReporterEnabled");
                    request.DefaultRequestHeaders.TryAddWithoutValidation("x-discord-locale", "en-US");
                    request.DefaultRequestHeaders.TryAddWithoutValidation("x-kl-ajax-request", "Ajax_Request");
                    request.DefaultRequestHeaders.TryAddWithoutValidation("x-super-properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiRGlzY29yZCBDbGllbnQiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfdmVyc2lvbiI6IjEuMC45MDAxIiwib3NfdmVyc2lvbiI6IjEwLjAuMTkwNDIiLCJvc19hcmNoIjoieDY0Iiwic3lzdGVtX2xvY2FsZSI6ImVuLVVTIiwiY2xpZW50X2J1aWxkX251bWJlciI6ODMwNDAsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
                    var res = (int)request.PostAsync("https://discord.com/api/v9/hypesquad/online", new StringContent(body, Encoding.UTF8, "application/json")).Result.StatusCode;
                    if(res == 204)
                    {
                        MessageBox.Show("Sucessfully set HypeSquad!", "HypeSquad Changer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        token.Text = "";
                        return;
                    } else if(res == 401)
                    {
                        MessageBox.Show("An invalid token was provided!", "HypeSquad Changer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        token.Text = "";
                        return;

                    } else if(res == 403)
                    {
                        MessageBox.Show("The token provided is locked!", "HypeSquad Changer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        token.Text = "";
                        return;

                    } else if(res == 429)
                    {
                        MessageBox.Show("You are currently ratelimited!", "HypeSquad Changer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        token.Text = "";
                        return;
                    } else
                    {
                        MessageBox.Show("An error occured, please try again later.", "HypeSquad Changer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        token.Text = "";
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured while executing request.", "HypeSquad Changer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    token.Text = "";
                    return;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
