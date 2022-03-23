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
    
    public partial class ContactDetails : Form
    {
        public int? id;
        Contacts contact = null;
        public ContactDetails(int? id = null)
        {
            InitializeComponent();
            this.id = id;
            if (id != null)
                LoadContact();
        }

        private void LoadContact()
        {
            using (WinFormsContactsEntities db = new WinFormsContactsEntities())
            {
                contact = db.Contacts.Find(id);
                txtFirstName.Text = contact.FirstName;
                txtLastName.Text = contact.LastName;
                txtPhone.Text = contact.Phone;
                txtAddress.Text = contact.Address;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
        private void Save_Click(object sender, EventArgs e)
        {
            using (WinFormsContactsEntities db = new WinFormsContactsEntities())
            {
                if(id == null)
                    contact = new Contacts();

                contact.FirstName = txtFirstName.Text;
                contact.LastName = txtLastName.Text;
                contact.Phone = txtPhone.Text;
                contact.Address = txtAddress.Text;

                if (id == null)
                    db.Contacts.Add(contact);
                else
                {
                    db.Entry(contact).State = System.Data.Entity.EntityState.Modified;
                }

                
                db.SaveChanges();


            }
        this.Close();

    
        }
    }
}
