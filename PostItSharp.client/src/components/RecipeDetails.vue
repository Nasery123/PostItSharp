<template>
    <div class="modal-content">
        <div class="modal-header">
            <h1 class="modal-title fs-5" id="staticBackdropLabel">Recipe Name </h1>
        </div>
        <div>
            <div class="row">
                <button class="btn btn-primary m-1" data-bs-toggle="modal" data-bs-target="#editRecipe">Edit
                    RECIPE</button>
            </div>
            <div class="row">
                <div class="col-4 modal-body">
                    <img class="img-fluid" :src="activeRecipe.img" alt="">
                </div>
                <div class="col-4">
                    <p>{{ activeRecipe.instructions }}</p>
                </div>
                <div clas="col-4">
                    {{ activeRecipe.title }}
                    {{ activeRecipe.category }}

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

export default {
    setup() {
        return {

            recipe: computed(() => AppState.recipe),
            activeRecipe: computed(() => AppState.activeRecipe)

        }
    }
}
</script>


<style lang="scss" scoped>
</style>
