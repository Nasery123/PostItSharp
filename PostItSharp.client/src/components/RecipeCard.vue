<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-4" @click="setActiveRecipe(recipe.id)">

                <!-- <router-link :to="{ name: 'RecipeDetailsPage', params: { recipeId: recipe.id } }"> -->

                <img class="pic elevation-4 rounded" :src="recipe.img" alt="" @click="">

                <!-- </router-link> -->
                <i @click.prevent="DeleteRecipe(recipe.id)" class="mdi mdi-delete"></i>
                <p class="category">{{ recipe.category }}</p>

            </div>
        </div>
    </div>
</template>


<script>
import { computed } from 'vue';
import { Recipe } from '../models/Recipe.js';
import { recipesService } from '../services/RecipesService.js';
import { ingredientsService } from '../services/IngredientsService.js'
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { Modal } from 'bootstrap';

export default {
    props: {
        recipe: { type: Recipe, required: true }
    },
    setup() {
        return {
            async DeleteRecipe(recipeId) {
                try {

                    const yes = await Pop.confirm("do you want to delete the recipe?")
                    if (!yes) {
                        return
                    }

                    await recipesService.deleteRecipe(recipeId)
                } catch (error) {
                    Pop.error(error)
                    logger.log(error)
                }
            },
            // recipe: computed(() => AppState.recipe)

            async setActiveRecipe(recipeId) {
                try {

                    Modal.getOrCreateInstance('#recipeDetails').show()
                    await recipesService.getRecipeById(recipeId)
                    await ingredientsService.getIngredientsByRecipeId(recipeId)
                } catch (error) {
                    Pop.error(error)
                    Pop.toast(error)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.pic {
    height: 180px;
    width: 200px;

}

// .category {
//     position: relative;
//     top: 30px
// }
</style>
