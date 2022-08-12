using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace ZFame
{
    public static class Program
    {
        //Mini Market / POS biasa
        private const string PROGRAM_VERSION = "1.1.110.19";
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            //System.Diagnostics.Process[] currentProcess = null;

            //DEMOOOOOOOOOOOOOOOOOOOO
            //utk HP
            //if (DateTime.Now.Subtract(new DateTime(2010, 05, 01)).Days > 0)
            //{
            //    MessageBox.Show("DEMO BERAKHIR!!!", "InFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}


            // Getting the current culture of the executing thread: 
            CultureInfo currentUserCulture = Thread.CurrentThread.CurrentCulture;

            if (currentUserCulture.Name != "en-US")
            {
                MessageBox.Show("Silakan ubah Bahasa menjadi 'English (US)' di 'Regional and Language Option' pada Control Panel!!!", "Setting Bahasa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Security.Encryption funcEncrypt = new ZFame.Security.Encryption();
            string title, connString, kdCabang, warehouseIDDef, printerName, sqlServiceName;

            if (!funcEncrypt.DecryptConnString(out title, out connString, out kdCabang, out warehouseIDDef, out printerName, out sqlServiceName))
            {
                MessageBox.Show("File Connection String Cannot be found!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            //if (ZFame.Classes.clsFunction.IsAppRunning(out currentProcess) == false)
            if (ZFame.Classes.clsFunction.IsOnlyProcess(title))
            {
                //currentProcess = null;
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    InfoApp.ProgramVersion = PROGRAM_VERSION;
                    InfoApp.BranchID = kdCabang;
                    InfoApp.PrinterName = printerName;
                    InfoApp.Title = title;
                    InfoApp.WarehouseIDDefaultPenjualan = warehouseIDDef;
                    InfoApp.KODE_MSSERVERSERVICE = sqlServiceName;
                    InfoApp.Default_Messagebox_Button = MessageBoxDefaultButton.Button1;
                    //ZFame.Classes.clsVarProgram.DB_CONN_STRING = ZFame.Classes.clsVarProgram._DB_CONN_STRING2;
                    ZFame.Classes.clsVarProgram.DB_CONN_STRING = connString;

                    //ZFame.Security.GetInfo getInfo = new ZFame.Security.GetInfo();
                    //InfoApp.ValidationKey = getInfo.GetCPUId();

                    DateTime dateRegistered = DateTime.Now;
                    InfoApp.FullVersion = funcEncrypt.DecryptRegisterKeys(InfoApp.ValidationKey, out dateRegistered);
                    InfoApp.DateRegistered = dateRegistered;
                    funcEncrypt = null;


                    GetVarStruk(ZFame.Classes.clsVarProgram.DB_CONN_STRING, kdCabang, GlobalFunction.GetIPAddress());

                    FrmFullProduct newForm = new FrmFullProduct();
                    Application.Run(newForm);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //else
            //    MessageBox.Show("Application has already running!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void GetVarStruk(string cnnString, string KODE_CABANG, string MY_IPADDRESS)
        {
            using SqlConnection sqlCnn = new(cnnString);
            using var sqlCmd = new SqlCommand
            {
                Connection = sqlCnn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "Get_VarStruk"
            };
            sqlCmd.Parameters.Add("@KdCabang", SqlDbType.VarChar, 5).Value = KODE_CABANG;
            sqlCmd.Parameters.Add("@IPAddress", SqlDbType.VarChar, 15).Value = MY_IPADDRESS;

            sqlCnn.Open();

            using var dr = sqlCmd.ExecuteReader();
            if (dr.Read())
            {
                InfoApp.PRICE_LEVEL = dr.GetInt32(dr.GetOrdinal("pricelevel"));
            }
            else
            {
                InfoApp.PRICE_LEVEL = 2;
            }
        }

    }
}
