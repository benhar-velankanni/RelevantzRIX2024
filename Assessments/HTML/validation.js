function validateForm() {
    var name = document.getElementById("name").value;
    var email = document.getElementById("email").value;
    var phone = document.getElementById("phone").value;
    var password = document.getElementById("password").value;
    var confirmPassword = document.getElementById("confirmPassword").value;
    var address = document.getElementById("address").value;
    var dateOfBirth = document.getElementById("dateOfBirth").value;
    var income = document.getElementById("income").value;
    if(name==" "){
        alert("Please enter your name");
        return false;
    }
    if(email==" "){
        alert("Please enter your email");
        return false;
    }
    if(phone==" "){
        alert("Please enter your phone number");
        return false;
    }
    if(password==" "){
        alert("Please enter your password");
        return false;
    }
    if(confirmPassword==" "){
        alert("Please enter your confirm password");
        return false;
    }
    if(address==" "){
        alert("Please enter your address");
        return false;
    }
    if(dateOfBirth==" "){
        alert("Please enter your date of birth");
        return false;
    }
    if(income==" "){
        alert("Please enter your income");
        return false;
    }
    if(password!=confirmPassword){
        alert("Password and confirm password do not match");
        return false;
    }
    alert("Registration successful");
}