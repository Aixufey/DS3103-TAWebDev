const MovieModuleService = (
    () => {
        let movies = [];
        const getAllMovies = () => {
            return new Promise((resolve, reject) => {
                fetch('http://localhost:5500/exercises/exe6/data.json')
                    .then(resp => resp.json())
                    .then(data => {
                        movies = data.data.movies
                        // console.log(movies)
                        resolve(movies);
                    })
                    .catch(err => {
                        reject(err);
                    })
                return movies
            })
        }
        return {
            getAllMovies
        }
    }
)();
export default MovieModuleService;