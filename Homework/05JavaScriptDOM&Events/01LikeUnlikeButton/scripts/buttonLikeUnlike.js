function changeText() {
    if (this.innerHTML === 'Like') {
        this.innerHTML = 'Unlike';
    } else {
        this.innerHTML = 'Like';
    }
}
document.getElementById('button').addEventListener('click', changeText);