using Microsoft.AspNetCore.Mvc;

namespace GabrielAreiaAPI.Controllers
{
    public interface IResumeItemsController<T, TApi> where T : class
    {
        public IActionResult GetItem(int id);
        public IActionResult GetFullItem(int id);

        public IActionResult PostItems([FromBody] T item);

        public TApi[] SelectItems(int matchId);
        public T[] SelectFullItems(int matchId);
        public T[] InsertItems(params T[] items);
    }
}
