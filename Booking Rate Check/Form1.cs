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

        private void Parse_txt(string file_name)
        {
            int count = 0;

            string orates = File.ReadAllText(filetxt);
            string[] temp = orates.Split(separators);
            foreach (string booking in temp)
            {
                System.Diagnostics.Debug.WriteLine($"Substring: {booking}");
            }
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
            Excel.Application Booking_Rates = new Excel.Application();
            Booking_Rates.Visible = false;

            Excel.Workbook Booking_rates_workbook = Booking_Rates.Workbooks.Open(filexl);
            Excel.Sheets Booking_rates_sheet = Booking_rates_workbook.Worksheets;
            Excel.Worksheet brates = (Excel.Worksheet)Booking_rates_sheet.get_Item("Sheet1");

            Parse_txt(filetxt);
            Booking_rates_workbook.Close(false);
        }
    }
}
