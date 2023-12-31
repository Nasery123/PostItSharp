namespace PostItSharp.Services
{
    public class FavoriteService
    {
        private readonly FavoriteRepository _repo;
        public FavoriteService(FavoriteRepository repo)
        {
            _repo = repo;
        }

        internal Favorite CreateFavorite(Favorite faveData)
        {
            Favorite makeFavorite = _repo.MakeFavorite(faveData);
            return makeFavorite;
        }

        // internal string DeleteFavorite(int recipeId, string id)
        // {
        //     Favorite deletFavorite = _repo.DeletFavorite(int recipeId)
        // }

        internal List<FavoriteRecipe> GetMyFavorite(string accountId)
        {
            List<FavoriteRecipe> myFavorite = _repo.GetMyFavorite(accountId);
            return myFavorite;
        }
    }
}
