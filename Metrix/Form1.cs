using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Metrix
{
    public partial class Form1 : Form
    {
        private MetrixDistributedService.EmployeeServicesClient empclient; //Employee Client Object
        private MetrixDistributedService.Employee employee; //New instance of employee object Reff : Line 363 Save Method
        
        private MetrixDistributedService.CustomerServicesClient cusclient;
        private MetrixDistributedService.Customer customer;
        
        private MetrixDistributedService.ProductServicesClient proclient;
        private MetrixDistributedService.Product product;

        private MetrixDistributedService.SupplierServicesClient supclient;
        private MetrixDistributedService.Supplier supplier;

        private MetrixDistributedService.InvoiceServicesClient invoclient;
        private MetrixDistributedService.Invoice invoice;

        private MetrixDistributedService.OrderServicesClient ordclient;
        private MetrixDistributedService.Order order;
        
        private DataSet set;
        private DataTable table;

        String user;

        public Form1()
        {
            InitializeComponent();
            timer1.Start();

        }
        public Form1(String y)
        {
            InitializeComponent();
            timer1.Start();
            user = y;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            //panel2.BackColor=Color.#c0392b;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            //panel2.BackColor = Color.AntiqueWhite;
          
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (StockProId_txt.Text == "" || StockIn_txt.Text == "" || StockRecoLvl_txt.Text== "" || StockOrder_txt.Text == "" )
            {
                MessageBox.Show("Fill all the fields to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
            //s.SproId = Convert.ToInt16(StockProId_txt.Text);
            //s.Sinstock = Convert.ToInt16(StockIn_txt.Text);
            //s.Srelevel = Convert.ToInt16(StockRecoLvl_txt.Text);
            ////s.Squan = Convert.ToInt16(StockRecoQuan_txt.Text);
            //s.Sordered = Convert.ToInt16(StockOrder_txt.Text);

            //s.save();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //StockClass s = new StockClass();
                //s.SproId = Convert.ToInt16(StockProId_txt.Text);
                //s.Search();
                //StockIn_txt.Text = Convert.ToString(s.Sinstock);
                //StockRecoLvl_txt.Text = Convert.ToString(s.Srelevel);
                //StockRecoQuan_txt.Text = Convert.ToString(s.Squan);
                //StockOrder_txt.Text = Convert.ToString(s.Sordered);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter the required ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {   
            
            string firstColum = OrdProdId_txt.Text;
            string secondColum = OrdQuan_txt.Text;
            string[] row = { firstColum, secondColum };

            DataTable dt = new DataTable();

            dt.Columns.Add("ProductId");
            dt.Columns.Add("Quantity");
            
            
                dt.Rows.Add(row[0], row[1]);
                OrdList_grid.DataSource = dt;
            

           // MessageBox.Show(OrdList_grid.Rows.Count.ToString());

            OrdProdId_txt.Clear();
            OrdQuan_txt.Clear();
        
        }

        private void OrderSavebtn_Click(object sender, EventArgs e)
        {
            ordclient = new MetrixDistributedService.OrderServicesClient();
            int check = 0;
            int check1 = 0;
            for (int i = 0; i < OrdList_grid.Rows.Count; i++)
            {
                order = new MetrixDistributedService.Order()
                {
                    ordId = Convert.ToInt16(OrdId_txt.Text),
                    product = Convert.ToInt16(OrdList_grid.Rows[i].Cells[0].Value),
                    Quantity = Convert.ToInt16(OrdList_grid.Rows[i].Cells[1].Value)
                };


                check = ordclient.SaveOrderList(order);

                if (check == 1)
                {
                    MessageBox.Show(string.Format("Data Saved Sucessfully in Order List"), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    MessageBox.Show("Data Not Saved Sucessfully in Order List", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
           // OrdList_grid.Rows.RemoveAt(OrdList_grid.Rows.Count);
            try
            {
                order = new MetrixDistributedService.Order()
                {
                    ordId = Convert.ToInt16(OrdId_txt.Text),
                    ordDate = Convert.ToDateTime(ordDate.Text),
                    expectDate = Convert.ToDateTime(expectDate.Text),
                    suplier = Convert.ToInt16(OrdSupId_txt.Text)
                    //so.ordPaid = ordPaid.select
                };
                check1 = ordclient.OrderSave(order);
                if (check1 == 1)
                {
                    MessageBox.Show(string.Format("Order ID {0} Saved ", OrdId_txt.Text), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show(string.Format("Order ID {0} Not Saved", OrdId_txt.Text), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            catch (Exception)
            {
                MessageBox.Show("A database error ocurred! Contact system administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        

        private void OrdId_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void OrdList_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OrderUpdatebtn_Click(object sender, EventArgs e)
        {
            ordclient = new MetrixDistributedService.OrderServicesClient();
            int check = 0;
            //update wenna ona order table eka witharayi. order list ona na.
            try
            {
                order = new MetrixDistributedService.Order()
                {
                    ordId = Convert.ToInt16(OrdId_txt.Text),
                    ordDate = Convert.ToDateTime(ordDate.Text),
                    expectDate = Convert.ToDateTime(expectDate.Text),
                    suplier = Convert.ToInt16(OrdSupId_txt.Text)

                    //Boolean paid;
                    //if (checkBox1.Checked)
                    //{
                    //    paid = true;
                    //}
                    //else {
                    //    paid = false;
                    //}
                    //so.ordPaid = paid;

                };

                check = ordclient.OrderUpdate(order);
                if (check == 1)
                {
                    MessageBox.Show(string.Format("Order ID {0} Updated ", OrdId_txt.Text), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show(string.Format("Order ID {0} Not Updated", OrdId_txt.Text), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("A database error ocurred! Contact system administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void OrderSearch_btn_Click(object sender, EventArgs e)
        {
            ordclient = new MetrixDistributedService.OrderServicesClient();
            try
            {
                order = new MetrixDistributedService.Order()
                {
                    ordId = Convert.ToInt16(OrdId_txt.Text),
                    ordDate = Convert.ToDateTime(ordDate.Text),
                    expectDate = Convert.ToDateTime(expectDate.Text),
                    suplier = Convert.ToInt16(OrdSupId_txt.Text)
                };
                OrdList_grid.DataSource = ordclient.SaveOrderList(order);
            }
            catch (Exception)
            {
                MessageBox.Show("Enter the required ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StockClearbtn_Click(object sender, EventArgs e)
        {
            
            StockIn_txt.Clear();
            StockProId_txt.Clear();
            StockRecoLvl_txt.Clear();
            StockRecoQuan_txt.Clear();
            StockOrder_txt.Clear();
        }

        private void StockUpdatebtn_Click(object sender, EventArgs e)
        {
            if (StockProId_txt.Text == "" || StockIn_txt.Text == "" || StockRecoLvl_txt.Text== "" ||StockOrder_txt.Text == "" )
            {
                MessageBox.Show("Fill all the fields to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
            //s.SproId = Convert.ToInt16(StockProId_txt.Text);
            //s.Sinstock = Convert.ToInt16(StockIn_txt.Text);
            //s.Srelevel = Convert.ToInt16(StockRecoLvl_txt.Text);
            //s.Squan = Convert.ToInt16(StockRecoQuan_txt.Text);
            //s.Sordered = Convert.ToInt16(StockOrder_txt.Text);
            //s.update();
            }
        }

        private void StockDeletebtn_Click(object sender, EventArgs e)
        {
            if (StockProId_txt.Text == "")
            {
                MessageBox.Show("Enter ID!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                //s.SproId = Convert.ToInt16(StockProId_txt.Text);
                //s.delete();
            }
        }

        private void OrderDelete_btn_Click(object sender, EventArgs e)
        {
            ordclient = new MetrixDistributedService.OrderServicesClient();
            int check = 0;
            try
            {
                order = new MetrixDistributedService.Order()
                {
                    ordId = Convert.ToInt16(OrdId_txt.Text)
                };
                check = ordclient.OrderDelete(order);

                if (check == 1)
                {
                    MessageBox.Show(string.Format("Order ID {0} Deleted ", OrdId_txt.Text), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show(string.Format("Order ID {0} Not Deleted", OrdId_txt.Text), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("A database error ocurred! Contact system administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void b1_Click(object sender, EventArgs e)
        {

        }

        private void InvoiceSave_Click(object sender, EventArgs e)
        {
            invoclient = new MetrixDistributedService.InvoiceServicesClient();
            int check = 0;
            int check1 = 0; 
            if (InvoId_txt.Text == "" || InvoTime.Text == "" || InvoTot_txt.Text == "" || InvoEmpId_txt.Text == "" || InvoiceCusId_txt.Text == "")
            {
                MessageBox.Show("Fill all the fields to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                try
                {
                    //invoice table
                    invoice = new MetrixDistributedService.Invoice()
                    {
                        //Parsing values into service
                        invoice = Convert.ToInt16(InvoId_txt.Text),
                        Date = Convert.ToDateTime(InvoDate.Text),
                        Invotime = InvoTime.Text,
                        tot = Convert.ToInt16(InvoTot_txt.Text),
                        employeeId = Convert.ToInt16(InvoEmpId_txt.Text),
                        customer = Convert.ToInt16(InvoiceCusId_txt.Text)
                    };
                    check = invoclient.InvoiceSave(invoice);
                    if (check == 1)
                    {
                        MessageBox.Show(string.Format("Invoice ID {0} Saved ", InvoId_txt.Text), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        MessageBox.Show(string.Format("Invoice ID {0} Not Saved", InvoId_txt.Text), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("A database error ocurred! Contact system administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                                   
                //invoiceProductList table
                for (int i = 0; i < (InvoList_grid.Rows.Count-1); i++)
                {
                    invoice = new MetrixDistributedService.Invoice()
                        
                    {
                      //Parsing values into service
                      product = Convert.ToInt16(InvoList_grid.Rows[i].Cells["ProductId"].Value),
                      quan = Convert.ToInt16(InvoList_grid.Rows[i].Cells["Quantity"].Value)
                    };
                    check1 = invoclient.SaveInvoiceList(invoice);
                    if (check1 == 1)
                    {
                        MessageBox.Show(string.Format("Data Saved Sucessfully to Invoice List ", InvoId_txt.Text), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        MessageBox.Show(string.Format("Invoice ID {0} Not Saved to Invoice List", InvoId_txt.Text), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                        
                }
                

               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (InvoProId_txt.Text == "" || InvoQuan_txt.Text == "")
            //{
            //    MessageBox.Show("Fill all the fields to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //}
            //else
            //{
            //    //string firstColum = txtUomtyp.Text;
            //    //string secondColum = txtUomDesc.Text;
            //    //string[] row = { firstColum, secondColum };
            //    //DataGridViewRow.Rows.Add(row);
            //    string firstColumn = "Auto Increment";
            //    string secondColumn = InvoProId_txt.Text;
            //    string thirdColumn = InvoQuan_txt.Text;
            //    string[] row = {firstColumn, secondColumn, thirdColumn };
            //    InvoList_grid.Rows.Add(row);

            //    //stock table
            //    s.proInvo = Convert.ToInt16(InvoProId_txt.Text);
            //    s.quanInvo = Convert.ToInt16(InvoQuan_txt.Text);
            //    s.updateSockByInvoice();
            //}
        }

        private void btnEmpSave_Click(object sender, EventArgs e)
        {

        }

        private void btnEmpSave_Click_1(object sender, EventArgs e)
        {
            empclient = new MetrixDistributedService.EmployeeServicesClient();
            int check = 0;
            if (Empid_txt.Text == "" || EmpName_txt.Text == "" || EmpContact_text.Text == "" || EmpNic_text.Text == "" || EmpPos_text.Text == "" || EmpDept_text.Text == "")
            {
                MessageBox.Show("Fill all the fields to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                try
                {
                    //Parsing the textbox values to  the service
                    employee = new MetrixDistributedService.Employee()
                    {
                        empIdValue = int.Parse(Empid_txt.Text),
                        empNameValue = EmpName_txt.Text,
                        empContactValue = EmpContact_text.Text,
                        empAdLine1Value = EmpAdLine1_text.Text,
                        empAdLine2Value = EmpAdLine2_text.Text,
                        empDobValue = Convert.ToDateTime(EmpDob_text.Text),
                        empNicValue = EmpNic_text.Text,
                        empPosValue = EmpPos_text.Text,
                        empDeptValue = EmpDept_text.Text
                    };

                    check = empclient.EmployeeSave(employee);
                    if (check == 1)
                    {
                        MessageBox.Show(string.Format("Employee ID {0} Data Saved", Empid_txt.Text), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Employee ID {0} Not Saved", Empid_txt.Text), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("A database error ocurred! Contact system administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                 

            }
        }

        private void btnEmpUpdate_Click(object sender, EventArgs e)
        {
            empclient = new MetrixDistributedService.EmployeeServicesClient();
            int check = 0;
            if (Empid_txt.Text == "" || EmpName_txt.Text == "" || EmpContact_text.Text == "" || EmpNic_text.Text == "" || EmpPos_text.Text == "" || EmpDept_text.Text == "")
            {
                MessageBox.Show("Fill all the fields to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                try
                {
                    //Parsing the textbox values to  the service
                    employee = new MetrixDistributedService.Employee()
                    {
                        empIdValue = int.Parse(Empid_txt.Text),
                        empNameValue = EmpName_txt.Text,
                        empContactValue = EmpContact_text.Text,
                        empAdLine1Value = EmpAdLine1_text.Text,
                        empAdLine2Value = EmpAdLine2_text.Text,
                        empDobValue = Convert.ToDateTime(EmpDob_text.Text),
                        empNicValue = EmpNic_text.Text,
                        empPosValue = EmpPos_text.Text,
                        empDeptValue = EmpDept_text.Text
                    };

                    check = empclient.EmployeeUpdate(employee);
                    if (check == 1)
                    {
                        MessageBox.Show(string.Format("Employee ID {0} Data Updated", Empid_txt.Text), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Employee ID {0} Not Updated", Empid_txt.Text), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("A database error ocurred! Contact system administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEmpDelete_Click(object sender, EventArgs e)
        {
            empclient = new MetrixDistributedService.EmployeeServicesClient();
            int check = 0;
            if (Empid_txt.Text == "")
            {
                MessageBox.Show("Enter ID !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                try
                {
                    //Parsing the textbox values to  the service
                    employee = new MetrixDistributedService.Employee()
                    {
                        empIdValue = int.Parse(Empid_txt.Text),
                        empNameValue = EmpName_txt.Text,
                        empContactValue = EmpContact_text.Text,
                        empAdLine1Value = EmpAdLine1_text.Text,
                        empAdLine2Value = EmpAdLine2_text.Text,
                        empDobValue = Convert.ToDateTime(EmpDob_text.Text),
                        empNicValue = EmpNic_text.Text,
                        empPosValue = EmpPos_text.Text,
                        empDeptValue = EmpDept_text.Text
                    };

                    check = empclient.EmployeeDelete(employee);
                    if (check == 1)
                    {
                        MessageBox.Show(string.Format("Employee ID {0} Data Deleted", Empid_txt.Text), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Employee ID {0} Not Deleted", Empid_txt.Text), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("A database error ocurred! Contact system administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnProdSave_Click(object sender, EventArgs e)
        {
            proclient = new MetrixDistributedService.ProductServicesClient();
            int check = 0;
            if (ProductId_text.Text == "" || ProdName_text.Text == "" || ProdBrand_text.Text == "" || ProdCon_text.Text == "" || ProdSupid_text.Text == "" || ProdPurch_text.Text == "" || ProdSales_text.Text == "")
            {
                MessageBox.Show("Fill all the fields to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                
                try
                {
                    
                    product = new MetrixDistributedService.Product()
                    {
                        prodIdValue = int.Parse(ProductId_text.Text),
                        nameValue = ProdName_text.Text,
                        brandValue = ProdBrand_text.Text,
                        countryValue = ProdCon_text.Text,
                        supIdValue = int.Parse(ProdSupid_text.Text),
                        purchPriceValue = int.Parse(ProdPurch_text.Text),
                        salePriceValue = int.Parse(ProdSales_text.Text),
                        warrentValue = ProdWarr_text.Text
                    };
                    check = proclient.ProductSave(product); 

                    if (check == 1)
                    {
                        MessageBox.Show(string.Format("Product ID {0} Data Saved", ProductId_text.Text), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Product ID {0} Not Saved", ProductId_text.Text), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch(Exception)
                {
                   MessageBox.Show("A database error ocurred! Contact system administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
        }

        private void btnProdUpdate_Click(object sender, EventArgs e)
        {
            proclient = new MetrixDistributedService.ProductServicesClient();
            int check = 0;
            if (ProductId_text.Text == "" || ProdName_text.Text == "" || ProdBrand_text.Text == "" || ProdCon_text.Text == "" || ProdSupid_text.Text == "" || ProdPurch_text.Text == "" || ProdSales_text.Text == "")
            {
                MessageBox.Show("Fill all the fields to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                try
                {
                    product = new MetrixDistributedService.Product(){
                    
                    prodIdValue = int.Parse(ProductId_text.Text),
                    nameValue = ProdName_text.Text,
                    brandValue = ProdBrand_text.Text,
                    countryValue = ProdCon_text.Text,
                    supIdValue = int.Parse(ProdSupid_text.Text),
                    purchPriceValue = int.Parse(ProdPurch_text.Text),
                    salePriceValue = int.Parse(ProdSales_text.Text),
                    warrentValue = ProdWarr_text.Text
                    };
                    check = proclient.ProductUpdate(product);
                    if (check == 1)
                    {
                        MessageBox.Show(string.Format("Product ID {0} Data Updated", ProductId_text.Text), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Product ID {0} Not Updated", ProductId_text.Text), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                
                
                catch (Exception)
                {
                    MessageBox.Show("A database error ocurred! Contact system administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnProdDelete_Click(object sender, EventArgs e)
        {
            proclient = new MetrixDistributedService.ProductServicesClient();
            int check = 0;
            if (ProductId_text.Text == "")
            {
                MessageBox.Show("Enter the ID !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                try
                {
                    product = new MetrixDistributedService.Product(){
                    
                    prodIdValue = int.Parse(ProductId_text.Text),
                    nameValue = ProdName_text.Text,
                    brandValue = ProdBrand_text.Text,
                    countryValue = ProdCon_text.Text,
                    supIdValue = int.Parse(ProdSupid_text.Text),
                    purchPriceValue = int.Parse(ProdPurch_text.Text),
                    salePriceValue = int.Parse(ProdSales_text.Text),
                    warrentValue = ProdWarr_text.Text
                    
                    };
                    check = proclient.ProductDelete(product);
                    if (check == 1)
                    {
                        MessageBox.Show(string.Format("Product ID {0} Data Deleted", ProductId_text.Text), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Product ID {0} Not Deleted", ProductId_text.Text), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("A database error ocurred! Contact system administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSupSave_Click(object sender, EventArgs e)
        {
            supclient = new MetrixDistributedService.SupplierServicesClient();
            int check = 0;
            if (SupId_txt.Text == "" || SupName_txt.Text == "" || SupConNo_txt.Text == "" || SupAddress_txt.Text == "" || SupEmail_txt.Text == "" || SupRefName_txt.Text == "")
            {
                MessageBox.Show("Fill all the fields to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            else
            {
               
                if (System.Text.RegularExpressions.Regex.IsMatch(SupEmail_txt.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                {
                    MessageBox.Show("Please Enter a valid Email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    try{
                        
                        supplier = new MetrixDistributedService.Supplier(){
                        
                        supIdValue = int.Parse(SupId_txt.Text),
                        companyNameValue = SupName_txt.Text,
                        contactValue = SupConNo_txt.Text,
                        countryValue = SupAddress_txt.Text,
                        emailValue = SupEmail_txt.Text,
                        refNameValue = SupRefName_txt.Text
                        
                    };
                    check = supclient.SupplierSave(supplier);
                    if (check == 1)
                    {
                        MessageBox.Show(string.Format("Supplier ID {0} Data Saved", ProductId_text.Text), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Supplier ID ID {0} Not Saved", ProductId_text.Text), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("A database error ocurred! Contact system administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSupUpdate_Click(object sender, EventArgs e)
        {

            supclient = new MetrixDistributedService.SupplierServicesClient();
            int check = 0;
            if (SupId_txt.Text == "" || SupName_txt.Text == "" || SupConNo_txt.Text == "" || SupAddress_txt.Text == "" || SupEmail_txt.Text == "" || SupRefName_txt.Text == "")
            {
                MessageBox.Show("Fill all the fields to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            else
            {

                if (System.Text.RegularExpressions.Regex.IsMatch(SupEmail_txt.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                {
                    MessageBox.Show("Please Enter a valid Email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    try{
                        
                        supplier = new MetrixDistributedService.Supplier(){
                        
                        supIdValue = int.Parse(SupId_txt.Text),
                        companyNameValue = SupName_txt.Text,
                        contactValue = SupConNo_txt.Text,
                        countryValue = SupAddress_txt.Text,
                        emailValue = SupEmail_txt.Text,
                        refNameValue = SupRefName_txt.Text
                        
                    };
                    check = supclient.SupplierUpdate(supplier);
                    if (check == 1)
                    {
                        MessageBox.Show(string.Format("Supplier ID {0} Data Updated", ProductId_text.Text), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Supplier ID ID {0} Not Updated", ProductId_text.Text), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("A database error ocurred! Contact system administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSupDelete_Click(object sender, EventArgs e)
        {
            supclient = new MetrixDistributedService.SupplierServicesClient();
            int check = 0;
            if (SupId_txt.Text == "" )
            {
                 MessageBox.Show("Enter ID !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                try{
                        
                        supplier = new MetrixDistributedService.Supplier(){
                        
                        supIdValue = int.Parse(SupId_txt.Text),
                        companyNameValue = SupName_txt.Text,
                        contactValue = SupConNo_txt.Text,
                        countryValue = SupAddress_txt.Text,
                        emailValue = SupEmail_txt.Text,
                        refNameValue = SupRefName_txt.Text
                        
                    };
                    check = supclient.SupplierDelete(supplier);
                    if (check == 1)
                    {
                        MessageBox.Show(string.Format("Supplier ID {0} Data Deleted", ProductId_text.Text), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Supplier ID ID {0} Not Deleted", ProductId_text.Text), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("A database error ocurred! Contact system administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void btnCusSave_Click(object sender, EventArgs e)
        {
            cusclient = new MetrixDistributedService.CustomerServicesClient();
            int check = 0;
            if (CusID_txt.Text == "" || CusName_txt.Text == "" || CusConNo_txt.Text == "" || CusNic_txt.Text == "" || CusAddress1_txt.Text == "" || CusAddress2_txt.Text == "")
            {
                MessageBox.Show("Fill all the blanks to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                try
                {
                    customer = new MetrixDistributedService.Customer()
                    {
                        cusIdValue = int.Parse(CusID_txt.Text),
                        cusNameValue = CusName_txt.Text,
                        cusContactValue = CusConNo_txt.Text,
                        cusNicValue = CusNic_txt.Text,
                        cusAdLine1Value = CusAddress1_txt.Text,
                        cusAdLine2Value = CusAddress2_txt.Text,
                        cusAdLine3Value = CusAddress3_txt.Text
                    };
                    check = cusclient.CustomerSave(customer);
                    if (check == 1)
                    {
                        MessageBox.Show(string.Format("Customer ID {0} Data Saved", CusID_txt.Text), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Customer ID {0} Not Saved", CusID_txt.Text), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("A database error ocurred! Contact system administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void btnCusUpdate_Click(object sender, EventArgs e)
        {
            cusclient = new MetrixDistributedService.CustomerServicesClient();
            int check = 0;
            if (CusID_txt.Text == "" || CusName_txt.Text == "" || CusConNo_txt.Text == "" || CusNic_txt.Text == "" || CusAddress1_txt.Text == "" || CusAddress2_txt.Text == "")
            
            {
                MessageBox.Show("Fill all the blanks to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            else
            {
                try
                {
                    customer = new MetrixDistributedService.Customer()
                    {
                        cusIdValue = int.Parse(CusID_txt.Text),
                        cusNameValue = CusName_txt.Text,
                        cusContactValue = CusConNo_txt.Text,
                        cusNicValue = CusNic_txt.Text,
                        cusAdLine1Value = CusAddress1_txt.Text,
                        cusAdLine2Value = CusAddress2_txt.Text,
                        cusAdLine3Value = CusAddress3_txt.Text
                    };
                    check = cusclient.CustomerUpdate(customer);
                    if (check == 1)
                    {
                        MessageBox.Show(string.Format("Customer ID {0} Data Updated", CusID_txt.Text), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Customer ID {0} Not Updated", CusID_txt.Text), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("A database error ocurred! Contact system administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCusDelete_Click(object sender, EventArgs e)
        {
            cusclient = new MetrixDistributedService.CustomerServicesClient();
            int check = 0;
            if (CusID_txt.Text == "")
            {
                MessageBox.Show("Enter the ID !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
             {
                 try
                 {
                     customer = new MetrixDistributedService.Customer()
                     {
                         cusIdValue = int.Parse(CusID_txt.Text),
                         cusNameValue = CusName_txt.Text,
                         cusContactValue = CusConNo_txt.Text,
                         cusNicValue = CusNic_txt.Text,
                         cusAdLine1Value = CusAddress1_txt.Text,
                         cusAdLine2Value = CusAddress2_txt.Text,
                         cusAdLine3Value = CusAddress3_txt.Text
                     };
                     check = cusclient.CustomerDelete(customer);
                     if (check == 1)
                     {
                         MessageBox.Show(string.Format("Customer ID {0} Data Deleted", CusID_txt.Text), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                     else
                     {
                         MessageBox.Show(string.Format("Customer ID {0} Not Deleted", CusID_txt.Text), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     }
                 }

                 catch (Exception)
                 {
                     MessageBox.Show("A database error ocurred! Contact system administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
             }
        }

        private void SupConNo_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductbtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                
               
                    product = new MetrixDistributedService.Product(){
                    
                    prodIdValue = int.Parse(ProductId_text.Text),
                    nameValue = ProdName_text.Text,
                    brandValue = ProdBrand_text.Text,
                    countryValue = ProdCon_text.Text,
                    supIdValue = int.Parse(ProdSupid_text.Text),
                    purchPriceValue = int.Parse(ProdPurch_text.Text),
                    salePriceValue = int.Parse(ProdSales_text.Text),
                    warrentValue = ProdWarr_text.Text
                    
                    };
                    proclient.ProductSearch(Convert.ToInt16(ProductId_text.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Enter the required ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                supplier = new MetrixDistributedService.Supplier()
                {

                    supIdValue = Convert.ToInt16(SupId_txt.Text),
                    companyNameValue = SupName_txt.Text,
                    contactValue = SupConNo_txt.Text,
                    add = SupAddress_txt.Text,
                    emailValue = SupEmail_txt.Text,
                    refNameValue = SupRefName_txt.Text 
                };
                supclient.SupplierSearch(Convert.ToInt16(SupId_txt.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Enter the required ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InvoiceSearch_Click(object sender, EventArgs e)
        {
            invoclient = new MetrixDistributedService.InvoiceServicesClient();
            try
            {
                invoice = new MetrixDistributedService.Invoice()
                {
                    invoice = Convert.ToInt16(InvoId_txt.Text),
                    Date = Convert.ToDateTime(InvoDate.Text),
                    Invotime = InvoTime.Text,
                    tot = Convert.ToInt16(InvoTot_txt.Text),
                    employeeId = Convert.ToInt16(InvoEmpId_txt.Text),
                    customer = Convert.ToInt16(InvoiceCusId_txt.Text)
                };
                invoclient.InvoiceProductSearch(Convert.ToInt16(InvoId_txt.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Enter the required ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ProductId_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void ProdSupid_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void ProdPurch_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void ProdSales_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void Empid_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void EmpContact_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void empSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //Parsing the textbox values to  the service
                employee = new MetrixDistributedService.Employee()
                {
                    empIdValue = int.Parse(Empid_txt.Text),
                    empNameValue = EmpName_txt.Text,
                    empContactValue = EmpContact_text.Text,
                    empAdLine1Value = EmpAdLine1_text.Text,
                    empAdLine2Value = EmpAdLine2_text.Text,
                    empDobValue = Convert.ToDateTime(EmpDob_text.Text),
                    empNicValue = EmpNic_text.Text,
                    empPosValue = EmpPos_text.Text,
                    empDeptValue = EmpDept_text.Text
                };

                empclient.EmployeeSearch(Convert.ToInt16(Empid_txt.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Enter the required ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StockProId_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        
        }

        private void StockRecoQuan_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        
        }

        private void StockRecoLvl_txt_TextChanged(object sender, EventArgs e)
        {
            
        
        }

        private void OrdProdId_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void OrdQuan_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void OrdSupId_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void InvoId_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
             //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void InvoTot_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
             //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void InvoEmpId_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
             //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        
        }

        private void InvoiceCusId_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void InvoiceCusId_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
             //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void InvoProId_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
             //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
       
        }

        private void InvoQuan_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
             //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        
        }

        private void customerSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //Parsing the textbox values to  the service
                customer = new MetrixDistributedService.Customer()
                {
                    cusIdValue = int.Parse(CusID_txt.Text),
                    cusNameValue = CusName_txt.Text,
                    cusContactValue = CusConNo_txt.Text,
                    cusNicValue = CusNic_txt.Text,
                    cusAdLine1Value = CusAddress1_txt.Text,
                    cusAdLine2Value = CusAddress2_txt.Text,
                    cusAdLine3Value = CusAddress3_txt.Text
                };

                cusclient.CustomerSearch(Convert.ToInt16(CusID_txt.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Enter the required ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CusID_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void CusConNo_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void SupId_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void btnMainExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            login lg = new login();
            lg.ShowDialog();
        }

        private void btnCurrency_Click(object sender, EventArgs e)
        {
            
            Currency cur = new Currency();
            cur.ShowDialog();
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(user=="ad"){
                lblWellcome.Text = "Hi Admin";
            }
            else if (user != "ad")
            {
                lblWellcome.Text = "Hi "+""+user+"";
                btnSupUpdate.Hide();
                btnSupDelete.Hide();
                btnCusUpdate.Hide();
                btnCusDelete.Hide();
                InvoiceSearch.Hide();
                OrderUpdatebtn.Hide();
                OrderDelete_btn.Hide();
                StockUpdatebtn.Hide();
                StockDeletebtn.Hide();
                btnEmpDelete.Hide();
                btnProdDelete.Hide();
            }
            else {
                this.Dispose();
            }

           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.time_lbl.Text = dateTime.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void supBtnClear_Click(object sender, EventArgs e)
        {
            SupId_txt.Clear();
            SupName_txt.Clear();
            SupConNo_txt.Clear();
            SupAddress_txt.Clear();
            SupEmail_txt.Clear();
            SupRefName_txt.Clear();
        }

        private void btnCusClear_Click(object sender, EventArgs e)
        {
            CusID_txt.Clear();
            CusName_txt.Clear();
            CusConNo_txt.Clear();
            CusNic_txt.Clear();
            CusAddress1_txt.Clear();
            CusAddress2_txt.Clear();
            CusAddress3_txt.Clear();
        }

        private void btnProClear_Click(object sender, EventArgs e)
        {
            ProductId_text.Clear();
            ProdName_text.Clear();
            ProdBrand_text.Clear();
            ProdCon_text.Clear();
            ProdSupid_text.Clear();
            ProdPurch_text.Clear();
            ProdSales_text.Clear();
            ProdWarr_text.Clear();

        }

        private void ProdSupid_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEmpClear_Click(object sender, EventArgs e)
        {
            Empid_txt.Clear();
            EmpName_txt.Clear();
            EmpContact_text.Clear();
            EmpAdLine1_text.Clear();
            EmpAdLine2_text.Clear();
            EmpDob_text.Clear();
            EmpNic_text.Clear();
            EmpPos_text.Clear();
            EmpDept_text.Clear();
        }

        private void StockRecoLvl_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void StockOrder_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void StockIn_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void btnOrdClear_Click(object sender, EventArgs e)
        {

        }

        private void SupConNo_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if else shorthand
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
        
    }
}
