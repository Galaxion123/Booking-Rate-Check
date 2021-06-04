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
            int count = (temp.Length - 1)/11;
            System.Diagnostics.Debug.WriteLine(count);
            Queue<Resv> resvs = new Queue<Resv>();
            while (count > 0)
            {
                resvs.Enqueue(new Resv() { reference_no = temp[i], conf_no = temp[i + 1], name = temp[i + 2], price = temp[i + 9] });
                i += 11;
                count--;
            }
            return resvs;
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
            int count = 1;
            Excel.Application Booking_Rates = new Excel.Application();
            Booking_Rates.Visible = false;

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
                Resv resv = orates.Peek();
                string ref_no = (string)(brates.Cells[i, "A"] as Excel.Range).Value.ToString();
                while (i < count)
                {
                    if (String.Equals(ref_no, resv.reference_no))
                    {
                        System.Diagnostics.Debug.WriteLine($"{ref_no} and {resv.reference_no}");
                        break;
                    }
                    i++;
                    ref_no = (string)(brates.Cells[i, "A"] as Excel.Range).Value.ToString();
                }
                orates.Dequeue();
            }

            Booking_rates_workbook.Close(false);
        }
    }
}
