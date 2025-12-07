using Microsoft.Extensions.DependencyInjection;
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

namespace Yfitops
{
    public partial class MainForm : Form
    {
        private User _currentUser;
        public MainForm()
        {
            InitializeComponent();
        }

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
            UpdateUIBasedOnRole();

        }

        private void UpdateUIBasedOnRole()
        {
            if (_currentUser == null)
                return;
            switch (_currentUser.Role)
            {
                case "Admin":
                    buttonLogout.Visible = true;
                    break;
                case "Musician":
                    buttonLogout.Visible = true;
                    break;
                case "User":
                    buttonLogout.Visible = true;
                    break;
                case "Guest":
                    buttonLogout.Visible = false;
                    break;
                default:
                    // Handle unknown roles
                    break;
            }

            labelUsername.Text = _currentUser.Username;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void Logout()
        {
            

            var loginForm = Program.ServiceProvider.GetRequiredService<LoginForm>();

            loginForm.ResetForm();
            loginForm.Show();

            _currentUser = null;
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (e.CloseReason == CloseReason.UserClosing)
            {               
                Application.Exit(); 
            }
        }

    }
}
