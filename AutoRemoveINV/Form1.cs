using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AutoRemoveINV
{

    public partial class Form1 : Form
    {
        private string URL_EACOUNT_LOGIN = "https://loginbc.ecount.com/";
        private string URL_EACOUNT_MAIN = "/ECERP/ECP";
        private IWebDriver driver;
        private List<string> OLD_INV;
        private string OLD_URL;
        // Tạo mới một instance của ChromeDriver (hoặc trình duyệt bạn muốn sử dụng)

        public Form1()
        {
            InitializeComponent();
            this.OLD_INV = new List<string>();
        }

        private string getIDButtonSearch(string type)
        {
            switch (type)
            {
                case "SO":
                    return "div.control-set div#header_data_model_toolbar_item_search button#search";
                case "PI":
                    return "div.control-set div#header_data_model_toolbar_item_search button#search";
                case "WP":
                    return "#tgHeaderSearch";
                case "INV":
                    return "#tgHeaderSearch";
                default:
                    break;
            }
            return "";
        }
        private string cssSelectorButtonDelete(string type)
        {
            switch (type)
            {
                case "SO":
                    return ".wrapper-toolbar .control-set #footer_toolbar_toolbar_item_selected_delete button.btn";
                case "PI":
                    return ".wrapper-toolbar .control-set #footer_toolbar_toolbar_item_selected_delete button.btn";
                case "WP":
                    return "#slipDeleteSelected";
                case "INV":
                    return "#slipDeleteSelected";
                default:
                    break;
            }
            return "";
        }

        private string cssSelectorInputSearch(string type)
        {
            switch (type)
            {
                case "SO":
                    return "//*[@id='quick_search']";
                case "PI":
                    return "//*[@id='quick_search']";
                case "WP":
                    //return "input[data-cid=" + "__headerQuick" + "]";
                    return "//*[@id='mainPage']/div[1]/div[1]/div/div[2]/div[1]/div/input";
                case "INV":
                    return "//*[@id='mainPage']/div[1]/div[2]/div[1]/div/ul/li[2]/div[2]/div/div/input";
                //return ".form .control-set .control input.form-control[data-cid='txtDocNo']";
                default:
                    break;
            }
            return "";
        }


        private string getSelectorBtnXoaNo(string type)
        {
            switch (type)
            {
                case "SO":
                    return "#prodDeleteSelected";
                case "PI":
                    return "#prodDeleteSelected";
                case "WP":
                    return "#prodDeleteSelectedsubmain";
                case "INV":
                    return "#prodDeleteSelected";
                default:
                    break;
            }
            return "";
        }
        private string getSelectorDateNo(string type)
        {
            switch (type)
            {
                case "SO":
                    return "#grid-main > tbody > tr > td:nth-child(3) > a > span";
                case "PI":
                    return "#grid-main > tbody > tr > td:nth-child(3) > a > span";
                case "WP":
                    return "#grid-main > tbody > tr > td:nth-child(3) > a";
                case "INV":
                    return "#grid-main > tbody > tr > td:nth-child(3) > a";
                default:
                    break;
            }
            return "";
        }
        private string getUrlTabs(string type)
        {
            switch (type)
            {
                case "SO":
                    return "#menuType=4&menuSeq=30&groupSeq=30&prgId=C000030";
                case "PI":
                    return "#menuType=4&menuSeq=31&groupSeq=31&prgId=C000031";
                case "WP":
                    return "#menuType=4&menuSeq=32&groupSeq=32&prgId=C000032";
                case "INV":
                    return "#menuType=4&menuSeq=33&groupSeq=33&prgId=C000033";
                default:
                    break;
            }
            return "";
        }
        //returns as soon as element is not visible, or throws WebDriverTimeoutException
        protected void WaitUntilElementNotVisible(By searchElementBy, int timeoutInSeconds)
        {
            new WebDriverWait(this.driver, TimeSpan.FromSeconds(timeoutInSeconds))
                            .Until(drv => !IsElementVisible(searchElementBy));
        }

        private bool IsElementVisible(By searchElementBy)
        {
            try
            {
                return this.driver.FindElement(searchElementBy).Displayed;

            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        private string getOldUrl(string url)
        {
            int index = url.IndexOf('#');
            string result = (index >= 0) ? url.Substring(0, index) : url;
            return result;

        }
        private bool handleDelete(string type)
        {
            try
            {
                if (this.radio_product.Checked)
                {

                    IWebElement deleteButton = this.driver.FindElement(By.CssSelector(this.cssSelectorButtonDelete(type)));
                    deleteButton.Click();
                    IWebElement buttonConfirm = driver.FindElement(By.Id("confirm"));
                    buttonConfirm.Click();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void addDataGridView(string inv, string dateNo, string status)
        {
            var oldIndex = this.dataGridView1.Rows.Count - 1;
            var newIndex = oldIndex + 1;
            string currentDate = DateTime.Now.ToString("HH:mm:ss dd-MM-yyyy");
            int rowIndex = this.dataGridView1.Rows.Add(newIndex, inv, dateNo, status, currentDate);
            DataGridViewCell cell = this.dataGridView1.Rows[rowIndex].Cells[3]; // Assuming you want to style the first cell in the new row
            if (status.Contains("DELETED"))
            {
                cell.Style.ForeColor = Color.Green; // Change to any color you want
            }
            else
            {
                cell.Style.ForeColor = Color.Red; // Change to any color you want
            }

        }
        private void handleWithWQickSearch(string typeINV, string[] arrInv)
        {
            foreach (var inv in arrInv)
            {
                // Check if "wp" is not present in the string "inv"
                if (!inv.Contains(typeINV))
                {
                    this.addDataGridView(inv, "", "INVALID INV!");
                    continue; // Skip to the next iteration
                }
                string newInv = inv.Trim();
                var checkRemoveNo = this.checkNoDelete(newInv);
                if (checkRemoveNo.Length > 0)
                {
                    newInv = checkRemoveNo[0];
                }
                this.setStatusProcessing(newInv);
                IWebElement inputFieldSearch = this.driver.FindElement(By.XPath(this.cssSelectorInputSearch(typeINV)));
                inputFieldSearch.Clear();
                System.Threading.Thread.Sleep(1000); // 2000 milliseconds = 2 seconds
                inputFieldSearch.SendKeys(newInv);
                System.Threading.Thread.Sleep(500); // 2000 milliseconds = 2 seconds
                inputFieldSearch.SendKeys(OpenQA.Selenium.Keys.Enter);

                string userInput = newInv.Trim(); // Giá trị cần so sánh trong thẻ <span> của cột thứ 2
                System.Threading.Thread.Sleep(2000); // 2000 milliseconds = 2 seconds
                if (checkRemoveNo.Length > 0)
                {
                    var noDel = int.Parse(checkRemoveNo[1]);
                    this.deleteNoInINV(userInput, noDel, typeINV);
                }
                else
                {
                    this.handleClickCheckBox(userInput, typeINV);
                }
            }


        }
        private string[] checkNoDelete(string inv)
        {

            if (inv.Contains(";"))
            {
                string[] parts = inv.Split(';'); // Split the string at the semicolon

                if (parts.Length > 1) // Check if there are at least two parts
                {
                    return parts;
                }
            }
            return new string[0];
        }
        private void deleteNoInINV(string inv, int noDel, string type)
        {
            try
            {
                IWebElement spanINV_NO = this.driver.FindElement(By.CssSelector("#grid-main > tbody > tr > td:nth-child(2) > span"));
                if (spanINV_NO != null)
                {
                    string textINV = spanINV_NO.Text;
                    if (textINV.Trim().ToLower() == inv.Trim().ToLower())
                    {
                        IWebElement spanDate_NO = this.driver.FindElement(By.CssSelector(this.getSelectorDateNo(type)));
                        if (spanDate_NO != null)
                        {

                            string dateNo = spanDate_NO.Text;
                            spanDate_NO.Click();
                            System.Threading.Thread.Sleep(5000);
                            string xpathCheckbox = "#grid-main > tbody > tr:nth-child(noDel) > td:nth-child(1) > div > input[type=checkbox]".Replace("noDel", noDel.ToString());
                            IWebElement checkboxNo = this.driver.FindElement(By.CssSelector(xpathCheckbox));
                            checkboxNo.Click();
                            System.Threading.Thread.Sleep(500);
                            if (this.radio_product.Checked)
                            {
                                IWebElement btnXoa = this.driver.FindElement(By.CssSelector(this.getSelectorBtnXoaNo(type)));
                                btnXoa.Click();
                                System.Threading.Thread.Sleep(500);
                                IWebElement btnSaveNo = this.driver.FindElement(By.CssSelector("#group3slipSave"));
                                btnSaveNo.Click();
                                System.Threading.Thread.Sleep(1000);
                            }
                            this.addDataGridView(inv, dateNo, $"DELETED NO:{noDel}");
                        }
                        else
                        {
                            this.addDataGridView(inv, "", "NOT FOUND DATE_NO!");
                        }
                    }
                    else
                    {
                        this.addDataGridView(inv, "", "NOT FOUND INV!");
                    }
                    //f8 -> lưu
                }
                else
                {
                    this.addDataGridView(inv, "", "NOT FOUND INV!");
                }

            }
            catch (Exception)
            {
                this.addDataGridView(inv, "", "ERORR WHILE WORKING!");
            }

        }
        private void handleClickCheckBox(string inv, string typeINV)
        {
            string userInput = inv.Trim(); // Giá trị cần so sánh trong thẻ <span> của cột thứ 2

            //
            // Lấy giá trị text từ thẻ <span> trong cột thứ 2 của hàng
            string invNo = "";
            string dateNo = "";
            try
            {
                IWebElement spanINV_NO = this.driver.FindElement(By.CssSelector("#grid-main > tbody > tr > td:nth-child(2) > span"));
                if (spanINV_NO != null)
                {
                    invNo = spanINV_NO.Text;
                }
            }
            catch (Exception)
            {

            }
            if (invNo.Trim() == userInput)
            {
                //#grid-main > tbody > tr > td:nth-child(3) > a
                // lay gia tri cua date no
                try
                {
                    IWebElement spanDateNo = this.driver.FindElement(By.CssSelector(this.getSelectorDateNo(typeINV)));
                    if (spanDateNo != null)
                    {
                        dateNo = spanDateNo.Text;
                    }
                }
                catch (Exception)
                {
                }
                if (dateNo != "")
                {
                    IWebElement checkbox = this.driver.FindElement(By.CssSelector("#grid-main > tbody > tr > td:nth-child(1) > div > input[type=checkbox]"));
                    if (!checkbox.Selected)
                    {
                        checkbox.Click(); // Đánh dấu checkbox nếu chưa được chọn
                    }
                    var checkDelete = this.handleDelete(typeINV);
                    if (checkDelete)
                    {
                        this.addDataGridView(inv, dateNo, "DELETED");
                    }
                    else
                    {
                        OLD_INV.Add(inv);
                        this.addDataGridView(inv, dateNo, "DELETE FAIL!");
                    }
                }
                else
                {
                    OLD_INV.Add(inv);
                    this.addDataGridView(inv, dateNo, "NOT FOUND DATE_NO!");
                }
            }
            else
            {
                OLD_INV.Add(inv);
                this.addDataGridView(inv, "", "NOT FOUND");
            }
        }

        private void handleWithMoreSearch(string typeINV, string[] arrInv)
        {
            IWebElement buttonSearch = this.driver.FindElement(By.CssSelector(this.getIDButtonSearch(typeINV)));
            IWebElement inputFieldSearch = this.driver.FindElement(By.XPath(this.cssSelectorInputSearch(typeINV)));
            foreach (var inv in arrInv)
            {
                // Check if "wp" is not present in the string "inv"
                if (!inv.Contains(typeINV))
                {
                    this.addDataGridView(inv, "", "INVALID INV!");
                    continue; // Skip to the next iteration
                }

                string newInv = inv.Trim();
                var checkRemoveNo = this.checkNoDelete(newInv);
                if (checkRemoveNo.Length > 0)
                {
                    newInv = checkRemoveNo[0];
                }

                this.setStatusProcessing(newInv);
                System.Threading.Thread.Sleep(1000);
                // Click vào button search sau khi nó xuất hiện
                buttonSearch.Click();
                // Tìm input field theo ID (hoặc các phương pháp tìm khác như Xpath, CSS Selector)

                // Khởi tạo WebDriverWait

                // Nếu overlay đã biến mất, focus vào input

                inputFieldSearch.Click();
                inputFieldSearch.Clear();
                inputFieldSearch.SendKeys(newInv);


                // Press F8 after sending the keys
                System.Threading.Thread.Sleep(500);
                inputFieldSearch.SendKeys(OpenQA.Selenium.Keys.F8);
                System.Threading.Thread.Sleep(1500);
                if (checkRemoveNo.Length > 0)
                {

                    var noDel = int.Parse(checkRemoveNo[1]);
                    Console.WriteLine("noDel" + noDel);
                    this.deleteNoInINV(newInv, noDel, typeINV);
                }
                else
                {
                    this.handleClickCheckBox(newInv, typeINV);
                }

            }
        }
        private void login(string typeINV)
        {
            this.driver.SwitchTo().NewWindow(WindowType.Tab);
            // nếu không phải trang chủ thì login
            if (!this.driver.Url.Contains(this.URL_EACOUNT_MAIN) && String.IsNullOrEmpty(this.OLD_URL))
            {
                // Điều hướng tới trang web mong muốn
                this.driver.Navigate().GoToUrl(this.URL_EACOUNT_LOGIN);

                // Tìm input field theo ID (hoặc các phương pháp tìm khác như Xpath, CSS Selector)
                IWebElement inputField = this.driver.FindElement(By.Id("com_code"));

                // Điền giá trị vào input field
                inputField.SendKeys(this.tb_companyCode.Text.Trim());

                // Tìm input field theo ID (hoặc các phương pháp tìm khác như Xpath, CSS Selector)
                IWebElement inputFieldID = this.driver.FindElement(By.Id("id"));

                // Điền giá trị vào input field
                inputFieldID.SendKeys(this.tb_ID.Text.Trim());

                // Tìm input field theo ID (hoặc các phương pháp tìm khác như Xpath, CSS Selector)
                IWebElement inputFieldPW = this.driver.FindElement(By.Id("passwd"));

                // Điền giá trị vào input field
                inputFieldPW.SendKeys(this.tb_pw.Text.Trim());

                // Tìm button theo ID (hoặc các phương pháp tìm khác như Xpath, CSS Selector)
                IWebElement button = this.driver.FindElement(By.Id("save"));
                button.Click();


                // Đợi URL thay đổi sau khi đăng nhập thành công
                WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
                wait.Until(drv => drv.Url.Contains(this.URL_EACOUNT_MAIN));
            }



            // Khi URL thay đổi, chuyển hướng tới tab mong muốn
            string currentUrl = !String.IsNullOrEmpty(this.OLD_URL) ? this.OLD_URL : this.driver.Url;
            this.driver.Navigate().GoToUrl(currentUrl + this.getUrlTabs(typeINV));
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //lấy thông tin từng inv ra để xóa
            var arrInv = this.tb_inv.Text.Split('\n');

            if (typeINV == "INV")
            {
                this.handleWithMoreSearch(typeINV, arrInv);
            }
            else
            {
                this.handleWithWQickSearch(typeINV, arrInv);
            }


        }
        private void buttonOpenWeb_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                    $"Bắt đầu chạy trong chế độ:{this.checkMode()}?", // The message to display
                    "Thông báo",                      // The title of the message box
                    MessageBoxButtons.YesNo,             // Buttons to display (Yes and No)
                    MessageBoxIcon.Question              // Icon to display (Question mark)
                );

            // Check the result of the user's choice
            if (result == DialogResult.Yes)
            {
                this.OLD_INV.Clear();
                this.tb_inv.Text = this.tb_inv.Text.Trim();
                this.ValidateBeforeWork();
            }
        }

        private void setStatusReady()
        {
            this.lb_processing.Visible = false;
            this.lb_ready.Visible = true;
            this.lb_ready.Show();
        }

        private void setStatusProcessing(string text)
        {
            this.lb_ready.Visible = false;
            if (String.IsNullOrEmpty(text))
            {
                this.lb_processing.Text = $"Đang xử lý";

            }
            else
            {

                this.lb_processing.Text = $"Đang xử lý:{text}";
            }
            this.lb_processing.Visible = true;
            this.lb_processing.Show();
        }

        private string checkType()
        {
            string checkFlag = "";
            foreach (Control control in grbox_typeINV.Controls)
            {
                if (control is System.Windows.Forms.RadioButton radioButton && radioButton.Checked)
                {
                    // Xử lý khi radioButton được chọn
                    checkFlag = radioButton.Text;
                    break; // Thoát khỏi vòng lặp sau khi tìm thấy RadioButton được chọn
                }
            }
            return checkFlag;
        }

        private void ValidateBeforeWork()
        {
            if (String.IsNullOrEmpty(this.tb_companyCode.Text.Trim()) || String.IsNullOrEmpty(this.tb_ID.Text.Trim()) || String.IsNullOrEmpty(this.tb_pw.Text.Trim()))
            {
                MessageBox.Show("Điền đầy đủ thông tin tài khoản!", "Thông báo");
                return;
            }
            if (String.IsNullOrEmpty(this.tb_inv.Text))
            {
                MessageBox.Show("Chưa Nhập Số Invoice!", "Thông báo");
                return;
            }

            string checkFlag = this.checkType();
            if (checkFlag != "")
            {

                this.setStatusProcessing("");
                if (this.driver == null)
                {
                    // Thiết lập Service để ẩn cửa sổ Terminal
                    var chromeService = ChromeDriverService.CreateDefaultService();
                    chromeService.HideCommandPromptWindow = true;

                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("headless");
                    chromeOptions.AddArgument("--disable-gpu"); // Bắt buộc trên Windows
                    //chromeOptions.AddArgument("--window-size=1920,1080"); // Thiết lập kích thước cửa sổ ảo
                    this.driver = new ChromeDriver(chromeService, chromeOptions);
                }
                this.login(checkFlag);
                this.OLD_URL = this.getOldUrl(this.driver.Url);
                this.driver.Close();
                // Chuyển sang một tab khác nếu còn tab khác đang mở
                if (this.driver.WindowHandles.Count > 0)
                {
                    this.driver.SwitchTo().Window(driver.WindowHandles[0]);
                }
                this.showNotifiIcon();
                this.setStatusReady();
                this.tb_inv.Text = "";

            }
            else
            {
                MessageBox.Show("Chưa Chọn Loại Invoice!", "Thông báo");
            }

        }

        private void closeDriver()
        {
            try
            {
                if (this.driver != null)
                {
                    this.driver.Quit();
                }
            }
            catch (Exception)
            {


            }

        }

        private string checkMode()
        {
            string checkFlag = "";
            foreach (Control control in grb_mode.Controls)
            {
                if (control is System.Windows.Forms.RadioButton radioButton && radioButton.Checked)
                {
                    // Xử lý khi radioButton được chọn
                    checkFlag = radioButton.Text;
                    break; // Thoát khỏi vòng lặp sau khi tìm thấy RadioButton được chọn
                }
            }
            return checkFlag;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                    "Chạy lại các phiếu bị lỗi?", // The message to display
                    "Thông báo",                      // The title of the message box
                    MessageBoxButtons.YesNo,             // Buttons to display (Yes and No)
                    MessageBoxIcon.Question              // Icon to display (Question mark)
                );

            // Check the result of the user's choice
            if (result == DialogResult.Yes)
            {
                int countOLD = OLD_INV.Count;
                if (countOLD > 0)
                {

                    string text = string.Join(Environment.NewLine, this.OLD_INV);
                    this.tb_inv.Text = text;
                    DialogResult resultErr = MessageBox.Show(
                    $"Chạy lại {countOLD} phiếu bị lỗi?", // The message to display
                    "Thông báo",                      // The title of the message box
                    MessageBoxButtons.YesNo,             // Buttons to display (Yes and No)
                    MessageBoxIcon.Question              // Icon to display (Question mark)
                );
                    if (resultErr == DialogResult.Yes)
                    {
                        ValidateBeforeWork();

                    }
                }
                else
                {
                    MessageBox.Show(
                    "Không tìm thấy phiếu lỗi!", // The message to display
                    "Thông báo");            // Icon to display (Question mark)
                }
            }
        }

        private void radioBDHH_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void showNotifiIcon()
        {
            this.notifyIcon1.Icon = new System.Drawing.Icon("meme-loopy-14.ico");
            this.notifyIcon1.Text = "Text";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipTitle = "Thông báo";
            this.notifyIcon1.BalloonTipText = "Hoàn thành xử lý!";
            this.notifyIcon1.ShowBalloonTip(50);
        }

        private void initDataGridView()
        {
            this.dataGridView1.Columns.Add("stt", "#");
            this.dataGridView1.Columns.Add("inv", "Số INV");
            this.dataGridView1.Columns.Add("dateNo", "Date No");
            this.dataGridView1.Columns.Add("status", "Status");
            this.dataGridView1.Columns.Add("time", "Time");
            this.dataGridView1.Columns[0].Width = 25;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.initDataGridView();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.closeDriver();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tb_inv_TextChanged(object sender, EventArgs e)
        {
            var arrInv = this.tb_inv.Text.Split('\n');
            int count = 0;
            foreach (var arrInvItem in arrInv)
            {
                if (!String.IsNullOrEmpty(arrInvItem))
                {
                    count++;
                }
            }
            this.lb_total_inv.Text = count.ToString();
        }
    }
}
