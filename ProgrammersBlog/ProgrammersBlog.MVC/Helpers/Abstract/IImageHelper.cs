using Microsoft.AspNetCore.Http;
using ProgrammersBlog.Core.Utilities.Results.Abstract;
using ProgrammersBlog.Entites.ComplexTypes;
using ProgrammersBlog.Entites.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.MVC.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<ImageUplodedDto>> Upload(string name, IFormFile pictureFile, PictureType pictureType, string folderName = null);
        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}
