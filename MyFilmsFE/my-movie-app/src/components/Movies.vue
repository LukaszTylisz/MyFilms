<template>
  <div>
    <h3 class="mb-3 border-bottom-orange pb-3 px-2">All Movies</h3>
    <button
      id="show-modal"
      class="btn btn-lg mb-4 glow-on-hover"
      @click="openModal('Add Movie', false)"
    >
      Add Movie
    </button>
    <button type="button" class="btn btn-lg btn-secondary mb-4 mx-1" @click="FetchData">Fetch Data</button>
 
    <Teleport to="body">
      <Modal
        :show="showModal"
        :selected="selectedMovie"
        :edit="isEditMode"
        @close="handleModalClose"
      >
        <template #header>
          <h3>{{ modalHeader }}</h3>
        </template>
      </Modal>
    </Teleport>
 
    <div v-if="message" class="alert alert-success">{{ message }}</div>
    <div class="container">
      <table class="table table-dark">
        <thead>
          <tr>
            <th class="text-orange">Id</th>
            <th>Title</th>
            <th>Director</th>
            <th>Year</th>
            <th>Rate</th>
            <th></th>
          </tr>
        </thead>
        <tbody v-if="movies && movies.length > 0">
          <tr v-for="movie in movies" :key="movie.id">
            <td>{{ movie.id }}</td>
            <td>{{ movie.title }}</td>
            <td>{{ movie.director }}</td>
            <td>{{ movie.year }}</td>
            <td>{{ movie.rate }}</td>
 
            <td>
              <div class="btn-group" role="group" aria-label="Basic example">
                <button
                 class="btn btn-info mx-1 text-white"
                 @click="editMovie(movie)"
                >
                 Edit
                </button>
                <button
                 class="btn btn-danger"
                 @click="deleteMovie(movie.id)"
                >
                 Delete
                </button>
              </div>
            </td>
          </tr>
        </tbody>
        <tbody v-else>
          <tr>
            <td colspan="6">No movies available</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
 </template>
 
 <script>
 import MovieDataService from "@/DataService/MovieDataService";
 import Modal from "./MovieModal.vue";
 
 export default {
  name: "MoviesComponent",
  data() {
    return {
      movies: [],
      message: "",
      showModal: false,
      isEditMode: false,
      selectedMovie: null,
      modalHeader: null,
    };
  },
  components: {
    Modal,
  },
  methods: {
    refreshMovies() {
 MovieDataService.getMovies()
   .then((res) => {
     if (res.data && res.data.length > 0) {
       this.movies = res.data;
       console.log('Movies:', this.movies);
     } else {
       console.error('No data received from the server:', res.data);
     }
   })
   .catch((error) => {
     this.handleError(error, 'Error connecting to the database, check the API.');
   });
},
    openModal(header, isEditMode) {
      this.modalHeader = header;
      this.showModal = true;
      this.isEditMode = isEditMode;
    },
    updateMovie(id) {
      this.$router.push(`/movie/${id}`);
    },
    deleteMovie(id) {
      if (confirm("Are you sure you want to delete this video?")) {
        MovieDataService.deleteMovie(id)
          .then(() => {
            this.refreshMovies();
          })
          .catch((error) => {
            this.handleError(
              error,
              "Error connecting to the database, check the API."
            );
          });
      }
    },
    editMovie(movie) {
      this.isEditMode = true;
      this.openModal("Edit Movie", true);
      this.selectedMovie = movie;
    },
    FetchData() {
      MovieDataService.fetchMovies()
          .then(() => {
            this.refreshMovies();
          })
          .catch((error) => {
            this.handleError(error, 'Failed to download videos from database. Please try later.');
          });
      },
    handleModalClose() {
      this.showModal = false;
      this.selectedMovie = null;
      this.shouldRefresh = true;
    },
    handleError(error, message) {
      alert(`${message}\n\n Error Code ${error}`);
    },
  },
  created() {
    this.refreshMovies();
    console.log('Component created. Movies:', this.movies);
  },
  watch: {
    shouldRefresh(newVal) {
      if (newVal) {
        this.refreshMovies();
        this.shouldRefresh = false;
      }
    },
  },
 };
 </script>