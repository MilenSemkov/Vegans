using ShopVegieAndFruitMS.Controllers;
using ShopVegieAndFruitMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopVegieAndFruitMS
{
    public partial class Form1 : Form
    {
        VeganLogic vegansController = new VeganLogic();
        VeganTypeLogic veganTypeController = new VeganTypeLogic();
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadRecord(Vegan vegan)
        {
            txtID.BackColor = Color.White;
            txtID.Text = vegan.Id.ToString();
            txtName.Text = vegan.Name;
            txtInfo.Text = vegan.Discription;
            txtPrice.Text = vegan.Price.ToString();
            cmbType.Text = vegan.TypeId.ToString();
        }
        private void ClearScreen()
        {
            txtID.BackColor = Color.White;
            txtID.Clear();
            txtInfo.Clear();
            txtName.Clear();
            txtPrice.Clear();
            cmbType.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<VeganType> allVeganTypes = veganTypeController.GetAllTypes();
            cmbType.DataSource = allVeganTypes;
            cmbType.ValueMember = "Id";
            cmbType.DisplayMember = "NameType";
            

            btnSAll_Click(sender, e);

        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text)||txtName.Text=="")
            {
                MessageBox.Show("Въведете данни!");
                txtName.Focus();
                return;
            }
            Vegan newVegan = new Vegan();
            newVegan.Discription = txtInfo.Text;
            newVegan.Name = txtName.Text;
            newVegan.Price =  decimal.Parse(txtPrice.Text);

            //newVegan.TypeId = (int)cmbType.SelectedValue;

            vegansController.Create(newVegan);
            MessageBox.Show("Записът е успешно добавен!");
            ClearScreen();
            btnSAll_Click(sender, e);
        }

        private void btnSAll_Click(object sender, EventArgs e)
        {
            List<Vegan> allVegans = vegansController.GetAll();
            lxbAll.Items.Clear();
            foreach (var item in allVegans)
            {
                lxbAll.Items.Add($"{item.Id}. {item.Name} Описание: {item.Discription} {item.Price}лв. Тип: {item.TypeId}");
            }
        }

        private void btnFIND_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtID.Text)||!txtID.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете ID!");
                txtID.BackColor = Color.Red;
                txtID.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtID.Text);
            }
            Vegan findedVegan = vegansController.Get(findId);
            if (findedVegan==null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС В БД!\nВъведете ID!");
                txtID.BackColor = Color.Red;
                txtID.Focus();
                return;
            }
            LoadRecord(findedVegan);
        }

        private void btnUPDATE_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtID.Text) || !txtID.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете ID!");
                txtID.BackColor = Color.Red;
                txtID.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtID.Text);
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                Vegan findedVegan = vegansController.Get(findId);
                if (findedVegan == null)
                {
                    MessageBox.Show("НЯМА ТАКЪВ ЗАПИС В БД!\nВъведете ID!");
                    txtID.BackColor = Color.Red;
                    txtID.Focus();
                    return;
                }
                LoadRecord(findedVegan);
            }
            else
            {
                Vegan uddatedVegan = new Vegan();
                uddatedVegan.Name = txtName.Text;
                uddatedVegan.Price = decimal.Parse(txtPrice.Text);
                uddatedVegan.Discription = txtInfo.Text;
                uddatedVegan.TypeId = (int)cmbType.SelectedIndex;
                vegansController.Update(findId, uddatedVegan);
            }
            btnSAll_Click(sender, e);
        }

        private void btnDELETE_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtID.Text) || !txtID.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете ID!");
                txtID.BackColor = Color.Red;
                txtID.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtID.Text);
            }
            Vegan findedVegan = vegansController.Get(findId);
            if (findedVegan == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС В БД!\nВъведете ID!");
                txtID.BackColor = Color.Red;
                txtID.Focus();
                return;
            }
            LoadRecord(findedVegan);

            DialogResult answear = MessageBox.Show("Наистина ли искате да изтриете запис № " + findId + " ?", "PROMPT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answear==DialogResult.Yes)
            {
                vegansController.Delete(findId);
            }
            btnSAll_Click(sender, e);
           
        }
    }
}
