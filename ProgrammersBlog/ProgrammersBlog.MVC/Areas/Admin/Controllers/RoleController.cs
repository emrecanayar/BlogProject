using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Core.Utilities.Extensions;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.MVC.Areas.Admin.Models;
using ProgrammersBlog.MVC.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProgrammersBlog.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : BaseController
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleController(RoleManager<Role> roleManager, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper) : base(userManager, mapper, imageHelper)
        {
            _roleManager = roleManager;
        }
        [HttpGet]
        [Authorize(Roles = "SuperAdmin,Role.Read")]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return View(new RoleListDto
            {

                Roles = roles,

            });
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin,Role.Read")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            var rolesListDto = JsonSerializer.Serialize(new RoleListDto
            {

                Roles = roles,
            });

            return Json(rolesListDto);
        }
        [Authorize(Roles = "SuperAdmin,User.Update")]
        [HttpGet]
        public async Task<IActionResult> Assign(int userId)
        {
            var user = await UserManager.Users.SingleOrDefaultAsync(u => u.Id == userId);
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await UserManager.GetRolesAsync(user);
            UserRoleAssignDto userRoleAssignDto = new UserRoleAssignDto
            {

                UserId = user.Id,
                UserName = user.UserName,
            };
            foreach (var role in roles)
            {
                RoleAssignDto roleAssignDto = new RoleAssignDto
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    HasRole = userRoles.Contains(role.Name),
                };

                userRoleAssignDto.RoleAssignDtos.Add(roleAssignDto);
            }

            return PartialView("_RoleAssignPartial", userRoleAssignDto);
        }

        [Authorize(Roles = "SuperAdmin,User.Update")]
        [HttpPost]
        public async Task<IActionResult> Assign(UserRoleAssignDto userRoleAssignDto)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.Users.SingleOrDefaultAsync(u => u.Id == userRoleAssignDto.UserId);

                foreach (var roleAssignDto in userRoleAssignDto.RoleAssignDtos)
                {
                    if (roleAssignDto.HasRole)
                        await UserManager.AddToRoleAsync(user, roleAssignDto.RoleName);
                    else
                    {
                        await UserManager.RemoveFromRoleAsync(user, roleAssignDto.RoleName);
                    }

                }

                await UserManager.UpdateSecurityStampAsync(user);

                var userRoleAssignAjaxViewModel = JsonSerializer.Serialize(new UserRoleAssignAjaxViewModel
                {
                    UserDto = new UserDto
                    {
                        User = user,
                        Message = $"{user.UserName} kullanıcısına ait rol atama işlemi başarıyla tamamlanmıştır.",
                        ResultStatus = Core.Utilities.Results.ComplexTypes.ResultStatus.Success
                    },
                    RoleAssignPartial = await this.RenderViewToStringAsync("_RoleAssignPartial", userRoleAssignDto)
                });

                return Json(userRoleAssignAjaxViewModel);
            }
            else
            {
                var userRoleAssignAjaxErrorModel = JsonSerializer.Serialize(new UserRoleAssignAjaxViewModel
                {

                    RoleAssignPartial = await this.RenderViewToStringAsync("_RoleAssignPartial", userRoleAssignDto),
                    UserRoleAssignDto = userRoleAssignDto
                });

                return Json(userRoleAssignAjaxErrorModel);
            }

        }
    }
}
