<template>
    <div class="container-fluid">
        <div class="row">
            <!-- <card class="bg-dark"> -->
            <card class="text-light my-2 coverImg" @click="setActiveRecipe(recipe.id)"
                :style="{ backgroundImage: `url(${recipe.img})` }">
                <!-- <div class="col-4 pe-2 my-2"> -->

                <!-- <router-link :to="{ name: 'RecipeDetailsPage', params: { recipeId: recipe.id } }"> -->

                <!-- <img class=" elevation-4 rounded" :src="recipe.img" alt="" @click=""> -->

                <!-- </router-link> -->

                <div class="d-flex det">
                    <div>
                        <p class="category">{{ recipe.category }}</p>
                        <p>{{ recipe.title }}</p>
                    </div>

                </div>

                <!-- </div> -->
            </card>
            <div class="d-flex justify-content-evenly">
                <i @click.prevent="DeleteRecipe(recipe.id)" class="mdi mdi-delete"></i>
                <div>


                    <button v-if="!isfavorite" class="text-end"><i class="mdi mdi-heart-outline"
                            @click="createFavorite()"></i></button>

                    <button v-else class="text-end"><i class="mdi mdi-heart text-danger" @click="unFavorite()"></i></button>
                    <button class="btn btn-primary mdi mdi-thumb-down" @click="unFavorite()"></button>
                </div>
            </div>
            <!-- </card> -->

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
import { useRoute } from 'vue-router';
import { favoritesService } from '../services/FavoritesService.js';

export default {
    props: {
        recipe: { type: Recipe, required: true }
    },
    setup(props) {
        // const route = useRoute()
        return {
            async createFavorite() {
                try {
                    // debugger
                    // const recipeId = route.params.recipeId
                    const recipeId = props.recipe.id
                    console.log('recipeId', recipeId);
                    await favoritesService.createFavorite(recipeId)
                } catch (error) {
                    logger.log(error)
                    Pop.error(error)
                    Pop.toast(error)
                }
            },
            async unFavorite() {
                try {
                    const recipeId = props.recipe.id
                    if (await Pop.confirm) {
                        const favorite = AppState.favorites.find(f => f.creatorId == AppState.account.id)
                        await favoritesService.unFavoriteRecipe(recipeId)
                    }
                } catch (error) {
                    Pop.error(error)
                    logger.log(error)
                }
            },

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
            },
            isfavorite: computed(() => AppState.favorites.find(f => f.creatorId == AppState.user.id)),
            user: computed(() => AppState.user)
            // favorites: computed(() => AppState.favorites)
            // recipe: computed(() => AppState.recipe)
        }
    }
}
</script>


<style lang="scss" scoped>
.coverImg {
    // height: 180px;
    // width: 230px;

    height: 40dvb;
    width: 30dvb;
    border-radius: 10px;
    position: relative;
    background-size: cover;
    background-repeat: no-repeat;
    background-position: center;


}

// card {
//     width: 250px;
//     border-radius: 10px
// }

.text {
    position: absolute;
    bottom: 0px;
    color: black;
    padding-left: 2px;
    z-index: 3;
    opacity: 1;
    padding: 0px;
    margin: 0px;
    width: 39dvb;
    height: 17dvb;
    overflow: auto;

}

// .details {
//     position: relative;

// }
.det {
    position: absolute;
    bottom: 0px;
    justify-content: space-between;
    overflow: hidden;
    background-color: lightgray;
    color: black;
    width: 30dvb;
    left: 0px;
    margin-right: 5px;
    text-align: center;
    padding-left: 5px;
    border-bottom-left-radius: 10px;
    border-bottom-right-radius: 10px;
}

.det::after {
    content: "";
    position: absolute;
    bottom: 0;
    left: 0;
    width: 100%;
    height: 5%;
    backdrop-filter: blur(20px);
    z-index: -3;
}

.details::before {
    position: absolute;
    /* z-index: 2; */
    /* filter: blur(10px); */
}

// .category {
//     position: relative;
//     top: 30px
// }
</style>
