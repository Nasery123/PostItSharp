<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-4">
                <router-link :to="{ name: 'RecipeDetailsPage', params: { recipeId: recipe.id } }">
                    <img class="pic elevation-4 rounded" :src="recipe.img" alt="recipe.category">
                </router-link>
                <p>{{ recipe.category }}</p>
            </div>
        </div>
    </div>
</template>


<script>
import { Recipe } from '../models/Recipe.js';

export default {
    props: {
        recipe: { type: Recipe, required: true }
    },
    setup() {
        return {}
    }
}
</script>


<style lang="scss" scoped>
.pic {
    height: 180px;
    width: 200px;
}
</style>
