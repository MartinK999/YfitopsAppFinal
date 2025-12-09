using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yfitops.Models.Entities;
using Yfitops.Repositories;
using BCrypt.Net;

namespace Yfitops.Forms
{
    public partial class RegistrationForm : Form
    {
        private readonly IUserRepository _userRepository;
        public RegistrationForm(IUserRepository userRepository)
        {
            InitializeComponent();
            _userRepository = userRepository;
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var existingUser = _userRepository.GetByUsername(textBoxUsername.Text);
            if (existingUser != null)
            {
                MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(textBoxPassword.Text);

            comboBoxRole.Items.Add("User");
            comboBoxRole.Items.Add("Musician");

            comboBoxRole.SelectedItem = "User";

            var newUser = new User
            {
                Username = textBoxUsername.Text,
                Password = hashedPassword,
                Role = comboBoxRole.SelectedItem.ToString()
            };

            _userRepository.Add(newUser);
            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
