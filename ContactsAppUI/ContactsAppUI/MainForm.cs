using System;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class Form1 : Form
    {
        private Project _project = new Project();
        /// <summary>
        /// Поле для хранения пути файла.
        /// </summary>
        private readonly string _address = 
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\ContactApp.txt";

        public Form1()
        {
            InitializeComponent();
            BirthdateTimePicker.MaxDate = DateTime.Now;

            if (ProjectManager.LoadFromFile(_address) != null)
            {
                _project = ProjectManager.LoadFromFile(_address);
            }

            ShowListBox();
          
            ContactsListBox.Sorted = true;

            Birthday();
            _project._contactslistone.Sort(delegate (Contact _contactOne, Contact _contactTwo)
            { return _contactOne.SecondName.CompareTo(_contactTwo.SecondName); });

        }
        private void Birthday()
        {
            Project birth = Project.Birthday(_project, DateTime.Today);
            for (int i = 0; i != birth._contactslistone.Count; i++)
            {
                Birthdaylabel10.Text = 
                Birthdaylabel10.Text + birth._contactslistone[i].SecondName + ".  ";
            }
        }
        
        public void ShowListBox()
        {
            foreach(Contact t in _project._contactslistone)
            {
                ContactsListBox.Items.Add(t.Name);
            }
        }

        private void addContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
          var form2 = new ContactForm();
          form2.Owner = this;
          form2.ShowDialog();
          var UpdatedDate = form2.Data;
          if (UpdatedDate != null)
          {
            _project._contactslistone.Add(UpdatedDate._contactsplus);
            ContactsListBox.Items.Add(UpdatedDate.TxtBox);
          }      
        }

        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
          ContactForm Contactform = new ContactForm();
           if (ContactsListBox.SelectedIndex >= 0)
            {
               Contactform.Data._contactsplus = _project._contactslistone[ContactsListBox.SelectedIndex];
               Contactform.Data.TxtBox = _project._contactslistone[ContactsListBox.SelectedIndex].SecondName;
               Contactform.ShowDialog();
               var UpdatedDate = Contactform.Data;
               _project._contactslistone.RemoveAt(ContactsListBox.SelectedIndex);
               ContactsListBox.Items.RemoveAt(ContactsListBox.SelectedIndex);
               _project._contactslistone.Add(UpdatedDate._contactsplus);
               ContactsListBox.Items.Add(UpdatedDate.TxtBox);
               NameTextBox.Text = UpdatedDate._contactsplus.Name;
               SecondTextBox.Text = UpdatedDate._contactsplus.SecondName;
               EmailTextBox.Text = UpdatedDate._contactsplus.Email;
               VKTextBox.Text = UpdatedDate._contactsplus.IDVk;
               BirthdateTimePicker.Value = UpdatedDate._contactsplus.Birth;
               PhoneTextBox.Text = Convert.ToString(UpdatedDate._contactsplus.Phone.Number);
            }
        }

        private void removeContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
          DialogResult result = 
          MessageBox.Show("Do you really want to delete the contact?\n" 
          + _project._contactslistone[ContactsListBox.SelectedIndex].SecondName 
          + " " + _project._contactslistone[ContactsListBox.SelectedIndex].Name, "Warning", 
          MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
          if (result == DialogResult.OK)

            {
                _project._contactslistone.RemoveAt(ContactsListBox.SelectedIndex);
                ContactsListBox.Items.RemoveAt(ContactsListBox.SelectedIndex);
                NameTextBox.Clear();
                SecondTextBox.Clear();
                EmailTextBox.Clear();
                PhoneTextBox.Clear();
                VKTextBox.Clear();
                BirthdateTimePicker.Value = BirthdateTimePicker.MaxDate;
            }
        }

        private void About(object sender, EventArgs e)
        {
            var form3 = new About();
            form3.Owner = this;
            form3.ShowDialog();
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var form2 = new ContactForm();
            form2.Owner = this;
            form2.ShowDialog();
            var UpdatedDate = form2.Data;
            if (UpdatedDate != null)
            {
                _project._contactslistone.Add(UpdatedDate._contactsplus);
                ContactsListBox.Items.Add(UpdatedDate.TxtBox);
            }
            ProjectManager.SaveToFile(_project, _address);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            ContactForm contactForm = new ContactForm();
            if (ContactsListBox.SelectedIndex >= 0)
            {
                contactForm.Data._contactsplus = _project._contactslistone[ContactsListBox.SelectedIndex];
                contactForm.Data.TxtBox = _project._contactslistone[ContactsListBox.SelectedIndex].SecondName;
                contactForm.ShowDialog();
                var UpdatedDate = contactForm.Data;
                _project._contactslistone.RemoveAt(ContactsListBox.SelectedIndex);
                ContactsListBox.Items.RemoveAt(ContactsListBox.SelectedIndex);
                _project._contactslistone.Add(UpdatedDate._contactsplus);
                ContactsListBox.Items.Add(UpdatedDate.TxtBox);
                NameTextBox.Text = UpdatedDate._contactsplus.Name;
                SecondTextBox.Text = UpdatedDate._contactsplus.SecondName;
                EmailTextBox.Text = UpdatedDate._contactsplus.Email;
                VKTextBox.Text = UpdatedDate._contactsplus.IDVk;
                BirthdateTimePicker.Value = UpdatedDate._contactsplus.Birth;
                PhoneTextBox.Text = Convert.ToString(UpdatedDate._contactsplus.Phone.Number);
            }
            ProjectManager.SaveToFile(_project, _address);
        }
        
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete the contact?\n"
         + _project._contactslistone[ContactsListBox.SelectedIndex].SecondName + " "
         + _project._contactslistone[ContactsListBox.SelectedIndex].Name, "Warning",
         MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                _project._contactslistone.RemoveAt(ContactsListBox.SelectedIndex);
                ContactsListBox.Items.RemoveAt(ContactsListBox.SelectedIndex);
                NameTextBox.Clear();
                SecondTextBox.Clear();
                EmailTextBox.Clear();
                PhoneTextBox.Clear();
                VKTextBox.Clear();
                BirthdateTimePicker.Value = BirthdateTimePicker.MaxDate;
            }
            ProjectManager.SaveToFile(_project, _address);
        }

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactsListBox.SelectedIndex >= 0)
            {
                Contact _contactsplus;
                _contactsplus = _project._contactslistone[ContactsListBox.SelectedIndex];
                SecondTextBox.Text = _contactsplus.Name;
                NameTextBox.Text = _contactsplus.SecondName;
                EmailTextBox.Text = _contactsplus.Email;
                VKTextBox.Text = _contactsplus.IDVk;
                BirthdateTimePicker.Value = _contactsplus.Birth;
                PhoneTextBox.Text = Convert.ToString(_contactsplus.Phone.Number);
            }
        }
    }
}

