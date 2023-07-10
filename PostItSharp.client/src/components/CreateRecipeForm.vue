<template>
    <div class="modal-content">
        <div class="modal-header">
            <h1 class="modal-title fs-5" id="exampleModalLabel">Create Recipe</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>


        <form id="createRecipe" @submit.prevent="createRecipe">
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
                <button type="submit" class="btn btn-primary">Create Recipe</button>
            </div>
        </form>
    </div>
</template>


<script>
import { useRoute } from 'vue-router';
import { router } from '../router.js';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop.js';
import { ref } from 'vue';

export default {
    setup() {
        const editable = ref({})
        const router = useRoute()
        return {
            editable,
            async createRecipe() {
                try {
                    const formData = editable.value
                    const newRecipe = await recipesService.createRecipe(formData)
                    router.push({ name: 'RecipeDetailsPage', params: { recipeId: recipe.id } })
                } catch (error) {
                    Pop.error(error)
                }
            }
            //     async EditRecipe() {
            //         try {
            //             const
            //         } catch (error) {

            //             Pop.error(error)
            //         }
            //     }
            // }
        }
    }
}
</script>


<style lang="scss" scoped>
</style>
