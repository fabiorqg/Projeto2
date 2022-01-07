

function ValidateNome()
{
    let nome = document.getElementById('inputNome');
    if (nome.value == '')
    {
        nome.focus();
        nome.style.color = 'red';
        return false;

    }
    else
    {
        nome.style.color = 'black';
        return true;
    }

}

function ValidateEmail()
{
    // let emailCampo = document.getElementById('inputEmail')
    
    let email = document.getElementById('inputEmail')
    let regexEmail = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (!regexEmail.test(email.value))
    {
        email.focus();
        email.style.color = 'red';
        return false;
    }
    else
    {
        email.style.color = 'black';
        return true
    }
}

function ValidateMessage() {
    let nome = document.getElementById('inputMessage');
    if (nome.value == '') {
        nome.focus();
        nome.style.color = 'red';
        return false;

    }
    else {
        nome.style.color = 'black';
        return true;
    }

}

function Enviar() {
    if (inputNome == "" && ValidateEmail == "" && inputMessage == "") {
        alert("Formulário enviado. Obrigado");
    }
    else {
        alert("Erro. Confirme novamente os dados");
    }
    
}



