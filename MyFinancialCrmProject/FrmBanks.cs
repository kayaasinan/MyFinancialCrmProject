using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFinancialCrmProject.Models;

namespace MyFinancialCrmProject
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmBanks_Load(object sender, EventArgs e)
        {
            #region Banka Bakiyeleri

            var ziraatBankBalance = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y => y.BankBalance).FirstOrDefault();
            var vakifBankBalance = db.Banks.Where(x => x.BankTitle == "Vakıf Bankası").Select(y => y.BankBalance).FirstOrDefault();
            var garantiBankBalance = db.Banks.Where(x => x.BankTitle == "Garanti Bankası").Select(y => y.BankBalance).FirstOrDefault();

            lblZiraatBankBalance.Text = ziraatBankBalance.ToString()+ " ₺";
            lblVakifBankBalance.Text = vakifBankBalance.ToString() + " ₺";
            lblGarantiBankBalance.Text = garantiBankBalance.ToString() + " ₺";

            #endregion

            #region Banka Hareketleri

            var bankProcess1=db.BankProcesses.OrderByDescending(x=>x.BankProcess).Take(1).FirstOrDefault();
            lblBankProcess1.Text = bankProcess1.Description+" /"+bankProcess1.Amount+" /"+bankProcess1.ProcessDate;

            var bankProcess2 = db.BankProcesses.OrderByDescending(x => x.BankProcess).Take(2).Skip(1).FirstOrDefault();
            lblBankProcess2.Text = bankProcess2.Description + " /" + bankProcess2.Amount + " /" + bankProcess2.ProcessDate;

            var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.BankProcess).Take(3).Skip(2).FirstOrDefault();
            lblBankProcess3.Text = bankProcess3.Description + " /" + bankProcess3.Amount + " /" + bankProcess3.ProcessDate;

            var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.BankProcess).Take(4).Skip(3).FirstOrDefault();
            lblBankProcess4.Text = bankProcess4.Description + " /" + bankProcess4.Amount + " /" + bankProcess4.ProcessDate;

            var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.BankProcess).Take(5).Skip(4).FirstOrDefault();
            lblBankProcess5.Text = bankProcess5.Description + " /" + bankProcess5.Amount + " /" + bankProcess5.ProcessDate;

            var bankProcess6 = db.BankProcesses.OrderByDescending(x => x.BankProcess).Take(6).Skip(5).FirstOrDefault();
            lblBankProcess6.Text = bankProcess6.Description + " /" + bankProcess6.Amount + " /" + bankProcess6.ProcessDate;


            #endregion

        }

        private void btnDashboardForm_Click(object sender, EventArgs e)
        {
            FrmDashboard fr = new FrmDashboard();
            fr.Show();
            this.Hide();
        }

        private void btnCategoriesForm_Click(object sender, EventArgs e)
        {
            FrmCategories fr = new FrmCategories();
            fr.Show();
            this.Hide();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks fr = new FrmBanks();
            fr.Show();
            this.Hide();
        }

        private void btnBankProcessFrom_Click(object sender, EventArgs e)
        {
            FrmBankProcess fr = new FrmBankProcess();
            fr.Show();
            this.Hide();
        }

        private void btnSpendingForm_Click(object sender, EventArgs e)
        {
            FrmSpendings fr = new FrmSpendings();
            fr.Show();
            this.Hide();
        }

        private void btnBillsForm_Click(object sender, EventArgs e)
        {
            FrmBilling fr = new FrmBilling();
            fr.Show();
            this.Hide();
        }
    }
}
