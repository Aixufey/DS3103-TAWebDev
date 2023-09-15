const FilmModule = (
    () => {
        const films = [
            {
                id: 1,
                name: 'The Lord of the Rings',
            },
            {
                id: 2,
                name: 'Harry Potter',
            },
            {
                id: 3,
                name: 'Star Wars',
            }
        ]

        const getAll = () => films.map(film => { 
            return {...film}
        });
        
        const getAllFilm = () => films

        const getById = (id) => films.find(film => film.id === id);

        return {
            getAll,
            getAllFilm,
            getById
        }   
    }
)();

export default FilmModule;