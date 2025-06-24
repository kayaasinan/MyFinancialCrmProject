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
    public partial class FrmSpendings : Form
    {
        public FrmSpendings()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmSpendings_Load(object sender, EventArgs e)
        {
            var categories = db.Categories.Select(x => new
            {
                x.CategoryId,
                x.CategoryName
            }).ToList();

            cmbCategories.DisplayMember = "CategoryName";
            cmbCategories.ValueMember = "CategoryId";
            cmbCategories.DataSource = categories;

            GetAllSpendings();
        }
        void GetAllSpendings()
        {

            var values = db.Spendings.Select(x => new
            {
                x.SpendingId,
                x.SpendingTitle,
                x.SpendingAmount,
                x.SpendingDate,
                CategoryNames = x.Categories.CategoryName
            }).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnSpendingList_Click(object sender, EventArgs e)
        {
            GetAllSpendings();
        }

        private void btnCreateSpendig_Click(object sender, EventArgs e)
        {
            string spendingTitle = txtSpendingTitle.Text;
            decimal spendingAmount = decimal.Parse(txtSpendingAmount.Text);
            DateTime spendingDatetime = DateTime.Parse(mtbSpendigDate.Text);
            int categotyId = int.Parse(cmbCategories.SelectedValue.ToString());

            Spendings spendings = new Spendings();
            spendings.SpendingTitle = spendingTitle;
            spendings.SpendingAmount = spendingAmount;
            spendings.SpendingDate = spendingDatetime;
            spendings.CategoryId = categotyId;
            db.Spendings.Add(spendings);
            db.SaveChanges();
            MessageBox.Show("Harcama Başarılı Bir Şekilde Sisteme Eklendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllSpendings();
        }

        private void btnDeleteSpendig_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSpendingId.Text);
            var deletedValue = db.Spendings.Find(id);
            db.Spendings.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Harcama Başarılı Bir Şekilde Sistemden Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllSpendings();
        }

        private void btnUpdateSpending_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSpendingId.Text);
            int categoryId = int.Parse(cmbCategories.SelectedValue.ToString());
            string spendingTitle = txtSpendingTitle.Text;
            decimal spendingAmount = decimal.Parse(txtSpendingAmount.Text);
            DateTime spendingDatetime = DateTime.Parse(mtbSpendigDate.Text);
            var values = db.Spendings.Find(id);
            values.SpendingTitle = spendingTitle;
            values.SpendingAmount = spendingAmount;
            values.SpendingDate = spendingDatetime;
            values.CategoryId = categoryId;
            db.SaveChanges();
            MessageBox.Show("Harcama Başarılı Bir Şekilde Güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllSpendings();
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
            FrmBilling fr= new FrmBilling();
            fr.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
