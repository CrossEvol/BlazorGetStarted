namespace BlazorAppPizza.Services
{
	public class DemoListState
	{
		public List<string> list = new List<string>();

		public void AddItem() {
			list.Add(new Bogus.DataSets.Hacker().Noun());
		}

		public void RemoveItem() { 
			list.RemoveAt(0);
		}
	}
}
