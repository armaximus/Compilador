﻿namespace Compilador
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button button7;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            button7 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button7
            // 
            button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            button7.Location = new System.Drawing.Point(656, 2);
            button7.Margin = new System.Windows.Forms.Padding(2);
            button7.MinimumSize = new System.Drawing.Size(105, 70);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(105, 70);
            button7.TabIndex = 7;
            button7.Text = "compilar [F9]";
            button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            button7.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(2, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.MinimumSize = new System.Drawing.Size(105, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 70);
            this.button1.TabIndex = 1;
            this.button1.Text = "novo [ctrl-n]";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Controls.Add(this.button5);
            this.flowLayoutPanel1.Controls.Add(this.button6);
            this.flowLayoutPanel1.Controls.Add(button7);
            this.flowLayoutPanel1.Controls.Add(this.button8);
            this.flowLayoutPanel1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 1);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(882, 558);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(111, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.MinimumSize = new System.Drawing.Size(105, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 70);
            this.button2.TabIndex = 2;
            this.button2.Text = "abrir [ctrl-o]";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(220, 2);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.MaximumSize = new System.Drawing.Size(0, 70);
            this.button3.MinimumSize = new System.Drawing.Size(105, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 70);
            this.button3.TabIndex = 3;
            this.button3.Text = "salvar [ctrl-s]";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(329, 2);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.MinimumSize = new System.Drawing.Size(105, 70);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 70);
            this.button4.TabIndex = 4;
            this.button4.Text = "copiar [ctrl-c]";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(438, 2);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.MinimumSize = new System.Drawing.Size(105, 70);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(105, 70);
            this.button5.TabIndex = 5;
            this.button5.Text = "colar [ctrl-v]";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(547, 2);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.MinimumSize = new System.Drawing.Size(105, 70);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(105, 70);
            this.button6.TabIndex = 6;
            this.button6.Text = "recortar [ctrl-x]";
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Right;
            this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
            this.button8.Location = new System.Drawing.Point(765, 2);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.MinimumSize = new System.Drawing.Size(105, 70);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(105, 70);
            this.button8.TabIndex = 8;
            this.button8.Text = "equipe [F1]";
            this.button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button1;
    }
}

