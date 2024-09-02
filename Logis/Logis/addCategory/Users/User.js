//////////////////////// Login////////////////////////////////////
const url = "https://localhost:44389/api/User/Login";
const form = document.getElementById('LoginForm');
async function loginUser() {
    debugger
    event.preventDefault();
    let formData = new FormData(form);
    let response = await fetch(url, {
        method: "POST",
        body: formData

    });
    if (response.ok) {
        alert('login succssfuly')
    }
    else
        alert('UNUTHARIZED')
}

//////////////////////////// Register /////////////////////////////


const Url2 = "https://localhost:44389/api/User/Register";
const RegisterForm = document.getElementById('registerForm')
async function registerUser() {
    debugger
    event.preventDefault();
    let formData = new FormData(RegisterForm);
    let response = await fetch(Url2,{
        method :'POST',
        body : formData
    });
    if (response.ok) {
        alert('Register succssfuly')
    }
    else{
        alert('Failed to Register')
    }
}
//////////////////////////// user Info /////////////////////////////
async function getData() {
    
    var n =document.getElementById('ID').value;
    const url3 = `https://localhost:44389/api/User/Api/User/${n}`;
    var response = await fetch(url3);
    var data = await response.json();
    var Email = document.getElementById('email');
    Email.value = data.usEm;
    var USerName = document.getElementById('userName');
    USerName.value = data.usName;
}