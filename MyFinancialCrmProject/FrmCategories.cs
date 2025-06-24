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
    public partial class FrmCategories : Form
    {
        public FrmCategories()
        {
            InitializeComponent();
        }
      FinancialCrmDbEntities db= new FinancialCrmDbEntities();
        private void FrmCategories_Load(object sender, EventArgs e)
        {
            GetAllCategories();
        }
        void GetAllCategories()
        {
            var values = db.Categories.Select(x => new
            {
                x.CategoryId,
                x.CategoryName
            }).ToList();
            dataGridView1.DataSource = values;
        }
        private void btnCategoryList_Click(object sender, EventArgs e)
        {
            GetAllCategories();
        }

        private void btnCreateCategory_Click(object sender, EventArgs e)
        {
            string name=txtCategoryName.Text;
            Categories categories = new Categories();
            categories.CategoryName = name;
            db.Categories.Add(categories);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı Bir Şekilde Sisteme Eklendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllCategories();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtCategoryId.Text);
            var deletedValues = db.Categories.Find(id);
            db.Categories.Remove(deletedValues);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı Bir Şekilde Sistemden Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllCategories();

        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            string name = txtCategoryName.Text;
            var updatedValues=db.Categories.Find(id);
            updatedValues.CategoryName = name;
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı Bir Şekilde Sistemde Güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllCategories();
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

        private void brnSpendingForm_Click(object sender, EventArgs e)
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
