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
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        FinancialCrmDbEntities db=new FinancialCrmDbEntities();
        private void FrmBilling_Load(object sender, EventArgs e)
        {
          GetAllBills();
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            GetAllBills();
        }
        void GetAllBills()
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }
        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            string title=txtBillTitle.Text;
            decimal amaount=decimal.Parse(txtBillAmount.Text);
            string period=txtBillPeriod.Text;

            Bills bills=new Bills();
            bills.BillTitle=title;
            bills.BillAmount=amaount;
            bills.BillPeriod=period;
            db.Bills.Add(bills);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bir Şekilde Sisteme Eklendi","Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllBills();
        }

        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtBillId.Text);
            var deletedValue=db.Bills.Find(id);
            db.Bills.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bir Şekilde Sistemden Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllBills();
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            string title = txtBillTitle.Text;
            decimal amaount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;
            int id = int.Parse(txtBillId.Text);
            var values = db.Bills.Find(id);

            values.BillTitle = title;
            values.BillAmount = amaount;
            values.BillPeriod = period;
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bir Şekilde Güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllBills();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks fr=new FrmBanks();
            fr.Show();
            this.Hide();
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

        private void btnBanksForm_Click_1(object sender, EventArgs e)
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

        private void brnBillsForm_Click(object sender, EventArgs e)
        {
            FrmBilling fr=new FrmBilling();
            fr.Show();
            this.Hide();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
