namespace PostItSharp.Services;
public class RecipeService
{
    private readonly RecipeRepository _repo;

    public RecipeService(RecipeRepository repo)
    {
        _repo = repo;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _repo.CreateRecipe(recipeData);
        return recipe;
    }

    internal List<Recipe> GetAllRecipes()
    {
        List<Recipe> recipes = _repo.GetAllRecipes();
        return recipes;
    }

    internal Recipe GetById(int recipeId)
    {
        Recipe recipe = _repo.GetById(recipeId);
        if (recipe == null) throw new Exception($" the recipe on Id :{recipeId} does not exist");
        return recipe;
    }


    internal Recipe UpdateRecipe(Recipe updateData)
    {
        Recipe original = GetById(updateData.Id);
        original.Title = updateData.Title != null ? updateData.Title : original.Title;
        original.Instructions = updateData.Instructions != null ? updateData.Instructions : original.Instructions;
        original.Img = updateData.Img != null ? updateData.Img : original.Img;
        original.Category = updateData.Category != null ? updateData.Category : original.Category;

        _repo.UpdateRecipe(original);
        return original;

    }
    internal string RemoveRecipe(int recipeId)
    {
        Recipe recipe = GetById(recipeId);

        int rows = _repo.RemoveRecipe(recipeId);
        if (rows > 1) throw new Exception("make sure your action does not affect more than one rows");
        return "you successfully deleted the recipe";
    }
}
