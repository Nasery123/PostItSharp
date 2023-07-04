<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-4">

                <router-link :to="{ name: 'RecipeDetailsPage', params: { recipeId: recipe.id } }">

                    <img class="pic elevation-4 rounded" :src="recipe.img" alt="recipe.category">

                </router-link>
                <i @click.prevent="DeleteRecipe(recipe.recipeId)" class="mdi mdi-delete"></i>
                <p class="category">{{ recipe.category }}</p>

            </div>
        </div>
    </div>
</template>


<script>
import { computed } from 'vue';
import { Recipe } from '../models/Recipe.js';
import { recipesService } from '../services/RecipesService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';

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
            }
            // recipe: computed(() => AppState.recipe)
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
