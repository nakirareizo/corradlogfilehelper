namespace CorradLogFileHelper
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnGet = new System.Windows.Forms.Button();
            this.dgLogFile = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgLogFile)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(12, 27);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(99, 23);
            this.btnGet.TabIndex = 0;
            this.btnGet.Text = "Get Log File";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // dgLogFile
            // 
            this.dgLogFile.AllowUserToAddRows = false;
            this.dgLogFile.AllowUserToDeleteRows = false;
            this.dgLogFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLogFile.Location = new System.Drawing.Point(12, 56);
            this.dgLogFile.Name = "dgLogFile";
            this.dgLogFile.RowTemplate.Height = 24;
            this.dgLogFile.Size = new System.Drawing.Size(1059, 520);
            this.dgLogFile.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 588);
            this.Controls.Add(this.dgLogFile);
            this.Controls.Add(this.btnGet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Corrad Log File Helper";
            ((System.ComponentModel.ISupportInitialize)(this.dgLogFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.DataGridView dgLogFile;
    }
}

