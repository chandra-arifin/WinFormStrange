using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ZFame
{
    public partial class FrmSearch_Product : Form
    {
        private static int Current_rowGrid;

        private void ChangeIconForm()
        {
            //System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //System.IO.Stream stream = assembly.GetManifestResourceStream(InfoApp.MyAssemblyName + "." + InfoApp.IconPath + "." + InfoApp.IconName);
            //this.Icon = new Icon(stream);
        }

        private void CloseAllManagedResx()
        {
            gFunc = null;
        }

        private void dgvGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, new Font("Tahoma", 8, FontStyle.Bold), SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        #region Private Variables
        private readonly NumberFormatInfo nFi;
        private GlobalFunction gFunc = new GlobalFunction();
        private string strTitle;
        private const int idxKdProduk = 0,
            idxNmProduk = 1,
            idxHargaAkhir = 2;
        //private int current_rowGrid;
        private int isPaket = -1;
        private readonly bool isFilterSubCategory = false;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        #endregion

        #region Constructor
        public FrmSearch_Product() : this(-1, "")
        {
        }

        public FrmSearch_Product(int isPaket, string productName)
        {
            InitializeComponent();

            ChangeIconForm();

            isFilterSubCategory = InfoApp.FilterSubCategory;

            gFunc.SetButtonEnable(false, btnOK);

            dgvGrid.RowHeadersVisible = true;
            dgvGrid.RowHeadersDefaultCellStyle.Padding = new Padding(dgvGrid.RowHeadersWidth);
            dgvGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgvGrid_RowPostPaint);


            DataGridViewCellStyle dgvCSReadOnly = new DataGridViewCellStyle();

            dgvCSReadOnly.Format = "N2";
            dgvCSReadOnly.NullValue = null;

            dgvGrid.Columns[idxHargaAkhir].DefaultCellStyle = dgvCSReadOnly;

            Title = InfoApp.Title;
            nFi = InfoApp.NFormatInfo;

            btnOK.Enabled = false;

            txtProductName.Text = productName;
            this.isPaket = isPaket;

            dgvGrid.Columns[idxKdProduk].DataPropertyName = "kdproduk";
            dgvGrid.Columns[idxNmProduk].DataPropertyName = "NmProduk";
            dgvGrid.Columns[idxHargaAkhir].DataPropertyName = "HargaAkhir";
            dgvGrid.AutoGenerateColumns = false;
        }
        #endregion

        #region Methods
        private void LoadData()
        {
            object[] rows;

            try
            {
                table = new DataTable();
                dgvGrid.DataSource = null;
                using (SqlConnection sqlCnn = new SqlConnection(ZFame.Classes.clsVarProgram.DB_CONN_STRING))
                {
                    int iID = 0, iDesc = 0, iStatus = 0,
                        iIsPaket = 0, iHargaBeli = 0, iHargaJual = 0, iTax = 0, iHargaAkhir = 0, no = 1;
                    string stsRc;

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.Connection = sqlCnn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;


                    if (txtProductName.Text.Length > 0)
                    {
                        sqlCmd.CommandText = "Get_SearchProduct";
                        if (!string.IsNullOrEmpty(txtProductName.Text.Trim()))
                            sqlCmd.Parameters.Add("@NmProduct", SqlDbType.NVarChar, 255).Value = txtProductName.Text;
                        //else
                        //    sqlCmd.CommandText = "Get_Product";
                    }
                    else
                    {
                        sqlCmd.CommandText = "Get_SearchProductByID";
                        sqlCmd.Parameters.Add("@KdProduk", SqlDbType.VarChar, 10).Value = txtProductID.Text;
                    }

                    if (isPaket > -1)
                        sqlCmd.Parameters.Add("@IsPaket", SqlDbType.Bit).Value = isPaket;
                    sqlCmd.Parameters.Add("@FilterSubCategory", SqlDbType.Bit).Value = isFilterSubCategory;

                    sqlCnn.Open();

                    adapter.SelectCommand = sqlCmd;
                    adapter.Fill(table);
                    dgvGrid.DataSource = table;

                    dgvGrid.Columns[idxNmProduk].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    //SqlDataReader sqlDR = sqlCmd.ExecuteReader();

                    //if (sqlDR.Read())
                    //{
                    //    iID = sqlDR.GetOrdinal("KdProduk");
                    //    iDesc = sqlDR.GetOrdinal("NmProduk");
                    //    iIsPaket = sqlDR.GetOrdinal("IsPaket");
                    //    iHargaBeli = sqlDR.GetOrdinal("HargaBeli");
                    //    iHargaJual = sqlDR.GetOrdinal("HargaJual");
                    //    iTax = sqlDR.GetOrdinal("TaxAmount");
                    //    iHargaAkhir = sqlDR.GetOrdinal("HargaAkhir");
                    //    iStatus = sqlDR.GetOrdinal("StsRc");

                    //    do
                    //    {
                    //        Application.DoEvents();
                    //        switch (sqlDR.GetString(iStatus).ToUpper())
                    //        {
                    //            case "A":
                    //                stsRc = "Active";
                    //                break;
                    //            case "I":
                    //                stsRc = "Inactive";
                    //                break;
                    //            case "D":
                    //                stsRc = "Deleted";
                    //                break;
                    //            default:
                    //                stsRc = "Unknown";
                    //                break;
                    //        }
                    //        rows = new object[] {
                    //                        //no.ToString("N", nFi),
                    //                        no,
                    //                        stsRc,
                    //                        (sqlDR.GetBoolean(iIsPaket) ? "Ya" : "Tidak"),
                    //                        sqlDR.GetString(iID),
                    //                        sqlDR.GetString(iDesc),
                    //                        sqlDR.GetDecimal(iHargaBeli), // .ToString("N2", nFi),
                    //                        sqlDR.GetDecimal(iHargaJual), // .ToString("N", nFi),
                    //                        sqlDR.GetDecimal(iTax), // .ToString("N2", nFi),
                    //                        sqlDR.GetDecimal(iHargaAkhir) // .ToString("N", nFi)
                    //        };
                    //        no++;
                    //        dgvGrid.Rows.Add(rows);
                    //        if (stsRc == "Deleted")
                    //        {
                    //            dgvGrid.Rows[dgvGrid.Rows.GetLastRow(DataGridViewElementStates.Visible)].DefaultCellStyle.SelectionForeColor =
                    //                dgvGrid.Rows[dgvGrid.Rows.GetLastRow(DataGridViewElementStates.Visible)].DefaultCellStyle.ForeColor = Color.Red;
                    //        }
                    //    } while (sqlDR.Read());

                    //    dgvGrid.PerformLayout();
                    //}

                    //rows = null;
                    //sqlDR.Close();
                    //sqlDR = null;
                    sqlCmd = null;
                    sqlCnn.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Cannot Load Data!" + Environment.NewLine + Environment.NewLine +
                    exc.Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRefresh.Enabled = true;
            }
        }
        private void LoadData2()
        {
            object[] rows;

            try
            {
                dgvGrid.Rows.Clear();
                using (SqlConnection sqlCnn = new SqlConnection(ZFame.Classes.clsVarProgram.DB_CONN_STRING))
                {
                    int iID = 0, iDesc = 0, iStatus = 0, 
                        iIsPaket = 0, iHargaBeli = 0, iHargaJual = 0, iTax = 0, iHargaAkhir =0, no = 1;
                    string stsRc;

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.Connection = sqlCnn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    if (txtProductName.Text.Length > 0)
                    {
                        sqlCmd.CommandText = "Get_SearchProduct";
                        if (!string.IsNullOrEmpty(txtProductName.Text.Trim()))
                            sqlCmd.Parameters.Add("@NmProduct", SqlDbType.NVarChar, 255).Value = txtProductName.Text;
                        else
                            sqlCmd.CommandText = "Get_Product";
                    }
                    else
                    {
                        sqlCmd.CommandText = "Get_SearchProductByID";
                        sqlCmd.Parameters.Add("@KdProduk", SqlDbType.VarChar, 10).Value = txtProductID.Text;
                    }

                    if (isPaket > -1)
                        sqlCmd.Parameters.Add("@IsPaket", SqlDbType.Bit).Value = isPaket;
                    sqlCmd.Parameters.Add("@FilterSubCategory", SqlDbType.Bit).Value = isFilterSubCategory; 

                    sqlCnn.Open();

                    SqlDataReader sqlDR = sqlCmd.ExecuteReader();

                    if (sqlDR.Read())
                    {
                        iID = sqlDR.GetOrdinal("KdProduk");
                        iDesc = sqlDR.GetOrdinal("NmProduk");
                        iHargaAkhir = sqlDR.GetOrdinal("HargaAkhir");

                        do
                        {
                            Application.DoEvents();
                            rows = new object[] {
                                            no,
                                            sqlDR.GetString(iID),
                                            sqlDR.GetString(iDesc),
                                            sqlDR.GetDecimal(iHargaAkhir) // .ToString("N", nFi)
                            };
                            no++;
                            dgvGrid.Rows.Add(rows);
                        } while (sqlDR.Read());

                        dgvGrid.PerformLayout();
                    }

                    //rows = null;
                    sqlDR.Close();
                    sqlDR = null;
                    sqlCmd = null;
                    sqlCnn.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Cannot Load Data!" + Environment.NewLine + Environment.NewLine +
                    exc.Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRefresh.Enabled = true;
            }
        }

        private void LoadData234()
        {
            object[] rows;

            try
            {
                dgvGrid.Rows.Clear();
                using (SqlConnection sqlCnn = new SqlConnection(ZFame.Classes.clsVarProgram.DB_CONN_STRING))
                {
                    int iID = 0, iDesc = 0, iStatus = 0,
                        iIsPaket = 0, iHargaBeli = 0, iHargaJual = 0, iTax = 0, iHargaAkhir = 0, no = 1;
                    string stsRc;

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.Connection = sqlCnn;
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    if (txtProductName.Text.Length > 0)
                    {
                        sqlCmd.CommandText = "Get_SearchProduct";
                        if (!string.IsNullOrEmpty(txtProductName.Text.Trim()))
                            sqlCmd.Parameters.Add("@NmProduct", SqlDbType.NVarChar, 255).Value = txtProductName.Text;
                        else
                            sqlCmd.CommandText = "Get_Product";
                    }
                    else
                    {
                        sqlCmd.CommandText = "Get_SearchProductByID";
                        sqlCmd.Parameters.Add("@KdProduk", SqlDbType.VarChar, 10).Value = txtProductID.Text;
                    }

                    if (isPaket > -1)
                        sqlCmd.Parameters.Add("@IsPaket", SqlDbType.Bit).Value = isPaket;
                    sqlCmd.Parameters.Add("@FilterSubCategory", SqlDbType.Bit).Value = isFilterSubCategory;

                    sqlCnn.Open();

                    SqlDataReader sqlDR = sqlCmd.ExecuteReader();

                    if (sqlDR.Read())
                    {
                        iID = sqlDR.GetOrdinal("KdProduk");
                        iDesc = sqlDR.GetOrdinal("NmProduk");
                        iIsPaket = sqlDR.GetOrdinal("IsPaket");
                        iHargaBeli = sqlDR.GetOrdinal("HargaBeli");
                        iHargaJual = sqlDR.GetOrdinal("HargaJual");
                        iTax = sqlDR.GetOrdinal("TaxAmount");
                        iHargaAkhir = sqlDR.GetOrdinal("HargaAkhir");
                        iStatus = sqlDR.GetOrdinal("StsRc");

                        do
                        {
                            Application.DoEvents();
                            switch (sqlDR.GetString(iStatus).ToUpper())
                            {
                                case "A":
                                    stsRc = "Active";
                                    break;
                                case "I":
                                    stsRc = "Inactive";
                                    break;
                                case "D":
                                    stsRc = "Deleted";
                                    break;
                                default:
                                    stsRc = "Unknown";
                                    break;
                            }
                            rows = new object[] {
                                            //no.ToString("N", nFi),
                                            no,
                                            stsRc,
                                            (sqlDR.GetBoolean(iIsPaket) ? "Ya" : "Tidak"),
                                            sqlDR.GetString(iID),
                                            sqlDR.GetString(iDesc),
                                            sqlDR.GetDecimal(iHargaBeli), // .ToString("N2", nFi),
                                            sqlDR.GetDecimal(iHargaJual), // .ToString("N", nFi),
                                            sqlDR.GetDecimal(iTax), // .ToString("N2", nFi),
                                            sqlDR.GetDecimal(iHargaAkhir) // .ToString("N", nFi)
                            };
                            no++;
                            dgvGrid.Rows.Add(rows);
                            if (stsRc == "Deleted")
                            {
                                dgvGrid.Rows[dgvGrid.Rows.GetLastRow(DataGridViewElementStates.Visible)].DefaultCellStyle.SelectionForeColor =
                                    dgvGrid.Rows[dgvGrid.Rows.GetLastRow(DataGridViewElementStates.Visible)].DefaultCellStyle.ForeColor = Color.Red;
                            }
                        } while (sqlDR.Read());

                        dgvGrid.PerformLayout();
                    }

                    //rows = null;
                    sqlDR.Close();
                    sqlDR = null;
                    sqlCmd = null;
                    sqlCnn.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Cannot Load Data!" + Environment.NewLine + Environment.NewLine +
                    exc.Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRefresh.Enabled = true;
            }
        }

        #endregion

        #region Properties
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

        private static char KeysENTER
        {
            get
            {
                return (char)13;
            }
        }
        public string _ProductID
        {
            get
            {
                return dgvGrid.Rows[Current_rowGrid].Cells[idxKdProduk].Value.ToString();
            }
        }

        public string _ProductName
        {
            get
            {
                return dgvGrid.Rows[Current_rowGrid].Cells[idxNmProduk].Value.ToString();
            }
        }
        #endregion

        #region Events
        //private void dgvGrid_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == KeysENTER)
        //    {
        //        e.Handled = true;
        //        btnOK.PerformClick();
        //    }
        //}

        private void dgvGrid_DoubleClick(object sender, EventArgs e)
        {
            btnOK.PerformClick();
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgvGrid.Rows.Count == 0) return;
            Current_rowGrid = dgvGrid.SelectedRows[0].Index;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            LoadData();
            int rowCount = dgvGrid.RowCount;
            btnOK.Enabled = (rowCount == 0 ? false : true);
            if (btnOK.Enabled)
                dgvGrid.Focus();
            btnRefresh.Enabled = true;
        }

        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == KeysENTER)
            {
                e.Handled = true;
                txtProductID.Text = "";
                btnRefresh.PerformClick();
            }
        }

        private void dgvGrid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F1))
            {
                txtProductName.Focus();
            }
            else
            if (e.Control && e.KeyCode.Equals(Keys.Enter))
            {
                btnOK.PerformClick();
            }
        }

        private void txtProductName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F1))
            {
                dgvGrid.Focus();
            }
        }

        private void btnOK_EnabledChanged(object sender, EventArgs e)
        {
            dgvGrid.Enabled = btnOK.Enabled;
        }

        private void btnRefresh_EnabledChanged(object sender, EventArgs e)
        {
            if(dgvGrid.RowCount > 0)
                btnOK.Enabled = btnRefresh.Enabled;
        }

        private void FrmSearch_Product_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseAllManagedResx();
        }

        private void txtProductID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == KeysENTER)
            {
                e.Handled = true;
                txtProductName.Text = "";
                btnRefresh.PerformClick();
            }
        }

        private void txtProductID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F1))
            {
                dgvGrid.Focus();
            }
        }

        public static void SetIndexRow(int val)
        {
            Current_rowGrid = val;
        }

        private class CustomDataGridView : DataGridView
        {
            [System.Security.Permissions.SecurityPermission(
            System.Security.Permissions.SecurityAction.LinkDemand, Flags =
            System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
            protected override bool ProcessDataGridViewKey(KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (this.CurrentCell == null) return true;
                    SetIndexRow(this.CurrentCell.RowIndex);
                    ((Form)this.TopLevelControl).DialogResult = DialogResult.OK;
                    return true;
                }
                return base.ProcessDataGridViewKey(e);
            }
        }
    }
}
