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

        private void PopulateContacts()
        {
            using (WinFormsContactsEntities db = new WinFormsContactsEntities())
            {
                var list = from d in db.Contacts
                           select d;
                gridContacts.DataSource = list.ToList();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ContactDetails contactDetails = new ContactDetails();
            contactDetails.ShowDialog(this);
        }
    }
}
