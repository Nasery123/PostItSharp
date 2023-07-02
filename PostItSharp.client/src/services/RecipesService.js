import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class RecipesService {

    async getRecipes() {
        logger.log("it is working or not")
        const res = await api.get("api/recipes")
        logger.log('[here are some recipes]', res.data)
        AppState.recipe = res.data.map(r => new Recipe(r))
    }


}
export const recipesService = new RecipesService();
