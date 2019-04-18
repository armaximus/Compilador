using Rules;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class Principal : Form
    {
        private Compiler compiler = new Compiler();
        private FileManager fileManager = new FileManager();

        public Principal()
        {
            InitializeComponent();
            this.editor.Styles[Style.Default].Font = "Consolas";
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(OnKeyDown);
        }

        private void editor_TextChanged(object sender, EventArgs e)
        {
            // Did the number of characters in the line number display change?
            // i.e. nnn VS nn, or nnnn VS nn, etc...
            var _maxLineNumberCharLength = this.editor.Lines.Count.ToString().Length;
            if (_maxLineNumberCharLength == this.maxLineNumberCharLength)
                return;

            // Calculate the width required to display the last line number
            // and include some padding for good measure.
            const int padding = 2;
            editor.Margins[0].Width = editor.TextWidth(Style.LineNumber, new string('9', _maxLineNumberCharLength + 1)) + padding;
            this.maxLineNumberCharLength = _maxLineNumberCharLength;
        }
       
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                ShowTeam();
            }
            else if (e.KeyCode == Keys.F9)
            {
                Compile();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.N)
            {
                NewFile();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.O)
            {
                OpenFile();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                SaveFile();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            NewFile();
        }
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            editor.Copy();
        }

        private void btnColar_Click(object sender, EventArgs e)
        {
            editor.Paste();
        }

        private void btnRecortar_Click(object sender, EventArgs e)
        {
            editor.Cut();
        }
        private void btnCompilar_Click(object sender, EventArgs e)
        {
            Compile();
        }
        private void btnEquipe_Click(object sender, EventArgs e)
        {
            ShowTeam();
        }

        private void NewFile()
        { 
            editor.Text = mensagens.Text = barraStatus.Text = string.Empty;
            fileManager = new FileManager();
        }

        private void OpenFile()
        {
            try
            {
                fileManager = new FileManager();

                if (fileManager.OpenFile())
                {
                    editor.Text = fileManager.fileContent;
                    barraStatus.Text = fileManager.filePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Não foi possível abrir o arquivo. Erro: {0}", ex.Message), "Erro");
            }
        }

        private void SaveFile()
        {
            try
            {
                fileManager.SaveFile(editor.Text);
                mensagens.Text = string.Empty;
                MessageBox.Show("Arquivo salvo com sucesso!");
                barraStatus.Text = fileManager.filePath;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("O arquivo não foi salvo, nenhum local selecionado.", "Aviso");
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Não foi possível salvar o arquivo: {0}", e.Message), "Atenção");
            }
        }

        private void ShowTeam()
        {
            MessageBox.Show("Alan Felipe Jantz, Caroline Belli Regalin e Matheus Manhke", "Equipe");
        }

        private void Compile()
        {
            mensagens.Text = compiler.Compile(editor.Text);
        }
    }
}
