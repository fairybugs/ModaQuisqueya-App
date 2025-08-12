using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ModaQuisqueya.Application.Core
{
    public interface IServiceResult
    {
        bool Success { get; set; }
        string Message { get; set; }
    }
}
