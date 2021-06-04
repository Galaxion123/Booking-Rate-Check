
namespace Booking_Rate_Check
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ExcelFile = new System.Windows.Forms.TextBox();
            this.ExcelBrowse = new System.Windows.Forms.Button();
            this.TXTBrowse = new System.Windows.Forms.Button();
            this.TXTFile = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.CheckRatesButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Export = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // ExcelFile
            // 
            this.ExcelFile.Location = new System.Drawing.Point(12, 19);
            this.ExcelFile.Name = "ExcelFile";
            this.ExcelFile.ReadOnly = true;
            this.ExcelFile.Size = new System.Drawing.Size(440, 20);
            this.ExcelFile.TabIndex = 0;
            this.ExcelFile.Text = "Excel Report";
            // 
            // ExcelBrowse
            // 
            this.ExcelBrowse.Location = new System.Drawing.Point(458, 19);
            this.ExcelBrowse.Name = "ExcelBrowse";
            this.ExcelBrowse.Size = new System.Drawing.Size(86, 20);
            this.ExcelBrowse.TabIndex = 1;
            this.ExcelBrowse.Text = "Select Excel File";
            this.ExcelBrowse.UseVisualStyleBackColor = true;
            this.ExcelBrowse.Click += new System.EventHandler(this.ExcelBrowse_Click);
            // 
            // TXTBrowse
            // 
            this.TXTBrowse.Location = new System.Drawing.Point(458, 60);
            this.TXTBrowse.Name = "TXTBrowse";
            this.TXTBrowse.Size = new System.Drawing.Size(86, 20);
            this.TXTBrowse.TabIndex = 3;
            this.TXTBrowse.Text = "Select .txt file";
            this.TXTBrowse.UseVisualStyleBackColor = true;
            this.TXTBrowse.Click += new System.EventHandler(this.TXTBrowse_Click);
            // 
            // TXTFile
            // 
            this.TXTFile.Location = new System.Drawing.Point(12, 60);
            this.TXTFile.Name = "TXTFile";
            this.TXTFile.ReadOnly = true;
            this.TXTFile.Size = new System.Drawing.Size(440, 20);
            this.TXTFile.TabIndex = 2;
            this.TXTFile.Text = ".txt Report";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel files|*.xls";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Filter = "txt files|*.txt";
            // 
            // CheckRatesButton
            // 
            this.CheckRatesButton.Enabled = false;
            this.CheckRatesButton.Location = new System.Drawing.Point(458, 102);
            this.CheckRatesButton.Name = "CheckRatesButton";
            this.CheckRatesButton.Size = new System.Drawing.Size(86, 20);
            this.CheckRatesButton.TabIndex = 4;
            this.CheckRatesButton.Text = "Check Rates";
            this.CheckRatesButton.UseVisualStyleBackColor = true;
            this.CheckRatesButton.Click += new System.EventHandler(this.CheckRatesButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(12, 102);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(86, 20);
            this.QuitButton.TabIndex = 5;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 139);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(532, 214);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // Export
            // 
            this.Export.Enabled = false;
            this.Export.Location = new System.Drawing.Point(399, 363);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(145, 20);
            this.Export.TabIndex = 7;
            this.Export.Text = "Export as .txt and quit";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "txt files|*.txt";
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 395);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.CheckRatesButton);
            this.Controls.Add(this.TXTBrowse);
            this.Controls.Add(this.TXTFile);
            this.Controls.Add(this.ExcelBrowse);
            this.Controls.Add(this.ExcelFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Booking Rate Check";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ExcelFile;
        private System.Windows.Forms.Button ExcelBrowse;
        private System.Windows.Forms.Button TXTBrowse;
        private System.Windows.Forms.TextBox TXTFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button CheckRatesButton;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

