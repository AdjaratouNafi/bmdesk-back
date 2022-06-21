using BMSDesk_CLI_API.Logic;
using BMSDesk_CLI_API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using BMSDesk_CLI_API.Web.Helpers;

namespace BMSDesk_CLI_API.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private static IConfiguration _config;
        public SummaryController(IHttpContextAccessor accessor, IConfiguration config)
        {
            _config = config;
            var helper = new HtmlHelpers.ClaimsModelService(accessor, config);
        }

        [HttpPost]
        public List<TicketCount_ByType_Model> Get_TicketCount_ByType(dynamic obj)
        {
            var res = Summary_Manager.Get_TicketCount_ByType((bool)obj.Is_Agent, (bool)obj.Is_Client, (string)obj.Type, ClaimsModel.UserId, (string)obj.FromDate, (string)obj.ToDate);
            return res;
        }
        [HttpPost]
        public List<TicketCount_ByType_Model> Get_TicketSummary_ByType(dynamic obj)
        {
            var res = Summary_Manager.Get_TicketSummary_ByType((bool)obj.Is_Agent, (bool)obj.Is_Client, (string)obj.Type, ClaimsModel.UserId);
            return res;
        }
        [HttpPost]
        public List<TicketReceived_ByDays_Model> Get_TicketReceived_ByDays(dynamic obj)
        {
            var res = Summary_Manager.Get_TicketReceived_ByDays((bool)obj.Is_Agent, (bool)obj.Is_Client, (string)obj.Type, (int)obj.Days, ClaimsModel.UserId);
            return res;
        }
        [HttpPost]
        public List<TicketReceived_ByDays_Model> Get_TicketClosed_ByDays(dynamic obj)
        {
            var res = Summary_Manager.Get_TicketReceived_ByDays((bool)obj.Is_Agent, (bool)obj.Is_Client, (string)obj.Type, (int)obj.Days, ClaimsModel.UserId);
            return res;
        }
        [HttpPost]
        public List<TicketCount_ByType_Model> Get_OpenTicket_ByType(dynamic obj)
        {
            var res = Summary_Manager.Get_OpenTicket_ByType((bool)obj.Is_Agent, (bool)obj.Is_Client, (string)obj.Type, ClaimsModel.UserId, (string)obj.FromDate, (string)obj.ToDate);
            return res;
        }
    }
}