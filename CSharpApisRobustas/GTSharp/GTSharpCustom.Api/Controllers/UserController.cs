using GTSharp.Domain.Arguments.User;
using GTSharp.Domain.Interfaces.Services;
using GTSharp.Infra.Transactions;
using GTSharpCustom.Api.Controllers.Base;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace GTSharpCustom.Api.Controllers
{
    //custom.com.br/api/user
    [RoutePrefix("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IServiceUser _serviceUser;

        public UserController(UnitOfWork unitOfWork, IServiceUser serviceUser) : base(unitOfWork)
        {
            _serviceUser = serviceUser;
        }

        [Route("add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(AddUserRequest request)
        {
            try
            {
                var response = _serviceUser.AddUser(request);

                return await ResponseAsync(response, _serviceUser);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Update")]
        [HttpPut]
        public async Task<HttpResponseMessage> Update(UpdateUserRequest request)
        {
            try
            {
                var response = _serviceUser.UpdateUser(request);

                return await ResponseAsync(response, _serviceUser);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Authorize]
        [Route("Delete")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                var response = _serviceUser.RemoveUser(id);

                return await ResponseAsync(response, _serviceUser);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("List")]
        [HttpGet]
        public async Task<HttpResponseMessage> List()
        {
            try
            {
                var response = _serviceUser.UserList();

                return await ResponseAsync(response, _serviceUser);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}