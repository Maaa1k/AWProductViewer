
namespace AWForm
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
            this.TBId = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.viewerControl1 = new AWProductViewer.ViewerControl();
            this.SuspendLayout();
            // 
            // TBId
            // 
            this.TBId.Location = new System.Drawing.Point(54, 464);
            this.TBId.Name = "TBId";
            this.TBId.Size = new System.Drawing.Size(100, 20);
            this.TBId.TabIndex = 1;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(175, 464);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // viewerControl1
            // 
            this.viewerControl1.Location = new System.Drawing.Point(12, 12);
            this.viewerControl1.Name = "viewerControl1";
            this.viewerControl1.Size = new System.Drawing.Size(296, 418);
            this.viewerControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 566);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.TBId);
            this.Controls.Add(this.viewerControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TBId;
        private System.Windows.Forms.Button searchButton;
        private AWProductViewer.ViewerControl viewerControl1;
    }
}

