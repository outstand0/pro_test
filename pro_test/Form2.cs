using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro_test
{
    public partial class Form2 : Form
    {        
        public delegate void FormSendDataHandler(string s);
        public event FormSendDataHandler FormSendEvent;
                 
        public Form2()
        {
            InitializeComponent();            
        }        

        private void Form2_Load(object sender, EventArgs e)
        {
            Combobox_Data_Add();
            cbbTestSelect.Text = "RF";
        }
        private void Combobox_Data_Add()
        {            
            //cbbTestSelect.Items.Add("BD_CHECKER");
            cbbTestSelect.Items.Add("BDA");
            //cbbTestSelect.Items.Add("Charging");
            cbbTestSelect.Items.Add("CRYSTAL");
            //cbbTestSelect.Items.Add("Dongle_Pairing");
            //cbbTestSelect.Items.Add("FR_Confirmation");
            //cbbTestSelect.Items.Add("GAGE_IC");
            //cbbTestSelect.Items.Add("Howling");
            //cbbTestSelect.Items.Add("IR");
            //cbbTestSelect.Items.Add("LR_PAIRING");
            //cbbTestSelect.Items.Add("Loopback");
            cbbTestSelect.Items.Add("RF");
            //cbbTestSelect.Items.Add("Seal");
            //cbbTestSelect.Items.Add("Thermistor");
            //cbbTestSelect.Items.Add("Touch");
            //cbbTestSelect.Items.Add("Uplink");
        }

        public void cbbTestSelect_SelectedIndexChanged(object sender, EventArgs e)
        {   
            try
            {                
                if (cbbTestSelect.Text == "BD_CHECKER")
                {
                    MessageBox.Show("BD_CHECKER Program Execute!!");                    
                }
                else if (cbbTestSelect.Text == "Charging")
                {
                    MessageBox.Show("Charging Program Execute!!");
                }
                else if (cbbTestSelect.Text == "BDA")
                {
                    MessageBox.Show("BDA Program Execute!!");
                }
                else if (cbbTestSelect.Text == "GAGE_IC")
                {
                    MessageBox.Show("GAGE IC Program Execute!!");
                }
                else if(cbbTestSelect.Text == "CRYSTAL")
                {
                    MessageBox.Show("CRYSTAL Program Execute!!");
                }
                else if(cbbTestSelect.Text == "RF")
                {
                    MessageBox.Show("RF Program Execute!!");
                }
            }
            finally
            {                
                this.FormSendEvent(cbbTestSelect.Text);
                this.Close();
            }
        }
    }
}