using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Business.Abstract;
using ProgrammersBlog.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.MVC.Attributes;


namespace ProgrammersBlog.MVC.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ArticleRightSideBarWidgetOptions _articleRightSideBarWidgetOptions;
        public ArticleController(IArticleService articleService, IOptionsSnapshot<ArticleRightSideBarWidgetOptions> articleRightSideBarWidgetOptions)
        {
            _articleService = articleService;
            _articleRightSideBarWidgetOptions = articleRightSideBarWidgetOptions.Value;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            var searchResult = await _articleService.SearchAsync(keyword, currentPage, pageSize, isAscending);
            if (searchResult.ResultStatus == Core.Utilities.Results.ComplexTypes.ResultStatus.Success)
            {
                return View(new ArticleSearchViewModel
                {
                    ArticleListDto = searchResult.Data,
                    Keyword = keyword,
                });
            }
            return NotFound();
        }

        [HttpGet]
        [ViewCountFilter]
        public async Task<IActionResult> Detail(int articleId)
        {
            var articleResult = await _articleService.GetAsync(articleId);
            if (articleResult.ResultStatus == Core.Utilities.Results.ComplexTypes.ResultStatus.Success)
            {
                var userArticles = await _articleService.GetAllByUserIdOnFilter(articleResult.Data.Article.UserId,
                    _articleRightSideBarWidgetOptions.FilterBy, _articleRightSideBarWidgetOptions.OrderBy, _articleRightSideBarWidgetOptions.IsAscending, _articleRightSideBarWidgetOptions.TakeSize, _articleRightSideBarWidgetOptions.CategoryId, _articleRightSideBarWidgetOptions.StartAt,
                    _articleRightSideBarWidgetOptions.EndAt, _articleRightSideBarWidgetOptions.MinViewCount, _articleRightSideBarWidgetOptions.MaxViewCount, _articleRightSideBarWidgetOptions.MinCommentCount, _articleRightSideBarWidgetOptions.MaxCommentCount);
                //await _articleService.IncreaseViewCountAsync(articleId);
                return View(new ArticleDetailViewModel
                {
                    ArticleDto = articleResult.Data,
                    ArticleDetailRightSideBarViewModel = new ArticleDetailRightSideBarViewModel
                    {
                        ArticleListDto = userArticles.Data,
                        Header = _articleRightSideBarWidgetOptions.Header,
                        User = articleResult.Data.Article.User
                    }
                });
            }

            return NotFound();
        }
    }
}
