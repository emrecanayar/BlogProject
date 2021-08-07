using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Business.Abstract;
using ProgrammersBlog.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.MVC.ViewComponents
{
    public class RightSideBarViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;

        public RightSideBarViewComponent(ICategoryService categoryService, IArticleService articleService)
        {
            _categoryService = categoryService;
            _articleService = articleService;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoriesResult = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            var articleResult = await _articleService.GetAllByViewCountAsync(isAscending: false, takeSize: 5);

            return View(new RightSideBarViewModel
            {
                Categories = categoriesResult.Data.Categories,
                Articles = articleResult.Data.Articles
            });
        }
    }
}
