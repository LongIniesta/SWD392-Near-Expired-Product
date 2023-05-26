using NearExpiredProduct.Data.Models;
using NTQ.Sdk.Core.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearExpiredProduct.Service.InterfaceService
{
    public interface IMemberService
    {
        Task<BaseResponseViewModel<List<Member>>> GetMembers();
    }
}
