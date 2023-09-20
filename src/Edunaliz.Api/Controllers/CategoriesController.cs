using Edunaliz.Api.Models;
using Edunaliz.Service.DTOs;
using Edunaliz.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Edunaliz.Api.Controllers;

public class CategoriesController : BaseController
{
    private readonly ICategoryService categoryService;
    public CategoriesController(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> PostAsync(CategoryCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.categoryService.CreateAsync(dto)
        });


    [HttpPut("update")]
    public async ValueTask<IActionResult> PutAsync(CategoryUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.categoryService.UpdateAsync(dto)
        });


    [HttpDelete("delete/{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.categoryService.DeleteAsync(id)
        });


    [HttpGet("get/{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.categoryService.GetAsync(id)
        });


    [HttpGet("get-all")]
    public async ValueTask<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.categoryService.GetAllAsync()
        });
}
