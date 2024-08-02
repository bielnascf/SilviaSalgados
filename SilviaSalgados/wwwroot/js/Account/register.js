const btnTogglePassword = document.querySelector('.toggle_password')
const eyeIcon = document.getElementById('eye_icon')
const inputPassword = document.getElementById('userPassword')

btnTogglePassword.addEventListener('click', () => {
    const type = inputPassword.getAttribute('type') === 'password' ? 'text' : 'password';
    inputPassword.setAttribute('type', type);

    if (type === 'password') {
        eyeIcon.src = '/assets/icons/hidePassword.svg';
        eyeIcon.alt = 'Hide Password';
    } else {
        eyeIcon.src = '/assets/icons/showPassword.svg';
        eyeIcon.alt = 'Show Password';
    }
})