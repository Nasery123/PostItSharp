<template></template>


<script>
import { onMounted } from 'vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { recipesService } from './service/RecipesService.js';


export default {
    setup() {
        async function getRecipe() {
            try {
                await recipesService.getRecipes();
            } catch (error) {
                Pop.error(error)
                logger.log(error)
            }
        }
        onMounted(() => {
            getRecipe();
        })
        return {}
    }
}
</script>


<style lang="scss" scoped>
</style>
