import MovieModuleService from "../services/MovieModuleService.js"
import { dynamicCreated } from '../utils/index.js'

const handleClick = (event) => {
    console.log(event.target)
    console.log(event.target.getAttribute('data'))
    // event.target.remove();
}

let html = "";
let movies = await MovieModuleService.getAllMovies();
try {
    movies.forEach(movie => {
        html += `
        <article data="${movie.title}" class="movie-item col-12 col-md-6 col-lg-4">
            <h2>${movie.title}</h2>
            <p>${movie.year}</p>
        </article>
        `})
} catch (e) {
    html = `<p>${e}</p>`
} finally {
    dynamicCreated.tag('.movie-container').innerHTML = html;
}


const movieItem = document.querySelectorAll('.movie-item');
movieItem.forEach(item => (
    item.addEventListener('click', handleClick))
)
