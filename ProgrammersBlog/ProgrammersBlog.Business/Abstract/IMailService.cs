using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Core.Utilities.Results.Abstract;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Business.Abstract
{
    public interface IMailService
    {
        IResult Send(EmailSendDto emailSendDto);
        IResult SendContactEmail(EmailSendDto emailSendDto);
    }
}
