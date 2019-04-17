using System;
using System.Windows.Forms;

namespace Main
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private int maxLineNumberCharLength;

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
            System.Windows.Forms.Button btnCompilar;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.btnEquipe = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnColar = new System.Windows.Forms.Button();
            this.btnRecortar = new System.Windows.Forms.Button();
            this.editor = new ScintillaNET.Scintilla();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mensagens = new System.Windows.Forms.RichTextBox();
            this.barraStatus = new System.Windows.Forms.TextBox();
            btnCompilar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCompilar
            // 
            btnCompilar.AutoSize = true;
            btnCompilar.Image = ((System.Drawing.Image)(resources.GetObject("btnCompilar.Image")));
            btnCompilar.Location = new System.Drawing.Point(650, 0);
            btnCompilar.Margin = new System.Windows.Forms.Padding(2);
            btnCompilar.MinimumSize = new System.Drawing.Size(105, 70);
            btnCompilar.Name = "btnCompilar";
            btnCompilar.Size = new System.Drawing.Size(105, 70);
            btnCompilar.TabIndex = 14;
            btnCompilar.Text = "Compilar [F9]";
            btnCompilar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnCompilar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnCompilar.UseVisualStyleBackColor = true;
            btnCompilar.Click += new System.EventHandler(this.btnCompilar_Click);
            // 
            // btnEquipe
            // 
            this.btnEquipe.AutoSize = true;
            this.btnEquipe.Image = ((System.Drawing.Image)(resources.GetObject("btnEquipe.Image")));
            this.btnEquipe.Location = new System.Drawing.Point(759, 0);
            this.btnEquipe.Margin = new System.Windows.Forms.Padding(2);
            this.btnEquipe.MinimumSize = new System.Drawing.Size(105, 70);
            this.btnEquipe.Name = "btnEquipe";
            this.btnEquipe.Size = new System.Drawing.Size(105, 70);
            this.btnEquipe.TabIndex = 2;
            this.btnEquipe.Text = "Equipe [F1]";
            this.btnEquipe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEquipe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEquipe.UseVisualStyleBackColor = true;
            this.btnEquipe.Click += new System.EventHandler(this.btnEquipe_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.AutoSize = true;
            this.btnNovo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.Location = new System.Drawing.Point(0, 0);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNovo.MinimumSize = new System.Drawing.Size(105, 70);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(105, 70);
            this.btnNovo.TabIndex = 8;
            this.btnNovo.Text = "Novo [Ctrl + N]";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnAbrir
            // 
            this.btnAbrir.AutoSize = true;
            this.btnAbrir.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrir.Image")));
            this.btnAbrir.Location = new System.Drawing.Point(109, 1);
            this.btnAbrir.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbrir.MinimumSize = new System.Drawing.Size(105, 70);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(105, 70);
            this.btnAbrir.TabIndex = 9;
            this.btnAbrir.Text = "Abrir [Ctrl + O]";
            this.btnAbrir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = true;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.Location = new System.Drawing.Point(216, 1);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalvar.MaximumSize = new System.Drawing.Size(0, 70);
            this.btnSalvar.MinimumSize = new System.Drawing.Size(105, 70);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(105, 70);
            this.btnSalvar.TabIndex = 10;
            this.btnSalvar.Text = "Salvar [Ctrl + S]";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCopiar
            // 
            this.btnCopiar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCopiar.Image = ((System.Drawing.Image)(resources.GetObject("btnCopiar.Image")));
            this.btnCopiar.Location = new System.Drawing.Point(324, 1);
            this.btnCopiar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopiar.MinimumSize = new System.Drawing.Size(105, 70);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(105, 70);
            this.btnCopiar.TabIndex = 11;
            this.btnCopiar.Text = "Copiar [Ctrl + C]";
            this.btnCopiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // btnColar
            // 
            this.btnColar.Image = ((System.Drawing.Image)(resources.GetObject("btnColar.Image")));
            this.btnColar.Location = new System.Drawing.Point(433, 0);
            this.btnColar.Margin = new System.Windows.Forms.Padding(2);
            this.btnColar.MinimumSize = new System.Drawing.Size(105, 70);
            this.btnColar.Name = "btnColar";
            this.btnColar.Size = new System.Drawing.Size(105, 70);
            this.btnColar.TabIndex = 12;
            this.btnColar.Text = "Colar [Ctrl + V]";
            this.btnColar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnColar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnColar.UseVisualStyleBackColor = true;
            this.btnColar.Click += new System.EventHandler(this.btnColar_Click);
            // 
            // btnRecortar
            // 
            this.btnRecortar.Image = ((System.Drawing.Image)(resources.GetObject("btnRecortar.Image")));
            this.btnRecortar.Location = new System.Drawing.Point(542, 0);
            this.btnRecortar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRecortar.MinimumSize = new System.Drawing.Size(105, 70);
            this.btnRecortar.Name = "btnRecortar";
            this.btnRecortar.Size = new System.Drawing.Size(105, 70);
            this.btnRecortar.TabIndex = 13;
            this.btnRecortar.Text = "Recortar [Ctrl + X]";
            this.btnRecortar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecortar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRecortar.UseVisualStyleBackColor = true;
            this.btnRecortar.Click += new System.EventHandler(this.btnRecortar_Click);
            // 
            // editor
            // 
            this.editor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editor.Location = new System.Drawing.Point(3, 74);
            this.editor.MinimumSize = new System.Drawing.Size(882, 350);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(882, 350);
            this.editor.TabIndex = 15;
            this.editor.VScrollBar = false;
            this.editor.TextChanged += new System.EventHandler(this.editor_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.btnNovo);
            this.panel1.Controls.Add(this.btnAbrir);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.btnCopiar);
            this.panel1.Controls.Add(this.btnEquipe);
            this.panel1.Controls.Add(btnCompilar);
            this.panel1.Controls.Add(this.btnRecortar);
            this.panel1.Controls.Add(this.btnColar);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.MinimumSize = new System.Drawing.Size(882, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 73);
            this.panel1.TabIndex = 18;
            // 
            // mensagens
            // 
            this.mensagens.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mensagens.AutoSize = true;
            this.mensagens.Location = new System.Drawing.Point(3, 425);
            this.mensagens.MinimumSize = new System.Drawing.Size(882, 100);
            this.mensagens.Name = "mensagens";
            this.mensagens.ReadOnly = true;
            this.mensagens.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.mensagens.Size = new System.Drawing.Size(882, 100);
            this.mensagens.TabIndex = 16;
            this.mensagens.Text = "";
            this.mensagens.WordWrap = false;
            // 
            // barraStatus
            // 
            this.barraStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.barraStatus.Location = new System.Drawing.Point(3, 531);
            this.barraStatus.MaxLength = 0;
            this.barraStatus.MinimumSize = new System.Drawing.Size(880, 30);
            this.barraStatus.Name = "barraStatus";
            this.barraStatus.ReadOnly = true;
            this.barraStatus.Size = new System.Drawing.Size(880, 20);
            this.barraStatus.TabIndex = 19;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.barraStatus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mensagens);
            this.Controls.Add(this.editor);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEquipe;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Button btnColar;
        private System.Windows.Forms.Button btnRecortar;
        private ScintillaNET.Scintilla editor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox mensagens;
        private System.Windows.Forms.TextBox barraStatus;
    }


}