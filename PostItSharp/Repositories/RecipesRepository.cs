
namespace PostItSharp.Repositories;
public class RecipeRepository
{
    private readonly IDbConnection _db;
    public RecipeRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        string sql = @"
        INSERT INTO recipe
        (title, instructions, img, category, creatorId)
        VALUES
        (@title, @instructions, @img, @category, @creatorId);

        SELECT
        recipe.*,
        accounts.*
        FROM recipe
        JOIN accounts ON recipe.creatorId = accounts.id
        WHERE recipe.id = LAST_INSERT_ID();
        ";
        Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) =>
        {

            recipe.Creator = creator;
            return recipe;
        }, recipeData).FirstOrDefault();
        return recipe;
    }

    internal List<Recipe> GetAllRecipes()
    {
        string sql = @"
        SELECT
        recipe.*,
        accounts.*
        FROM recipe
        JOIN accounts ON recipe.creatorId = accounts.id

        ;";

        List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {

            recipe.Creator = account;
            return recipe;
        }).ToList();
        return recipes;
    }

    internal Recipe GetById(int recipeId)
    {
        string sql = @"
        SELECT
        recipe.*,
        accounts.*
        FROM recipe
        JOIN accounts ON recipe.creatorId = accounts.id
        WHERE recipe.id = @recipeId
        ;";

        Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;

        }, new { recipeId }).FirstOrDefault();
        return recipe;
    }



    internal void UpdateRecipe(Recipe original)
    {
        string sql = @"
        UPDATE recipe SET
        title = @title,
        instructions = @instructions,
        img = @img,
        category = @category
        WHERE id = @id
        ;";

        _db.Execute(sql, original);
    }
    internal int RemoveRecipe(int recipeId)
    {
        string sql = "DELETE FROM recipe WHERE id = @recipeId LIMIT 1;";
        int rows = _db.Execute(sql, new { recipeId });
        return rows;
    }
}
