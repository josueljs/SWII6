namespace Desktop
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.btnObterUsuarios = new System.Windows.Forms.Button();
            this.btnUsuariosPorID = new System.Windows.Forms.Button();
            this.btnIncluirUsuario = new System.Windows.Forms.Button();
            this.btnAtualizaUsuario = new System.Windows.Forms.Button();
            this.btnDeletarUsuario = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDados
            // 
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Location = new System.Drawing.Point(12, 12);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.RowTemplate.Height = 25;
            this.dgvDados.Size = new System.Drawing.Size(574, 300);
            this.dgvDados.TabIndex = 2;
            // 
            // btnObterUsuarios
            // 
            this.btnObterUsuarios.Location = new System.Drawing.Point(12, 318);
            this.btnObterUsuarios.Name = "btnObterUsuarios";
            this.btnObterUsuarios.Size = new System.Drawing.Size(100, 23);
            this.btnObterUsuarios.TabIndex = 3;
            this.btnObterUsuarios.Text = "Listar Usuários";
            this.btnObterUsuarios.UseVisualStyleBackColor = true;
            this.btnObterUsuarios.Click += new System.EventHandler(this.btnObterUsuarios_Click);
            // 
            // btnUsuariosPorID
            // 
            this.btnUsuariosPorID.Location = new System.Drawing.Point(118, 318);
            this.btnUsuariosPorID.Name = "btnUsuariosPorID";
            this.btnUsuariosPorID.Size = new System.Drawing.Size(125, 23);
            this.btnUsuariosPorID.TabIndex = 4;
            this.btnUsuariosPorID.Text = "Obter Usuário por ID";
            this.btnUsuariosPorID.UseVisualStyleBackColor = true;
            this.btnUsuariosPorID.Click += new System.EventHandler(this.btnUsuariosPorID_Click);
            // 
            // btnIncluirUsuario
            // 
            this.btnIncluirUsuario.Location = new System.Drawing.Point(249, 318);
            this.btnIncluirUsuario.Name = "btnIncluirUsuario";
            this.btnIncluirUsuario.Size = new System.Drawing.Size(100, 23);
            this.btnIncluirUsuario.TabIndex = 5;
            this.btnIncluirUsuario.Text = "Incluir Usuário";
            this.btnIncluirUsuario.UseVisualStyleBackColor = true;
            this.btnIncluirUsuario.Click += new System.EventHandler(this.btnIncluirUsuario_Click);
            // 
            // btnAtualizaUsuario
            // 
            this.btnAtualizaUsuario.Location = new System.Drawing.Point(355, 318);
            this.btnAtualizaUsuario.Name = "btnAtualizaUsuario";
            this.btnAtualizaUsuario.Size = new System.Drawing.Size(125, 23);
            this.btnAtualizaUsuario.TabIndex = 6;
            this.btnAtualizaUsuario.Text = "Atualizar Usuário";
            this.btnAtualizaUsuario.UseVisualStyleBackColor = true;
            this.btnAtualizaUsuario.Click += new System.EventHandler(this.btnAtualizaUsuario_Click);
            // 
            // btnDeletarUsuario
            // 
            this.btnDeletarUsuario.Location = new System.Drawing.Point(486, 318);
            this.btnDeletarUsuario.Name = "btnDeletarUsuario";
            this.btnDeletarUsuario.Size = new System.Drawing.Size(100, 23);
            this.btnDeletarUsuario.TabIndex = 7;
            this.btnDeletarUsuario.Text = "Deletar Usuário";
            this.btnDeletarUsuario.UseVisualStyleBackColor = true;
            this.btnDeletarUsuario.Click += new System.EventHandler(this.btnDeletarUsuario_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 351);
            this.Controls.Add(this.btnDeletarUsuario);
            this.Controls.Add(this.btnAtualizaUsuario);
            this.Controls.Add(this.btnIncluirUsuario);
            this.Controls.Add(this.btnUsuariosPorID);
            this.Controls.Add(this.btnObterUsuarios);
            this.Controls.Add(this.dgvDados);
            this.Name = "FormMain";
            this.Text = "SWII6 - TP Final - Gerenciamento de usuários";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView dgvDados;
        private Button btnObterUsuarios;
        private Button btnUsuariosPorID;
        private Button btnIncluirUsuario;
        private Button btnAtualizaUsuario;
        private Button btnDeletarUsuario;
    }
}