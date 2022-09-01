using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.Business.Interfaces;
using TodoApp.Common.Responses;
using TodoApp.DTOs.WorkDtos;
using TodoApp.UI.Extensions;
using TodoApp.UI.Models;

namespace TodoApp.UI.Controllers;

public class HomeController : Controller
{
    private readonly IWorkService _workService;
    
    public HomeController(IWorkService workService)
    {
        _workService = workService;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _workService.GetAll();
        return View(response.Data);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new WorkCreateDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(WorkCreateDto dto)
    {
        var response = await _workService.Create(dto);
        return this.ResponseRedirectToAction(response, "Index");
    }

    public async Task<IActionResult> Update(string id)
    {
        var response = await _workService.GetById<WorkUpdateDto>(id , false);
        return this.ResponseView(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(WorkUpdateDto dto)
    {
        var response = await _workService.Update(dto);
        return this.ResponseRedirectToAction(response, "Index");
    }

    public async Task<IActionResult> Delete(string id)
    {
        var response = await _workService.RemoveAsync(id);
        return this.ResponseRedirectToAction(response, "Index");
    }

    public IActionResult NotFound(int code)
    {
        return View();
    }
    
}