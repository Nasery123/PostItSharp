namespace PostItSharp.Controllers;
[ApiController]
[Route("api/recipes")]
public class RecipesController : ControllerBase
{
    private readonly RecipeService _recipeService;
    private readonly Auth0Provider _auth;
    private readonly IngredientsService _ingredientsService;

    public RecipesController(RecipeService recipesService, Auth0Provider auth, IngredientsService ingredientsService)
    {
        _recipeService = recipesService;
        _auth = auth;
        _ingredientsService = ingredientsService;
    }


    [HttpPost]
    [Authorize]

    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            recipeData.CreatorId = userInfo.Id;

            Recipe recipe = _recipeService.CreateRecipe(recipeData);
            return new ActionResult<Recipe>(Ok(recipe));
        }
        catch (Exception e)
        {
            return new ActionResult<Recipe>(BadRequest(e.Message));
        }
    }

    [HttpGet]
    public ActionResult<List<Recipe>> GetAllRecipes()
    {
        try
        {
            List<Recipe> recipes = _recipeService.GetAllRecipes();
            return Ok(recipes);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("{recipeId}")]
    public ActionResult<Recipe> GetById(int recipeId)
    {
        try
        {
            Recipe recipe = _recipeService.GetById(recipeId);
            return Ok(recipe);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet("{recipeId}/ingredients")]
    public ActionResult<List<Ingredients>> GetIngredientsByRecipeId(int recipeId)
    {
        try
        {
            List<Ingredients> ingredients = _ingredientsService.GetIngredientsByRecipeId(recipeId);
            return Ok(ingredients);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }


    [HttpPut("{recipeId}")]
    public ActionResult<Recipe> UpdateRecipe(int recipeId, [FromBody] Recipe updateData)
    {
        try
        {
            updateData.Id = recipeId;
            Recipe recipe = _recipeService.UpdateRecipe(updateData);
            return Ok(recipe);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{recipeId}")]
    public ActionResult<string> RemoveRecipe(int recipeId)
    {
        try
        {
            string message = _recipeService.RemoveRecipe(recipeId);
            return Ok(message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
