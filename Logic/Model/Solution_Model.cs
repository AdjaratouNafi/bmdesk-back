using BMSDesk_CLI_API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSDesk_CLI_API.Model
{
    public class Solution_Model
    {
        public long SolutionID { get; set; }
        public string DisplaySolutionID { get; set; }
        public long? TicketID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public long CategoryID { get; set; }
        public long SubCategoryID { get; set; }
        public long ItemID { get; set; }
        public string MetaKeywords { get; set; }
        public long CreatedUser { get; set; }
        public long UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string IPAddress { get; set; }
        public bool Is_Client_Visible { get; set; }
        public bool Is_Active { get; set; }
        public string CreatedUserName { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string ItemName { get; set; }
        public bool HasAttachment { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class Solution_Model_Export
    {
        public string DisplaySolutionID { get; set; }
        public string Subject { get; set; }
        //public string Description { get; set; }
        public string Comments { get; set; }
        public string MetaKeywords { get; set; }
        public string CreatedUserName { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string ItemName { get; set; }
        public string IPAddress { get; set; }
        public string Is_Client_Visible { get; set; }
        public string Is_Active { get; set; }
        public string CreatedDate { get; set; }
    }
    public class SolutionAttachment_Model
    {
        public long SolutionAttachmentID { get; set; }
        public long SolutionID { get; set; }
        public string FileName { get; set; }
        public string DisplayName { get; set; }
        public string Extension { get; set; }
        public string FileSize { get; set; }
    }

    public class Common_Solution_Detail_Model
    {
        public List<KeyValueDefault> CategoryList { get; set; }
        public List<KeyValueDefault> SubCategoryList { get; set; }
        public List<KeyValueDefault> ItemList { get; set; }
    }



    public class Print_Model
    {
        public List<Ticket_Model> TicketList { get; set; }
        public List<Solution_Model> SolutionList { get; set; }
        public List<TicketAttachment_Model> TicketAttachment { get; set; }
        public List<SolutionAttachment_Model> SolutionAttachment { get; set; }
        public string Documents_URL { get; set; }
        public string lang { get; set; }
    }


}
