import FilmModule from './FilmModule.js';

const article = document.querySelector(".container");
const inputField = document.querySelector(".inputfield");
const btn = document.querySelector("#aBtn");



btn.addEventListener('click', () => {
    console.log('clicked')
    console.log(inputField.value)
    const found = FilmModule.getById(parseInt(inputField.value));
    if (found) {
        article.innerHTML += `<h1>${found.name}</h1>`
    } else {
        article.innerHTML += `<h1>Not found</h1>`
    }

})

