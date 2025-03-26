using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace merge_jpg_2pdf_v01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            labelPDF.Text = "";
            textBoxPath.Text = @"I:\Foto\test";
            textBoxPath2PDF.Text = @"I:\Foto\pdf";
        }

        FolderBrowserDialog ofd_dir = new FolderBrowserDialog();

        private void button_OtworzKatakog_Click(object sender, EventArgs e)
        {
            // ofd_dir.SelectedPath = Directory.GetCurrentDirectory();
            ofd_dir.SelectedPath = textBoxPath.Text;
            if (ofd_dir.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = ofd_dir.SelectedPath;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(textBoxPath.Text) || String.IsNullOrEmpty(textBoxPath.Text))
            {
                MessageBox.Show("Należy wskazać poprawną śieżkę do katalogu z operatami", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                richTextBox1.Text = "";
                string[] lista_katakogow = Directory.GetDirectories(textBoxPath.Text, "P*");
                // Display the ProgressBar control.
                progressBar1.Visible = true;
                // Set Minimum to 1 to represent the first file being copied.
                progressBar1.Minimum = 0;
                // Set Maximum to the total number of files to copy.
                progressBar1.Maximum = lista_katakogow.Length;
                // Set the initial value of the ProgressBar.
                progressBar1.Value = 0;
                // Set the Step property to a value of 1 to represent each file being copied.
                progressBar1.Step = 1;

                richTextBox1.Text = "";
                labelPDF.Text = "0 z " + lista_katakogow.Length.ToString();
                labelPDF.Refresh();

                try
                {
                    foreach (string katalog in lista_katakogow)
                    {

                        string[] lista_plikow = Directory.GetFiles(katalog, "*.jpg");
                        int licz_plikow = lista_plikow.Length;
                        string path_to_operat = textBoxPath2PDF.Text + @"\" + Path.GetFileName(katalog);
                        //CreatePDF_3(lista_plikow);
                        CreatePDF_3_1str(lista_plikow);
                        //            CreatePDF_3a(lista_plikow);

                        try
                        {
                            if (!Directory.Exists(path_to_operat))
                            {
                                // Try to create the directory.
                                DirectoryInfo di = Directory.CreateDirectory(path_to_operat);
                            }
                        }
                        catch (IOException ioex)
                        {
                            Console.WriteLine(ioex.Message);
                        }

                        MergePDFs(path_to_operat + @"\" + Path.GetFileName(katalog) + "_tmp.pdf", Directory.GetFiles(katalog, "*.pdf"));
                        VerySimpleReplaceText(path_to_operat + @"\" + Path.GetFileName(katalog) + "_tmp.pdf", path_to_operat + @"\" + Path.GetFileName(katalog) + ".pdf");
                        progressBar1.Value = progressBar1.Value + 1;
                        richTextBox1.AppendText(katalog + "\n");
                        richTextBox1.Refresh();
                        labelPDF.Text = (progressBar1.Value).ToString() + " z " + lista_katakogow.Length.ToString();
                        labelPDF.Refresh();

                        if (File.Exists(path_to_operat + @"\" + Path.GetFileName(katalog) + "_tmp.pdf"))
                        {
                            File.Delete(path_to_operat + @"\" + Path.GetFileName(katalog) + "_tmp.pdf");
                        }
                    }
                    MessageBox.Show(String.Format("Wygenerowano {0} plików", progressBar1.Value), "Eksport do PDF", MessageBoxButtons.OK);
                }
                catch
                {
                    MessageBox.Show("Błąd eksportu do PDF ", "ERR Eksport", MessageBoxButtons.OK);
                }
            }

        }

        //-------------------------------------------------------------------------------------------------------------------------------       

        public void CreatePDF_3a(string[] lista_plikow)
        {
            for (int i = 0; i < lista_plikow.Length - 1; i++)
            {
                do_pdf(1 + i, i + 2, i + 1, lista_plikow);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------       

        public void CreatePDF_3(string[] lista_plikow)
        {
            int licz_dokument = 0;
            if (lista_plikow.Length > 0)
            {
                if (lista_plikow.Length < 5)
                {
                    licz_dokument++;
                    do_pdf(1, lista_plikow.Length, 1, lista_plikow);
                }

                else
                {

                    float dziel = lista_plikow.Length / 4;
                    float dziel_mod = lista_plikow.Length % 4;

                    if (dziel_mod == 0)
                    {
                        int aaa = 0;
                        for (int i = 0; i < dziel - 1; i++)
                        {
                            do_pdf(1 + (4 * i), (4 * i) + 4, i + 1, lista_plikow);
                            aaa = i;
                        }
                        aaa++;
                        do_pdf(1 + (4 * aaa), lista_plikow.Length, aaa + 1, lista_plikow);
                    }
                    else
                    {
                        int aaa = 0;
                        for (int i = 0; i < dziel; i++)
                        {
                            do_pdf(1 + (4 * i), (4 * i) + 4, i + 1, lista_plikow);
                            aaa = i;
                        }
                        aaa++;
                        do_pdf(1 + (4 * aaa), lista_plikow.Length, aaa + 1, lista_plikow);
                    }
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------
        public void CreatePDF_3_3str(string[] lista_plikow)
        {
            int licz_dokument = 0;
            if (lista_plikow.Length > 0)
            {
                if (lista_plikow.Length < 4)
                {
                    licz_dokument++;
                    do_pdf(1, lista_plikow.Length, 1, lista_plikow);
                }

                else
                {

                    float dziel = lista_plikow.Length / 3;
                    float dziel_mod = lista_plikow.Length % 3;

                    if (dziel_mod == 0)
                    {
                        int aaa = 0;
                        for (int i = 0; i < dziel - 1; i++)
                        {
                            do_pdf(1 + (3 * i), (3 * i) + 3, i + 1, lista_plikow);
                            aaa = i;
                        }
                        aaa++;
                        do_pdf(1 + (3 * aaa), lista_plikow.Length, aaa + 1, lista_plikow);
                    }
                    else
                    {
                        int aaa = 0;
                        for (int i = 0; i < dziel; i++)
                        {
                            do_pdf(1 + (3 * i), (3 * i) + 3, i + 1, lista_plikow);
                            aaa = i;
                        }
                        aaa++;
                        do_pdf(1 + (3 * aaa), lista_plikow.Length, aaa + 1, lista_plikow);
                    }
                }
            }
        }


        //----------------------------------------------------------------------------------------------------------------------------------------
        public void CreatePDF_3_1str(string[] lista_plikow)
        {
            int licz_dokument = 0;
            if (lista_plikow.Length > 0)
            {
                if (lista_plikow.Length < 2)
                {
                    licz_dokument++;
                    do_pdf(1, lista_plikow.Length, 1, lista_plikow);
                }

                else
                {

                    float dziel = lista_plikow.Length / 1;
                    float dziel_mod = lista_plikow.Length % 1;

                    if (dziel_mod == 0)
                    {
                        int aaa = 0;
                        for (int i = 0; i < dziel - 1; i++)
                        {
                            do_pdf(1 + (1 * i), (1 * i) + 1, i + 1, lista_plikow);
                            aaa = i;
                        }
                        aaa++;
                        do_pdf(1 + (1 * aaa), lista_plikow.Length, aaa + 1, lista_plikow);
                    }
                    else
                    {
                        int aaa = 0;
                        for (int i = 0; i < dziel; i++)
                        {
                            do_pdf(1 + (1 * i), (1 * i) + 1, i + 1, lista_plikow);
                            aaa = i;
                        }
                        aaa++;
                        do_pdf(1 + (1 * aaa), lista_plikow.Length, aaa + 1, lista_plikow);
                    }
                }
            }
        }


        //-------------------------------------------------------------------------------------------------------------------------------

        public void do_pdf(int start, int stop, int part, string[] lista_plikow)
        {
            Aspose.Pdf.Document doc = new Aspose.Pdf.Document();
            int intIndex = start - 1;

            while (intIndex < stop)
            {
                if (intIndex < stop)
                {
                    System.Drawing.Image srcImage = System.Drawing.Image.FromFile(lista_plikow[intIndex]);
                    //richTextBox1.Text += "\t"+lista_plikow[intIndex] + "\n";

                    // Read Height of input image
                    int h = srcImage.Height;
                    // Read Height of input image
                    int w = srcImage.Width;

                    // Add an empty page
                    Aspose.Pdf.Page page = doc.Pages.Add();
                    Aspose.Pdf.Image image = new Aspose.Pdf.Image();

                    image.File = (lista_plikow[intIndex]);

                    page.PageInfo.Height = h;
                    page.PageInfo.Width = w;
                    //richTextBox1.Text += image.File + "\n";
                    //richTextBox1.Text += srcImage.Size + "\n-- W " + srcImage.Size.Width + " H " + srcImage.Size.Height + "\n -- W " + w + "-- H " + h + "\n";
                    //richTextBox1.Text += "PI_W - " + page.PageInfo.Width + "PI_H - " + page.PageInfo.Height + "\n";

                    page.PageInfo.Margin.Bottom = (0);
                    page.PageInfo.Margin.Top = (0);
                    page.PageInfo.Margin.Right = (0);
                    page.PageInfo.Margin.Left = (0);


                    page.Paragraphs.Add(image);


                }
                intIndex++;
            }

            string dir_name = Path.GetDirectoryName(lista_plikow[intIndex - 1]);
            string file_name_part01 = Path.GetFileName(dir_name);
            if (part < 10)
                doc.Save(dir_name + @"\" + file_name_part01 + "#00" + part + ".pdf");
            else if (part >= 10 && part < 100)
                doc.Save(dir_name + @"\" + file_name_part01 + "#0" + part + ".pdf");
            else if (part >= 100)
                doc.Save(dir_name + @"\" + file_name_part01 + "#" + part + ".pdf");

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        public static void MergePDFs(string targetPath, params string[] pdfs)
        {
            using (PdfSharp.Pdf.PdfDocument targetDoc = new PdfSharp.Pdf.PdfDocument())
            {
                foreach (string pdf in pdfs)
                {
                    using (PdfSharp.Pdf.PdfDocument pdfDoc = PdfSharp.Pdf.IO.PdfReader.Open(pdf, PdfDocumentOpenMode.Import))
                    {
                        for (int i = 0; i < pdfDoc.PageCount; i++)
                        {
                            targetDoc.AddPage(pdfDoc.Pages[i]);
                        }
                    }
                }
                targetDoc.Save(targetPath);
            }
            // Skasowanie plików częściowych pdf 
            foreach (string pdf in pdfs)
            {
                if (File.Exists(pdf))
                {
                    File.Delete(pdf);
                }
            }

        }

        //-------------------------------------------------------------------------------------------------------------------------------
        public static void VerySimpleReplaceText(string OrigFile, string ResultFile)
        {
            using (iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(OrigFile))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    byte[] contentBytes = reader.GetPageContent(i);
                    string contentString = PdfEncodings.ConvertToString(contentBytes, iTextSharp.text.pdf.PdfObject.TEXT_PDFDOCENCODING);
                    contentString = contentString.Replace("002800590044004F005800440057004C00520051000300320051004F005C0011000300260055004800440057004800470003005A004C0057004B0003002400560053005200560048001100330027002900110003002600520053005C0055004C004A004B005700030015001300130015001000150013001500140003002400560053005200560048000300330057005C0003002F005700470011", "");
                    reader.SetPageContent(i, PdfEncodings.ConvertToBytes(contentString, iTextSharp.text.pdf.PdfObject.TEXT_PDFDOCENCODING));
                }
                new iTextSharp.text.pdf.PdfStamper(reader, new FileStream(ResultFile, FileMode.Create, FileAccess.Write)).Close();
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            ofd_path_pdf_out.SelectedPath = Directory.GetCurrentDirectory() + @"\pdf_out";
            if (ofd_path_pdf_out.ShowDialog() == DialogResult.OK)
            {
                textBoxPath2PDF.Text = ofd_path_pdf_out.SelectedPath;
            }
        }

    }
}
