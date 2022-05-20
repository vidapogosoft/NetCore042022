using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebForm1.DTO;
using WebForm1.Services;

namespace WebForm1.Mantenimientos
{
    public partial class FrmPersona : System.Web.UI.Page
    {

        RestServicesPersona ApiPersona = new RestServicesPersona();
        public List<DTOPersona> ListPersonas;

        protected void Page_Load(object sender, EventArgs e)
        {
            CargaPersonas();

        }

        protected void BtnConsulta_Click(object sender, EventArgs e)
        {
            CargaPersonas();
        }

        private async void CargaPersonas()
        {
            ListPersonas = new List<DTOPersona>();

            ListPersonas = await ApiPersona.GetPersonas();

            if (ListPersonas.Count > 0)
            {
                GrdPersona.DataSource = ListPersonas;
            }

            GrdPersona.DataBind();
        }

        protected async void BtnGrabarDatos_Click(object sender, EventArgs e)
        {
            int grabado = 0;

            try
            {
                DTOPersona item = new DTOPersona();

                item.Identificacion = Txtidentificacion.Text;
                item.Apellidos = TxtApellidos.Text;
                item.Nombres = TxtNombres.Text;

                grabado = await ApiPersona.SaveDatos(item);

                if(grabado == 1)
                {
                    LblMensaje.Text = "Registro Exitoso";

                }

            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
                Debug.WriteLine(@"Error {0}", ex.Message);
            }
            finally
            {
                CargaPersonas();
            }

        }

    }
}