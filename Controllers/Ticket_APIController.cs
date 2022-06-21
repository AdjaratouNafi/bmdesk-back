using BMSDesk_CLI_API.Logic;
using BMSDesk_CLI_API.Model;
using BMSDesk_CLI_API.Hubs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using BMSDesk_CLI_API.Web.Helpers;
using Microsoft.AspNetCore.SignalR;

namespace BMSDesk_CLI_API.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private IHubContext<AppHub> HubContext;
        private static IConfiguration _config;
        public TicketController(IHttpContextAccessor accessor, IConfiguration config, IHubContext<AppHub> hubcontext)
        {
            _config = config;
            var helper = new HtmlHelpers.ClaimsModelService(accessor, config);
            HubContext = hubcontext;
        }

        [HttpPost]
        public List<Ticket_Model> Get_Ticket_List(dynamic obj)
        {
            var res = Ticket_Manager.Get_Ticket_List((bool)obj.Is_Agent, (bool)obj.Is_Client, ClaimsModel.UserId);
            return res;
        }
        [HttpPost]
        public Ticket_Model Get_Ticket_ByID(dynamic obj)
        {
            var res = Ticket_Manager.Get_Ticket_ByID((long)obj.TicketID, (string)obj.DisplayTicketID);
            return res;
        }
        [HttpPost]
        public Tuple<long, string> Ticket_Create(dynamic obj)
        {
            var res = Ticket_Manager.Ticket_Create(obj.model.ToObject<Ticket_Model>(), obj.attachment.ToObject<List<File_Attachments>>(), ClaimsModel.UserId);
            return res;
        }
        [HttpPost]
        public Tuple<long, string> Ticket_Update(dynamic obj)
        {
            var res = Ticket_Manager.Ticket_Update(obj.model.ToObject<Ticket_Model>(), obj.attachment.ToObject<List<File_Attachments>>(), ClaimsModel.UserId);
            return res;
        }
        [HttpPost]
        public Tuple<long, string> Ticket_Clone(dynamic obj)
        {
            var res = Ticket_Manager.Ticket_Clone((long)obj.TicketID);
            return res;
        }
        [HttpPost]
        public long Ticket_Delete(dynamic obj)
        {
            var res = Ticket_Manager.Ticket_Delete((string)obj.TicketIDs);
            return res;
        }
        [HttpPost]
        public Common_Ticket_Detail_Model Get_Ticket_Detail_Data(dynamic obj)
        {
            var res = Ticket_Manager.Get_Common_Ticket_Detail_Data((bool)obj.Is_Agent);
            return res;
        }
        [HttpPost]
        public int Ticket_AssignTo_Update(dynamic obj)
        {
            var res = Ticket_Manager.Ticket_AssignTo_Update(obj.lstTicket.ToObject<List<Ticket_Model>>(), obj.objUser.ToObject<AssignUser_Model>());
            return res;
        }

        [HttpPost]
        public int Ticket_Status_Update(dynamic obj)
        {
            var res = Ticket_Manager.Ticket_Status_Update(obj.lstTicket.ToObject<List<Ticket_Model>>(), (long)obj.StatusID, (long)obj.TicketCloseModeID, (string)obj.StatusCloseReason);
            return res;
        }
        //[HttpPost]
        //public string Export_Tickets(dynamic obj)
        //{
        //    var res = Ticket_Manager.Export_Tickets(obj.model.ToObject<List<Ticket_Model_Export>>(), obj.resource.ToObject<List<string>>(), (string)obj.Type);
        //    return res;
        //}
        [HttpPost]
        public long Set_Ticket_FCR(dynamic obj)
        {
            var res = Ticket_Manager.Set_Ticket_FCR((long)obj.TicketID, (bool)obj.Is_FCR);
            return res;
        }

        #region TicketAttachment
        [HttpPost]
        public List<TicketAttachment_Model> Get_TicketAttachment_ByID(dynamic obj)
        {
            var res = Ticket_Manager.Get_TicketAttachment_ByID((long)obj.TicketID);
            return res;
        }
        [HttpPost]
        public int TicketAttachment_Delete(dynamic obj)
        {
            var res = Ticket_Manager.TicketAttachment_Delete((long)obj.TicketAttachmentID, (string)obj.FileName);
            return res;
        }
        #endregion

        #region Requester Ticket
        [HttpPost]
        public Tuple<long, string> Ticket_Requester_Create(dynamic obj)
        {
            var res = Ticket_Manager.Ticket_Requester_Create(obj.model.ToObject<Ticket_Model>(), obj.attachment.ToObject<List<File_Attachments>>(), ClaimsModel.UserId, ClaimsModel.UserName, ClaimsModel.Email);
            return res;
        }
        [HttpPost]
        public Tuple<long, string> Ticket_Requester_Update(dynamic obj)
        {
            var res = Ticket_Manager.Ticket_Requester_Update(obj.model.ToObject<Ticket_Model>(), obj.attachment.ToObject<List<File_Attachments>>(), ClaimsModel.UserId);
            return res;
        }
        #endregion

        #region Ticket Chat
        [HttpPost]
        public List<TicketChat_Model> Get_TicketChat(dynamic obj)
        {
            return Ticket_Manager.Get_TicketChat((long)obj.TicketID);
        }
        [HttpPost]
        public TicketChat_Model Get_TicketChat_ByID(dynamic obj)
        {
            return Ticket_Manager.Get_TicketChat_ByID((long)obj.TicketChatID);
        }
        [HttpPost]
        public long TicketChat_Update(dynamic obj)
        {
            var model = obj.model.ToObject<TicketChat_Model>();
            var res = Ticket_Manager.TicketChat_Update(model);
            if (res > 0)
            {
                var item = Ticket_Manager.Get_TicketChat_ByID(res);
                this.Update_TicketChat_Refresh(item);
            }
            return res;
        }
        [HttpPost]
        public long TicketChat_Delete(dynamic obj)
        {
            var TicketChatID = obj.TicketChatID == null ? 0 : (long)obj.TicketChatID;
            var res = Ticket_Manager.TicketChat_Delete(TicketChatID);
            return res;
        }
        #endregion

        public void Update_TicketChat_Refresh(TicketChat_Model item)
        {
            try
            {
                this.HubContext.Clients.All.SendAsync("Get_TicketChat_Refresh", item);
            }
            catch (Exception) { }
        }

    }

}