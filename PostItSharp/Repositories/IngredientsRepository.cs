namespace PostItSharp.Repositories;

public class IngredientsRepository
{
    private readonly IDbConnection _db;
    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Ingredients CreateIngredients(Ingredients inData)
    {
        string sql = @"
            INSERT INTO ingredients
            (name, quantity, recipeId)
            VALUES
            (@name, @quantity, @recipeId);

            SELECT
            ingredients.*

            FROM ingredients

            WHERE ingredients.id = LAST_INSERT_ID()

            ;";

        Ingredients ingredients = _db.Query<Ingredients>(sql, inData).FirstOrDefault();
        return ingredients;
    }

    internal Ingredients GetById(int ingredientsId)
    {
        string sql = @"
        SELECT
        ingredients.*
        FROM ingredients
        WHERE ingredients.id = @ingredientsId


        ;";
        Ingredients ingredients = _db.Query<Ingredients>(sql, new { ingredientsId }).FirstOrDefault();
        return ingredients;
    }

    internal List<Ingredients> GetIngredientsByRecipeId(int recipeId)
    {
        string sql = @"
            SELECT
            ingredients.*,
            recipe.*
            FROM ingredients
            JOIN recipe ON ingredients.recipeId = recipe.id
            WHERE ingredients.recipeId = @recipeId

            ;";

        List<Ingredients> recipeIngredients = _db.Query<Ingredients, Recipe, Ingredients>(sql, (ingredients, recipe) =>
        {
            // ingredients.RecipeId = recipe;
            return ingredients;
        }, new { recipeId }).ToList();

        return recipeIngredients;
    }

    internal int RemoveIngrediens(int ingredientsId)
    {
        string sql = "DELETE FROM ingredients WHERE id = @ingredientsId";
        int rows = _db.Execute(sql, new { ingredientsId });
        return rows;
    }

    // private string GetDebuggerDisplay()
    // {
    //     return ToString();
    // }

    //     internal List<Ingredients> GetAllIngredients()
    //     {
    //         string sql = @"
    //         SELECT
    //         ingredients.*,
    //         recipe.*
    //         FROM ingredients
    //         JOIN recipe ON ingredients.recipeId = recipe.id
    //         ;";

    //         List<Ingredients> ingredients = _db.Query<Ingredients, Recipe, Ingredients>(sql, (ingredients, recipe) =>
    //         {
    //             ingredients.RecipeId = recipe.Id;
    //             return ingredients;
    //         }).ToList();
    //         return ingredients;
    //     }
    // }

}
