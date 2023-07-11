<template>
  <div class="row">
    <div class="col-md-4 col-8 d-flex justify-content-between">
      <button class="btn btn-primary m-1" data-bs-toggle="modal" data-bs-target="#createRecipe">CREATE
        RECIPE</button>
    </div>
  </div>
  <div class="d-flex">
    <div class="row">
      <div class="col-md-3 col-12 " v-for="r in recipe" :key="r.id">

        <RecipeCard :recipe="r" />
      </div>

    </div>
  </div>
</template>


<script>
import { computed, onMounted } from 'vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js';
import { Recipe } from '../models/Recipe.js';
import RecipeCard from '../components/RecipeCard.vue';
import { AppState } from '../AppState.js';


export default {
  setup() {
    async function getRecipe() {
      try {

        await recipesService.getRecipes();
      }
      catch (error) {
        Pop.error(error);
        logger.log(error);
      }
    }

    onMounted(() => {
      getRecipe();
    });
    return {
      recipe: computed(() =>
        AppState.recipe)
    };
  }
  // components: RecipeCard
}

</script>


<style lang="scss" scoped>
</style>
