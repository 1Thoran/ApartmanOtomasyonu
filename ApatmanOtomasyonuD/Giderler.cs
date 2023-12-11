using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApatmanOtomasyonuD
{
    public partial class Giderler : Form
    {
        public Giderler()
        {
            InitializeComponent();
        }
        SqlHelper can = new SqlHelper();    
        private void button1_Click(object sender, EventArgs e)
        {
            int para = (int)numericUpDown1.Value;

            DateTime dt = dateTimePicker1.Value;

            string giderler = "";
            foreach (Control i in groupBox1.Controls)
            {
                if (i is CheckBox && ((CheckBox)i).Checked)
                {
                    giderler += ","+i.Text;
                }
            }
            giderler=giderler.Remove(0,1);

            SqlParameter p1 = new SqlParameter("Gider",giderler);
            SqlParameter p2 = new SqlParameter("Para", para);
            SqlParameter p3 = new SqlParameter("Tarih", dt);

            can.ExecuteProc("giderlerim",p1,p2,p3);
        }

        private void Giderler_Load(object sender, EventArgs e)
        {
            DataTable dtb= can.GetTable("select * from GiderTablosu");

            foreach (DataRow i in dtb.Rows)    
            {
                listBox1.Items.Add(i[3]).ToString();
                listBox2.Items.Add(i[1]).ToString();
                listBox3.Items.Add(i[2]).ToString();
            }
        }
    }
}
