namespace Nan.Controls
{
    partial class TextBoxEx
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
            this.txtBox = new System.Windows.Forms.TextBox();
            this.btnChoose = new System.Windows.Forms.PictureBox();
            this.btnLink = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnChoose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLink)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(14, 0);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(140, 20);
            this.txtBox.TabIndex = 1;
            // 
            // btnChoose
            // 
            this.btnChoose.Image = global::Nan.Controls.Properties.Resources.ButtonChoose;
            this.btnChoose.Location = new System.Drawing.Point(154, 3);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(13, 13);
            this.btnChoose.TabIndex = 2;
            this.btnChoose.TabStop = false;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnLink
            // 
            this.btnLink.Image = global::Nan.Controls.Properties.Resources.ButtonLink;
            this.btnLink.Location = new System.Drawing.Point(0, 5);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(14, 10);
            this.btnLink.TabIndex = 0;
            this.btnLink.TabStop = false;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // TextBoxEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.btnLink);
            this.Name = "TextBoxEx";
            this.Size = new System.Drawing.Size(170, 20);
            this.SizeChanged += new System.EventHandler(this.TextBoxEx_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.btnChoose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLink)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnLink;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.PictureBox btnChoose;
    }
}
