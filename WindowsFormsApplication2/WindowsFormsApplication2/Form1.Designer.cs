namespace WindowsFormsApplication2
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
            this.comboEx2 = new WindowsFormsApplication2.ComboEx();
            this.comboEx1 = new WindowsFormsApplication2.ComboEx();
            this.SuspendLayout();
            // 
            // comboEx2
            // 
            this.comboEx2.DesField = "WhsName";
            this.comboEx2.FormattingEnabled = true;
            this.comboEx2.KeyField = "WhsCode";
            this.comboEx2.Location = new System.Drawing.Point(82, 42);
            this.comboEx2.Name = "comboEx2";
            this.comboEx2.Size = new System.Drawing.Size(121, 21);
            this.comboEx2.TabIndex = 4;
            this.comboEx2.TableSource = "OWHS";
            // 
            // comboEx1
            // 
            this.comboEx1.DesField = null;
            this.comboEx1.FormattingEnabled = true;
            this.comboEx1.KeyField = null;
            this.comboEx1.Location = new System.Drawing.Point(82, 15);
            this.comboEx1.Name = "comboEx1";
            this.comboEx1.Size = new System.Drawing.Size(121, 21);
            this.comboEx1.TabIndex = 3;
            this.comboEx1.TableSource = "OBIN";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 262);
            this.Controls.Add(this.comboEx2);
            this.Controls.Add(this.comboEx1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboEx comboEx1;
        private ComboEx comboEx2;

    }
}

