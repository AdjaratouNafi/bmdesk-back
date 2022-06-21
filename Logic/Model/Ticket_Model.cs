using BMSDesk_CLI_API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSDesk_CLI_API.Model
{
    public class Ticket_Model
    {
        public long TicketID { get; set; }
        public string DisplayTicketID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public long? RequestTypeID { get; set; }
        public long? StatusID { get; set; }
        public long? OldStatusID { get; set; }
        public long? PriorityID { get; set; }
        public long? UrgencyID { get; set; }
        public long? CategoryID { get; set; }
        public long? SubCategoryID { get; set; }
        public long? ItemID { get; set; }
        public long? ImpactID { get; set; }
        public long? DepartmentID { get; set; }
        public long? LevelID { get; set; }
        public long? LocationID { get; set; }
        public long? TicketModeID { get; set; }
        public long CreatedUser { get; set; }
        public long UpdatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long RequestedUser { get; set; }
        public string RequestedUserEmail { get; set; }
        public long? AssignedUser { get; set; }
        public long? OldAssignedUser { get; set; }
        public string AssignedUserEmail { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string SolutionDescription { get; set; }
        public string IPAddress { get; set; }
        public DateTime? ClosedDate { get; set; }
        public bool Is_FCR { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Closed_Status { get; set; }
        public string RequestTypeName { get; set; }
        public string StatusName { get; set; }
        public string StatusType { get; set; }
        public string PriorityName { get; set; }
        public string ColorName { get; set; }
        public string UrgencyName { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string ItemName { get; set; }
        public string ImpactName { get; set; }
        public string DepartmentName { get; set; }
        public string LevelName { get; set; }
        public string LocationName { get; set; }
        public string TicketModeName { get; set; }
        public string RequestedName { get; set; }
        public string AssignedName { get; set; }
        public string CreatedUserName { get; set; }
        public bool HasAttachment { get; set; }
        public long TicketCloseModeID { get; set; }
        public string StatusCloseReason { get; set; }
    }

    public class Ticket_Model_Export
    {
        public string DisplayTicketID { get; set; }
        public string Subject { get; set; }
        //public string Description { get; set; }
        public string RequestTypeName { get; set; }
        public string StatusName { get; set; }
        public string RequestedName { get; set; }
        public string AssignedName { get; set; }
        public string CreatedUserName { get; set; }
        public string PriorityName { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string ItemName { get; set; }
        public string UrgencyName { get; set; }
        public string ImpactName { get; set; }
        public string DepartmentName { get; set; }
        public string LevelName { get; set; }
        public string LocationName { get; set; }
        public string TicketModeName { get; set; }
        public string CreatedDate { get; set; }
        public string DueDate { get; set; }
        public string ClosedDate { get; set; }
    }

    public class Common_Ticket_Detail_Model
    {
        public List<KeyValueDefault> RequestTypeList { get; set; }
        public List<KeyValueDefault> StatusList { get; set; }
        public List<KeyValueDefault> PriorityList { get; set; }
        public List<KeyValueDefault> CategoryList { get; set; }
        public List<KeyValueDefault> SubCategoryList { get; set; }
        public List<KeyValueDefault> ItemList { get; set; }
        public List<KeyValueDefault> UrgencyList { get; set; }
        public List<KeyValueDefault> ImpactList { get; set; }
        public List<KeyValueDefault> DepartmentList { get; set; }
        public List<KeyValueDefault> LevelList { get; set; }
        public List<KeyValueDefault> LocationList { get; set; }
        public List<KeyValueDefault> TicketModeList { get; set; }
    }

    public class File_Attachments
    {
        public string name { get; set; }
        public string type { get; set; }
        public string extension { get; set; }
        public string size { get; set; }
        public string value { get; set; }
    }
    public class TicketAttachment_Model
    {
        public long TicketAttachmentID { get; set; }
        public long TicketID { get; set; }
        public string FileName { get; set; }
        public string DisplayName { get; set; }
        public string Extension { get; set; }
        public string FileSize { get; set; }
    }


    public class Dashboard_Summary_Model
    {
        public long AllTickets { get; set; }
        public long OpenTickets { get; set; }
        public long ClosedTickets { get; set; }
        public long PendingTickets { get; set; }
        public long UnAssignedTickets { get; set; }
        public long OverdueTickets { get; set; }
        public long DueTodayTickets { get; set; }
        public long AssignedToMeTickets { get; set; }
    }


    //Assign Agents Or PickUp
    public class AssignTicket_Model
    {
        public long TicketID { get; set; }
        public string DisplayTicketID { get; set; }
        public string Subject { get; set; }
        public long AssignedUser { get; set; }
        public DateTime? AssignedDate { get; set; }
    }
    public class AssignUser_Model
    {
        public long UserID { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }


    public class TicketChat_Model
    {
        public long TicketChatID { get; set; }
        public long TicketID { get; set; }
        public string Description { get; set; }
        public long UserID { get; set; }
        public string DisplayName { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
