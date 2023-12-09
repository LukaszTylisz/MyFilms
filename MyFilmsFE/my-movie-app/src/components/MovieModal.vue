<template>
    <Transition name="modal">
      <div v-if="show" class="modal-mask">
        <div class="modal-container">
          <div class="modal-header">
            <slot name="header"></slot>
          </div>
  
          <div class="modal-body text-white">
            <form>
              <div v-for="field in formFields" :key="field.id" class="form-group">
                <label :for="field.name">{{ field.label }}:</label>
                <input
                  :type="field.type"
                  :class="['form-control', 'm-2', { 'is-invalid': !v$.movie[field.name]?.required?.$pending && !v$.movie[field.name]?.required?.value }]"
                  :id="field.name"
                  v-model="movie[field.name]"
                />
                <small v-if="!v$.movie[field.name]?.required?.$pending && !v$.movie[field.name]?.required?.value" class="mx-3 mb-4 d-block validation-error-text">
                  <strong>{{ v$.movie[field.name]?.required?.$message }}</strong>
                </small>
              </div>
            </form>
          </div>
          <div class="modal-footer">
            <slot name="footer">
              <div class="btn-group" role="group" aria-label="Basic example">
                <button v-if="edit" class="btn btn-success modal-default-button px-4 text-white" @click="updateMovie">Zapisz</button>
                <button v-else class="btn btn-success modal-default-button px-4 text-white" @click="addMovie">Dodaj</button>
                <button class="btn btn-info modal-default-button px-4 text-white" @click="$emit('close'), clearForm()">Cofnij</button>
              </div>
            </slot>
          </div>
        </div>
      </div>
    </Transition>
  </template>
  
  <script>
  import MovieDataService from '@/DataService/MovieDataService';
  import { useVuelidate } from '@vuelidate/core';
  import { required, maxLength, between, helpers } from '@vuelidate/validators';
  
  export default {
    props: {
      show: Boolean,
      selected: Object,
      edit: Boolean,
    },
    setup() {
      return { v$: useVuelidate() };
    },
    data() {
      return {
        movie: {
          id: '',
          title: '',
          director: '',
          year: '',
          rate: '',
        },
        formFields: [
          { id: 1, label: 'Title', name: 'title', type: 'text' },
          { id: 2, label: 'Director', name: 'director', type: 'text' },
          { id: 3, label: 'Year', name: 'year', type: 'number' },
          { id: 4, label: 'Rate', name: 'rate', type: 'number' },
        ],
      };
    },
    validations() {
      return {
        movie: {
          title: {
            required: helpers.withMessage('This field must be completed', required),
            maxLength: helpers.withMessage('Max 200 characters', maxLength(200)),
          },
          director: {
            required: helpers.withMessage('This field must be completed', required),
            maxLength: helpers.withMessage('Max 40 characters', maxLength(40)),
          },
          year: {
            required: helpers.withMessage('This field must be completed with a year in the range 1900-2200', required),
            between: helpers.withMessage('The year given should be in the range 1900-2200', between(1900, 2200)),
          },
          rate: {
            required: helpers.withMessage('This field must be completed with a number 1-10', required),
            between: helpers.withMessage('This field must be completed with a number 1-10', between(1, 10)),
          },
        },
      };
    },
    methods: {
      async addMovie() {
        const isFormCorrect = await this.v$.$validate();
        if (!isFormCorrect) {
          return;
        }
  
        MovieDataService.createMovie(this.movie)
          .then(() => {
            this.clearForm();
            this.$emit('close');
          })
          .catch((error) => {
            this.handleError(error, 'Failed to add the video to the database, check the API.');
          });
      },
      async updateMovie() {
        const isFormCorrect = await this.v$.$validate();
        if (!isFormCorrect) {
          return;
        }
  
        MovieDataService.updateMovie(this.movie)
          .then(() => {
            this.clearForm();
            this.$emit('close');
          })
          .catch((error) => {
            this.handleError(error, 'Failed to save changes, check API.');
          });
      },
      clearForm() {
        this.movie = {
          id: '',
          title: '',
          director: '',
          year: '',
          rate: '',
        };
      },
      handleError(error, message) {
        alert(`${message}\n\n Error Code ${error}`);
      },
    },
    watch: {
      selected(newVal) {
        if (newVal) {
          this.movie = {
            id: newVal.id,
            title: newVal.title,
            director: newVal.director,
            year: newVal.year,
            rate: newVal.rate,
          };
        }
      },
    },
  };
  </script>
  
  <style>
    .is-invalid {
      border-color: red !important;
    }
  </style>
  