namespace Metrix
{
    partial class Currency
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Currency));
            this.webBrowseCurrency = new System.Windows.Forms.WebBrowser();
            this.btnEnableCurrency = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowseCurrency
            // 
            this.webBrowseCurrency.Location = new System.Drawing.Point(-2, 47);
            this.webBrowseCurrency.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowseCurrency.Name = "webBrowseCurrency";
            this.webBrowseCurrency.Size = new System.Drawing.Size(402, 211);
            this.webBrowseCurrency.TabIndex = 0;
            this.webBrowseCurrency.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // btnEnableCurrency
            // 
            this.btnEnableCurrency.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnableCurrency.Location = new System.Drawing.Point(12, 8);
            this.btnEnableCurrency.Name = "btnEnableCurrency";
            this.btnEnableCurrency.Size = new System.Drawing.Size(275, 33);
            this.btnEnableCurrency.TabIndex = 1;
            this.btnEnableCurrency.Text = "Enable Currency Converter";
            this.btnEnableCurrency.UseVisualStyleBackColor = true;
            this.btnEnableCurrency.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(304, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 33);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Currency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 259);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnEnableCurrency);
            this.Controls.Add(this.webBrowseCurrency);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Currency";
            this.Text = "Online Currency Converter";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowseCurrency;
        private System.Windows.Forms.Button btnEnableCurrency;
        private System.Windows.Forms.Button btnExit;
    }
}