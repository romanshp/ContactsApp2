using System;
using System.Drawing;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class ContactForm : Form
    {
        private Contact _contactsplus = new Contact();
        
        private PhoneNumber _phone = new PhoneNumber();

        public ContactForm()
        {
            InitializeComponent();
            BirthdateTimePicker.MaxDate = DateTime.Now;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (Data._contactsplus != null)
            {
                SecondTextBox.Text = Data._contactsplus.SecondName;
                NameTextBox.Text = Data._contactsplus.Name;
                EmailTextBox.Text = Data._contactsplus.Email;
                IDTextBox.Text = Data._contactsplus.IDVk;
                BirthdateTimePicker.Value = Data._contactsplus.Birth;
                PhoneTextBox.Text = Convert.ToString(Data._contactsplus.Phone.Number);
            }

        }
        public class DataInMainForm
        {
            public string TxtBox;
            public Contact _contactsplus;
        }
        private DataInMainForm _data = new DataInMainForm();
        public DataInMainForm Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        private void Okbutton_Click(object sender, EventArgs e)
        {
            bool flag;
            try
            {

                flag = true;
                _phone.Number = System.Int64.Parse(PhoneTextBox.Text);
                _contactsplus.SecondName = SecondTextBox.Text;
                _contactsplus.Name = NameTextBox.Text;
                _contactsplus.Birth = BirthdateTimePicker.Value;
                _contactsplus.Phone = _phone;
                _contactsplus.Email = EmailTextBox.Text;
                _contactsplus.IDVk = IDTextBox.Text;
                _data.TxtBox = _contactsplus.SecondName;
                _data._contactsplus = _contactsplus;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неверный ввод данных");
                flag = false;
            }

            if (flag == true)
            {
                this.Close();
                DialogResult = DialogResult.OK;

            }
        }
    
        private void CancelButton_Click(object sender, EventArgs e)
        {
                Form1 main = this.Owner as Form1;
                var form1 = new Form1();
                if (main != null)
                {
                    Data = null;
                }
                this.Close();
            }

        private void SecondtextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactsplus.SecondName = SecondTextBox.Text;
                SecondTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                SecondTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactsplus.Name = NameTextBox.Text;
                NameTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                NameTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void BirthdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _contactsplus.Birth = BirthdateTimePicker.Value;
                BirthdateTimePicker.BackColor = Color.White;

            }
            catch (Exception)
            {
                BirthdateTimePicker.BackColor = Color.LightSalmon;

            }
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            long number;
            try
            {
                long.TryParse(PhoneTextBox.Text, out number);
                _contactsplus.Phone.Number = number;
                PhoneTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                PhoneTextBox.BackColor = Color.Red;
            }
        }

        private void IDTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {

                _contactsplus.IDVk = IDTextBox.Text;
                IDTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                IDTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactsplus.Email = EmailTextBox.Text;
                EmailTextBox.BackColor = Color.White;

            }
            catch (Exception)
            {
                EmailTextBox.BackColor = Color.LightSalmon;
            }
        }
    }
}
