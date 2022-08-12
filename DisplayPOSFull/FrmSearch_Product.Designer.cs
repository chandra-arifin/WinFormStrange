namespace ZFame
{
    partial class FrmSearch_Product
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblProductID = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.dgvGrid = new ZFame.FrmSearch_Product.CustomDataGridView();
            this._KdProduk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._NmProduk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._HargaAkhir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.lblProductID);
            this.panel1.Controls.Add(this.lblProductName);
            this.panel1.Controls.Add(this.txtProductID);
            this.panel1.Controls.Add(this.txtProductName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 314);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 103);
            this.panel1.TabIndex = 0;
            // 
            // btnEdit
            // 
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(84, 71);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(64, 23);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "&Cancel";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(211, 34);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.EnabledChanged += new System.EventHandler(this.btnRefresh_EnabledChanged);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(12, 71);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(64, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&OK";
            this.btnOK.EnabledChanged += new System.EventHandler(this.btnOK_EnabledChanged);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Location = new System.Drawing.Point(12, 40);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(58, 13);
            this.lblProductID.TabIndex = 2;
            this.lblProductID.Text = "Product ID";
            this.lblProductID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(12, 12);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(75, 13);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Product N&ame";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(93, 37);
            this.txtProductID.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtProductID.MaxLength = 10;
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(112, 20);
            this.txtProductID.TabIndex = 3;
            this.txtProductID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductID_KeyPress);
            this.txtProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProductID_KeyUp);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(93, 9);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtProductName.MaxLength = 255;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(185, 20);
            this.txtProductName.TabIndex = 1;
            this.txtProductName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductName_KeyPress);
            this.txtProductName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProductName_KeyUp);
            // 
            // dgvGrid
            // 
            this.dgvGrid.AllowUserToAddRows = false;
            this.dgvGrid.AllowUserToDeleteRows = false;
            this.dgvGrid.AllowUserToOrderColumns = true;
            this.dgvGrid.AllowUserToResizeRows = false;
            this.dgvGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._KdProduk,
            this._NmProduk,
            this._HargaAkhir});
            this.dgvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvGrid.Location = new System.Drawing.Point(0, 0);
            this.dgvGrid.MultiSelect = false;
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.ReadOnly = true;
            this.dgvGrid.RowHeadersVisible = false;
            this.dgvGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Gold;
            this.dgvGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrid.Size = new System.Drawing.Size(646, 314);
            this.dgvGrid.TabIndex = 1;
            this.dgvGrid.DoubleClick += new System.EventHandler(this.dgvGrid_DoubleClick);
            this.dgvGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvGrid_KeyUp);
            // 
            // _KdProduk
            // 
            this._KdProduk.HeaderText = "Product ID";
            this._KdProduk.Name = "_KdProduk";
            this._KdProduk.ReadOnly = true;
            // 
            // _NmProduk
            // 
            this._NmProduk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._NmProduk.HeaderText = "Product Name";
            this._NmProduk.Name = "_NmProduk";
            this._NmProduk.ReadOnly = true;
            this._NmProduk.Width = 443;
            // 
            // _HargaAkhir
            // 
            this._HargaAkhir.HeaderText = "Harga Akhir";
            this._HargaAkhir.Name = "_HargaAkhir";
            this._HargaAkhir.ReadOnly = true;
            // 
            // FrmSearch_Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnEdit;
            this.ClientSize = new System.Drawing.Size(646, 417);
            this.Controls.Add(this.dgvGrid);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSearch_Product";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Product";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSearch_Product_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomDataGridView dgvGrid;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _KdProduk;
        private System.Windows.Forms.DataGridViewTextBoxColumn _NmProduk;
        private System.Windows.Forms.DataGridViewTextBoxColumn _HargaAkhir;
    }
}