using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public partial class FormUpdate : Form
    {
        private Usuario usuario;
        private string URI = "http://localhost:64935/api/usuario";

        public FormUpdate(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            txtNome.Text = usuario.Nome;
            txtSenha.Text= usuario.Senha;
            chkStatus.Checked = usuario.Status;
        }

        private async void UpdateUsuario()
        {
            usuario.Nome=txtNome.Text;
            usuario.Senha=txtSenha.Text;
            usuario.Status=chkStatus.Checked;

            using(var client=new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.PutAsJsonAsync(URI + "/" + usuario.Id, usuario);
                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuário atualizado!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Falha ao atualizar o usuario. Erro: " + responseMessage.StatusCode);
                    Close();
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            UpdateUsuario();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
