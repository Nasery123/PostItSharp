<template>
    <!-- <form id="EditRecipe" @submit.prevent="handleChanges">
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
    </form> -->















    <div class="containder-fluid">
        <div class="row">
            <div class="col-4">
                <img class="img-fluid" :src="activeRecipe.img" alt="">
            </div>
            <div class="col-4">
                <p>{{ activeRecipe.instructions }}</p>
            </div>
            <div clas="col-4">
                {{ activeRecipe.title }}
                {{ activeRecipe.category }}

            </div>
        </div>
    </div>
</template>


<script>
import { useRoute } from 'vue-router';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { recipesService } from '../services/RecipesService.js';
import { computed, onMounted, ref } from 'vue';
import { AppState } from '../AppState.js';

export default {
    setup() {
        const editable = ref({})
        const route = useRoute()


        async function getRecipeById() {
            try {
                const recipeId = route.params.recipeId
                await recipesService.getRecipeById(recipeId)
            } catch (error) {
                Pop.error(error)
                logger.log(error)
            }
        }
        onMounted(() => {
            getRecipeById()
        })
        return {
            editable,
            // async handleChanges() {
            //     try {
            //         await recipesService.editRecipe(editable.value)
            //     } catch (error) {
            //         Pop.error(error)
            //     }
            // },
            recipe: computed(() => AppState.recipe),
            activeRecipe: computed(() => AppState.activeRecipe)
        }
    }
}
</script>


<style lang="scss" scoped>
</style>
