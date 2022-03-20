using API.Data.Entities;
using API.Models;
using API.Models.Dtos;
using API.Services.BookService;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/book/[controller]")]
// [Authorize(Roles = "admin")]
public class BookController : ControllerBase
{

    private readonly IMapper _mapper;
    private readonly ILogger<BookController> _logger;
    private readonly IBookService _bookService;

    public BookController(ILogger<BookController> logger, IBookService bookService, IMapper mapper)
    {
        _logger = logger;
        _bookService = bookService;
        _mapper = mapper;
    }

    [HttpGet, AllowAnonymous]
    public async Task<IActionResult> GetAllAsync()
    {
        var entities = await _bookService.GetAllAsync();

        var entitiesDto = new List<BookViewDto>();
        foreach (var entity in entities){
            entitiesDto.Add(_mapper.Map<BookViewDto>(entity));
        }
        return new JsonResult(entitiesDto);
    }

    [HttpGet("category/{Name}")]
    public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBooksByCategory(string Name)
    {
        var result = await _bookService.GetBooksByCategory(Name);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] BookCreateDto model)
    {
        try
        {

            var bookEntity = _mapper.Map<Book>(model);
            var result = await _bookService.AddAsync(bookEntity);
             return CreatedAtRoute("GetOneAsync", new { id= bookEntity.Id }, bookEntity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

    }

    [HttpGet("{id}", Name ="GetOneAsync")]
    public async Task<IActionResult> GetOneAsync(int id)
    {
        var entity = await _bookService.GetOneAsync(id);
        if(entity == null)
        {
            return NotFound();
        }
        var entityDto = _mapper.Map<BookViewDto>(entity);
        return new JsonResult(entityDto);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> EditAsync(int id, BookEditDto model)
    {
        try
        {

            var bookEntity = _mapper.Map<Book>(model);
            var result = await _bookService.EditAsync(bookEntity);
            return  new JsonResult(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]

    public async Task<IActionResult> RemoveAsync(int id)
    {
        var entity = await _bookService.GetOneAsync(id);
        if (entity == null) return NotFound();

        await _bookService.RemoveAsync(id, entity);
        return Ok();
    }
}
