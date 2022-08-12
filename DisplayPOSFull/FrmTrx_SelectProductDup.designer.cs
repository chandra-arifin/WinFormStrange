namespace ZFame
{
    partial class FrmTrx_SelectProductDup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panButton = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvGrid = new CustomDataGridView();
            this._ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panInfoProduct = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.panInfoProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // panButton
            // 
            this.panButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panButton.Controls.Add(this.btnClose);
            this.panButton.Controls.Add(this.btnSave);
            this.panButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panButton.Location = new System.Drawing.Point(0, 329);
            this.panButton.Name = "panButton";
            this.panButton.Size = new System.Drawing.Size(646, 32);
            this.panButton.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(75, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&OK";
            this.btnSave.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dgvGrid
            // 
            this.dgvGrid.AllowUserToAddRows = false;
            this.dgvGrid.AllowUserToResizeRows = false;
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._ProductID,
            this._Name});
            this.dgvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrid.Location = new System.Drawing.Point(0, 41);
            this.dgvGrid.MultiSelect = false;
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.ReadOnly = true;
            this.dgvGrid.RowHeadersVisible = false;
            this.dgvGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            this.dgvGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrid.Size = new System.Drawing.Size(646, 288);
            this.dgvGrid.TabIndex = 1;
            this.dgvGrid.DoubleClick += new System.EventHandler(this.dgvGrid_DoubleClick);
            this.dgvGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvGrid_KeyUp);
            // 
            // _ProductID
            // 
            this._ProductID.HeaderText = "Product ID";
            this._ProductID.Name = "_ProductID";
            this._ProductID.ReadOnly = true;
            this._ProductID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _Name
            // 
            this._Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._Name.HeaderText = "Product Name";
            this._Name.MinimumWidth = 200;
            this._Name.Name = "_Name";
            this._Name.ReadOnly = true;
            this._Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panInfoProduct
            // 
            this.panInfoProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panInfoProduct.Controls.Add(this.lblInfo);
            this.panInfoProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.panInfoProduct.Location = new System.Drawing.Point(0, 0);
            this.panInfoProduct.Name = "panInfoProduct";
            this.panInfoProduct.Size = new System.Drawing.Size(646, 41);
            this.panInfoProduct.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(3, 8);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(402, 24);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Please Select one Product below and Click OK";
            // 
            // FrmTrx_SelectProductDup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 361);
            this.ControlBox = false;
            this.Controls.Add(this.dgvGrid);
            this.Controls.Add(this.panInfoProduct);
            this.Controls.Add(this.panButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTrx_SelectProductDup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Product";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmTrx_SelectProductDup_FormClosed);
            this.panButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.panInfoProduct.ResumeLayout(false);
            this.panInfoProduct.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panButton;
        private CustomDataGridView dgvGrid;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panInfoProduct;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Name;
    }
}