namespace BlazorAppPizza.Data
{
    public class PizzaService
    {
        public async Task<Pizza[]> GetPizzasAsync()
        {
            var pizzas = Enumerable.Range(1, 10).Select(i =>
            new Pizza
            {
                Id = i,
                Name = new Bogus.DataSets.Name().FirstName(),
                Description = new Bogus.DataSets.Lorem("en").Sentence(5),
                Price = new Bogus.Randomizer().Decimal(),
                Vegetarian = new Bogus.Randomizer().Bool(),
                Vegan = new Bogus.Randomizer().Bool()
            }).ToArray();

            // Simulate async operation by wrapping the data in a Task
            return await Task.FromResult(pizzas);

        }
    }

}