using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;
using NearExpiredProduct.Data.UnitOfWork;
using NearExpiredProduct.Service.Exceptions;
using NTQ.Sdk.Core.CustomModel;
using NearExpiredProduct.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Member = NearExpiredProduct.Data.Models.Member;
using NearExpiredProduct.Service.InterfaceService;

namespace NearExpiredProduct.Service.ImplService
{
    public class MemberService:IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponseViewModel<List<Member>>> GetMembers()
        {
            try
            {
                var list = _unitOfWork.Repository<Member>().GetAll().ToList();
                return new BaseResponseViewModel<List<Member>>()
                {
                    Status = new StatusViewModel()
                    {
                        Message = "Sucess",
                        Success = true,
                        ErrorCode = 0
                    },
                    Data = list
                };
            }

            catch (Exception e)
            {

                throw new CrudException(HttpStatusCode.BadRequest, "Get Members Error!!!", e.InnerException?.Message);
            }
        }
    }
}
