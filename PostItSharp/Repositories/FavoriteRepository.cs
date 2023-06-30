namespace PostItSharp.Repositories;

public class FavoriteRepository
{
    private readonly IDbConnection _db;
    public FavoriteRepository(IDbConnection db)
    {
        _db = db;
    }

    internal List<FavoriteRecipe> GetMyFavorite(string accountId)
    {
        string sql = @"
       SELECT
       favorite.*,
       recipe.*,
       accounts.*
       FROM favorite
       JOIN recipe ON recipe.id = favorite.recipeId
       JOIN accounts ON accounts.id = favorite.accountId
       WHERE favorite.accountId = accountId

       ;";

        List<FavoriteRecipe> myFavorite = _db.Query<Favorite, FavoriteRecipe, Account, FavoriteRecipe>(sql, (favorite, recipe, account) =>
        {
            recipe.FavoriteId = favorite.Id;
            recipe.Creator = account;
            return recipe;

        }, new { accountId }).ToList();
        return myFavorite;
    }

    internal Favorite MakeFavorite(Favorite faveData)
    {
        string sql = @"
        INSERT INTO favorite
        (accountId, recipeId)
        VALUES
        (@accountId, @recipeId);
        SELECT LAST_INSERT_ID();
        ";

        int lastInsertId = _db.ExecuteScalar<int>(sql, faveData);
        faveData.Id = lastInsertId;
        return faveData;
    }
}
