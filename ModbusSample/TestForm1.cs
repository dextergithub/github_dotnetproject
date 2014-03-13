using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseCommon;

namespace ModbusSample
{
    public partial class TestForm1 : Form
    {

        public Vendor V = null;

        public List<ChannelInfo> Channels_A = new List<ChannelInfo>();

        List<ChannelInfo> Channels_B = new List<ChannelInfo>();
        public TestForm1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (V == null) return;
            int index = -1;
            if (!Program.GetIndex("A", ref index))
            {

                return;
            }
            V.OutputGoods(index, (flag) =>
            {
                MessageBox.Show("出货A：{0},货道：{1}".ExtFormat(flag ? "成功" : "失败", ""));

            });

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (V == null) return;
            int index = -1;
            if (!Program.GetIndex("B", ref index))
            {
                return;
            }

            V.OutputGoods(index, (flag) =>
            {
                MessageBox.Show("出货B：{0},货道：{1}".ExtFormat(flag ? "成功" : "失败", ""));

            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VEMConfigHelper config = VEMConfigHelper.Create();

            config.SetProductAChannels(this.Channels_A);
            config.SetProductBChannels(this.Channels_B);

            config.ACurrent = (int)this.numericUpDown_A.Value;
            config.BCurrent = (int)this.numericUpDown_B.Value;

            config.Port = port.Text;
            config.Save();
            MessageBox.Show("保存成功！");

        }



        private void TestForm1_Load(object sender, EventArgs e)
        {
            VEMConfigHelper config = VEMConfigHelper.Create();
            this.Channels_A = config.GetProductAChannels();
            this.Channels_B = config.GetProductBChannels();
            this.dataGridView_A.AutoGenerateColumns = false;
            this.dataGridView_B.AutoGenerateColumns = false;
            this.dataGridView_A.DataSource = this.Channels_A;
            this.dataGridView_B.DataSource = this.Channels_B;

            this.numericUpDown_A.Value = config.ACurrent;
            this.numericUpDown_B.Value = config.BCurrent;

            this.port.Text = config.Port;


        }

        private void toolStripMenuItem1_Click_Add(object sender, EventArgs e)
        {
            try
            {
                var viewer = this.contextMenuStrip1.SourceControl as DataGridView;
                if (viewer != null)
                {
                    var name = viewer.Name;
                    if (name == "dataGridView_A")
                    {
                        this.dataGridView_A.DataSource = null;
                        this.Channels_A.Add(new ChannelInfo());
                        this.dataGridView_A.DataSource = this.Channels_A;
                    }
                    else
                    {
                        this.dataGridView_B.DataSource = null;
                        this.Channels_B.Add(new ChannelInfo());
                        this.dataGridView_B.DataSource = this.Channels_B;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.log.Error(ex.Message, ex);
            }
        }
        private void toolStripMenuItem2_Click_Remove(object sender, EventArgs e)
        {
            try
            {


                var viewer = this.contextMenuStrip1.SourceControl as DataGridView;
                var item = viewer.SelectedRows;
                var name = viewer.Name;

                if (viewer != null && item != null && item.Count > 0)
                {
                    ChannelInfo info = item[0].DataBoundItem as ChannelInfo;
                    if (info != null)
                    {
                        if (name == "dataGridView_A")
                        {
                            if (this.Channels_A.Contains(info))
                            {

                                this.dataGridView_A.DataSource = null;
                                this.Channels_A.Remove(info);
                                this.dataGridView_A.DataSource = this.Channels_A;
                            }
                        }
                        else
                        {
                            if (this.Channels_B.Contains(info))
                            {
                                //this.dataGridView_B.Rows.RemoveAt(item[0].Index);
                                this.dataGridView_B.DataSource = null;
                                this.Channels_B.Remove(info);
                                //this.dataGridView_B.AllowUserToDeleteRows = true;
                                //(item[0].DataBoundItem as DataRowView).Delete();
                                // ResetView(this.dataGridView_B);
                                this.dataGridView_B.DataSource = this.Channels_B;
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Log.log.Error(ex.Message, ex);
            }
        }

        private void ResetView(DataGridView dview)
        {
            // 
            // Column_ID
            // 
            this.Column_ID.DataPropertyName = "ID";
            this.Column_ID.HeaderText = "编号(从0开始)";
            this.Column_ID.Name = "Column_ID";
            this.Column_ID.Width = 200;

            dview.Columns.Add(this.Column_ID.Clone() as DataGridViewTextBoxColumn);
            // 
            // Column_Count
            // 
            this.Column_Count.DataPropertyName = "Count";
            this.Column_Count.HeaderText = "数量";
            this.Column_Count.Name = "Column_Count";
            this.Column_Count.Width = 200;
            dview.Columns.Add(this.Column_Count.Clone() as DataGridViewTextBoxColumn);
            dview.AutoGenerateColumns = false;
        }
    }
}
