namespace PostItSharp.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _repo;
        public IngredientsService(IngredientsRepository repo)
        {
            _repo = repo;
        }

        internal Ingredients CreateIngredient(Ingredients inData)
        {
            Ingredients ingredients = _repo.CreateIngredients(inData);
            return ingredients;
        }

        internal List<Ingredients> GetIngredientsByRecipeId(int recipeId)
        {
            List<Ingredients> ingredients = _repo.GetIngredientsByRecipeId(recipeId);
            return ingredients;
        }

        internal string RemoveIngredients(int ingredientsId)
        {
            Ingredients ingredients = GetById(ingredientsId);
            int rows = _repo.RemoveIngrediens(ingredientsId);
            return "you delete ingrediens that you hated for somereason";
        }


        internal Ingredients GetById(int ingredientsId)
        {
            Ingredients ingredients = _repo.GetById(ingredientsId);
            if (ingredients == null) throw new Exception($" the ingredients on Id :{ingredientsId} does not exist");
            return ingredients;
        }

        // internal List<Ingredients> GetIngredientsByRecipeId()
        // {
        //     List<Ingredients> ingredients = _repo.GetAllIngredients();
        //     return ingredients;
        // }

        // internal <Ingredients> CreateIngredient(Ingredients inData)
        // {
        //     Ingredients ingredients = _repo.CreateIngredients(inData);
        //     return ingredients;
        // }
    }
}
