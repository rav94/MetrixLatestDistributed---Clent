using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Metrix
{
    public partial class login : Form
    {
        string user1;
        string pass;
        public int y;

        private MetrixDistributedService.LoginServiceClient logclient;
        private MetrixDistributedService.user user;

        public login()
        {
            InitializeComponent();
            
            txtPass.PasswordChar = '*';
            txtPass.MaxLength = 5;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////Class1 c = new Class1();
            ////c.user = textBox1.Text;
            ////c.pass = textBox2.Text;
            ////c.login();
            //////this.Dispose();


            //logclient = new MetrixDistributedService.LoginServiceClient();


            //MySqlDataReader rd = (logclient.SignIn(Convert.ToString(user));
            
            //    while (rd.Read())
            //    {
            //        user = new MetrixDistributedService.User(){
            //            Username = rd["username"].ToString(),
            //            Password = rd["password"].ToString()
            //        };
            //    }
        
            

            if (txtUser.Text == "admin" && txtPass.Text == "123")
            {
                Form1 f = new Form1("ad");
                //y = 1;
                f.Show();
                //this.Dispose();
                this.Hide();
                //Application.Exit();
            }
            else if (user1 == txtUser.Text && pass == txtPass.Text)
            {
                Form1 f = new Form1(txtUser.Text);
                //y = 2;
                f.Show();
                //this.Dispose();
                this.Hide();
                //Application.Exit();
            }
            else
            {
                MessageBox.Show("Enter the Correct Credentilas", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings st = new Settings();
            st.Show();
            this.Hide();
        }

    }
}
