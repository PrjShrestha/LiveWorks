using System;
using AutoMapper;
using LiveWorks.Core.Models;
using LiveWorks.Core.UniOfWork;
using LiveWorks.EntityDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LiveWorksWeb.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        protected readonly ILogger<ClientController> _logger;
        protected readonly InventoryUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public ClientController(InventoryUnitOfWork unitOfwork, ILogger<ClientController> logger, IMapper mapper)
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
                var entities = _unitOfWork.ClientRepository.GetAll();

                return Ok(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to list all entities [Clients] from catalog.\n {ex}");
            }

            return BadRequest($"Failed to list all entities [Clients] from catalog.");
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            try
            {
                var entity = _unitOfWork.ClientRepository.Get(id);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to find a Clients with the id: {id}.\n {ex}");
            }

            return BadRequest($"Failed to find a Clients with the id: {id}.");
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody]ClientDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var Client = _mapper.Map<Client>(model);
                _unitOfWork.ClientRepository.Add(Client);
                _unitOfWork.Commit();
                return Created(Request.Path.Value, model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding new Clients. \n {ex}");
            }

            return BadRequest($"Error adding new Clients.");
        }

        [HttpPut]
        public virtual IActionResult Put([FromBody]ClientDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var Client = _mapper.Map<Client>(model);
                _unitOfWork.ClientRepository.Update(Client);
                _unitOfWork.Commit();
                return Ok("Successfully Updated.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating Clients with id: {model.Id}.\n {ex}");
            }

            return BadRequest($"Error updating Clients with id: {model.Id}.");
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            try
            {
                _unitOfWork.ClientRepository.Remove(id);
                _unitOfWork.Commit();
                return Ok("Successfully Deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting Clients with id: {id}.\n {ex}");
            }

            return BadRequest($"Error deleting Clients with id: {id}.");
        }
    }
}