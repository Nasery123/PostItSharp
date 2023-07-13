<template>
    <!-- <Modal id="editRecipe"> -->

    <!-- <div class="modal-content">
        <div class="modal-header">


        </div> -->


    <div class="modal-content">
        <div class="modal-header">
            <h1 class="modal-title fs-5" id="exampleModalLabel">Create Recipe</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>

        <form @submit.prevent="handleChanges(recipeId)">
            <div class="modal-body">
                <div class="form-floating mb-3">
                    <input type="text" class="form-control" id="floatingInput" placeholder="Category"
                        v-model="editable.Category">
                    <label for="floatingInput">Recipe Category</label>
                </div>
                <div class="form-floating">
                    <input type="text" class="form-control" id="floatingPassword" placeholder="Cover Image"
                        v-model="editable.img">
                    <label for="floatingPassword">Cover img</label>
                </div>
                <div class="form-floating">
                    <input type="text" class="form-control" id="floatingPassword" placeholder="Cover Image"
                        v-model="editable.instructions">
                    <label for="floatingPassword">instructions</label>
                </div>
                <div class="form-floating">
                    <input type="text" class="form-control" id="floatingPassword" placeholder="location"
                        v-model="editable.title">
                    <label for="floatingPassword">title</label>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                <button type="submit" class="btn btn-primary">Save Changes</button>
            </div>
        </form>
    </div>
    <!-- </div> -->
    <!-- </Modal> -->
</template>


<script>
import { computed, mergeProps, ref } from 'vue';
import { AppState } from '../AppState.js';
import { Recipe } from '../models/Recipe.js';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js';
import { Modal } from 'bootstrap';

export default {
    props: {
        recipe: { type: Recipe, Required: true }
    },
    setup() {
        const editable = ref({ ...mergeProps.recipe })
        return {
            editable,
            async handleChanges() {
                try {
                    const recipeData = editable.value

                    await recipesService.editRecipe(recipeData)
                    editable.value = {}
                    Modal.getOrCreateInstance("#editRecipe").hide()
                } catch (error) {
                    Pop.error(error)
                }
            },


            recipe: computed(() => AppState.recipe),
            activeRecipe: computed(() => AppState.activeRecipe)
        }
    }
}
</script>


<style lang="scss" scoped>
</style>
