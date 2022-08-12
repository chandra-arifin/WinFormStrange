namespace ZFame
{
    partial class FrmFullProduct
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lblStokVal = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.txtFontText = new System.Windows.Forms.TextBox();
            this.txtFontLabel = new System.Windows.Forms.TextBox();
            this.cboSettings = new System.Windows.Forms.ComboBox();
            this.lblFontLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFontButton = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panGrid = new System.Windows.Forms.Panel();
            this.dgvGrid = new System.Windows.Forms.DataGridView();
            this.panTop = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNmMerkBarang = new System.Windows.Forms.TextBox();
            this.txtNmSubCat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNmCat = new System.Windows.Forms.TextBox();
            this.txtNmProduk = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.panTop.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Location = new System.Drawing.Point(10, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(145, 55);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblStokVal
            // 
            this.lblStokVal.AutoSize = true;
            this.lblStokVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStokVal.ForeColor = System.Drawing.Color.Red;
            this.lblStokVal.Location = new System.Drawing.Point(617, 569);
            this.lblStokVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStokVal.Name = "lblStokVal";
            this.lblStokVal.Size = new System.Drawing.Size(0, 54);
            this.lblStokVal.TabIndex = 14;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLocation.ForeColor = System.Drawing.Color.Red;
            this.lblLocation.Location = new System.Drawing.Point(491, 173);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(0, 63);
            this.lblLocation.TabIndex = 4;
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSettings.Location = new System.Drawing.Point(316, 5);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(145, 55);
            this.btnSettings.TabIndex = 16;
            this.btnSettings.Text = "&Setting";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Visible = false;
            this.btnSettings.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFontText
            // 
            this.txtFontText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFontText.Location = new System.Drawing.Point(839, 25);
            this.txtFontText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFontText.MaxLength = 20;
            this.txtFontText.Name = "txtFontText";
            this.txtFontText.Size = new System.Drawing.Size(48, 26);
            this.txtFontText.TabIndex = 21;
            this.txtFontText.Text = "35";
            this.txtFontText.Visible = false;
            // 
            // txtFontLabel
            // 
            this.txtFontLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFontLabel.Location = new System.Drawing.Point(768, 25);
            this.txtFontLabel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFontLabel.MaxLength = 20;
            this.txtFontLabel.Name = "txtFontLabel";
            this.txtFontLabel.Size = new System.Drawing.Size(46, 26);
            this.txtFontLabel.TabIndex = 19;
            this.txtFontLabel.Text = "40";
            this.txtFontLabel.Visible = false;
            // 
            // cboSettings
            // 
            this.cboSettings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboSettings.FormattingEnabled = true;
            this.cboSettings.Location = new System.Drawing.Point(479, 17);
            this.cboSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboSettings.Name = "cboSettings";
            this.cboSettings.Size = new System.Drawing.Size(173, 37);
            this.cboSettings.TabIndex = 17;
            this.cboSettings.Visible = false;
            this.cboSettings.SelectedIndexChanged += new System.EventHandler(this.cboSettings_SelectedIndexChanged);
            // 
            // lblFontLabel
            // 
            this.lblFontLabel.AutoSize = true;
            this.lblFontLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFontLabel.Location = new System.Drawing.Point(660, 28);
            this.lblFontLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFontLabel.Name = "lblFontLabel";
            this.lblFontLabel.Size = new System.Drawing.Size(77, 20);
            this.lblFontLabel.TabIndex = 18;
            this.lblFontLabel.Text = "Font Size";
            this.lblFontLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(816, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "-";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(893, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "-";
            this.label2.Visible = false;
            // 
            // txtFontButton
            // 
            this.txtFontButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFontButton.Location = new System.Drawing.Point(916, 25);
            this.txtFontButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFontButton.MaxLength = 20;
            this.txtFontButton.Name = "txtFontButton";
            this.txtFontButton.Size = new System.Drawing.Size(48, 26);
            this.txtFontButton.TabIndex = 23;
            this.txtFontButton.Text = "20";
            this.txtFontButton.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panGrid);
            this.panel1.Controls.Add(this.panTop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1286, 707);
            this.panel1.TabIndex = 24;
            // 
            // panGrid
            // 
            this.panGrid.Controls.Add(this.dgvGrid);
            this.panGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panGrid.Location = new System.Drawing.Point(0, 95);
            this.panGrid.Name = "panGrid";
            this.panGrid.Size = new System.Drawing.Size(1286, 612);
            this.panGrid.TabIndex = 1;
            // 
            // dgvGrid
            // 
            this.dgvGrid.AllowUserToAddRows = false;
            this.dgvGrid.AllowUserToDeleteRows = false;
            this.dgvGrid.AllowUserToOrderColumns = true;
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrid.Location = new System.Drawing.Point(0, 0);
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.ReadOnly = true;
            this.dgvGrid.RowTemplate.Height = 35;
            this.dgvGrid.Size = new System.Drawing.Size(1286, 612);
            this.dgvGrid.TabIndex = 4;
            this.dgvGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvGrid_KeyUp);
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.label6);
            this.panTop.Controls.Add(this.label5);
            this.panTop.Controls.Add(this.label4);
            this.panTop.Controls.Add(this.txtNmMerkBarang);
            this.panTop.Controls.Add(this.txtNmSubCat);
            this.panTop.Controls.Add(this.label3);
            this.panTop.Controls.Add(this.txtNmCat);
            this.panTop.Controls.Add(this.txtNmProduk);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(1286, 95);
            this.panTop.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(672, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Merk Barang (CTRL+4)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(449, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Sub Category (CTRL+3)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Category (CTRL+2)";
            // 
            // txtNmMerkBarang
            // 
            this.txtNmMerkBarang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNmMerkBarang.Location = new System.Drawing.Point(674, 49);
            this.txtNmMerkBarang.MaxLength = 255;
            this.txtNmMerkBarang.Name = "txtNmMerkBarang";
            this.txtNmMerkBarang.Size = new System.Drawing.Size(201, 29);
            this.txtNmMerkBarang.TabIndex = 3;
            this.txtNmMerkBarang.TextChanged += new System.EventHandler(this.txtNmMerkBarang_TextChanged);
            this.txtNmMerkBarang.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNmMerkBarang_KeyUp);
            // 
            // txtNmSubCat
            // 
            this.txtNmSubCat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNmSubCat.Location = new System.Drawing.Point(451, 49);
            this.txtNmSubCat.MaxLength = 255;
            this.txtNmSubCat.Name = "txtNmSubCat";
            this.txtNmSubCat.Size = new System.Drawing.Size(201, 29);
            this.txtNmSubCat.TabIndex = 2;
            this.txtNmSubCat.TextChanged += new System.EventHandler(this.txtNmSubCat_TextChanged);
            this.txtNmSubCat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNmSubCat_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nama Produk (CTRL+1)";
            // 
            // txtNmCat
            // 
            this.txtNmCat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNmCat.Location = new System.Drawing.Point(232, 49);
            this.txtNmCat.MaxLength = 255;
            this.txtNmCat.Name = "txtNmCat";
            this.txtNmCat.Size = new System.Drawing.Size(201, 29);
            this.txtNmCat.TabIndex = 1;
            this.txtNmCat.TextChanged += new System.EventHandler(this.txtNmCat_TextChanged);
            this.txtNmCat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNmCat_KeyUp);
            // 
            // txtNmProduk
            // 
            this.txtNmProduk.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNmProduk.Location = new System.Drawing.Point(12, 49);
            this.txtNmProduk.MaxLength = 255;
            this.txtNmProduk.Name = "txtNmProduk";
            this.txtNmProduk.Size = new System.Drawing.Size(201, 29);
            this.txtNmProduk.TabIndex = 0;
            this.txtNmProduk.TextChanged += new System.EventHandler(this.txtNmProduk_TextChanged);
            this.txtNmProduk.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNmProduk_KeyUp);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnSettings);
            this.panel2.Controls.Add(this.cboSettings);
            this.panel2.Controls.Add(this.lblFontLabel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtFontLabel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtFontButton);
            this.panel2.Controls.Add(this.txtFontText);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 707);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1286, 65);
            this.panel2.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRefresh.Location = new System.Drawing.Point(163, 3);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(145, 55);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FrmFullProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 772);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblStokVal);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmFullProduct";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblStokVal;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.TextBox txtFontText;
        private System.Windows.Forms.TextBox txtFontLabel;
        private System.Windows.Forms.ComboBox cboSettings;
        private System.Windows.Forms.Label lblFontLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFontButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panGrid;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.DataGridView dgvGrid;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtNmProduk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNmMerkBarang;
        private System.Windows.Forms.TextBox txtNmSubCat;
        private System.Windows.Forms.TextBox txtNmCat;
    }
}

