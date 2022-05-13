using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Http;
using Newtonsoft.Json;
using DemoWinForm2.Entities;

namespace DemoWinForm2
{
    public partial class Form1 : Form
    {
        HttpClient _Client;
        public Form1()
        {
            _Client = new HttpClient();
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var uri = new Uri("http://localhost/APIDemo1/api/Token/authenticate");

            TokenData auth = new TokenData();
            auth.Username = TxtUser.Text;
            auth.Password = TxtPwd.Text;

            var json = JsonConvert.SerializeObject(auth);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage ResponseToken = null;

            ResponseToken = await _Client.PostAsync(uri, content);

            if (ResponseToken.IsSuccessStatusCode)
            {
                var Token = ResponseToken.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                
                Form2 LoginExito = new Form2(Token);
                LoginExito.Show();

            }

        }
    }
}
