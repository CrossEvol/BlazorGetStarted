namespace BlazorAppPizza
{
    public class PizzaTopping
    {
        public Topping Topping { get; set; }

        public int ToppingId { get; set; }
        
        public int PizzaId { get; set; }

		public string Name { get; set; }
		public string Ingredients { get; set; }
	}
}
