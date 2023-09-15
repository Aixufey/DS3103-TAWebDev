import FilmModule from './FilmModule.js';

const article = document.querySelector("#container");
const btn = document.getElementById("aBtn");



btn.addEventListener('click', () => {
    const found = FilmModule.getById(5);
    console.log(found);
})
