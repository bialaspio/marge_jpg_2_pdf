
namespace merge_jpg_2pdf_v01
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_OtworzKatakog = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonPDFout = new System.Windows.Forms.Button();
            this.textBoxPath2PDF = new System.Windows.Forms.TextBox();
            this.ofd_path_pdf_out = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelPDF = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_OtworzKatakog);
            this.groupBox1.Controls.Add(this.textBoxPath);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scieżka do katalogów";
            // 
            // button_OtworzKatakog
            // 
            this.button_OtworzKatakog.Location = new System.Drawing.Point(319, 17);
            this.button_OtworzKatakog.Name = "button_OtworzKatakog";
            this.button_OtworzKatakog.Size = new System.Drawing.Size(85, 23);
            this.button_OtworzKatakog.TabIndex = 1;
            this.button_OtworzKatakog.Text = "Wczytaj Katakog";
            this.button_OtworzKatakog.UseVisualStyleBackColor = true;
            this.button_OtworzKatakog.Click += new System.EventHandler(this.button_OtworzKatakog_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(6, 19);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(307, 20);
            this.textBoxPath.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 64);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(414, 202);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(319, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Generuj PDF";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 19);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(307, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonPDFout);
            this.groupBox2.Controls.Add(this.textBoxPath2PDF);
            this.groupBox2.Location = new System.Drawing.Point(15, 272);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 46);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scieżka dla PDF";
            // 
            // buttonPDFout
            // 
            this.buttonPDFout.Location = new System.Drawing.Point(319, 17);
            this.buttonPDFout.Name = "buttonPDFout";
            this.buttonPDFout.Size = new System.Drawing.Size(85, 23);
            this.buttonPDFout.TabIndex = 1;
            this.buttonPDFout.Text = "Scieżka do PDF";
            this.buttonPDFout.UseVisualStyleBackColor = true;
            this.buttonPDFout.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxPath2PDF
            // 
            this.textBoxPath2PDF.Location = new System.Drawing.Point(6, 19);
            this.textBoxPath2PDF.Name = "textBoxPath2PDF";
            this.textBoxPath2PDF.Size = new System.Drawing.Size(307, 20);
            this.textBoxPath2PDF.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelPDF);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(15, 325);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(414, 54);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Generowanie PDF";
            // 
            // labelPDF
            // 
            this.labelPDF.AutoSize = true;
            this.labelPDF.BackColor = System.Drawing.Color.Chartreuse;
            this.labelPDF.Location = new System.Drawing.Point(145, 24);
            this.labelPDF.Name = "labelPDF";
            this.labelPDF.Size = new System.Drawing.Size(35, 13);
            this.labelPDF.TabIndex = 4;
            this.labelPDF.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 389);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(457, 428);
            this.MinimumSize = new System.Drawing.Size(457, 428);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "jpg2pdf";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_OtworzKatakog;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonPDFout;
        private System.Windows.Forms.TextBox textBoxPath2PDF;
        private System.Windows.Forms.FolderBrowserDialog ofd_path_pdf_out;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelPDF;
    }
}

