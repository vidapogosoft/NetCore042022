using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DemoWinForm1.ApiHelper;
using DemoWinForm1.Entities;

namespace DemoWinForm1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGet_Click(object sender, EventArgs e)
        {

            //Creamos el listado que llenaremos con el api
            List<Post> listado = new List<Post>();

            //Instancia de un objeto Replay
            Reply oReply = new Reply();

            //poblar el objetocon el metodo generico EXECUTE - aqui vamos a pasar GET
            oReply = await Consumer.Execute<List<Post>>(this.txtUri.Text, ApiHelper.methodHttp.GET, listado);

            this.dataGridView1.DataSource = oReply.Data;

            //Mostramos mensaje devuelto del Reply el StatusCode

            MessageBox.Show(oReply.StatusCode);

        }

        private async void btnPost_Click(object sender, EventArgs e)
        {
            Post post = new Post()
            {
                userId = 1,
                title = "titulo del post- vpr",
                body = "Cuerpo del post- vpr:" + DateTime.Now.ToShortDateString()

            };

            Reply oReply = new Reply();

            oReply = await Consumer.Execute<Post>(this.txtUriPost.Text, ApiHelper.methodHttp.POST, post);

            MessageBox.Show(oReply.StatusCode + post.body);
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            Reply oReply = new Reply();

            oReply = await Consumer.Execute<Post>($"{this.txtUriPost.Text}/{this.txtId.Value}", ApiHelper.methodHttp.DELETE, null);

            MessageBox.Show(oReply.StatusCode);
        }
    }
}
