using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace final643450082_4
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int N1, N2, sum;
            N1 = (int)Convert.ToInt64(textboxPrice.Text);
            N2 = (int)Convert.ToInt64(textboxNumP.Text);
            sum = N1 * N2;
            textBoxSum.Text = "" + sum;

            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = textBoxNameP.Text;
            dataGridView1.Rows[n].Cells[1].Value = textboxNumP.Text;
            dataGridView1.Rows[n].Cells[2].Value = textBoxSum.Text;

            textBoxNameP.Text = " ";
            textboxPrice.Text = " ";
            textboxNumP.Text = " ";
            textBoxSum.Text = " ";

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);
                string readAllText = File.ReadAllText(openFileDialog.FileName);

                for (int i = 0; i < readAllLine.Length; i++)
                {
                    string ClassshopRAW = readAllLine[i];
                    string[] ClassshopSplited = ClassshopRAW.Split(',');
                    ClassShop classshop = new ClassShop(ClassshopSplited[0], ClassshopSplited[1], ClassshopSplited[2], ClassshopSplited[3]);
                    addDataToGridView("name", "amount", "price");
                }
            }
            void addDataToGridView(string name, string amount, string price)
            {
                this.dataGridView1.Rows.Add(new string[] { name, amount, price });
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = string.Empty;
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV(*.csv)|*.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView1.Columns.Count;
                            string columnNames = "";
                            string[] outputCSV = new string[dataGridView1.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCSV[0] += columnNames;
                            for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCSV[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }
                            File.WriteAllLines(sfd.FileName, outputCSV, Encoding.UTF8);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }

                    }
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "01")
            {
                textBoxNameP.Text = "เสื้อสีขาวลายอิฐ";
                textboxPrice.Text = "200";
            }
            else if (comboBox1.Text == "02")
            {
                textBoxNameP.Text = "หัวเข็มขัดนึกศึกษา";
                textboxPrice.Text = "50";
            }
            else if (comboBox1.Text == "03")
            {
                textBoxNameP.Text = "เสื้อเชิ๊ดเเขนยาว";
                textboxPrice.Text = "300";
            }
            else if (comboBox1.Text == "04")
            {
                textBoxNameP.Text = "เนคไท KKU";
                textboxPrice.Text = "110";
            }
            else if (comboBox1.Text == "05")
            {
                textBoxNameP.Text = "กระเป๋าผ้า KKU";
                textboxPrice.Text = "119";
            }

            textboxNumP.Focus();
        }

        private void textBoxSum_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textboxNumP_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox2.Text == "HAPPYLOWPRICE2022")
            {
                MessageBox.Show("ขอบคุณที่ใช้โค้ดส่วนลดขั้นต่ำ 300 บาท", "HAPPYLOWPRICE2022", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBox2.Text == "HAPPYHIGHPRICE2022")
            {
                MessageBox.Show("ขอบคุณที่ใช้โค้ดส่วนลดซื้อมากกว่า 500 บาท", "HAPPYHIGHPRICE2022", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}



