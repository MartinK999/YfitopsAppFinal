using Microsoft.Extensions.DependencyInjection;
using Yfitops.Forms;
using Yfitops.Models.Entities;
using Yfitops.Repositories;

namespace Yfitops
{
    public partial class LoginForm : Form
    {
        private readonly IUserRepository _userRepository;
        public LoginForm(IUserRepository userRepository)
        {
            InitializeComponent();
            _userRepository = userRepository;
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registrationForm = new RegistrationForm(_userRepository);
            registrationForm.ShowDialog();
        }

        private void login_Click(object sender, EventArgs e)
        {
            var user = _userRepository.GetByUsername(textBox1.Text);

            if (user != null && BCrypt.Net.BCrypt.Verify(textBox2.Text, user.Password))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var mainForm = Program.ServiceProvider.GetRequiredService<MainForm>();
                mainForm.SetCurrentUser(user);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGuest_Click(object sender, EventArgs e)
        {
            var guest = new User
            {
                Id = 0,
                Username = "Guest",
                Role = "Guest"
            };

            Hide();
            var mainForm = Program.ServiceProvider.GetRequiredService<MainForm>();
            mainForm.SetCurrentUser(guest);
            mainForm.Show();
        }

        public void ResetForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
