using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metrix
{
    public partial class Settings : Form
    {
        private MetrixDistributedService.UserSettingsServicesClient usersettclient;
        private MetrixDistributedService.UserSettings usersett;
        
        public Settings()
        {
            InitializeComponent();
            
            //For password field
            txtPw.PasswordChar = '*';
            txtPw.MaxLength = 5;

            //For confirmaing password field
            txtConPw.PasswordChar = '*';
            txtConPw.MaxLength = 5;

            //for admin password
            txtAdminPw.PasswordChar = '*';
            txtAdminPw.MaxLength = 5;
        }

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            usersettclient = new MetrixDistributedService.UserSettingsServicesClient();
            int c = 0;
            if (txtPw.Text == txtConPw.Text)
            {
                if (txtAdminPw.Text == "123")
                {
                    try
                    {
                        usersett = new MetrixDistributedService.UserSettings()
                        {
                            user = txtName.Text,
                            pass = txtPw.Text
                        };
                        c = usersettclient.SignUp(usersett);
                        
                        if (c == 1)
                        {
                            MessageBox.Show("Signning Up Process Successfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Signning Up Process Not Successfull", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("A database error ocurred! Contact system administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else {
                    MessageBox.Show("Enter Correct Admin Password","Try Again",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Check Your password !!","Try Again",MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usersettclient = new MetrixDistributedService.UserSettingsServicesClient();
            int c = 0;
            if (txtPw.Text == txtConPw.Text)
            {
                if (txtAdminPw.Text == "123")
                {
                    try
                    {
                        usersett = new MetrixDistributedService.UserSettings()
                        {
                            user = txtName.Text,
                            pass = txtPw.Text
                        };
                        c = usersettclient.SignUp(usersett);
                        if (c == 1)
                        {
                            MessageBox.Show("Password Changed Sucessfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Password Not Changed Successfully", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("A database error ocurred! Contact system administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Enter Correct Administrator Password", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Check Your Password!!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.Show();
            this.Hide();
        }

        private void txtConPw_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
