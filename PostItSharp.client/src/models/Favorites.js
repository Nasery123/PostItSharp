export class Favorite {
    constructor(data) {
        this.id = data.favoriteId
        this.accountId = data.creatorId
        this.recipeId = data.id
    }
}
