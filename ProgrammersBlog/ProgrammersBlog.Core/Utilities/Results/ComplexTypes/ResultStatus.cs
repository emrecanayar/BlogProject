using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Core.Utilities.Results.ComplexTypes
{
    public enum ResultStatus
    {
        Success = 0,
        Error = 1,
        Warning = 2, //ResultStatus.Warning
        Info = 3,    //ResultStatus.Info
        Authentication = 4,
        Authorization = 5,
    }
}
