using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsApp.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void AddContactbutton_Click(object sender, EventArgs e)
        {
            var form = new ContactForm();
            form.ShowDialog();
        }

        private void AddContactbutton_MouseEnter(object sender, EventArgs e)
        {
            AddContactbutton.Image = Properties.Resources.add_contact_32x32;
            AddContactbutton.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5FF");
        }

        private void AddContactbutton_MouseLeave(object sender, EventArgs e)
        {
            AddContactbutton.Image = Properties.Resources.add_contact_32x32_gray;
            AddContactbutton.BackColor = Color.White;
        }

        private void EditContactbutton_MouseEnter(object sender, EventArgs e)
        {
            EditContactbutton.Image = Properties.Resources.edit_contact_32x32;
            EditContactbutton.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5FF");
        }

        private void EditContactbutton_MouseLeave(object sender, EventArgs e)
        {
            EditContactbutton.Image = Properties.Resources.edit_contact_32x32_gray;
            EditContactbutton.BackColor = Color.White;
        }

        private void RemoveContactbutton_MouseEnter(object sender, EventArgs e)
        {
            RemoveContactbutton.Image = Properties.Resources.remove_contact_32x32;
            RemoveContactbutton.BackColor = System.Drawing.ColorTranslator.FromHtml("#FAF5F5");
        }

        private void RemoveContactbutton_MouseLeave(object sender, EventArgs e)
        {
            RemoveContactbutton.Image = Properties.Resources.remove_contact_32x32_gray;
            RemoveContactbutton.BackColor = Color.White;
        }
    }
}
