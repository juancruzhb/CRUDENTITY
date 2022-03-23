using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDEntity.Models;

namespace CRUDEntity
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            PopulateContacts();
        }

        public void PopulateContacts()
        {
            using (WinFormsContactsEntities db = new WinFormsContactsEntities())
            {
                var list = from d in db.Contacts
                           select d;
                gridContacts.DataSource = list.ToList();
            }
        }
        private int? GetId()
        {
            try
            {
                return int.Parse(gridContacts.Rows[gridContacts.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch (Exception)
            {

                return null;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ContactDetails contactDetails = new ContactDetails();
            contactDetails.ShowDialog(this);
            PopulateContacts();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                ContactDetails contactDetails = new ContactDetails(id);
                contactDetails.ShowDialog();

                PopulateContacts();
            }


        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                using(WinFormsContactsEntities db = new WinFormsContactsEntities())
                {
                    Contacts contact = db.Contacts.Find(id);
                    db.Contacts.Remove(contact);
                    db.SaveChanges();
                }

                PopulateContacts();
            }
        }
    }
}
