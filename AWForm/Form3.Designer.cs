
namespace AWForm
{
    partial class Form3
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
            this.controlFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.generateButton = new System.Windows.Forms.Button();
            this.viewerControl2 = new AWProductViewer.ViewerControl();
            this.controlFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlFlowLayoutPanel
            // 
            this.controlFlowLayoutPanel.AutoScroll = true;
            this.controlFlowLayoutPanel.Controls.Add(this.viewerControl2);
            this.controlFlowLayoutPanel.Location = new System.Drawing.Point(73, 26);
            this.controlFlowLayoutPanel.Name = "controlFlowLayoutPanel";
            this.controlFlowLayoutPanel.Size = new System.Drawing.Size(888, 637);
            this.controlFlowLayoutPanel.TabIndex = 0;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(456, 679);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 0;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.generateButton_MouseClick);
            // 
            // viewerControl2
            // 
            this.viewerControl2.Location = new System.Drawing.Point(3, 3);
            this.viewerControl2.Name = "viewerControl2";
            this.viewerControl2.Size = new System.Drawing.Size(81, 26);
            this.viewerControl2.TabIndex = 1;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 714);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.controlFlowLayoutPanel);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.controlFlowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel controlFlowLayoutPanel;
        private System.Windows.Forms.Button generateButton;
        private AWProductViewer.ViewerControl viewerControl2;
    }
}