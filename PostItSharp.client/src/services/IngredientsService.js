import { AppState } from "../AppState.js";
import { ingredients } from "../models/Ingredients.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class IngredientsService {


    async getIngredientsByRecipeId(recipeId) {

        const res = await api.get(`api/recipes/${recipeId}/ingredients`)
        logger.log('[Getting Ingredients for that recipe]', res.data)
        AppState.ingredients = res.data.map(i => new ingredients(i))

    }
}
export const ingredientsService = new IngredientsService();
