using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Desktop
{
    public partial class FormMain : Form
    {
        private string URI = "http://localhost:64935/api/usuario";
        FormAdd add = new FormAdd();
        Usuario usuario=new Usuario();

        public FormMain()
        {
            InitializeComponent();
        }

        private async void GetAllUsuarios()
        {
            using(var client=new HttpClient())
            {
                using(var response=await client.GetAsync(URI))
                {
                    if(response.IsSuccessStatusCode)
                    {
                        var UsuarioJsonString=await response.Content.ReadAsStringAsync();
                        dgvDados.DataSource = JsonConvert.DeserializeObject<Usuario[]>(UsuarioJsonString).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter a lista de usuários. Erro: " + response.StatusCode);
                        dgvDados.DataSource=null;
                    }
                }
            }
        }

        private async void GetUsuarioPorId(int codUsuario)
        {
            using(var client=new HttpClient())
            {
                BindingSource bsDados= new BindingSource();
                string txtURI=URI+"/"+codUsuario.ToString();
                HttpResponseMessage response= await client.GetAsync(txtURI);
                if(response.IsSuccessStatusCode)
                {
                    var UsuarioJsonString=await response.Content.ReadAsStringAsync();
                    bsDados.DataSource = JsonConvert.DeserializeObject<Usuario>(UsuarioJsonString);
                    dgvDados.DataSource = bsDados;
                }
                else
                {
                    MessageBox.Show("Falha ao obter dados do usuário. Erro:"+response.StatusCode);
                    dgvDados.DataSource = null;
                }
            }
        }

        private async void DeleteUsuario(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                HttpResponseMessage response = await client.DeleteAsync($"{URI}/{id}");

                if (response.IsSuccessStatusCode)
                    MessageBox.Show("Usuário excluído com sucesso!");
                else
                    MessageBox.Show("Falha ao excluir o Usuário : " + response.StatusCode, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            GetAllUsuarios();
        }

        private void btnObterUsuarios_Click(object sender, EventArgs e)
        {
            GetAllUsuarios();
        }

        private void btnUsuariosPorID_Click(object sender, EventArgs e)
        {
            string prompt = "Informe o código do usuário a ser encontrado: ";
            string titulo = "SWII6 - TP Final - Procurar usuário por ID";
            string resultado=Microsoft.VisualBasic.Interaction.InputBox(prompt, titulo);
            int codigolivro = Convert.ToInt32(resultado);
            GetUsuarioPorId(codigolivro);
        }

        private void btnIncluirUsuario_Click(object sender, EventArgs e)
        {
            add.ShowDialog();
        }

        private void btnAtualizaUsuario_Click(object sender, EventArgs e)
        {
            usuario.Id = int.Parse(dgvDados.CurrentRow.Cells[0].Value.ToString());
            usuario.Nome = (String)dgvDados.CurrentRow.Cells[1].Value;
            usuario.Senha = (String)dgvDados.CurrentRow.Cells[2].Value;
            usuario.Status = dgvDados.CurrentRow.Cells[1].Value.ToString().Equals("Ativo");
            FormUpdate update = new FormUpdate(usuario);
            update.ShowDialog();
        }

        private void btnDeletarUsuario_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Você realmente deseja excluir o Usuário {dgvDados.CurrentRow.Cells[1].Value}?",
                "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
                DeleteUsuario(int.Parse(dgvDados.CurrentRow.Cells[0].Value.ToString()));
        }
    }
}
