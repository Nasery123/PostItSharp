import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class RecipesService {

    async getRecipes() {
        logger.log("it is working or not")

        const res = await api.get('api/recipes')

        logger.log('[here are some recipes]', res.data)

        AppState.recipe = res.data.map(r => new Recipe(r))
        logger.log("here are the AppState recipe", AppState.recipe)
    }
    async getRecipeById(recipeId) {

        const res = await api.get(`api/recipes/${recipeId}`)
        logger.log('[here we go ]', res.data)
        AppState.activeRecipe = new Recipe(res.data)
    }
    async createRecipe(formData) {
        const res = await api.post('api/recipes', formData)
        logger.log('here is your new recipe', res.data)
        AppState.recipe.push(new Recipe(res.data))
        return res.data
    }
    async editRecipe(recipeData) {

        // const originalRecipe = this.getRecipeById()
        logger.log('[here is what you want]', recipeData)
        let activeRecipee = AppState.activeRecipe

        activeRecipee = await api.put(`api/recipes/${activeRecipee.id}`, recipeData)
        logger.log('[here is the recipe you want to edir]', activeRecipee)
        AppState.activeRecipe = new Recipe(activeRecipee)
        logger.log("heeeeere is ", activeRecipee)
    }

    async deleteRecipe(recipeId) {
        debugger
        const res = await api.delete(`api/recipes/${recipeId}`)
        AppState.recipe = AppState.recipe.filter(r => r.id != recipeId)
    }




}
export const recipesService = new RecipesService();
