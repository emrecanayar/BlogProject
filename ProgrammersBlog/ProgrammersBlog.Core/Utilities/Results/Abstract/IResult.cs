using ProgrammersBlog.Core.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;
using ProgrammersBlog.Core.Entities.Concrete;


namespace ProgrammersBlog.Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }  //ResultStatus.Success //ResultStatus.Error
        public string Message { get; }
        public Exception Exception { get; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; }
    }


}
