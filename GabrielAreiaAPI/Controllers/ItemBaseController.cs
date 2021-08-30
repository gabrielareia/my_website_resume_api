using Microsoft.AspNetCore.Mvc;
using System;
using GabrielAreiaAPI.ResumeDb;
using Microsoft.AspNetCore.Authorization;

namespace GabrielAreiaAPI.Controllers
{
    public class ItemBaseController<T, TApi> : ControllerBase, IResumeItemsController<T, TApi> where T : class
    {

        protected readonly IRepository<T> _itemsRepo;

        public ItemBaseController(IRepository<T> itemsRepo)
        {
            _itemsRepo = itemsRepo;
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var resultItems = SelectItems(id);

            if (resultItems == null || resultItems.Length == 0)
                return BadRequest("The id was not found");

            return Ok(resultItems);
        }

        [HttpGet("full/{id}")]
        public IActionResult GetFullItem(int id)
        {
            var resultItems = SelectFullItems(id);

            if (resultItems == null || resultItems.Length == 0)
                return BadRequest("The id was not found");

            return Ok(resultItems);
        }

        [Authorize]
        [HttpPost]
        public IActionResult PostItems([FromBody] T item)
        {
            if (ModelState.IsValid)
            {
                T[] resultItems = InsertItems(item);
                return Ok(resultItems);
            }

            return BadRequest("Somethig was wrong in the request.");
        }

        [Authorize]
        [HttpPut]
        public IActionResult PutItems([FromBody] T item)
        {
            if (ModelState.IsValid)
            {
                _itemsRepo.Update(item);
                return Ok(item);
            }

            return BadRequest("Somethig was wrong in the request.");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteItems(int id)
        {
            T item = _itemsRepo.Find(id);
            if (ModelState.IsValid)
            {
                _itemsRepo.Delete(item);
                return Ok(item);
            }

            return BadRequest("Somethig was wrong in the request.");
        }

        [NonAction]
        public virtual TApi[] SelectItems(int matchId)
        {
            throw new NotImplementedException();
        }

        [NonAction]
        public virtual T[] SelectFullItems(int matchId)
        {
            throw new NotImplementedException();
        }

        [NonAction]
        public virtual T[] InsertItems(params T[] items)
        {
            _itemsRepo.Insert(items);
            return items;
        }
    }
}
