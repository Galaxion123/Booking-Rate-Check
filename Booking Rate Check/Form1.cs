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
using Excel = Microsoft.Office.Interop.Excel;

namespace Booking_Rate_Check
{
    public partial class Form1 : Form
    {
        public string filexl;
        public string filetxt;
        public char[] separators = new char[] { '\t', ':', ';', '|', '$', '.', '\n'};

        class Resv
        {
            public string reference_no;
            public string conf_no;
            public string name;
            public string price;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Check_filenames()
        {
            if (filexl != null && filetxt != null)
            {
                CheckRatesButton.Enabled = true;
            }
            else
            {
                CheckRatesButton.Enabled = false;
            }
        }

        private Queue<Resv> Parse_txt(string file_name)
        {
            int i = 0;
            string orates = File.ReadAllText(filetxt);
            string[] temp = orates.Split(separators);
            int count = (temp.Length - 1) / 11;
            Queue<Resv> resvs = new Queue<Resv>();
            while (count > 0)
            {
                resvs.Enqueue(new Resv() { reference_no = temp[i], conf_no = temp[i + 1], name = temp[i + 2], price = temp[i + 9] });
                i += 11;
                count--;
            }
            return resvs;
        }

        private int index_search(string to_search)
        {
            int output;
            if ((output = to_search.IndexOf(".")) < 0)
                output = to_search.IndexOf(" ");
            return output;
        }

        private string Strim(string price)
        { 
            string output = price.Substring(0, index_search(price));
            return output;
        }

        private void ExcelBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                filexl = openFileDialog1.FileName;
                ExcelFile.Text = filexl;
            }
            Check_filenames();
        }

        private void TXTBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                filetxt = openFileDialog2.FileName;
                TXTFile.Text = filetxt;
            }
            Check_filenames();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckRatesButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int count = 1;
            int check = 0;
            Excel.Application Booking_Rates = new Excel.Application();
            Booking_Rates.Visible = false;
            string output = "Booking conf_no | Opera conf_no | Booking Price | Opera Price | Opera Guest Name | Разница между ценой в Опере и ценой в Букинге |\n\n";

            Excel.Workbook Booking_rates_workbook = Booking_Rates.Workbooks.Open(filexl);
            Excel.Sheets Booking_rates_sheet = Booking_rates_workbook.Worksheets;
            Excel.Worksheet brates = (Excel.Worksheet)Booking_rates_sheet.get_Item("Sheet1");

            string value = (string)(brates.Cells[count, "B"] as Excel.Range).Value;
            while (value != null)
            {
                count++;
                value = (string)(brates.Cells[count, "B"] as Excel.Range).Value;
            }
            count--;

            Queue<Resv> orates = Parse_txt(filetxt);
            while (orates.Count > 0)
            {
                int i = 2;
                int diff, bp, op;
                Resv resv = orates.Peek();
                string ref_no = (brates.Cells[i, "A"] as Excel.Range).Value.ToString();
                string price;
                while (i < count)
                {
                    if (String.Equals(ref_no, resv.reference_no))
                    {
                        check++;
                        price = Strim((brates.Cells[i, "M"] as Excel.Range).Value.ToString());
                        if (!String.Equals(price, resv.price))
                        {
                            bp = Int32.Parse(price);
                            op = Int32.Parse(resv.price);
                            diff = op - bp;
                            output = String.Concat(output, resv.reference_no, " | ", resv.conf_no, " | ", price, " | ", resv.price, " | ", resv.name, " | ", diff.ToString(), " |\n\n");
                        }
                        break;
                    }
                    i++;
                    ref_no = (brates.Cells[i, "A"] as Excel.Range).Value.ToString();
                }
                orates.Dequeue();
            }
            if (check < 3)
                output = String.Concat(output, "Совпадений номеров подтверждений не найдено, проверьте сравниваемые файлы и попробуйте снова !");

            Booking_rates_workbook.Close(false);
            richTextBox1.Text = output;
            Cursor.Current = Cursors.Default;
            if (check != 0)
                Export.Enabled = true;
            else
                Export.Enabled = false;
        }

        private void Export_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                MessageBox.Show("Файл сохранен успешно.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
