namespace PostItSharp.Controllers;

[ApiController]
[Route("api/ingredients")]
public class IngredientsController : ControllerBase
{
    private readonly IngredientsService _ingredientsService;
    private readonly Auth0Provider _auth;

    public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth)
    {
        _ingredientsService = ingredientsService;
        _auth = auth;
    }






    [HttpPost]
    [Authorize]
    public ActionResult<Ingredients> CreateIngredient([FromBody] Ingredients inData)
    {
        try
        {


            Ingredients ingredients = _ingredientsService.CreateIngredient(inData);
            return Ok(ingredients);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }
    [HttpDelete("{ingredientsId}")]
    [Authorize]

    public ActionResult<string> RemoveIngredients(int ingredientsId)
    {
        try
        {
            string message = _ingredientsService.RemoveIngredients(ingredientsId);
            return Ok(message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
