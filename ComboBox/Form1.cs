using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // ราคาก่อนหัก
            double Totalprice = Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox2.Text);

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                double discounted = 0;
                string selectedCustomerType = comboBox1.SelectedItem.ToString();
                switch (selectedCustomerType)
                {
                    case "ไม่เป็นสมาชิก":
                        if (Totalprice <= 10000)
                        {
                            discounted = 0;
                        }
                        else if (Totalprice <= 30000)
                        {
                            discounted = Totalprice * 0.03;
                        }
                        else
                        {
                            discounted = Totalprice * 0.05;
                        }
                        break;

                    case "สมาชิกปกติ":
                        if (Totalprice <= 10000)
                        {
                            discounted = Totalprice * 0.03;
                        }
                        else if (Totalprice <= 50000)
                        {
                            discounted = Totalprice * 0.07;
                        }
                        else
                        {
                            discounted = Totalprice * 0.1;
                        }
                        break;

                    case "สมาชิก VIP":
                        discounted = Totalprice * 0.1;
                        break;

                    default:
                        MessageBox.Show("โปรดเลือกสินค้าและประเภทลูกค้า");
                        break;
                }
                // ราตาหลังหัก
                double discountedPrice = Totalprice - discounted;
                // ภาษี
                double vat = discountedPrice * 0.07;
                // จำนวนเงินที่ลูกค้าต้องชำระ
                double totalAmount = discountedPrice + vat;

                listBox1.Items.Add("จำหวนเงินก่อนหักส่วนลด = " + Totalprice);
                listBox1.Items.Add("จำนวนส่วนลด = " + discounted);
                listBox1.Items.Add("จำหวนเงินก่อนหักส่วนลด = " + discountedPrice);
                listBox1.Items.Add("จำหวนเงินที่ต้องชำระ = " + totalAmount);
            }
            else
            {
                MessageBox.Show("โปรดเลือกสินค้าและประเภทลูกค้า");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
    

