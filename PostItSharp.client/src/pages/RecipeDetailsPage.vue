<template>
    <div class="containder-fluid">
        <!-- <div class="row">
            <button class="btn btn-primary m-1" data-bs-toggle="modal" data-bs-target="#editRecipe">Edit
                RECIPE</button>
        </div>
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
    </div> -->
        <!-- <Modal id="editRecipe">

        <div class="modal-content">
            <div class="modal-header">


            </div>


            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Create Recipe</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>

                <form id="EditRecipe" @submit.prevent="handleChanges(recipeId)">
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
        </div>
    </Modal> -->
    </div>
</template>


<script>
import { useRoute } from 'vue-router';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { recipesService } from '../services/RecipesService.js';
import { computed, onMounted, ref } from 'vue';
import { AppState } from '../AppState.js';
import { Recipe } from '../models/Recipe.js';
import { ingredientsService } from '../services/IngredientsService.js'

export default {
    props: {
        recipe: { type: Recipe, Required: true }
    },
    setup(props) {
        const editable = ref({ ...props.recipe })
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
        async function getIngredientsByRecipeId() {
            // const recipeId = getRecipeById()
            const recipeId = route.params.recipeId
            await ingredientsService.getIngredientsByRecipeId(recipeId)
        }
        onMounted(() => {
            getRecipeById()
            getIngredientsByRecipeId()
        })
        return {
            editable,
            // async handleChanges() {
            //     try {
            //         const recipeData = editable.value

            //         await recipesService.editRecipe(recipeData)
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
<!-- to  create a modal first check the button if it works or not. then bring the modal template on the page of the template put the dabs-bs-modal and data-bs-target then put the id on the page of the modal and then put that in the app.view and then make the form to put in the slot  -->
