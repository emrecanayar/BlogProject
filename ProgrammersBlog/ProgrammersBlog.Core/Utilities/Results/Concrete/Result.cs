using ProgrammersBlog.Core.Utilities.Results.Abstract;
using ProgrammersBlog.Core.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;
using ProgrammersBlog.Core.Entities.Concrete;

namespace ProgrammersBlog.Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;

        }
        public Result(ResultStatus resultStatus, IEnumerable<ValidationError> validationErrors)
        {
            ResultStatus = resultStatus;
            ValidationErrors = validationErrors;

        }
        public Result(ResultStatus resultStatus, string messages)
        {
            ResultStatus = resultStatus;
            Message = messages;
        }
        public Result(ResultStatus resultStatus, string messages, IEnumerable<ValidationError> validationErrors)
        {
            ResultStatus = resultStatus;
            Message = messages;
            ValidationErrors = validationErrors;

        }
        public Result(ResultStatus resultStatus, string messages, Exception exception)
        {
            ResultStatus = resultStatus;
            Message = messages;
            Exception = exception;
        }
        public Result(ResultStatus resultStatus, string messages, Exception exception, IEnumerable<ValidationError> validationErrors)
        {
            ResultStatus = resultStatus;
            Message = messages;
            Exception = exception;
            ValidationErrors = validationErrors;
        }
        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        //Kullanım şekli -> new Result(ResultStatus.Error,exception.message,exception)
    }
}
