namespace NanCrm.Setup
{
    partial class Country
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
            this.objList = new BrightIdeasSoftware.ObjectListView();
            this.olvcID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcFName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcAlias = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcCaptial = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.objList)).BeginInit();
            this.SuspendLayout();
            // 
            // objList
            // 
            this.objList.AllColumns.Add(this.olvcID);
            this.objList.AllColumns.Add(this.olvcName);
            this.objList.AllColumns.Add(this.olvcFName);
            this.objList.AllColumns.Add(this.olvcAlias);
            this.objList.AllColumns.Add(this.olvcCaptial);
            this.objList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcID,
            this.olvcName,
            this.olvcFName,
            this.olvcAlias,
            this.olvcCaptial});
            this.objList.Location = new System.Drawing.Point(12, 12);
            this.objList.Name = "objList";
            this.objList.Size = new System.Drawing.Size(573, 326);
            this.objList.TabIndex = 0;
            this.objList.UseCompatibleStateImageBehavior = false;
            this.objList.View = System.Windows.Forms.View.Details;
            // 
            // olvcID
            // 
            this.olvcID.Text = "#";
            this.olvcID.Width = 36;
            // 
            // olvcName
            // 
            this.olvcName.Text = "国家";
            this.olvcName.Width = 137;
            // 
            // olvcFName
            // 
            this.olvcFName.Text = "外文名";
            this.olvcFName.Width = 178;
            // 
            // olvcAlias
            // 
            this.olvcAlias.Text = "简写";
            this.olvcAlias.Width = 85;
            // 
            // olvcCaptial
            // 
            this.olvcCaptial.Text = "首都";
            this.olvcCaptial.Width = 114;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 353);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 353);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // Country
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 388);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.objList);
            this.Name = "Country";
            this.Text = "Country";
            this.Load += new System.EventHandler(this.Country_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView objList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private BrightIdeasSoftware.OLVColumn olvcID;
        private BrightIdeasSoftware.OLVColumn olvcName;
        private BrightIdeasSoftware.OLVColumn olvcFName;
        private BrightIdeasSoftware.OLVColumn olvcAlias;
        private BrightIdeasSoftware.OLVColumn olvcCaptial;
    }
}