namespace PostItSharp.Controllers;

[ApiController]
[Route("api/favorites")]
public class FavoriteController : ControllerBase
{
    private readonly FavoriteService _favoriteService;
    private readonly Auth0Provider _auth;

    public FavoriteController(FavoriteService favoriteService, Auth0Provider auth)
    {
        _favoriteService = favoriteService;
        _auth = auth;
    }





    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite faveData)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            faveData.AccountId = userInfo.Id;
            Favorite makeFavorite = _favoriteService.CreateFavorite(faveData);
            return Ok(makeFavorite);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
