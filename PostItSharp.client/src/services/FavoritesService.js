import { AppState } from "../AppState.js"
import { Favorite } from "../models/Favorites.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class FavoritesService {
    async createFavorite(recipeId) {

        const res = await api.post('api/favorites', { recipeId })
        logger.log('[Creating favorite]', res.data)
        AppState.favorites.push(new Favorite(res.data))
    }

    async getMyFavorites() {
        const res = await api.get('account/favorites')
        logger.log('[here are some favorite for your account]', res.data)

        AppState.favorites = res.data.map(f => new Favorite(f))
        logger.log('[THIS FAVORITES EXIST IN YOUR APPSTATE]', AppState.favorites)

    }

}
export const favoritesService = new FavoritesService()
