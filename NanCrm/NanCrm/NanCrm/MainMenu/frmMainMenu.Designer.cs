namespace NanCrm
{
    partial class frmMainMenu
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
            this.mainMenu = new Nan.Controls.TreeMenu();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenu.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.mainMenu.FullRowSelect = true;
            this.mainMenu.GradientFolderColorFrom = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.mainMenu.GradientFolderColorTo = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(166)))), ((int)(((byte)(223)))));
            this.mainMenu.GradientHoverColorFrom = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.mainMenu.GradientHoverColorTo = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(192)))), ((int)(((byte)(91)))));
            this.mainMenu.GradientLeafColorFrom = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            this.mainMenu.GradientLeafColorTo = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(182)))), ((int)(((byte)(239)))));
            this.mainMenu.GradientSelectedColorFrom = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(218)))), ((int)(((byte)(124)))));
            this.mainMenu.GradientSelectedColorTo = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(8)))));
            this.mainMenu.HideSelection = false;
            this.mainMenu.HotTracking = true;
            this.mainMenu.ItemHeight = 30;
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.ShowLines = false;
            this.mainMenu.Size = new System.Drawing.Size(236, 445);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.mainMenu_NodeMouseClick);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 445);
            this.Controls.Add(this.mainMenu);
            this.Name = "frmMainMenu";
            this.Text = "frmMainMenu";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Nan.Controls.TreeMenu mainMenu;
    }
}