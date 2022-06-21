using BMSDesk_CLI_API.Logic;
using BMSDesk_CLI_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using BMSDesk_CLI_API.Web.Helpers;

namespace BMSDesk_CLI_API.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private static IConfiguration _config;
        public DashboardController(IHttpContextAccessor accessor, IConfiguration config)
        {
            _config = config;
            var helper = new HtmlHelpers.ClaimsModelService(accessor, config);
        }

        [HttpPost]
        public Dashboard_Summary_Model Get_Dashboard_Summary(dynamic obj)
        {
            var res = Ticket_Manager.Get_Dashboard_Summary((bool)obj.Is_Agent, (bool)obj.Is_Client, ClaimsModel.UserId);
            return res;
        }

        [HttpPost]
        public Description_Model Get_DescriptionByID(dynamic obj)
        {
            var res = Ticket_Manager.Get_DescriptionByID((string)obj.ModuleType, (string)obj.ID);
            return res;
        }

    }
}