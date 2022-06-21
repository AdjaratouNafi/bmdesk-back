using BMSDesk_CLI_API.Logic;
using BMSDesk_CLI_API.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using BMSDesk_CLI_API.Web.Helpers;

namespace BMSDesk_CLI_API.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SolutionController : ControllerBase
    {
        private static IConfiguration _config;
        public SolutionController(IHttpContextAccessor accessor, IConfiguration config)
        {
            _config = config;
            var helper = new HtmlHelpers.ClaimsModelService(accessor, config);
        }

        [HttpPost]
        public List<Solution_Model> Get_Solution_List(dynamic obj)
        {
            var res = Solution_Manager.Get_Solution_List((bool)obj.Is_Agent, ClaimsModel.UserId);
            return res;
        }
        [HttpPost]
        public Solution_Model Get_Solution_ByID(dynamic obj)
        {
            var res = Solution_Manager.Get_Solution_ByID((long)obj.SolutionID, (string)obj.DisplaySolutionID);
            return res;
        }
        [HttpPost]
        public Tuple<long, string> Solution_Update(dynamic obj)
        {
            var res = Solution_Manager.Solution_Update(obj.model.ToObject<Solution_Model>(), obj.attachment.ToObject<List<File_Attachments>>(), ClaimsModel.UserId);
            return res;
        }
        [HttpPost]
        public Tuple<long, string> Solution_Clone(dynamic obj)
        {
            var res = Solution_Manager.Solution_Clone((long)obj.SolutionID);
            return res;
        }
        [HttpPost]
        public long Solution_Delete(dynamic obj)
        {
            var res = Solution_Manager.Solution_Delete((string)obj.SolutionIDs);
            return res;
        }
        [HttpPost]
        public Common_Solution_Detail_Model Get_Solution_Detail_Data()
        {
            var res = Solution_Manager.Get_Common_Solution_Detail_Data();
            return res;
        }
        //[HttpPost]
        //public string Export_Solutions(dynamic obj)
        //{
        //    var res = Solution_Manager.Export_Solutions(obj.model.ToObject<List<Solution_Model_Export>>(), obj.resource.ToObject<List<string>>(), (string)obj.Type);
        //    return res;
        //}


        #region SolutionAttachment
        [HttpPost]
        public List<SolutionAttachment_Model> Get_SolutionAttachment_ByID(dynamic obj)
        {
            var res = Solution_Manager.Get_SolutionAttachment_ByID((long)obj.SolutionID);
            return res;
        }
        [HttpPost]
        public int SolutionAttachment_Delete(dynamic obj)
        {
            var res = Solution_Manager.SolutionAttachment_Delete((long)obj.SolutionAttachmentID, (string)obj.FileName);
            return res;
        }
        #endregion
    }
}