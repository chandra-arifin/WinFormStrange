using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using ZFame.Classes;

namespace ZFame
{
    public partial class FrmFullProduct : Form
    {
        #region Private Variables

        private const int
            IDX_NMPRODUK = 0,
            IDX_CATEGORY = 1,
            IDX_SUBCATEGORY = 2,
            IDX_MERKBARANG = 3;

        private const string
            COL_NMPRODUK = "[Nama Produk]",
            COL_CATEGORY = "[Category]",
            COL_SUBCATEGORY = "[Sub Category]",
            COL_MERKBARANG = "[Merk Barang]";

        private const int COLUMN_TETAP_PRODUCT = 5;

        public BindingSource bsSource = new();
        public DataTable dtTable = new();

        private readonly NumberFormatInfo nFi;
        private GlobalFunction gFunc = new GlobalFunction();
        private string strTitle, strUserID, strKdCabang;
        private const int
            idxProductID = 0,
            idxSearchProductID = 1,
            idxProductName = 2,
            idxQty = 3,
            PJG_PRODUCTID = 10;
        private const string KODE_STS_OPENING = "OP";
        private readonly MessageBoxDefaultButton defButton;
        private readonly string
            PATH_IMAGES = "", KODE_WAREHOUSE = "";

        #endregion


        public FrmFullProduct()
        {
            InitializeComponent();

            dgvGrid.RowHeadersVisible = true;
            dgvGrid.RowHeadersDefaultCellStyle.Padding = new Padding(dgvGrid.RowHeadersWidth);
            dgvGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(DgvGrid_RowPostPaint);


            defButton = InfoApp.Default_Messagebox_Button;
            PATH_IMAGES = InfoApp.Path_Picture;
            KODE_WAREHOUSE = InfoApp.WarehouseIDDefaultPenjualan;
            Title = InfoApp.Title;
            KdCabang = InfoApp.BranchID;
            UserID = InfoApp.UserID;
            nFi = InfoApp.NFormatInfo;

            cboSettings.Items.Add("800x600");
            cboSettings.Items.Add("1024x800");
            cboSettings.Items.Add("Custom");

            cboSettings.SelectedIndex = 0;
            txtFontButton.Visible = txtFontLabel.Visible = txtFontText.Visible = 
                lblFontLabel.Visible = label1.Visible = label2.Visible = false;

            LoadWarehouse(KdCabang);
        }

        private void DgvGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (sender is DataGridView grid)
            {
                string rowIdx = (e.RowIndex + 1).ToString();

                using var centerFormat = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                Rectangle headerBounds = new(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
                using Font newFont = new("Tahoma", 8, FontStyle.Bold);
                e.Graphics.DrawString(rowIdx, newFont, SystemBrushes.ControlText, headerBounds, centerFormat);
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //FrmSearch_Product frmSearch = new FrmSearch_Product();

            //frmSearch.ShowDialog();

            //if (frmSearch.DialogResult == DialogResult.OK)
            //{
            //    txtProductID.Text = frmSearch._ProductID;
            //    txtProductNameVal.Text = frmSearch._ProductName;
            //    txtProductID_KeyPress(this, new KeyPressEventArgs(KeysENTER));
            //}
            //txtProductID.Focus();

            //frmSearch = null;
        }

        private void LoadWarehouse(string KdCabang)
        {
            //try
            //{
            //    //List<ArrayWarehouse> arrWarehouse = new List<ArrayWarehouse>();

            //    dgvGrid.Columns.Clear();
            //    dgvGrid.AllowUserToAddRows = false;
            //    dgvGrid.AllowUserToDeleteRows = false;

            //    using (SqlConnection sqlCnn = new SqlConnection(ZFame.Classes.clsVarProgram.DB_CONN_STRING))
            //    {
            //        int iID = 0, iDesc = 0;

            //        using (SqlCommand sqlCmd = new SqlCommand())
            //        {
            //            sqlCmd.Connection = sqlCnn;
            //            sqlCmd.CommandType = CommandType.StoredProcedure;
            //            sqlCmd.CommandText = "Get_Warehouse";
            //            sqlCmd.Parameters.Add("@KdCabang", SqlDbType.VarChar, 5).Value = KdCabang;

            //            sqlCnn.Open();

            //            using (SqlDataReader sqlDR = sqlCmd.ExecuteReader())
            //            {
            //                if (sqlDR.Read())
            //                {
            //                    iID = sqlDR.GetOrdinal("KdWarehouse");
            //                    iDesc = sqlDR.GetOrdinal("NmWarehouse");

            //                    do
            //                    {
            //                        string colName = sqlDR.GetString(iID),
            //                            colDesc = sqlDR.GetString(iDesc);

            //                        if (colDesc.ToUpper().Contains("RETUR") || colDesc.ToUpper().Contains("MOBIL")) continue;

            //                        dgvGrid.Columns.Add(colName, colDesc);

            //                        //dgvGrid.Columns[colName].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //                        dgvGrid.Columns[colName].SortMode = DataGridViewColumnSortMode.NotSortable;

            //                        //arrWarehouse.Add(new ArrayWarehouse(sqlDR.GetString(iID), sqlDR.GetString(iDesc)));
            //                    }
            //                    while (sqlDR.Read());
            //                }
            //            }
            //        }

            //        sqlCnn.Close();
            //    }

            //    //if (arrWarehouse.Count > 0)
            //    //{

            //    //    cboWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
            //    //    cboWarehouse.DisplayMember = DISP_WAREHOUSE;
            //    //    cboWarehouse.ValueMember = VAL_WAREHOUSE;
            //    //    cboWarehouse.DataSource = arrWarehouse;
            //    //    //cboWarehouse.Text = KODE_WAR_PENJUALAN;
            //    //    cboWarehouse.SelectedValue = KdWarehouse;
            //    //}
            //    //else
            //    //{
            //    //    dgvGrid.Columns.Clear();
            //    //}

            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show("Cannot Load Data!" + Environment.NewLine + Environment.NewLine +
            //        exc.Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tes()
        {
            string cnnString = @"Data Source=.\\SQL2019;Database=VictoryMotorDb;Integrated Security=False;Connect Timeout=30; User Instance=False;User ID=pajakpt;Password=LoginPajak123";
            string queueName = "ProductChangeNotificationService";


            NotificationExample a = new();
            a.StartNotification(ZFame.Classes.clsVarProgram.DB_CONN_STRING, queueName);
            a.StopNotification(cnnString, queueName);
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dtTable.Rows.Clear();

            try
            {
                //tes();

                using SqlConnection sqlCnn = new(ZFame.Classes.clsVarProgram.DB_CONN_STRING);
                using SqlCommand sqlCmd = new();
                sqlCmd.Connection = sqlCnn;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "Get_ProductForDisplay";
                sqlCmd.Parameters.Add("@PriceLevel", SqlDbType.Int).Value = InfoApp.PRICE_LEVEL;

                sqlCnn.Open();

                SqlDataAdapter sqlAdapter = new();

                sqlAdapter.SelectCommand = sqlCmd;
                sqlAdapter.Fill(dtTable);

                bsSource.DataSource = dtTable;
                
                dgvGrid.DataSource = bsSource;

                dgvGrid.Columns[IDX_CATEGORY].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvGrid.Columns[IDX_SUBCATEGORY].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvGrid.Columns[IDX_MERKBARANG].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvGrid.Columns[IDX_NMPRODUK].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 1; i <= InfoApp.PRICE_LEVEL; i++)
                {
                    dgvGrid.Columns[COLUMN_TETAP_PRODUCT + i - 1].HeaderText = $"Harga {i}";
                    dgvGrid.Columns[COLUMN_TETAP_PRODUCT + i - 1].ValueType = typeof(double);
                    dgvGrid.Columns[COLUMN_TETAP_PRODUCT + i - 1].DefaultCellStyle.Format = "N0";

                }

                txtNmProduk.Focus();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Cannot Load Data!" + Environment.NewLine + Environment.NewLine +
                    exc.Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetFilterString()
        {
            StringBuilder tmpStrBuilder = new();
            bool isFilter = false;

            if (txtNmCat.Text.Length > 0)
            {
                tmpStrBuilder.Append($"{COL_CATEGORY} Like '%" + txtNmCat.Text + "%'");
                isFilter = true;
            }

            if (isFilter)
            {
                tmpStrBuilder.Append(" And ");
                isFilter = false;
            }

            if (txtNmSubCat.Text.Length > 0)
            {
                tmpStrBuilder.Append($"{COL_SUBCATEGORY} Like '%" + txtNmSubCat.Text + "%'");
                isFilter = true;
            }

            if (isFilter)
            {
                tmpStrBuilder.Append(" And ");
                isFilter = false;
            }

            if (txtNmMerkBarang.Text.Length > 0)
            {
                tmpStrBuilder.Append($"{COL_MERKBARANG} Like '%" + txtNmMerkBarang.Text + "%'");
                isFilter = true;
            }

            if (isFilter)
            {
                tmpStrBuilder.Append(" And ");
                isFilter = false;
            }

            if (txtNmProduk.Text.Length > 0)
            {
                tmpStrBuilder.Append($"{COL_NMPRODUK} Like '%" + txtNmProduk.Text + "%'");
                isFilter = true;
            }

            string tmpString = string.Empty;
            if (tmpStrBuilder.ToString().Length == 0) return tmpString;

            if (tmpStrBuilder.ToString()[^5..].Equals(" And "))
                tmpString = tmpStrBuilder.ToString()[..^5];
            else
                tmpString = tmpStrBuilder.ToString();

            return tmpString;
        }

        private void SetFocusToControl(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1 && e.Control)
            {
                e.Handled = true;
                txtNmProduk.Focus();
            }
            else
            if (e.KeyCode == Keys.D2 && e.Control)
            {
                e.Handled = true;
                txtNmCat.Focus();
            }
            else
            if (e.KeyCode == Keys.D3 && e.Control)
            {
                e.Handled = true;
                txtNmSubCat.Focus();
            }
            else
            if (e.KeyCode == Keys.D4 && e.Control)
            {
                e.Handled = true;
                txtNmMerkBarang.Focus();
            }

        }
        private void txtNmProduk_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                txtNmProduk.Text = string.Empty;
            }
            else
                SetFocusToControl(e);
        }

        private void txtNmCat_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                txtNmCat.Text = string.Empty;
            }
            else
                SetFocusToControl(e);
        }

        private void txtNmSubCat_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                txtNmSubCat.Text = string.Empty;
            }
            else
                SetFocusToControl(e);
        }

        private void txtNmMerkBarang_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                txtNmMerkBarang.Text = string.Empty;
            }
            else
                SetFocusToControl(e);
        }

        private void dgvGrid_KeyUp(object sender, KeyEventArgs e)
        {
            SetFocusToControl(e);
        }

        private void txtNmCat_TextChanged(object sender, EventArgs e)
        {
            if (dtTable.Rows.Count == 0) return;
            bsSource.Filter = GetFilterString();//$"{COL_CATEGORY} Like '%" + txtNmCat.Text + "%'";
        }

        private void txtNmSubCat_TextChanged(object sender, EventArgs e)
        {
            if (dtTable.Rows.Count == 0) return;
            bsSource.Filter = GetFilterString();//bsSource.Filter = $"{COL_CATEGORY} Like '%" + txtNmCat.Text + "%'";
        }

        private void txtNmMerkBarang_TextChanged(object sender, EventArgs e)
        {
            if (dtTable.Rows.Count == 0) return;
            bsSource.Filter = GetFilterString();
        }

        private void txtNmProduk_TextChanged(object sender, EventArgs e)
        {
            if (dtTable.Rows.Count == 0) return;
            bsSource.Filter = GetFilterString();
            //if (dtTable.Rows.Count == 0) return;
            //bsSource.Filter = $"{COL_NMPRODUK} Like '%" + txtNmProduk.Text + "%'";
        }

        private void LoadData()
        {
            //decimal totalQty = 0;

            //if (string.IsNullOrEmpty(txtProductID.Text.Trim()))
            //{
            //    MessageBox.Show("Product ID harus diisi!", Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtProductID.Focus();
            //    return;
            //}

            //try
            //{
            //    //decimal.TryParse(txtQty.Text, out totalQty);
            //    totalQty = 1;

            //    using (SqlConnection sqlCnn = new SqlConnection(ZFame.Classes.clsVarProgram.DB_CONN_STRING))
            //    {
            //        SqlCommand sqlCmd = new SqlCommand();
            //        sqlCmd.Connection = sqlCnn;
            //        sqlCmd.CommandType = CommandType.StoredProcedure;
            //        sqlCmd.CommandText = "Get_ProductWithStockAndLocation";
            //        sqlCmd.Parameters.Add("@KdCabang", SqlDbType.VarChar, 5).Value = KdCabang;
            //        sqlCmd.Parameters.Add("@KdWarehouse", SqlDbType.VarChar, 3).Value = KODE_WAREHOUSE;
            //        sqlCmd.Parameters.Add("@KdProduk", SqlDbType.VarChar, 20).Value = txtProductID.Text;
            //        sqlCmd.Parameters.Add("@IsBarcode", SqlDbType.Bit).Value = (txtProductID.Text.Length <= PJG_PRODUCTID ? 0 : 1);

            //        sqlCnn.Open();

            //        SqlDataReader dr = sqlCmd.ExecuteReader();

            //        if (dr.Read())
            //        {
            //            int iKdProduk = dr.GetOrdinal("KdProduk"), iProductName = dr.GetOrdinal("NmProduk"),
            //                iStsRc = 0, iPictPath = 0,
            //                iIsPaket = 0, iIsTax = 0, iHargaBeli = 0, 
            //                iHargaJual = 0, iTax = 0, iTaxAmount = 0, iHargaAkhir = 0;

            //            if (int.Parse(dr.GetValue(dr.GetOrdinal("RowNo")).ToString()) > 1)
            //            {
            //                FrmTrx_SelectProductDup frmProductDup = new FrmTrx_SelectProductDup(ref dr, iKdProduk, iProductName);
            //                frmProductDup.ShowDialog();
            //                if (frmProductDup.DialogResult == DialogResult.OK)
            //                {
            //                    //sqlCmd.Parameters["@KdProduk"].Value = txtProductID.Text = frmProductDup.iProductID;
            //                    sqlCmd.Parameters["@KdProduk"].Value = txtBarcodeNoVal.Text = frmProductDup.iProductID;
            //                    sqlCmd.Parameters["@IsBarcode"].Value = 0;

            //                    dr = sqlCmd.ExecuteReader();
            //                    dr.Read();
            //                }
            //                else
            //                {
            //                    txtProductID.Text = "";
            //                    txtQty.Text = "1";
            //                    return;
            //                }
            //            }
            //            else
            //                txtProductID.Text = dr.GetString(dr.GetOrdinal("BarcodeID"));
            //            //txtProductID.Text = dr.GetString(dr.GetOrdinal("KdProduk"));

            //            iStsRc = dr.GetOrdinal("StsRc");
            //            iIsPaket = dr.GetOrdinal("IsPaket");
            //            iIsTax = dr.GetOrdinal("IsTaxItem");
            //            iHargaBeli = dr.GetOrdinal("HargaBeli");
            //            iHargaJual = dr.GetOrdinal("HargaJual");
            //            iTax = dr.GetOrdinal("Tax");
            //            iTaxAmount = dr.GetOrdinal("TaxAmount");
            //            iHargaAkhir = dr.GetOrdinal("HargaAkhir");
            //            iPictPath = dr.GetOrdinal("PictPath");

            //            lblStokVal.Text = dr.GetDouble(dr.GetOrdinal("OnHand")).ToString("N2", nFi) + @" [@" + dr.GetDouble(dr.GetOrdinal("SQPerDus")).ToString("N2", nFi) + " - " + dr.GetDouble(dr.GetOrdinal("SBPerDus")).ToString("N2", nFi)  + "kg] ";
            //            lblStokVal.Tag = dr.GetDouble(dr.GetOrdinal("OnHand")) * dr.GetDouble(dr.GetOrdinal("SQPerDus"));
            //            txtHargaVal.Tag = dr.GetDecimal(dr.GetOrdinal("HargaAkhir")) * totalQty;

            //            txtProductNameVal.Text = dr.GetString(iProductName);
            //            //txtBarcodeNoVal.Text = dr.GetString(dr.GetOrdinal("BarcodeID"));
            //            txtBarcodeNoVal.Text = dr.GetString(dr.GetOrdinal("KdProduk"));
            //            txtHargaVal.Text = dr.GetDecimal(iHargaAkhir).ToString("N", nFi);
            //            txtQty.Text = "1";

            //            try
            //            {
            //                lblLocation.Text = "Group " + dr.GetString(dr.GetOrdinal("GroupID")) + " - Rak " + dr.GetString(dr.GetOrdinal("LotID"));
            //            }
            //            catch
            //            {
            //                lblLocation.Text = "";
            //            }


            //            dr.Close();

            //            sqlCmd.Parameters.Clear();
            //            sqlCmd.CommandText = "Get_StockFromAllWarehouse";
            //            sqlCmd.Parameters.Add("@KdCabang", SqlDbType.VarChar, 5).Value = KdCabang;
            //            sqlCmd.Parameters.Add("@KdProduk", SqlDbType.VarChar, 10).Value = txtBarcodeNoVal.Text;

            //            dr = sqlCmd.ExecuteReader();

            //            dgvGrid.Rows.Clear();
            //            if (dr.Read())
            //            {
            //                int iKdWarehouse = 0, iOnHand = 0;
            //                string colName;
            //                double stok;

            //                iKdWarehouse = dr.GetOrdinal("KdWarehouse");
            //                iOnHand = dr.GetOrdinal("OnHand");

            //                dgvGrid.Rows.Add();
            //                do
            //                {
            //                    colName = dr.GetString(iKdWarehouse);
            //                    stok = dr.GetDouble(iOnHand);

            //                    try
            //                    {
            //                        dgvGrid.Rows[0].Cells[colName].Value = stok.ToString();
            //                    }
            //                    catch
            //                    {

            //                    }
            //                } while (dr.Read());
            //            }


            //            dr.Close();
            //            dr = null;
            //            sqlCmd = null;
            //            sqlCnn.Close();

            //            txtProductID.Focus();
            //            txtProductID.SelectAll();
            //        }
            //        else
            //        {
            //            txtQty.Text = "1";
            //            dr.Close();
            //            dr = null;
            //            sqlCmd = null;
            //            sqlCnn.Close();
            //            ClearForm();
            //        }
            //    }
            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show("Cannot Load Data!" + Environment.NewLine + Environment.NewLine +
            //        exc.Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtProductID.Focus();
            //}
        }

        #region Properties
        private bool IsSaved
        {
            get
            {
                return this.Tag.ToString().Equals("SAVE");
            }
        }


        private string KdCabang
        {
            set
            {
                strKdCabang = value;
            }
            get
            {
                return strKdCabang;
            }
        }

        private string Title
        {
            set
            {
                strTitle = value;
            }
            get
            {
                return strTitle;
            }
        }

        private string UserID
        {
            set
            {
                strUserID = value;
            }
            get
            {
                return strUserID;
            }
        }

        private static char KeysENTER
        {
            get
            {
                return (char)13;
            }
        }
        #endregion

        private void txtProductID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == KeysENTER)
            {
                e.Handled = true;
                LoadData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float sizeLabel = 28, sizeTextbox = 24, sizeButton = 20;

            try
            {
                switch (cboSettings.SelectedIndex)
                {
                    case 0:
                        sizeLabel = 28;
                        sizeTextbox = 24;
                        break;
                    case 1:
                        sizeLabel = 40;
                        sizeTextbox = 35;
                        break;
                    default:
                        sizeLabel = int.Parse(txtFontLabel.Text);
                        sizeTextbox = int.Parse(txtFontText.Text);
                        sizeButton = int.Parse(txtFontButton.Text);
                        break;
                }
            }
            catch
            {
            }

            //this.Top = this.Left = 0;
            //txtProductNameVal.Height = 180;
            //txtProductID.Left = lblProductID.Right + 10;
            //btnSearch.Left = txtProductID.Right + 10;
            //lblProductName.Top = (txtProductID.Top + txtProductID.Height) + 10;
            //lblLocation.Top = lblProductName.Top;
            //lblLocation.Left = lblProductName.Right + 10;
            //txtProductNameVal.Top = lblProductName.Top + lblProductName.Height + 10;
            //lblHarga.Top = lblsep1.Top = txtQty.Top = btnCalc.Top =
            //    txtHargaVal.Top = txtProductNameVal.Top + txtProductNameVal.Height + 10;
            //lblBarcodeNo.Top = txtBarcodeNoVal.Top = lblHarga.Top + lblHarga.Height + 10;
            //lblJmlStok.Top = lblStokVal.Top = lblBarcodeNo.Top + lblBarcodeNo.Height + 10;
            //btnClose.Top = btnSettings.Top = cboSettings.Top = txtFontText.Top = 
            //    txtFontLabel.Top = label1.Top = lblFontLabel.Top = label2.Top =
            //    txtFontButton.Top = lblStokVal.Top + lblStokVal.Height + 10;
            //lblStokVal.Left = lblJmlStok.Right + 10;
            //txtBarcodeNoVal.Left = lblBarcodeNo.Right + 10;
            //lblsep1.Left = lblHarga.Right + 10;
            //txtQty.Left = lblsep1.Right + 10;
            //btnCalc.Left = txtQty.Right + 10;
            //txtHargaVal.Left = btnCalc.Right + 10;
            //btnSearch.Top = lblProductID.Top;
            //txtProductNameVal.Width = btnSearch.Right - txtProductNameVal.Left;
            //txtHargaVal.Width = btnSearch.Right - btnCalc.Right - 10;
            //txtBarcodeNoVal.Width = btnSearch.Right - lblBarcodeNo.Right - 10;

            //this.Invalidate();
            //this.Refresh();
            //txtProductID.Focus();
        }

        private void cboSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cboSettings.SelectedIndex)
                {
                    case 0:
                        txtFontLabel.Text = "28";
                        txtFontText.Text = "24";
                        txtFontButton.Text = "20";
                        txtFontButton.Visible = txtFontLabel.Visible = txtFontText.Visible =
                            lblFontLabel.Visible = label1.Visible = label2.Visible = false;
                        break;
                    case 1:
                        txtFontLabel.Text = "40";
                        txtFontText.Text = "35";
                        txtFontButton.Text = "20";
                        txtFontButton.Visible = txtFontLabel.Visible = txtFontText.Visible =
                            lblFontLabel.Visible = label1.Visible = label2.Visible = false;
                        break;
                    default:
                        txtFontLabel.Text = "28";
                        txtFontText.Text = "24";
                        txtFontButton.Text = "20";
                        txtFontButton.Visible = txtFontLabel.Visible = txtFontText.Visible =
                            lblFontLabel.Visible = label1.Visible = label2.Visible = true;
                        break;
                }
            }
            catch
            {
            }
        }

    }
}
