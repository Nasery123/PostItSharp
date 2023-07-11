<template>
    <div class="modal-content">
        <div class="modal-header">
            <h1 class="modal-title fs-5" id="staticBackdropLabel"> </h1>
        </div>
        <div>
            <div class="row">
                <div class="col-4">
                    <button class="btn btn-primary m-1" data-bs-toggle="modal" data-bs-target="#editRecipe">Edit
                        RECIPE</button>
                </div>
            </div>
            <div class="row">
                <div class="col-3 modal-body">
                    <img class="img-fluid" :src="activeRecipe.img" alt="">
                </div>
                <div class="col-3">
                    <p>{{ activeRecipe.instructions }}</p>
                    {{ activeRecipe.title }}
                    {{ activeRecipe.category }}
                </div>
                <p>INGREDIENTS</p>
                <div class="col-3" v-for="i in ingredients" :key="i.id">
                    {{ i.name }}
                    {{ i.quantity }}

                    <!-- {{ ingredients.Quantity }} -->
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-bs-dismiss="modal">close</button>


                </div>

            </div>
        </div>
    </div>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';
import { ingredients } from '../models/Ingredients.js';

export default {
    setup() {
        return {

            recipe: computed(() => AppState.recipe),
            activeRecipe: computed(() => AppState.activeRecipe),
            ingredients: computed(() => AppState.ingredients)

        }
    }
}
</script>


<style lang="scss" scoped>
</style>
