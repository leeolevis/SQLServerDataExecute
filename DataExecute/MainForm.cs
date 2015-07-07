using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MetorDataApp.Properties;
using MetroFramework;
using MetroFramework.Forms;
using SubSonic;
using SubSonic.Generated;
namespace MetorDataApp
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();

            metroStyleManager.Theme = MetroThemeStyle.Light;
            //var m = new Random();
            //int next = m.Next(0, 13);
            //metroStyleManager.Style = (MetroColorStyle)next;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadScriptData();
        }

        private void LoadData()
        {
            var queryCommand = new QueryCommand("select Id,dbService,dbPort,dbName,dbUser,dbPwd,OrderOn from DataConfig order by OrderOn");
            var queryDs = DataService.GetDataSet(queryCommand);
            metroGrid1.DataSource = queryDs.Tables[0];
            metroGrid1.AllowUserToAddRows = true;
        }

        private void metroGrid1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)//添加
            {
                if (metroGrid1.Rows[e.RowIndex].Cells["id"].Value == null ||
                    string.IsNullOrEmpty(metroGrid1.Rows[e.RowIndex].Cells["id"].Value.ToString()))
                {
                    var currentTime = DateTime.Now;
                    var dataConfig = new DataConfig();
                    dataConfig.DbService = metroGrid1.Rows[e.RowIndex].Cells["DbService"].Value == null
                        ? ""
                        : metroGrid1.Rows[e.RowIndex].Cells["DbService"].Value.ToString();
                    dataConfig.DbName = metroGrid1.Rows[e.RowIndex].Cells["DbName"].Value == null
                        ? ""
                        : metroGrid1.Rows[e.RowIndex].Cells["DbName"].Value.ToString();
                    dataConfig.DbPort = metroGrid1.Rows[e.RowIndex].Cells["DbPort"].Value == null
                        ? ""
                        : metroGrid1.Rows[e.RowIndex].Cells["DbPort"].Value.ToString();
                    dataConfig.DbPwd = metroGrid1.Rows[e.RowIndex].Cells["DbPwd"].Value == null
                        ? ""
                        : metroGrid1.Rows[e.RowIndex].Cells["DbPwd"].Value.ToString();
                    dataConfig.DbUser = metroGrid1.Rows[e.RowIndex].Cells["DbUser"].Value == null
                        ? ""
                        : metroGrid1.Rows[e.RowIndex].Cells["DbUser"].Value.ToString();
                    dataConfig.OrderOn = e.RowIndex + 1;
                    dataConfig.TaskOn = currentTime;
                    dataConfig.CreateOn = currentTime;
                    dataConfig.ModifiedOn = currentTime;
                    dataConfig.Save();
                    LoadData();
                }
                else//修改
                {
                    var findKey = metroGrid1.Rows[e.RowIndex].Cells["id"].Value;
                    var findEntity = DataConfig.FetchByID(findKey.ToString());
                    findEntity.DbService = metroGrid1.Rows[e.RowIndex].Cells["dbservice"].Value.ToString();
                    findEntity.DbName = metroGrid1.Rows[e.RowIndex].Cells["dbname"].Value.ToString();
                    findEntity.DbPort = metroGrid1.Rows[e.RowIndex].Cells["dbport"].Value.ToString();
                    findEntity.DbPwd = metroGrid1.Rows[e.RowIndex].Cells["dbpwd"].Value.ToString();
                    findEntity.DbUser = metroGrid1.Rows[e.RowIndex].Cells["dbuser"].Value.ToString();
                    int sort = 0;
                    int.TryParse(metroGrid1.Rows[e.RowIndex].Cells["OrderOn"].Value.ToString(), out sort);
                    findEntity.OrderOn = sort;
                    findEntity.ModifiedOn = DateTime.Now;
                    findEntity.Save();
                    LoadData();
                }
            }
        }

        private void btnTestCon_Click(object sender, EventArgs e)
        {
            if (metroGrid1.Rows.Count <= 1)
            {
                MetroMessageBox.Show(this, "请先添加数据库信息：）", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool canConnectioned = true;
            string erroMessage = string.Empty;
            string connectionString = string.Format(
                    "Data Source={0};Initial Catalog={1};User Id={2};Password={3}",
                    metroGrid1.SelectedCells[1].Value, metroGrid1.SelectedCells[3].Value,
                    metroGrid1.SelectedCells[4].Value, metroGrid1.SelectedCells[5].Value);

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException sqlException)
                {
                    erroMessage = sqlException.Message;
                    canConnectioned = false;
                }
                finally
                {
                    connection.Close();
                }
            }

            if (canConnectioned)
                MetroMessageBox.Show(this, "恭喜你，连接成功：）", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MetroMessageBox.Show(this, "连接失败：" + erroMessage + "", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (metroGrid1.Rows.Count <= 1)
            {
                MetroMessageBox.Show(this, "请先添加数据库信息：）", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dialogResult = MetroMessageBox.Show(this, "你确定要删除当前项吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult.ToString() == "Yes")
            {
                var findKey = metroGrid1.SelectedCells[0].Value;

                if (DataConfig.Delete(findKey) > 0)
                {
                    MetroMessageBox.Show(this, "恭喜你，删除成功：）", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                    MetroMessageBox.Show(this, "抱歉，删除失败：）", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void LoadScriptData()
        {
            var queryCommand = new QueryCommand("select Id,ScriptName,OrderOn,CreateOn,dbId from DataScript order by OrderOn");
            var queryDs = DataService.GetDataSet(queryCommand);
            metroScriptGrid.DataSource = queryDs.Tables[0];
            metroScriptGrid.AllowUserToAddRows = false;
        }

        private void metroScriptGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var queryCommand = new QueryCommand("select Id,dbService,dbPort,dbName,dbUser,dbPwd,OrderOn from DataConfig Order by OrderOn");
            var queryDs = DataService.GetDataSet(queryCommand).Tables[0];
            var rowsQuery = metroScriptGrid.Rows.Count;
            for (int i = 0; i < rowsQuery; i++)
            {
                ((DataGridViewComboBoxCell)(metroScriptGrid.Rows[i].Cells["SelectDB"])).DisplayMember = "dbName";
                ((DataGridViewComboBoxCell)(metroScriptGrid.Rows[i].Cells["SelectDB"])).ValueMember = "Id";
                //var findKey = metroScriptGrid.Rows[i].Cells["ScriptId"].Value;
                //var dataScript = DataScript.FetchByID(findKey.ToString());
                var dbId = metroScriptGrid.Rows[i].Cells["dbId"].Value;
                if (dbId != null)
                {
                    if (dbId.ToString() == "0")
                    {
                        ((DataGridViewComboBoxCell)(metroScriptGrid.Rows[i].Cells["SelectDB"])).Value =
                            queryDs.Rows[0]["dbService"];
                    }
                    else
                    {
                        var dataConfig = DataConfig.FetchByID(dbId.ToString());
                        ((DataGridViewComboBoxCell)(metroScriptGrid.Rows[i].Cells["SelectDB"])).Value = dataConfig.Id;
                    }
                    ((DataGridViewComboBoxCell)(metroScriptGrid.Rows[i].Cells["SelectDB"])).DataSource = queryDs;
                }
            }
        }

        private void metroScriptGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //更新
                var findKey = metroScriptGrid.Rows[e.RowIndex].Cells["ScriptId"].Value;
                var findEntity = DataScript.FetchByID(findKey.ToString());

                int sort = 0;
                int.TryParse(metroScriptGrid.Rows[e.RowIndex].Cells["ScriptOrderOn"].Value.ToString(), out sort);
                bool noChange = findEntity.OrderOn == sort;
                if (noChange)
                    noChange = findEntity.DbId == int.Parse(metroScriptGrid.Rows[e.RowIndex].Cells["SelectDB"].Value.ToString());
                if (!noChange)
                {
                    findEntity.DbId = int.Parse(metroScriptGrid.Rows[e.RowIndex].Cells["SelectDB"].Value.ToString());
                    findEntity.OrderOn = sort;
                    findEntity.ModifiedOn = DateTime.Now;
                    findEntity.Save();
                    LoadScriptData();
                }
            }
        }

        private void btnUploadScript_Click(object sender, EventArgs e)
        {
            #region 检查是否有数据库配置
            var queryCommand = new QueryCommand("select Id,dbService,dbPort,dbName,dbUser,dbPwd,OrderOn from DataConfig Order by OrderOn");
            var queryDs = DataService.GetDataSet(queryCommand);
            if (queryDs.Tables[0].Rows.Count <= 0)
            {
                MetroMessageBox.Show(this, "请先添加数据库信息：）", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #endregion

            var dialog = new FolderBrowserDialog();
            dialog.Description = Resources.MainForm_btnUploadScript_Click_请选择文件路径;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //清空数据
                var deleteCommand = new QueryCommand("delete from DataScript");
                DataService.ExecuteScalar(deleteCommand);
                //添加数据
                var currentTime = DateTime.Now;
                string foldPath = dialog.SelectedPath;
                var files = Directory.GetFiles(foldPath, "*.sql", SearchOption.AllDirectories);

                int index = 1;
                foreach (var fileItem in files)
                {
                    var file = new FileInfo(fileItem);
                    var dataScript = new DataScript();
                    dataScript.ScriptName = file.Name;
                    dataScript.ScriptPath = file.FullName;
                    dataScript.ScriptContent = File.ReadAllText(file.FullName, Encoding.Default);
                    dataScript.DbId = int.Parse(queryDs.Tables[0].Rows[0]["Id"].ToString());
                    dataScript.OrderOn = index++;
                    dataScript.TaskOn = currentTime;
                    dataScript.CreateOn = currentTime;
                    dataScript.ModifiedOn = currentTime;
                    dataScript.Save();
                }
            }
            LoadScriptData();
        }

        private void btnRunScript_Click(object sender, EventArgs e)
        {
            #region 检查是否有数据库配置
            var queryCommand1 = new QueryCommand("select Id,dbService,dbPort,dbName,dbUser,dbPwd,OrderOn from DataConfig Order by OrderOn");
            var queryDs1 = DataService.GetDataSet(queryCommand1);
            if (queryDs1.Tables[0].Rows.Count <= 0)
            {
                MetroMessageBox.Show(this, "请先添加数据库信息：）", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #endregion

            var queryCommand = new QueryCommand("select Id,ScriptName,ScriptContent,OrderOn,dbId from DataScript Order By OrderOn ");
            var queryDs = DataService.GetDataSet(queryCommand);
            if (queryDs.Tables[0].Rows.Count <= 0)
                MetroMessageBox.Show(this, "请先添加需要执行的脚本：）", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                var queryTable = queryDs.Tables[0];
                string erroMessage = string.Empty;
                bool canConnectioned = true;

                for (int i = 0; i < queryTable.Rows.Count; i++)
                {
                    var dbId = queryTable.Rows[i]["dbId"];
                    var scriptName = queryTable.Rows[i]["ScriptName"].ToString();
                    var scriptContent = queryTable.Rows[i]["ScriptContent"].ToString();
                    var dataConfig = DataConfig.FetchByID(dbId.ToString());

                    string connectionString = string.Format(
                "Data Source={0};Initial Catalog={1};User Id={2};Password={3}",
                dataConfig.DbService, dataConfig.DbName,
                dataConfig.DbUser, dataConfig.DbPwd);
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            string[] arr = System.Text.RegularExpressions.Regex.Split(scriptContent, "GO");
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = connection;
                            SqlTransaction tx = connection.BeginTransaction();
                            cmd.Transaction = tx;
                            try
                            {
                                for (int n = 0; n < arr.Length; n++)
                                {
                                    string strsql = arr[n];
                                    if (strsql.Trim().Length > 1)
                                    {
                                        cmd.CommandText = strsql;
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                tx.Commit();
                            }
                            catch (SqlException sqlException)
                            {
                                tx.Rollback();
                                erroMessage = "数据库：" + dataConfig.DbName + "\r\n脚本名：" + scriptName + "\r\n错误信息：" + sqlException.Message + "";
                                canConnectioned = false;
                            }
                        }
                        catch (SqlException sqlException)
                        {
                            erroMessage = sqlException.Message;
                            canConnectioned = false;
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }

                if (!canConnectioned)
                {
                    MetroMessageBox.Show(this, erroMessage, "操作失败", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                else
                    MetroMessageBox.Show(this, "恭喜你，脚本执行成功：）", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //切换重新绑定数据
        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.TabControl)(sender)).SelectedIndex == 1)
            {
                LoadScriptData();
            }
        }
    }
}
