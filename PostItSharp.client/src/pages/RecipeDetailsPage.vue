<template>
    <div class="containder-fluid">
        <div class="row">
            <div class="col-4">
                <img class="img-fluid" :src="activeRecipe.img" alt="">
            </div>
            <div class="col-4">
                <p>{{ activeRecipe.instructions }}</p>
            </div>
            <div clas="col-4">
                {{ activeRecipe.ingredients }}
            </div>
        </div>
    </div>
</template>


<script>
import { useRoute } from 'vue-router';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { recipesService } from '../services/RecipesService.js';
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';

export default {
    setup() {
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
            recipe: computed(() => AppState.recipe),
            activeRecipe: computed(() => AppState.activeRecipe)
        }
    }
}
</script>


<style lang="scss" scoped>
</style>
