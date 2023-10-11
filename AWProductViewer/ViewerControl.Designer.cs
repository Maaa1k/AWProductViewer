
namespace AWProductViewer
{
    partial class ViewerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PBProduct = new System.Windows.Forms.PictureBox();
            this.TBProductName = new System.Windows.Forms.TextBox();
            this.PNLSize = new System.Windows.Forms.FlowLayoutPanel();
            this.TBId = new System.Windows.Forms.TextBox();
            this.PNLColor = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.PBProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // PBProduct
            // 
            this.PBProduct.Location = new System.Drawing.Point(16, 19);
            this.PBProduct.Name = "PBProduct";
            this.PBProduct.Size = new System.Drawing.Size(264, 180);
            this.PBProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBProduct.TabIndex = 0;
            this.PBProduct.TabStop = false;
            // 
            // TBProductName
            // 
            this.TBProductName.Location = new System.Drawing.Point(28, 230);
            this.TBProductName.Name = "TBProductName";
            this.TBProductName.ReadOnly = true;
            this.TBProductName.Size = new System.Drawing.Size(237, 20);
            this.TBProductName.TabIndex = 1;
            // 
            // PNLSize
            // 
            this.PNLSize.Location = new System.Drawing.Point(161, 267);
            this.PNLSize.Name = "PNLSize";
            this.PNLSize.Size = new System.Drawing.Size(104, 103);
            this.PNLSize.TabIndex = 3;
            // 
            // TBId
            // 
            this.TBId.Location = new System.Drawing.Point(92, 386);
            this.TBId.Name = "TBId";
            this.TBId.ReadOnly = true;
            this.TBId.Size = new System.Drawing.Size(100, 20);
            this.TBId.TabIndex = 4;
            this.TBId.TextChanged += new System.EventHandler(this.TBId_TextChanged);
            // 
            // PNLColor
            // 
            this.PNLColor.Location = new System.Drawing.Point(28, 267);
            this.PNLColor.Name = "PNLColor";
            this.PNLColor.Size = new System.Drawing.Size(104, 103);
            this.PNLColor.TabIndex = 4;
            // 
            // ViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PNLColor);
            this.Controls.Add(this.TBId);
            this.Controls.Add(this.PNLSize);
            this.Controls.Add(this.TBProductName);
            this.Controls.Add(this.PBProduct);
            this.Name = "ViewerControl";
            this.Size = new System.Drawing.Size(296, 418);
            this.Load += new System.EventHandler(this.ViewerControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PBProduct;
        private System.Windows.Forms.TextBox TBProductName;
        private System.Windows.Forms.FlowLayoutPanel PNLSize;
        private System.Windows.Forms.TextBox TBId;
        private System.Windows.Forms.FlowLayoutPanel PNLColor;
    }
}
