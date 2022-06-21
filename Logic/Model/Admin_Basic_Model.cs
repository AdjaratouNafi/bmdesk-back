using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSDesk_CLI_API.Model
{
    #region RequestType
    public class RequestType_Model
    {
        public long RequestTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Default { get; set; }
        public bool Is_Client_Visible { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    #endregion

    #region Category
    public class Category_Model
    {
        public long CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Default { get; set; }
        public bool Is_Client_Visible { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    #endregion

    #region Status
    public class Status_Model
    {
        public long StatusID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StatusType { get; set; }
        public int Is_Closed { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Default { get; set; }
        public bool Is_Client_Visible { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    #endregion

    #region Department
    public class Department_Model
    {
        public long DepartmentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Default { get; set; }
        public bool Is_Client_Visible { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    #endregion

    #region Impact
    public class Impact_Model
    {
        public long ImpactID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Default { get; set; }
        public bool Is_Client_Visible { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    #endregion

    #region Level
    public class Level_Model
    {
        public long LevelID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Default { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    #endregion

    #region Priority
    public class Priority_Model
    {
        public long PriorityID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Default { get; set; }
        public bool Is_Client_Visible { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    #endregion

    #region SubCategory
    public class SubCategory_Model
    {
        public long SubCategoryID { get; set; }
        public long CategoryID { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Default { get; set; }
        public bool Is_Client_Visible { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    #endregion

    #region Item
    public class Item_Model
    {
        public long ItemID { get; set; }
        public long CategoryID { get; set; }
        public long SubCategoryID { get; set; }
        public string Name { get; set; }
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Default { get; set; }
        public bool Is_Client_Visible { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    #endregion

    #region Location
    public class Location_Model
    {
        public long LocationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Default { get; set; }
        public bool Is_Client_Visible { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    #endregion

    #region Urgency
    public class Urgency_Model
    {
        public long UrgencyID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Default { get; set; }
        public bool Is_Client_Visible { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    #endregion

    #region Notification
    public class Notification_Model
    {
        public long NotificationID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Default { get; set; }
        public bool Is_Client_Visible { get; set; }
        public bool Is_Agent_Visible { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    #endregion

    #region TicketMode
    public class TicketMode_Model
    {
        public long TicketModeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
        public bool Is_Active { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    #endregion
}
