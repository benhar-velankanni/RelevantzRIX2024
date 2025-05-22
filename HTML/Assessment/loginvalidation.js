function validation() {
    var username = document.getElementById("username").value;
    if (username == "") {
        alert("Please enter your username");
        return false;
    }
    var password = document.getElementById("password").value;
    if (password == "") {
        alert("Please enter your password");
        return false;
    }
    return true; 
}