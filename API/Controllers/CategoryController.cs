using API.Models;
using API.Models.Dtos;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/category/[controller]")]
// [Authorize(Roles = "admin")]
public class CategoryController : ControllerBase
{

    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    
    public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService, IMapper mapper)
    {
        _logger = logger;
        _categoryService = categoryService;
        _mapper = mapper;
    }

    [HttpGet, AllowAnonymous]
    public async Task<IActionResult> GetAllAsync()
    {
        var entities = await _categoryService.GetAllAsync();
        var results = from item in entities
                      select new CategoryViewModel
                      {
                          Id = item.Id,
                          Name = item.Name,
                          Books = from p in item.Books
                                  select new BookViewDto
                                  {
                                      Id = p.Id,
                                      Name = p.Name,
                                      Author = p.Author,
                                      Summary = p.Summary
                                  }
                      };
        return new JsonResult(results);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CategoryCreateModel model)
    {
        try
        {
            var entity = new Data.Entities.Category
            {
                Name = model.Name,
                Books = (from p in model.Books
                         select new Data.Entities.Book
                         {
                             Name = p.Name,
                         }).ToList()
            };

            var result = await _categoryService.AddAsync(entity);
            return new JsonResult(new CategoryViewModel
            {
                Id = result.Id,
                Name = result.Name,
                Books = from p in result.Books
                        select new BookViewDto
                        {
                            Id = p.Id,
                            Name = p.Name,
                        }
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOneAsync(int id)
    {
        var entity = await _categoryService.GetOneAsync(id);
        return new JsonResult(entity);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> EditAsync(int id, CategoryEditModel model)
    {
        var entity = await _categoryService.GetOneAsync(id);

        entity.Name = model.Name;

        var result = await _categoryService.EditAsync(entity);
        return new JsonResult(new CategoryEditModel
        {
            Name = result.Name
        });
    }

    [HttpDelete]
    [Route("{id}")]

    public async Task<IActionResult> RemoveAsync(int id)
    {
        var entity = await _categoryService.GetOneAsync(id);
        if (entity == null) return NotFound();

        await _categoryService.RemoveAsync(id, entity);
        return Ok();
    }
}
