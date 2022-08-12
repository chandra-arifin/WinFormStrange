using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ZFame
{
    public partial class FrmTrx_SelectProductDup : Form
    {
        private static int Current_rowGrid;

        private void CloseAllManagedResx()
        {
            //gFunc = null;
            //this.Dispose(true);
        }

        #region Private Variables
        private readonly CultureInfo cultureInfo;
        private readonly DateTimeFormatInfo dFi;
        private readonly NumberFormatInfo nFi;
        private GlobalFunction gFunc = new GlobalFunction();
        private string strTitle, strUserID;
        private const int idxKdProduk = 0;
        //private int current_rowGrid;
        #endregion

        #region Constructor
        public FrmTrx_SelectProductDup(ref SqlDataReader sqlDR, int iKdProduk, int iNmProduk)
        {
            InitializeComponent();

            Title = InfoApp.Title;
            cultureInfo = InfoApp.Culture;
            dFi = InfoApp.DTFormatInfo;
            nFi = InfoApp.NFormatInfo;
            UserID = InfoApp.UserID;

            LoadData(ref sqlDR, iKdProduk, iNmProduk);
        }
        #endregion

        #region Methods
        private void LoadData(ref SqlDataReader sqlDR, int iKdProduk, int iNmProduk)
        {
            string[] rows;

            try
            {
                do
                {
                    rows = new string[] {
                                    sqlDR.GetString(iKdProduk),
                                    sqlDR.GetString(iNmProduk)
                    };
                    dgvGrid.Rows.Add(rows);
                } while (sqlDR.Read());

                dgvGrid.PerformLayout();
                sqlDR.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Cannot Load Data!" + Environment.NewLine + Environment.NewLine +
                    exc.Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public string iProductID
        {
            get
            {
                return dgvGrid.Rows[Current_rowGrid].Cells[idxKdProduk].Value.ToString();
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
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            Current_rowGrid = dgvGrid.SelectedRows[0].Index;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void dgvGrid_DoubleClick(object sender, EventArgs e)
        {
            btnSave.PerformClick();
        }

        private void dgvGrid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.Enter))
            {
                btnSave.PerformClick();
            }
        }

        private void FrmTrx_SelectProductDup_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseAllManagedResx();
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
