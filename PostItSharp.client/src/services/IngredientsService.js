import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class IngredientsService {


    async getIngredientsByRecipeId(recipeId) {

        const res = await api.get(`api/recipes/${recipeId}/ingredients`)
        logger.log('[Getting Ingredients for that recipe]', res.data)

    }
}
export const ingredientsService = new IngredientsService();
