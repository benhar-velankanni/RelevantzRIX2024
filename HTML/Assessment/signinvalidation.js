function validation() {
    var username = document.getElementById("username").value;
    if (username == "") {
        alert("Please enter your username");
        return false;
    }

    var age = document.getElementById("age").value;
    if (age < 0 || age > 120 || age == "") {
        alert("Please enter a valid age");
        return false;
    }

    var email = document.getElementById("email").value;
    var mail = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (!email.match(mail)) {
        alert("Invalid email address");
        return false;
    }

    var address = document.getElementById("address").value;
    if (address == "") {
        alert("Please enter your address");
        return false;
    }

    var date = document.getElementById("dob").value;
    if (date == "") {
        alert("Please enter your date of birth");
        return false;
    }

    var password = document.getElementById("password").value;
    var passw = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20}$/;
    if (!password.match(passw)) {
        alert("Invalid password. Password must be 6-20 characters long, contain at least one numeric digit, one uppercase, and one lowercase letter.");
        return false;
    }

    var cpassword = document.getElementById("cpassword").value;
    if (cpassword != password) {
        alert("Passwords do not match");
        return false;
    }

    var phone = document.getElementById("phone").value;
    var phoneno = /^[0-9]{10}$/;
    if (!phone.match(phoneno)) {
        alert("Invalid phone number. It must be 10 digits.");
        return false;
    }

    var gender = document.querySelector('input[name="gender"]:checked');
    if (!gender) {
        alert("Please select your gender");
        return false;
    }

    var occupation = document.getElementById("occupation").value;
    if (occupation == "") {
        alert("Please select your occupation");
        return false;
    }

    // If all validations pass
    window.location.href = "login.html";
    return true;
}