import axios from 'axios'

const MOVIE_API_URL = 'https://localhost:7235/api/myMovies'

class MovieDataService {

   getMovies() {
        return axios.get(`${MOVIE_API_URL}/`);
    }

    getMovieById(id) {
        return axios.get(`${MOVIE_API_URL}/${id}`);
    }

    deleteMovie(id) {
        return axios.delete(`${MOVIE_API_URL}/${id}`);
    }

    fetchMovies() {
        return axios.get(`${MOVIE_API_URL}/fetchmovies`);
    }
    
    updateMovie(movie) {
        return axios.put(`${MOVIE_API_URL}/`, movie);
    }

    createMovie(movie) {
        return axios.post(`${MOVIE_API_URL}/`, movie);
    }
  }
export default new MovieDataService()