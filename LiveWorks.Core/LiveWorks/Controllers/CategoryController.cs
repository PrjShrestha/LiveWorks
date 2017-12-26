//using System;
//using AutoMapper;
//using LiveWorks.Core.Models;
//using LiveWorks.Core.UniOfWork;
//using LiveWorks.EntityDto;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;

//namespace LiveWorksWeb.Controllers
//{
//    [Route("api/[controller]")]
//    public class CategoryController : Controller 
//    {
//        protected readonly ILogger<CategoryController> _logger;
//        protected readonly InventoryUnitOfWork _unitOfWork;
//        protected readonly IMapper _mapper;

//        public CategoryController(InventoryUnitOfWork unitOfwork, ILogger<CategoryController> logger, IMapper mapper)
//        {
//            _unitOfWork = unitOfwork;
//            _logger = logger;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public virtual IActionResult Get()
//        {
//            try
//            {
//                var entities = _unitOfWork.CategoryRepository.GetAll();

//                return Ok(entities);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Failed to list all entities [Categorys] from catalog.\n {ex}");
//            }

//            return BadRequest($"Failed to list all entities [Categorys] from catalog.");
//        }

//        [HttpGet("{id}")]
//        public virtual IActionResult Get(int id)
//        {
//            try
//            {
//                var entity = _unitOfWork.CategoryRepository.Get(id);
//                return Ok(entity);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Failed to find a Categorys with the id: {id}.\n {ex}");
//            }

//            return BadRequest($"Failed to find a Categorys with the id: {id}.");
//        }

//        [HttpPost]
//        public virtual IActionResult Post([FromBody]CategoryDto model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            try
//            {
//                var Category = _mapper.Map<Category>(model);
//                _unitOfWork.CategoryRepository.Add(Category);
//                _unitOfWork.Commit();
//                return Created(Request.Path.Value, model);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Error adding new Categorys. \n {ex}");
//            }

//            return BadRequest($"Error adding new Categorys.");
//        }

//        [HttpPut]
//        public virtual IActionResult Put([FromBody]CategoryDto model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            try
//            {
//                var Category = _mapper.Map<Category>(model);
//                _unitOfWork.CategoryRepository.Update(Category);
//                _unitOfWork.Commit();
//                return Ok("Successfully Updated.");
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Error updating Categorys with id: {model.Id}.\n {ex}");
//            }

//            return BadRequest($"Error updating Categorys with id: {model.Id}.");
//        }

//        [HttpDelete("{id}")]
//        public virtual IActionResult Delete(int id)
//        {
//            try
//            {
//                _unitOfWork.CategoryRepository.Remove(id);
//                _unitOfWork.Commit();
//                return Ok("Successfully Deleted.");
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Error deleting Categorys with id: {id}.\n {ex}");
//            }

//            return BadRequest($"Error deleting Categorys with id: {id}.");
//        }
//    }
//}