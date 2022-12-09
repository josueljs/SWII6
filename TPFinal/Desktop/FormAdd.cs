using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public partial class FormAdd : Form
    {
        private string URI = "http://localhost:64935/api/usuario";

        public FormAdd()
        {
            InitializeComponent();
        }

        private async void AddUsuario()
        {
            Usuario usuario = new Usuario
            {
                Nome=txtNome.Text,
                Senha=txtSenha.Text,
                Status=chkStatus.Checked
            };

            using(var client=new HttpClient())
            {
                var serializedUsuario=JsonConvert.SerializeObject(usuario);
                var content=new StringContent(serializedUsuario,Encoding.UTF8,"application/json");
                var result=await client.PostAsync(URI,content);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuário cadastrado com sucesso!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Falha ao cadastrar o usuário. Erro: "+result.StatusCode);
                    Close();
                }
            }
            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            AddUsuario();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
