using System;
using System.Collections.Generic;
using AutoMapper;
using LiveWorks.Core.Models;
using LiveWorks.Core.UniOfWork;
using LiveWorks.EntityDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LiveWorksWeb.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller 
    {
        protected readonly ILogger<ItemController> _logger;
        protected readonly InventoryUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public ItemController(InventoryUnitOfWork unitOfwork, ILogger<ItemController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfwork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            try                
            {
                var entities = _unitOfWork.ItemRepository.GetAll();
                var ItemDtoEntities = Mapper.Map<IEnumerable<Item>, IEnumerable<ItemDto>>(entities);
                return Ok(ItemDtoEntities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to list all entities [Items] from catalog.\n {ex}");
            }

            return BadRequest($"Failed to list all entities [Items] from catalog.");
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            try
            {
                var entity = _unitOfWork.ItemRepository.Get(id);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to find a Items with the id: {id}.\n {ex}");
            }

            return BadRequest($"Failed to find a Items with the id: {id}.");
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody]ItemDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var item = _mapper.Map<Item>(model);
                _unitOfWork.ItemRepository.Add(item);
                _unitOfWork.Commit();
                return Created(Request.Path.Value, model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding new Items. \n {ex}");
            }

            return BadRequest($"Error adding new Items.");
        }

        [HttpPut]
        public virtual IActionResult Put([FromBody]ItemDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var item = _mapper.Map<Item>(model);
                _unitOfWork.ItemRepository.Update(item);
                _unitOfWork.Commit();
                return Created(Request.Path.Value, model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating Items with id: {model.Id}.\n {ex}");
            }

            return BadRequest($"Error updating Items with id: {model.Id}.");
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            try
            {
                _unitOfWork.ItemRepository.Remove(id);
                _unitOfWork.Commit();
                return Ok("Successfully Deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting Items with id: {id}.\n {ex}");
            }

            return BadRequest($"Error deleting Items with id: {id}.");
        }
    }
}