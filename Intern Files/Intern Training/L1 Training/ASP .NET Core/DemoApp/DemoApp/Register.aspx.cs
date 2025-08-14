using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoApp
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            // Reset all error labels
            errUsername.Visible = errEmail.Visible = errAge.Visible = errMobile.Visible =
            errPassword.Visible = errConfirmPassword.Visible = false;

            // Username validation
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errUsername.Text = "Username is required.";
                errUsername.Visible = true;
                isValid = false;
            }

            // Email validation
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errEmail.Text = "Enter a valid email address.";
                errEmail.Visible = true;
                isValid = false;
            }

            // Age validation
            if (!int.TryParse(txtAge.Text, out int age) || age < 1 || age > 120)
            {
                errAge.Text = "Enter a valid age between 1 and 120.";
                errAge.Visible = true;
                isValid = false;
            }

            // Mobile number validation
            if (!Regex.IsMatch(txtMobile.Text, @"^\d{10}$"))
            {
                errMobile.Text = "Enter a valid 10-digit mobile number.";
                errMobile.Visible = true;
                isValid = false;
            }

            // Password validation
            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 6)
            {
                errPassword.Text = "Password must be at least 6 characters.";
                errPassword.Visible = true;
                isValid = false;
            }

            // Confirm Password validation
            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                errConfirmPassword.Text = "Passwords do not match.";
                errConfirmPassword.Visible = true;
                isValid = false;
            }

            // Final step — redirect if valid
            if (isValid)
            {
                lblStatus.Text = "Registration successful!";
                lblStatus.Visible = true;

                // Simulate save and redirect
                Response.Redirect("Login.aspx");
            }
        }
    }
}