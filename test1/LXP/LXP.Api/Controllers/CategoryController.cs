﻿using Google.Protobuf.Reflection;
using LXP.Common.Constants;
using LXP.Common.ViewModels;
using LXP.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LXP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    ///<summary>
    ///Category of the course
    ///</summary>
    public class CategoryController : BaseController
    {
        private readonly ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        ///<summary>
        ///getting all category name and its id
        ///</summary>
        ///<response code="200">Success</response>
        ///<response code="500">Internal server Error</response>
        [HttpGet("/lxp/course/category")]
        public async Task<IActionResult> GetAllCategory()
        {
            List<CourseCategoryListViewModel> categories = await _categoryServices.GetAllCategory();
            return Ok(CreateSuccessResponse(categories));
        }
        ///<summary>
        ///adding new category
        ///</summary>
        ///<response code="200">Success</response>
        ///<response code="422">Sourse is already exists</response>
        ///<response code="500">Internal server Error</response>
        [HttpPost("/lxp/course/category")]
        public async Task<IActionResult> AddCategory(CourseCategoryViewModel category)
        {
            bool isCategoryCreated = await _categoryServices.AddCategory(category);
            if (isCategoryCreated)
            {
                CourseCategoryListViewModel categories = await _categoryServices.GetCategoryByCategoryName(category.Category);
                return Ok(CreateInsertResponse(categories));
            }
            else
            {
                return Ok(CreateFailureResponse(MessageConstants.MsgAlreadyExists, (int)HttpStatusCode.PreconditionFailed));
            }
        }

    }
}
