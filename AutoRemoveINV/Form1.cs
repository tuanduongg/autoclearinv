using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Keys = OpenQA.Selenium.Keys;

namespace AutoRemoveINV
{

    public partial class Form1 : Form
    {
        private string URL_EACOUNT_LOGIN = "https://loginbc.ecount.com/";
        private string URL_EACOUNT_MAIN = "/ECERP/ECP";
        private IWebDriver driver;
        private string[] OLD_INT;
        private string OLD_URL;
        // Tạo mới một instance của ChromeDriver (hoặc trình duyệt bạn muốn sử dụng)

        public Form1()
        {
            InitializeComponent();
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

        private string cssSelectorDateNo(string type)
        {
            switch (type)
            {
                case "SO":
                    return "td:nth-child(3) a span";
                case "PI":
                    return "td:nth-child(3) a span";
                case "WP":
                    return "td:nth-child(3) a";
                case "INV":
                    return "td:nth-child(3) a";
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
            string currentDate = DateTime.Now.ToString("hh:mm:ss dd-MM-yyyy");
            int rowIndex = this.dataGridView1.Rows.Add(newIndex, inv, dateNo, status, currentDate);
            DataGridViewCell cell = this.dataGridView1.Rows[rowIndex].Cells[3]; // Assuming you want to style the first cell in the new row
            if (status == "DELETED")
            {
                cell.Style.ForeColor = Color.Green; // Change to any color you want
            }
            else
            {
                cell.Style.ForeColor = Color.Red; // Change to any color you want
            }
            // Set the text color for the cell
        }
        private void handleWithWQickSearch(string typeINV, string[] arrInv)
        {
            foreach (var inv in arrInv)
            {
                this.setStatusProcessing(inv);
                IWebElement inputFieldSearch = this.driver.FindElement(By.XPath(this.cssSelectorInputSearch(typeINV)));
                inputFieldSearch.Clear();
                System.Threading.Thread.Sleep(1500); // 2000 milliseconds = 2 seconds
                inputFieldSearch.SendKeys(inv);
                inputFieldSearch.SendKeys(OpenQA.Selenium.Keys.Enter);

                string userInput = inv.Trim(); // Giá trị cần so sánh trong thẻ <span> của cột thứ 2
                System.Threading.Thread.Sleep(2000); // 2000 milliseconds = 2 seconds
                // Tìm tất cả các hàng trong tbody
                IList<IWebElement> rows = driver.FindElements(By.CssSelector("tbody tr"));
                string dateNo = "";
                // Duyệt qua các hàng để tìm hàng phù hợp với điều kiện
                foreach (IWebElement row in rows)
                {
                    try
                    {
                        // Lấy giá trị text từ thẻ <span> trong cột thứ 2 của hàng
                        IWebElement spanEle = row.FindElement(By.CssSelector("td:nth-child(2) > span"));
                        string spanValue = spanEle.Text;
                        // So sánh giá trị này với giá trị người dùng nhập
                        if (spanValue.Trim() == userInput.Trim())
                        {
                            // Lấy text từ thẻ <a> trong cột thứ 3
                            string textInThirdColumn = row.FindElement(By.CssSelector(this.cssSelectorDateNo(typeINV))).Text;


                            // Đánh dấu checkbox trong cột đầu tiên
                            IWebElement checkbox = row.FindElement(By.CssSelector("td:first-child div input[type='checkbox']"));
                            if (!checkbox.Selected)
                            {
                                checkbox.Click(); // Đánh dấu checkbox nếu chưa được chọn
                            }
                            dateNo = textInThirdColumn;
                            // Thoát khỏi vòng lặp sau khi tìm thấy hàng phù hợp
                            break;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }

                if (dateNo != "")
                {
                    var checkDelete = this.handleDelete(typeINV);
                    if (checkDelete)
                    {

                        this.addDataGridView(inv, dateNo, "DELETED");
                    }
                    else
                    {
                        this.addDataGridView(inv, dateNo, "FAIL!");
                    }
                }
                else
                {
                    this.addDataGridView(inv, "", "NOT FOUND");
                }
            }


        }

        private void handleWithMoreSearch(string typeINV, string[] arrInv)
        {
            IWebElement buttonSearch = this.driver.FindElement(By.CssSelector(this.getIDButtonSearch(typeINV)));
            IWebElement inputFieldSearch = this.driver.FindElement(By.XPath(this.cssSelectorInputSearch(typeINV)));
            foreach (var inv in arrInv)
            {
                this.setStatusProcessing(inv);
                // Click vào button search sau khi nó xuất hiện
                buttonSearch.Click();
                // Tìm input field theo ID (hoặc các phương pháp tìm khác như Xpath, CSS Selector)

                // Khởi tạo WebDriverWait

                // Nếu overlay đã biến mất, focus vào input

                inputFieldSearch.Click();
                inputFieldSearch.Clear();
                inputFieldSearch.SendKeys(inv);


                // Press F8 after sending the keys
                inputFieldSearch.SendKeys(OpenQA.Selenium.Keys.F8);
                System.Threading.Thread.Sleep(1000); // 2000 milliseconds = 2 seconds

                string userInput = inv.Trim(); // Giá trị cần so sánh trong thẻ <span> của cột thứ 2

                // Tìm tất cả các hàng trong tbody
                IList<IWebElement> rows = driver.FindElements(By.CssSelector("tbody tr"));
                string dateNo = "";
                // Duyệt qua các hàng để tìm hàng phù hợp với điều kiện
                foreach (IWebElement row in rows)
                {
                    try
                    {
                        // Lấy giá trị text từ thẻ <span> trong cột thứ 2 của hàng
                        IWebElement spanEle = row.FindElement(By.CssSelector("td:nth-child(2) > span"));
                        string spanValue = spanEle.Text;
                        // So sánh giá trị này với giá trị người dùng nhập
                        if (spanValue.Trim() == userInput.Trim())
                        {
                            // Lấy text từ thẻ <a> trong cột thứ 3
                            string textInThirdColumn = row.FindElement(By.CssSelector(this.cssSelectorDateNo(typeINV))).Text;


                            // Đánh dấu checkbox trong cột đầu tiên
                            IWebElement checkbox = row.FindElement(By.CssSelector("td:first-child div input[type='checkbox']"));
                            if (!checkbox.Selected)
                            {
                                checkbox.Click(); // Đánh dấu checkbox nếu chưa được chọn
                            }
                            dateNo = textInThirdColumn;
                            // Thoát khỏi vòng lặp sau khi tìm thấy hàng phù hợp
                            break;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }

                if (dateNo != "")
                {
                    var checkDelete = this.handleDelete(typeINV);
                    if (checkDelete)
                    {

                        this.addDataGridView(inv, dateNo, "DELETED");
                    }
                    else
                    {
                        this.addDataGridView(inv, dateNo, "FAIL!");
                    }
                }
                else
                {
                    this.addDataGridView(inv, "", "NOT FOUND");

                }
                System.Threading.Thread.Sleep(1000);
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
                inputField.SendKeys("168426");

                // Tìm input field theo ID (hoặc các phương pháp tìm khác như Xpath, CSS Selector)
                IWebElement inputFieldID = this.driver.FindElement(By.Id("id"));

                // Điền giá trị vào input field
                inputFieldID.SendKeys("TUANIT");

                // Tìm input field theo ID (hoặc các phương pháp tìm khác như Xpath, CSS Selector)
                IWebElement inputFieldPW = this.driver.FindElement(By.Id("passwd"));

                // Điền giá trị vào input field
                inputFieldPW.SendKeys("Toilatuan201@");

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

            this.ValidateBeforeWork();
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


        private void ValidateBeforeWork()
        {
            if (String.IsNullOrEmpty(this.tb_inv.Text))
            {
                MessageBox.Show("Chưa Nhập Số Invoice!");
                return;
            }

            string checkFlag = "";
            foreach (Control control in grbox_typeINV.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    // Xử lý khi radioButton được chọn
                    checkFlag = radioButton.Text;
                    break; // Thoát khỏi vòng lặp sau khi tìm thấy RadioButton được chọn
                }
            }

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
                    chromeOptions.AddArgument("--window-size=1920,1080"); // Thiết lập kích thước cửa sổ ảo



                    this.driver = new ChromeDriver(chromeService, chromeOptions);
                }
                login(checkFlag);
                this.OLD_URL = this.getOldUrl(this.driver.Url);
                this.driver.Close();
                // Chuyển sang một tab khác nếu còn tab khác đang mở
                if (this.driver.WindowHandles.Count > 0)
                {
                    this.driver.SwitchTo().Window(driver.WindowHandles[0]);
                }
                this.setStatusReady();
                this.tb_inv.Text = "";
            }
            else
            {
                MessageBox.Show("Chưa Chọn Loại Invoice!");
            }

        }

        private void closeDriver()
        {
            try
            {
                this.driver.Close();
                this.driver.Quit();

            }
            catch (Exception)
            {


            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        private void radioBDHH_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void initDataGridView()
        {
            this.dataGridView1.Columns.Add("stt", "#");
            this.dataGridView1.Columns.Add("inv", "Số INV");
            this.dataGridView1.Columns.Add("dateNo", "Date No");
            this.dataGridView1.Columns.Add("status", "Status");
            this.dataGridView1.Columns.Add("time", "Time");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.initDataGridView();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.closeDriver();
        }
    }
}
