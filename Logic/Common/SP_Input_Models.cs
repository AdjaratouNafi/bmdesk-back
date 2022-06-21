using BMSDesk_CLI_API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSDesk_CLI_API.Logic
{
    #region UserManagement
    [SqlProcedure(Name = "Login_User")]
    public class SP_Login_User
    {
        [SqlParameter(Name = "UserName")]
        public string UserName { get; set; }
        [SqlParameter(Name = "Password")]
        public string Password { get; set; }
    }

    [SqlProcedure(Name = "Page_Permission")]
    public class SP_Page_Permission
    {
        [SqlParameter(Name = "UserID")]
        public long UserID { get; set; }
    }


    #region User
    [SqlProcedure(Name = "Check_UserName_Available")]
    public class SP_Check_UserName_Available
    {
        [SqlParameter(Name = "ReturnValue", IsOutput = true)]
        public int ReturnValue { get; set; }
        [SqlParameter(Name = "UserID")]
        public long UserID { get; set; }
        [SqlParameter(Name = "UserName")]
        public string UserName { get; set; }
    }

    [SqlProcedure(Name = "Get_UserManagement_List")]
    public class SP_Get_UserManagement_List
    {
        [SqlParameter(Name = "Is_Agent")]
        public bool Is_Agent { get; set; }
        [SqlParameter(Name = "Is_Client")]
        public bool Is_Client { get; set; }
    }
    [SqlProcedure(Name = "Get_UserSelection_List")]
    public class SP_Get_UserSelection_List
    {
        [SqlParameter(Name = "Is_Agent")]
        public bool Is_Agent { get; set; }
        //[SqlParameter(Name = "Is_Active")]
        //public bool Is_Active { get; set; }
    }
    [SqlProcedure(Name = "Get_UserManagement_ByID")]
    public class SP_Get_UserManagement_ByID
    {
        [SqlParameter(Name = "UserID")]
        public long UserID { get; set; }
    }
    [SqlProcedure(Name = "UserManagement_Update")]
    public class SP_UserManagement_Update
    {
        [SqlParameter(Name = "UserID", IsOutput = true)]
        public long UserID { get; set; }
        [SqlParameter(Name = "RoleID")]
        public long RoleID { get; set; }
        [SqlParameter(Name = "DisplayName")]
        public string DisplayName { get; set; }
        [SqlParameter(Name = "UserName")]
        public string UserName { get; set; }
        [SqlParameter(Name = "Password")]
        public string Password { get; set; }
        [SqlParameter(Name = "Email")]
        public string Email { get; set; }
        [SqlParameter(Name = "PhoneNo")]
        public string PhoneNo { get; set; }
        [SqlParameter(Name = "CellPhoneNo")]
        public string CellPhoneNo { get; set; }
        [SqlParameter(Name = "City")]
        public string City { get; set; }
        [SqlParameter(Name = "State")]
        public string State { get; set; }
        [SqlParameter(Name = "Country")]
        public string Country { get; set; }
        [SqlParameter(Name = "Pincode")]
        public string Pincode { get; set; }
        [SqlParameter(Name = "JobTitle")]
        public string JobTitle { get; set; }
        [SqlParameter(Name = "Address")]
        public string Address { get; set; }
        [SqlParameter(Name = "TimeZoneID")]
        public int? TimeZoneID { get; set; }
        [SqlParameter(Name = "Organization")]
        public string Organization { get; set; }
        [SqlParameter(Name = "Is_SendMail_Password")]
        public bool Is_SendMail_Password { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "Is_Active")]
        public bool Is_Active { get; set; }
    }
    [SqlProcedure(Name = "UserManagement_Delete")]
    public class SP_UserManagement_Delete
    {
        [SqlParameter(Name = "UserID")]
        public string UserIDs { get; set; }
    }
    [SqlProcedure(Name = "Update_User_ProfilePic")]
    public class SP_Update_User_ProfilePic
    {
        [SqlParameter(Name = "UserID")]
        public long UserID { get; set; }
        [SqlParameter(Name = "ProfilePicture")]
        public string ProfilePicture { get; set; }
    }

    [SqlProcedure(Name = "Get_Email_ByUserName")]
    public class SP_Get_Email_ByUserName
    {
        [SqlParameter(Name = "UserName")]
        public string UserName { get; set; }
    }

    [SqlProcedure(Name = "ResetPassword")]
    public class SP_ResetPassword
    {
        [SqlParameter(Name = "ReturnValue", IsOutput = true)]
        public int ReturnValue { get; set; }
        [SqlParameter(Name = "UserID")]
        public long UserID { get; set; }
        [SqlParameter(Name = "UserName")]
        public string UserName { get; set; }
        [SqlParameter(Name = "Email")]
        public string Email { get; set; }
        [SqlParameter(Name = "Password")]
        public string Password { get; set; }
    }


    [SqlProcedure(Name = "ActiveDeActive_User")]
    public class SP_ActiveDeActive_User
    {
        [SqlParameter(Name = "UserID")]
        public long UserID { get; set; }
        [SqlParameter(Name = "Is_Active")]
        public bool Is_Active { get; set; }
    }

    [SqlProcedure(Name = "ResetDefaultPassword_User")]
    public class SP_ResetDefaultPassword_User
    {
        [SqlParameter(Name = "UserID")]
        public string UserIDs { get; set; }
        [SqlParameter(Name = "DefaultPassword")]
        public string DefaultPassword { get; set; }
    }


    #region Requester Profile
    [SqlProcedure(Name = "Requester_UserManagement_Update")]
    public class SP_Requester_UserManagement_Update
    {
        [SqlParameter(Name = "UserID", IsOutput = true)]
        public long UserID { get; set; }
        [SqlParameter(Name = "DisplayName")]
        public string DisplayName { get; set; }
        [SqlParameter(Name = "Email")]
        public string Email { get; set; }
        [SqlParameter(Name = "PhoneNo")]
        public string PhoneNo { get; set; }
        [SqlParameter(Name = "CellPhoneNo")]
        public string CellPhoneNo { get; set; }
        [SqlParameter(Name = "City")]
        public string City { get; set; }
        [SqlParameter(Name = "State")]
        public string State { get; set; }
        [SqlParameter(Name = "Country")]
        public string Country { get; set; }
        [SqlParameter(Name = "Pincode")]
        public string Pincode { get; set; }
        [SqlParameter(Name = "JobTitle")]
        public string JobTitle { get; set; }
        [SqlParameter(Name = "Address")]
        public string Address { get; set; }
        [SqlParameter(Name = "TimeZoneID")]
        public int? TimeZoneID { get; set; }
        [SqlParameter(Name = "Organization")]
        public string Organization { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
    }

    #endregion


    #endregion

    #region User Roles

    [SqlProcedure(Name = "Get_Role_List_KeyValue")]
    public class SP_Get_Role_List_KeyValue
    {
    }
    [SqlProcedure(Name = "Get_Roles_List")]
    public class SP_Get_Roles_List
    {
    }
    [SqlProcedure(Name = "Get_Roles_ByID")]
    public class SP_Get_Roles_ByID
    {
        [SqlParameter(Name = "RoleID")]
        public long RoleID { get; set; }
    }
    [SqlProcedure(Name = "Roles_Update")]
    public class SP_Roles_Update
    {
        [SqlParameter(Name = "RoleID", IsOutput = true)]
        public long RoleID { get; set; }
        [SqlParameter(Name = "Name")]
        public string Name { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "Is_Agent")]
        public bool Is_Agent { get; set; }
        [SqlParameter(Name = "Is_Client")]
        public bool Is_Client { get; set; }
        [SqlParameter(Name = "Is_Active")]
        public bool Is_Active { get; set; }
    }
    [SqlProcedure(Name = "Roles_Delete")]
    public class SP_Roles_Delete
    {
        [SqlParameter(Name = "RoleID")]
        public string RoleIDs { get; set; }
    }

    [SqlProcedure(Name = "RolePermission_Update")]
    public class SP_RolePermission_Update
    {
        [SqlParameter(Name = "RolePermissionID", IsOutput = true)]
        public long RolePermissionID { get; set; }
        [SqlParameter(Name = "RoleID")]
        public long RoleID { get; set; }
        [SqlParameter(Name = "MenuID")]
        public long MenuID { get; set; }
        [SqlParameter(Name = "Is_Full")]
        public bool Is_Full { get; set; }
        [SqlParameter(Name = "Is_View")]
        public bool Is_View { get; set; }
        [SqlParameter(Name = "Is_Add")]
        public bool Is_Add { get; set; }
        [SqlParameter(Name = "Is_Edit")]
        public bool Is_Edit { get; set; }
        [SqlParameter(Name = "Is_Delete")]
        public bool Is_Delete { get; set; }
        [SqlParameter(Name = "Is_Active")]
        public bool Is_Active { get; set; }
    }
    #endregion


    #endregion

    #region Admin Basic

    #region RequestType
    [SqlProcedure(Name = "Get_RequestType_List")]
    public class SP_Get_RequestType_List
    {
    }
    [SqlProcedure(Name = "Get_RequestType_ByID")]
    public class SP_Get_RequestType_ByID
    {
        [SqlParameter(Name = "RequestTypeID")]
        public long RequestTypeID { get; set; }
    }
    [SqlProcedure(Name = "RequestType_Update")]
    public class SP_RequestType_Update
    {
        [SqlParameter(Name = "RequestTypeID", IsOutput = true)]
        public long RequestTypeID { get; set; }
        [SqlParameter(Name = "Name")]
        public string Name { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "Is_Active")]
        public bool Is_Active { get; set; }
        [SqlParameter(Name = "Is_Default")]
        public bool Is_Default { get; set; }
        [SqlParameter(Name = "Is_Client_Visible")]
        public bool Is_Client_Visible { get; set; }
    }
    [SqlProcedure(Name = "RequestType_Delete")]
    public class SP_RequestType_Delete
    {
        [SqlParameter(Name = "RequestTypeID")]
        public string RequestTypeIDs { get; set; }
    }
    #endregion


    #region Category
    [SqlProcedure(Name = "Get_Category_List")]
    public class SP_Get_Category_List
    {
    }
    [SqlProcedure(Name = "Get_Category_List_KeyValue")]
    public class SP_Get_Category_List_KeyValue
    {
    }
    [SqlProcedure(Name = "Get_Category_ByID")]
    public class SP_Get_Category_ByID
    {
        [SqlParameter(Name = "CategoryID")]
        public long CategoryID { get; set; }
    }
    [SqlProcedure(Name = "Category_Update")]
    public class SP_Category_Update
    {
        [SqlParameter(Name = "CategoryID", IsOutput = true)]
        public long CategoryID { get; set; }

        [SqlParameter(Name = "Name")]
        public string Name { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "Is_Active")]
        public bool Is_Active { get; set; }
        [SqlParameter(Name = "Is_Default")]
        public bool Is_Default { get; set; }
        [SqlParameter(Name = "Is_Client_Visible")]
        public bool Is_Client_Visible { get; set; }
    }
    [SqlProcedure(Name = "Category_Delete")]
    public class SP_Category_Delete
    {
        [SqlParameter(Name = "CategoryID")]
        public string CategoryIDs { get; set; }
    }
    #endregion

    #region Status
    [SqlProcedure(Name = "Get_Status_List")]
    public class SP_Get_Status_List
    {
    }
    [SqlProcedure(Name = "Get_Status_ByID")]
    public class SP_Get_Status_ByID
    {
        [SqlParameter(Name = "StatusID")]
        public long StatusID { get; set; }
    }
    [SqlProcedure(Name = "Status_Update")]
    public class SP_Status_Update
    {
        [SqlParameter(Name = "StatusID", IsOutput = true)]
        public long StatusID { get; set; }
        [SqlParameter(Name = "Name")]
        public string Name { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "Is_Closed")]
        public int Is_Closed { get; set; }
        [SqlParameter(Name = "Is_Active")]
        public bool Is_Active { get; set; }
        [SqlParameter(Name = "Is_Default")]
        public bool Is_Default { get; set; }
        [SqlParameter(Name = "Is_Client_Visible")]
        public bool Is_Client_Visible { get; set; }
    }
    [SqlProcedure(Name = "Status_Delete")]
    public class SP_Status_Delete
    {
        [SqlParameter(Name = "StatusID")]
        public string StatusIDs { get; set; }
    }
    #endregion

    #region Department
    [SqlProcedure(Name = "Get_Department_List")]
    public class SP_Get_Department_List
    {
    }
    [SqlProcedure(Name = "Get_Department_ByID")]
    public class SP_Get_Department_ByID
    {
        [SqlParameter(Name = "DepartmentID")]
        public long DepartmentID { get; set; }
    }
    [SqlProcedure(Name = "Department_Update")]
    public class SP_Department_Update
    {
        [SqlParameter(Name = "DepartmentID", IsOutput = true)]
        public long DepartmentID { get; set; }

        [SqlParameter(Name = "Name")]
        public string Name { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "Is_Active")]
        public bool Is_Active { get; set; }
        [SqlParameter(Name = "Is_Default")]
        public bool Is_Default { get; set; }
        [SqlParameter(Name = "Is_Client_Visible")]
        public bool Is_Client_Visible { get; set; }
    }
    [SqlProcedure(Name = "Department_Delete")]
    public class SP_Department_Delete
    {
        [SqlParameter(Name = "DepartmentID")]
        public string DepartmentIDs { get; set; }
    }
    #endregion

    #region Impact
    [SqlProcedure(Name = "Get_Impact_List")]
    public class SP_Get_Impact_List
    {
    }
    [SqlProcedure(Name = "Get_Impact_ByID")]
    public class SP_Get_Impact_ByID
    {
        [SqlParameter(Name = "ImpactID")]
        public long ImpactID { get; set; }
    }
    [SqlProcedure(Name = "Impact_Update")]
    public class SP_Impact_Update
    {
        [SqlParameter(Name = "ImpactID", IsOutput = true)]
        public long ImpactID { get; set; }

        [SqlParameter(Name = "Name")]
        public string Name { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "Is_Active")]
        public bool Is_Active { get; set; }
        [SqlParameter(Name = "Is_Default")]
        public bool Is_Default { get; set; }
        [SqlParameter(Name = "Is_Client_Visible")]
        public bool Is_Client_Visible { get; set; }
    }
    [SqlProcedure(Name = "Impact_Delete")]
    public class SP_Impact_Delete
    {
        [SqlParameter(Name = "ImpactID")]
        public string ImpactIDs { get; set; }
    }
    #endregion

    #region Level
    [SqlProcedure(Name = "Get_Level_List")]
    public class SP_Get_Level_List
    {
    }
    [SqlProcedure(Name = "Get_Level_ByID")]
    public class SP_Get_Level_ByID
    {
        [SqlParameter(Name = "LevelID")]
        public long LevelID { get; set; }
    }
    [SqlProcedure(Name = "Level_Update")]
    public class SP_Level_Update
    {
        [SqlParameter(Name = "LevelID", IsOutput = true)]
        public long LevelID { get; set; }

        [SqlParameter(Name = "Name")]
        public string Name { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "Is_Active")]
        public bool Is_Active { get; set; }
        [SqlParameter(Name = "Is_Default")]
        public bool Is_Default { get; set; }
    }
    [SqlProcedure(Name = "Level_Delete")]
    public class SP_Level_Delete
    {
        [SqlParameter(Name = "LevelID")]
        public string LevelIDs { get; set; }
    }
    #endregion

    #region Priority
    [SqlProcedure(Name = "Get_Priority_List")]
    public class SP_Get_Priority_List
    {
    }
    [SqlProcedure(Name = "Get_Priority_ByID")]
    public class SP_Get_Priority_ByID
    {
        [SqlParameter(Name = "PriorityID")]
        public long PriorityID { get; set; }
    }
    [SqlProcedure(Name = "Priority_Update")]
    public class SP_Priority_Update
    {
        [SqlParameter(Name = "PriorityID", IsOutput = true)]
        public long PriorityID { get; set; }

        [SqlParameter(Name = "Name")]
        public string Name { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "Color")]
        public string Color { get; set; }
        [SqlParameter(Name = "Is_Active")]
        public bool Is_Active { get; set; }
        [SqlParameter(Name = "Is_Default")]
        public bool Is_Default { get; set; }
        [SqlParameter(Name = "Is_Client_Visible")]
        public bool Is_Client_Visible { get; set; }
    }
    [SqlProcedure(Name = "Priority_Delete")]
    public class SP_Priority_Delete
    {
        [SqlParameter(Name = "PriorityID")]
        public string PriorityIDs { get; set; }
    }
    #endregion

    #region SubCategory
    [SqlProcedure(Name = "Get_SubCategory_List")]
    public class SP_Get_SubCategory_List
    {
    }
    [SqlProcedure(Name = "Get_SubCategory_List_KeyValue")]
    public class SP_Get_SubCategory_List_KeyValue
    {
        [SqlParameter(Name = "Is_Admin")]
        public bool Is_Admin { get; set; }
    }
    [SqlProcedure(Name = "Get_SubCategory_ByID")]
    public class SP_Get_SubCategory_ByID
    {
        [SqlParameter(Name = "SubCategoryID")]
        public long SubCategoryID { get; set; }
    }
    [SqlProcedure(Name = "SubCategory_Update")]
    public class SP_SubCategory_Update
    {
        [SqlParameter(Name = "SubCategoryID", IsOutput = true)]
        public long SubCategoryID { get; set; }
        [SqlParameter(Name = "CategoryID")]
        public long CategoryID { get; set; }
        [SqlParameter(Name = "Name")]
        public string Name { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "Is_Active")]
        public bool Is_Active { get; set; }
        [SqlParameter(Name = "Is_Client_Visible")]
        public bool Is_Client_Visible { get; set; }
    }
    [SqlProcedure(Name = "SubCategory_Delete")]
    public class SP_SubCategory_Delete
    {
        [SqlParameter(Name = "SubCategoryID")]
        public string SubCategoryIDs { get; set; }
    }
    #endregion

    #region Item
    [SqlProcedure(Name = "Get_Item_List")]
    public class SP_Get_Item_List
    {
    }
    [SqlProcedure(Name = "Get_Item_ByID")]
    public class SP_Get_Item_ByID
    {
        [SqlParameter(Name = "ItemID")]
        public long ItemID { get; set; }
    }
    [SqlProcedure(Name = "Item_Update")]
    public class SP_Item_Update
    {
        [SqlParameter(Name = "ItemID", IsOutput = true)]
        public long ItemID { get; set; }
        [SqlParameter(Name = "SubCategoryID")]
        public long SubCategoryID { get; set; }
        [SqlParameter(Name = "Name")]
        public string Name { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "Is_Active")]
        public bool Is_Active { get; set; }
        [SqlParameter(Name = "Is_Client_Visible")]
        public bool Is_Client_Visible { get; set; }
    }
    [SqlProcedure(Name = "Item_Delete")]
    public class SP_Item_Delete
    {
        [SqlParameter(Name = "ItemID")]
        public string ItemIDs { get; set; }
    }
    #endregion

    #region Location
    [SqlProcedure(Name = "Get_Location_List")]
    public class SP_Get_Location_List
    {
    }
    [SqlProcedure(Name = "Get_Location_ByID")]
    public class SP_Get_Location_ByID
    {
        [SqlParameter(Name = "LocationID")]
        public long LocationID { get; set; }
    }
    [SqlProcedure(Name = "Location_Update")]
    public class SP_Location_Update
    {
        [SqlParameter(Name = "LocationID", IsOutput = true)]
        public long LocationID { get; set; }

        [SqlParameter(Name = "Name")]
        public string Name { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "Is_Active")]
        public bool Is_Active { get; set; }
        [SqlParameter(Name = "Is_Default")]
        public bool Is_Default { get; set; }
        [SqlParameter(Name = "Is_Client_Visible")]
        public bool Is_Client_Visible { get; set; }
    }
    [SqlProcedure(Name = "Location_Delete")]
    public class SP_Location_Delete
    {
        [SqlParameter(Name = "LocationID")]
        public string LocationIDs { get; set; }
    }
    #endregion

    #region Urgency
    [SqlProcedure(Name = "Get_Urgency_List")]
    public class SP_Get_Urgency_List
    {
    }
    [SqlProcedure(Name = "Get_Urgency_ByID")]
    public class SP_Get_Urgency_ByID
    {
        [SqlParameter(Name = "UrgencyID")]
        public long UrgencyID { get; set; }
    }
    [SqlProcedure(Name = "Urgency_Update")]
    public class SP_Urgency_Update
    {
        [SqlParameter(Name = "UrgencyID", IsOutput = true)]
        public long UrgencyID { get; set; }

        [SqlParameter(Name = "Name")]
        public string Name { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "Is_Active")]
        public bool Is_Active { get; set; }
        [SqlParameter(Name = "Is_Default")]
        public bool Is_Default { get; set; }
        [SqlParameter(Name = "Is_Client_Visible")]
        public bool Is_Client_Visible { get; set; }
    }
    [SqlProcedure(Name = "Urgency_Delete")]
    public class SP_Urgency_Delete
    {
        [SqlParameter(Name = "UrgencyID")]
        public string UrgencyIDs { get; set; }
    }
    #endregion

    #region Notification
    [SqlProcedure(Name = "Get_Notification_List")]
    public class SP_Get_Notification_List
    {
    }
    [SqlProcedure(Name = "Get_Notification_ByID")]
    public class SP_Get_Notification_ByID
    {
        [SqlParameter(Name = "NotificationID")]
        public long NotificationID { get; set; }
    }
    [SqlProcedure(Name = "Notification_Update")]
    public class SP_Notification_Update
    {
        [SqlParameter(Name = "NotificationID", IsOutput = true)]
        public long NotificationID { get; set; }
        [SqlParameter(Name = "Subject")]
        public string Subject { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "StartDate")]
        public DateTime StartDate { get; set; }
        [SqlParameter(Name = "EndDate")]
        public DateTime EndDate { get; set; }
        [SqlParameter(Name = "Is_Active")]
        public bool Is_Active { get; set; }
        [SqlParameter(Name = "Is_Client_Visible")]
        public bool Is_Client_Visible { get; set; }
        [SqlParameter(Name = "Is_Agent_Visible")]
        public bool Is_Agent_Visible { get; set; }
    }
    [SqlProcedure(Name = "Notification_Delete")]
    public class SP_Notification_Delete
    {
        [SqlParameter(Name = "NotificationID")]
        public string NotificationIDs { get; set; }
    }
    [SqlProcedure(Name = "Get_AnnouncementList_Client")]
    public class SP_Get_AnnouncementList_Client
    {
        [SqlParameter(Name = "Is_Agent")]
        public bool Is_Agent { get; set; }
        [SqlParameter(Name = "Is_Client")]
        public bool Is_Client { get; set; }
    }

    #endregion

    #region TicketMode   
    [SqlProcedure(Name = "TicketMode_Update")]
    public class SP_TicketMode_Update
    {
        [SqlParameter(Name = "TicketModeID", IsOutput = true)]
        public long TicketModeID { get; set; }

        [SqlParameter(Name = "Name")]
        public string Name { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "Is_Active")]
        public bool Is_Active { get; set; }
    }
    #endregion

    #endregion

    #region Common Setting
    [SqlProcedure(Name = "Get_AgentSetting")]
    public class SP_Get_AgentSetting
    { }
    [SqlProcedure(Name = "AgentSetting_Update")]
    public class SP_AgentSetting_Update
    {
        [SqlParameter(Name = "AgentSettingID", IsOutput = true)]
        public long AgentSettingID { get; set; }
        [SqlParameter(Name = "Is_Profile_Visible")]
        public bool Is_Profile_Visible { get; set; }
        [SqlParameter(Name = "Is_CommonSetting_Visible")]
        public bool Is_CommonSetting_Visible { get; set; }
        [SqlParameter(Name = "Is_Help_Visible")]
        public bool Is_Help_Visible { get; set; }
        [SqlParameter(Name = "Is_Solution_Visible")]
        public bool Is_Solution_Visible { get; set; }
        [SqlParameter(Name = "Is_ColumnChooser_Visible")]
        public bool Is_ColumnChooser_Visible { get; set; }
        [SqlParameter(Name = "PageSize")]
        public int PageSize { get; set; }

        [SqlParameter(Name = "Is_Print")]
        public bool Is_Print { get; set; }
        [SqlParameter(Name = "Is_Export")]
        public bool Is_Export { get; set; }
        [SqlParameter(Name = "Is_Ticket_Search")]
        public bool Is_Ticket_Search { get; set; }
        [SqlParameter(Name = "Is_Solution_Search")]
        public bool Is_Solution_Search { get; set; }
        [SqlParameter(Name = "Is_Column_Filter_Ticket")]
        public bool Is_Column_Filter_Ticket { get; set; }
        [SqlParameter(Name = "Is_Column_Filter_Solution")]
        public bool Is_Column_Filter_Solution { get; set; }
        [SqlParameter(Name = "Is_Clone_Ticket")]
        public bool Is_Clone_Ticket { get; set; }
        [SqlParameter(Name = "Is_Clone_Solution")]
        public bool Is_Clone_Solution { get; set; }
    }

    [SqlProcedure(Name = "Get_ClientSetting")]
    public class SP_Get_ClientSetting
    { }
    [SqlProcedure(Name = "ClientSetting_Update")]
    public class SP_ClientSetting_Update
    {
        [SqlParameter(Name = "ClientSettingID", IsOutput = true)]
        public long ClientSettingID { get; set; }
        [SqlParameter(Name = "Is_Profile_Visible")]
        public bool Is_Profile_Visible { get; set; }
        [SqlParameter(Name = "Is_Help_Visible")]
        public bool Is_Help_Visible { get; set; }
        [SqlParameter(Name = "Is_Ticket_Visible")]
        public bool Is_Ticket_Visible { get; set; }
        [SqlParameter(Name = "Is_Solution_Visible")]
        public bool Is_Solution_Visible { get; set; }
        [SqlParameter(Name = "Is_ColumnChooser_Visible")]
        public bool Is_ColumnChooser_Visible { get; set; }
        [SqlParameter(Name = "Is_Search_Visible")]
        public bool Is_Search_Visible { get; set; }
        [SqlParameter(Name = "PageSize")]
        public int PageSize { get; set; }

        [SqlParameter(Name = "Is_Print")]
        public bool Is_Print { get; set; }
        [SqlParameter(Name = "Is_Export")]
        public bool Is_Export { get; set; }
        [SqlParameter(Name = "Is_Ticket_Search")]
        public bool Is_Ticket_Search { get; set; }
        [SqlParameter(Name = "Is_Solution_Search")]
        public bool Is_Solution_Search { get; set; }
        [SqlParameter(Name = "Is_Column_Filter_Ticket")]
        public bool Is_Column_Filter_Ticket { get; set; }
        [SqlParameter(Name = "Is_Column_Filter_Solution")]
        public bool Is_Column_Filter_Solution { get; set; }
        [SqlParameter(Name = "Is_Clone_Ticket")]
        public bool Is_Clone_Ticket { get; set; }
        [SqlParameter(Name = "Is_Clone_Solution")]
        public bool Is_Clone_Solution { get; set; }
    }


    [SqlProcedure(Name = "Get_ApplicationSetting")]
    public class SP_Get_ApplicationSetting
    { }
    [SqlProcedure(Name = "ApplicationSetting_Update")]
    public class SP_ApplicationSetting_Update
    {
        [SqlParameter(Name = "ApplicationSettingID", IsOutput = true)]
        public long ApplicationSettingID { get; set; }
        [SqlParameter(Name = "Is_EasyAddOn_Visible")]
        public bool Is_EasyAddOn_Visible { get; set; }
        [SqlParameter(Name = "DefaultLanguage")]
        public string DefaultLanguage { get; set; }
        [SqlParameter(Name = "DefaultPassword")]
        public string DefaultPassword { get; set; }
        [SqlParameter(Name = "Is_Chat_Visible")]
        public bool Is_Chat_Visible { get; set; }
        [SqlParameter(Name = "Is_LockUser")]
        public bool Is_LockUser { get; set; }
        [SqlParameter(Name = "Is_Admin_Search")]
        public bool Is_Admin_Search { get; set; }
        [SqlParameter(Name = "Is_Pickup")]
        public bool Is_Pickup { get; set; }
        [SqlParameter(Name = "Is_AssignTo_Dropdown")]
        public bool Is_AssignTo_Dropdown { get; set; }
        [SqlParameter(Name = "Is_Close_Ticket")]
        public bool Is_Close_Ticket { get; set; }
        [SqlParameter(Name = "Is_Ticket_StartPage")]
        public bool Is_Ticket_StartPage { get; set; }
        [SqlParameter(Name = "Is_EditRow_On_DoubleClick")]
        public bool Is_EditRow_On_DoubleClick { get; set; }
    }
    [SqlProcedure(Name = "Logo_Update")]
    public class SP_Logo_Update
    {
        [SqlParameter(Name = "ApplicationSettingID", IsOutput = true)]
        public long ApplicationSettingID { get; set; }
        [SqlParameter(Name = "CompanyLogo")]
        public string CompanyLogo { get; set; }
        [SqlParameter(Name = "CompanyTitle")]
        public string CompanyTitle { get; set; }
    }

    #region Tech Autoassign
    [SqlProcedure(Name = "Get_TechAutoAssign")]
    public class SP_Get_TechAutoAssign
    { }
    [SqlProcedure(Name = "TechAutoAssign_Update")]
    public class SP_TechAutoAssign_Update
    {
        [SqlParameter(Name = "TechAutoAssignID", IsOutput = true)]
        public int TechAutoAssignID { get; set; }
        [SqlParameter(Name = "Is_Enable")]
        public bool Is_Enable { get; set; }
        [SqlParameter(Name = "AutoAssign_Type")]
        public string AutoAssign_Type { get; set; }
        [SqlParameter(Name = "Exclude_Users")]
        public string Exclude_Users { get; set; }
    }
    [SqlProcedure(Name = "GetUser_ForTechAutoAssign")]
    public class SP_GetUser_ForTechAutoAssign
    { }
    #endregion

    #endregion




    #region Ticket
    [SqlProcedure(Name = "Get_Ticket_List")]
    public class SP_Get_Ticket_List
    {
        [SqlParameter(Name = "Is_Agent")]
        public bool Is_Agent { get; set; }
        [SqlParameter(Name = "Is_Client")]
        public bool Is_Client { get; set; }
        [SqlParameter(Name = "UserID")]
        public long UserID { get; set; }
    }
    [SqlProcedure(Name = "Get_Ticket_ByID")]
    public class SP_Get_Ticket_ByID
    {
        [SqlParameter(Name = "TicketID")]
        public long TicketID { get; set; }
        [SqlParameter(Name = "DisplayTicketID")]
        public string DisplayTicketID { get; set; }
    }

    [SqlProcedure(Name = "Ticket_Create")]
    public class SP_Ticket_Create
    {
        [SqlParameter(Name = "TicketID", IsOutput = true)]
        public long TicketID { get; set; }
        [SqlParameter(Name = "DisplayTicketID", IsOutput = true, Size = 5000)]
        public string DisplayTicketID { get; set; }
        [SqlParameter(Name = "Subject")]
        public string Subject { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "RequestTypeID")]
        public long RequestTypeID { get; set; }
        [SqlParameter(Name = "StatusID")]
        public long StatusID { get; set; }
        [SqlParameter(Name = "PriorityID")]
        public long PriorityID { get; set; }
        [SqlParameter(Name = "UrgencyID")]
        public long UrgencyID { get; set; }
        [SqlParameter(Name = "CategoryID")]
        public long CategoryID { get; set; }
        [SqlParameter(Name = "SubCategoryID")]
        public long SubCategoryID { get; set; }
        [SqlParameter(Name = "ItemID")]
        public long ItemID { get; set; }
        [SqlParameter(Name = "ImpactID")]
        public long ImpactID { get; set; }
        [SqlParameter(Name = "DepartmentID")]
        public long DepartmentID { get; set; }
        [SqlParameter(Name = "LevelID")]
        public long LevelID { get; set; }
        [SqlParameter(Name = "LocationID")]
        public long LocationID { get; set; }
        [SqlParameter(Name = "TicketModeID")]
        public long TicketModeID { get; set; }
        [SqlParameter(Name = "CreatedUser")]
        public long CreatedUser { get; set; }
        [SqlParameter(Name = "RequestedUser")]
        public long RequestedUser { get; set; }
        [SqlParameter(Name = "AssignedUser")]
        public long AssignedUser { get; set; }
        [SqlParameter(Name = "AssignedDate")]
        public DateTime? AssignedDate { get; set; }
        [SqlParameter(Name = "DueDate")]
        public DateTime? DueDate { get; set; }
        [SqlParameter(Name = "SolutionDescription")]
        public string SolutionDescription { get; set; }
        [SqlParameter(Name = "IPAddress")]
        public string IPAddress { get; set; }
        [SqlParameter(Name = "ClosedDate")]
        public DateTime? ClosedDate { get; set; }
        [SqlParameter(Name = "UpdatedUser")]
        public long UpdatedUser { get; set; }
        [SqlParameter(Name = "UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }
        [SqlParameter(Name = "CreatedDate")]
        public DateTime? CreatedDate { get; set; }
    }


    [SqlProcedure(Name = "Ticket_Update")]
    public class SP_Ticket_Update
    {
        [SqlParameter(Name = "TicketID", IsOutput = true)]
        public long TicketID { get; set; }
        [SqlParameter(Name = "DisplayTicketID", IsOutput = true, Size = 5000)]
        public string DisplayTicketID { get; set; }
        [SqlParameter(Name = "Subject")]
        public string Subject { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "RequestTypeID")]
        public long RequestTypeID { get; set; }
        [SqlParameter(Name = "StatusID")]
        public long StatusID { get; set; }
        [SqlParameter(Name = "PriorityID")]
        public long PriorityID { get; set; }
        [SqlParameter(Name = "UrgencyID")]
        public long UrgencyID { get; set; }
        [SqlParameter(Name = "CategoryID")]
        public long CategoryID { get; set; }
        [SqlParameter(Name = "SubCategoryID")]
        public long SubCategoryID { get; set; }
        [SqlParameter(Name = "ItemID")]
        public long ItemID { get; set; }
        [SqlParameter(Name = "ImpactID")]
        public long ImpactID { get; set; }
        [SqlParameter(Name = "DepartmentID")]
        public long DepartmentID { get; set; }
        [SqlParameter(Name = "LevelID")]
        public long LevelID { get; set; }
        [SqlParameter(Name = "LocationID")]
        public long LocationID { get; set; }
        [SqlParameter(Name = "TicketModeID")]
        public long TicketModeID { get; set; }
        [SqlParameter(Name = "CreatedUser")]
        public long CreatedUser { get; set; }
        [SqlParameter(Name = "RequestedUser")]
        public long RequestedUser { get; set; }
        [SqlParameter(Name = "AssignedUser")]
        public long AssignedUser { get; set; }
        [SqlParameter(Name = "AssignedDate")]
        public DateTime? AssignedDate { get; set; }
        [SqlParameter(Name = "DueDate")]
        public DateTime? DueDate { get; set; }
        [SqlParameter(Name = "SolutionDescription")]
        public string SolutionDescription { get; set; }
        [SqlParameter(Name = "IPAddress")]
        public string IPAddress { get; set; }
        [SqlParameter(Name = "ClosedDate")]
        public DateTime? ClosedDate { get; set; }
        [SqlParameter(Name = "UpdatedUser")]
        public long UpdatedUser { get; set; }
        [SqlParameter(Name = "UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }
    }

    [SqlProcedure(Name = "Ticket_Delete")]
    public class SP_Ticket_Delete
    {
        [SqlParameter(Name = "TicketID")]
        public string TicketIDs { get; set; }
    }
    [SqlProcedure(Name = "Ticket_Clone")]
    public class SP_Ticket_Clone
    {
        [SqlParameter(Name = "TicketID", IsOutput = true)]
        public long TicketID { get; set; }
        [SqlParameter(Name = "DisplayTicketID", IsOutput = true, Size = 5000)]
        public string DisplayTicketID { get; set; }
        [SqlParameter(Name = "Subject")]
        public string Subject { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "RequestTypeID")]
        public long RequestTypeID { get; set; }
        [SqlParameter(Name = "StatusID")]
        public long StatusID { get; set; }
        [SqlParameter(Name = "PriorityID")]
        public long PriorityID { get; set; }
        [SqlParameter(Name = "UrgencyID")]
        public long UrgencyID { get; set; }
        [SqlParameter(Name = "CategoryID")]
        public long CategoryID { get; set; }
        [SqlParameter(Name = "SubCategoryID")]
        public long SubCategoryID { get; set; }
        [SqlParameter(Name = "ItemID")]
        public long ItemID { get; set; }
        [SqlParameter(Name = "ImpactID")]
        public long ImpactID { get; set; }
        [SqlParameter(Name = "DepartmentID")]
        public long DepartmentID { get; set; }
        [SqlParameter(Name = "LevelID")]
        public long LevelID { get; set; }
        [SqlParameter(Name = "LocationID")]
        public long LocationID { get; set; }
        [SqlParameter(Name = "TicketModeID")]
        public long TicketModeID { get; set; }
        [SqlParameter(Name = "CreatedUser")]
        public long CreatedUser { get; set; }
        [SqlParameter(Name = "RequestedUser")]
        public long RequestedUser { get; set; }
        [SqlParameter(Name = "AssignedUser")]
        public long AssignedUser { get; set; }
        [SqlParameter(Name = "AssignedDate")]
        public DateTime? AssignedDate { get; set; }
        [SqlParameter(Name = "DueDate")]
        public DateTime? DueDate { get; set; }
        [SqlParameter(Name = "SolutionDescription")]
        public string SolutionDescription { get; set; }
        [SqlParameter(Name = "IPAddress")]
        public string IPAddress { get; set; }
        [SqlParameter(Name = "ClosedDate")]
        public DateTime? ClosedDate { get; set; }
        [SqlParameter(Name = "UpdatedUser")]
        public long UpdatedUser { get; set; }
        [SqlParameter(Name = "UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }
    }

    [SqlProcedure(Name = "Ticket_ClosedDate_Update")]
    public class SP_Ticket_ClosedDate_Update
    {
        [SqlParameter(Name = "TicketID")]
        public long TicketID { get; set; }
        [SqlParameter(Name = "ClosedDate")]
        public DateTime? ClosedDate { get; set; }
    }




    [SqlProcedure(Name = "Ticket_AssignTo_Update")]
    public class SP_Ticket_AssignTo_Update
    {
        [SqlParameter(Name = "TicketID")]
        public string TicketIDs { get; set; }
        [SqlParameter(Name = "UserID")]
        public long UserID { get; set; }

        [SqlParameter(Name = "AssignedDate")]
        public DateTime AssignedDate { get; set; }
    }
    [SqlProcedure(Name = "Ticket_Status_Update")]
    public class SP_Ticket_Status_Update
    {
        [SqlParameter(Name = "TicketID")]
        public string TicketIDs { get; set; }
        [SqlParameter(Name = "StatusID")]
        public long StatusID { get; set; }
        [SqlParameter(Name = "TicketCloseModeID")]
        public long TicketCloseModeID { get; set; }
        [SqlParameter(Name = "StatusCloseReason")]
        public string StatusCloseReason { get; set; }
    }

    [SqlProcedure(Name = "Get_TicketCloseMode_List")]
    public class SP_Get_TicketCloseMode_List
    {
    }
    [SqlProcedure(Name = "Get_Ticket_Detail_Data")]
    public class SP_Get_Ticket_Detail_Data
    {
        [SqlParameter(Name = "Is_Agent")]
        public bool Is_Agent { get; set; }
    }

    [SqlProcedure(Name = "Set_Ticket_FCR")]
    public class SP_Set_Ticket_FCR
    {
        [SqlParameter(Name = "TicketID")]
        public long TicketID { get; set; }
        [SqlParameter(Name = "Is_FCR")]
        public bool Is_FCR { get; set; }
    }

    [SqlProcedure(Name = "Get_Dashboard_Summary")]
    public class SP_Get_Dashboard_Summary
    {
        [SqlParameter(Name = "Is_Agent")]
        public bool Is_Agent { get; set; }
        [SqlParameter(Name = "Is_Client")]
        public bool Is_Client { get; set; }

        [SqlParameter(Name = "UserID")]
        public long UserID { get; set; }
    }

    [SqlProcedure(Name = "Get_DescriptionByID")]
    public class SP_Get_DescriptionByID
    {
        [SqlParameter(Name = "ModuleType")]
        public string ModuleType { get; set; }
        [SqlParameter(Name = "ID")]
        public string ID { get; set; }
    }


    #region TicketAttachment
    [SqlProcedure(Name = "TicketAttachment_Insert")]
    public class SP_TicketAttachment_Insert
    {
        [SqlParameter(Name = "TicketAttachmentID", IsOutput = true)]
        public long TicketAttachmentID { get; set; }
        [SqlParameter(Name = "TicketID")]
        public long TicketID { get; set; }
        [SqlParameter(Name = "FileName")]
        public string FileName { get; set; }
        [SqlParameter(Name = "DisplayName")]
        public string DisplayName { get; set; }
        [SqlParameter(Name = "Extension")]
        public string Extension { get; set; }
        [SqlParameter(Name = "FileSize")]
        public string FileSize { get; set; }
    }
    [SqlProcedure(Name = "TicketAttachment_Delete")]
    public class SP_TicketAttachment_Delete
    {
        [SqlParameter(Name = "TicketAttachmentID")]
        public long TicketAttachmentID { get; set; }
    }
    [SqlProcedure(Name = "Get_TicketAttachment_ByID")]
    public class SP_Get_TicketAttachment_ByID
    {
        [SqlParameter(Name = "TicketID")]
        public long TicketID { get; set; }
    }


    #endregion

    #region Ticket Chat
    [SqlProcedure(Name = "TicketChat_CRUD")]
    public class SP_TicketChat_CRUD
    {
        [SqlParameter(Name = "action")]
        public string action { get; set; }
        [SqlParameter(Name = "TicketChatID", IsOutput = true)]
        public long TicketChatID { get; set; }
        [SqlParameter(Name = "TicketID")]
        public long TicketID { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "UserID")]
        public long UserID { get; set; }
    }
    #endregion

    #endregion

    #region Print
    [SqlProcedure(Name = "Get_Print_ByModule")]
    public class SP_Get_Print_ByModule
    {
        [SqlParameter(Name = "Ids")]
        public string Ids { get; set; }
        [SqlParameter(Name = "ModuleType")]
        public string ModuleType { get; set; }
    }
    [SqlProcedure(Name = "Get_Attachment_List_ByModule")]
    public class SP_Get_Attachment_List_ByModule
    {
        [SqlParameter(Name = "Ids")]
        public string Ids { get; set; }
        [SqlParameter(Name = "ModuleType")]
        public string ModuleType { get; set; }
    }
    #endregion

    #region Solution
    [SqlProcedure(Name = "Get_Solution_List")]
    public class SP_Get_Solution_List
    {
        [SqlParameter(Name = "Is_Agent")]
        public bool Is_Agent { get; set; }
        [SqlParameter(Name = "UserID")]
        public long UserID { get; set; }
    }
    [SqlProcedure(Name = "Get_Solution_ByID")]
    public class SP_Get_Solution_ByID
    {
        [SqlParameter(Name = "SolutionID")]
        public long SolutionID { get; set; }
        [SqlParameter(Name = "DisplaySolutionID")]
        public string DisplaySolutionID { get; set; }
    }
    [SqlProcedure(Name = "Solution_Update")]
    public class SP_Solution_Update
    {
        [SqlParameter(Name = "SolutionID", IsOutput = true)]
        public long SolutionID { get; set; }
        [SqlParameter(Name = "DisplaySolutionID", IsOutput = true, Size = 5000)]
        public string DisplaySolutionID { get; set; }
        [SqlParameter(Name = "TicketID")]
        public long TicketID { get; set; }
        [SqlParameter(Name = "Subject")]
        public string Subject { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "Comments")]
        public string Comments { get; set; }
        [SqlParameter(Name = "CategoryID")]
        public long CategoryID { get; set; }
        [SqlParameter(Name = "SubCategoryID")]
        public long SubCategoryID { get; set; }
        [SqlParameter(Name = "ItemID")]
        public long ItemID { get; set; }
        [SqlParameter(Name = "MetaKeywords")]
        public string MetaKeywords { get; set; }
        [SqlParameter(Name = "CreatedUser")]
        public long CreatedUser { get; set; }
        [SqlParameter(Name = "UpdatedUser")]
        public long UpdatedUser { get; set; }
        [SqlParameter(Name = "UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }
        [SqlParameter(Name = "IPAddress")]
        public string IPAddress { get; set; }
        [SqlParameter(Name = "Is_Client_Visible")]
        public bool Is_Client_Visible { get; set; }
        [SqlParameter(Name = "Is_Active")]
        public bool Is_Active { get; set; }
    }

    [SqlProcedure(Name = "Solution_Delete")]
    public class SP_Solution_Delete
    {
        [SqlParameter(Name = "SolutionID")]
        public string SolutionIDs { get; set; }
    }

    [SqlProcedure(Name = "Get_Solution_Detail_Data")]
    public class SP_Get_Solution_Detail_Data
    {
    }

    #region TicketAttachment
    [SqlProcedure(Name = "SolutionAttachment_Insert")]
    public class SP_SolutionAttachment_Insert
    {
        [SqlParameter(Name = "SolutionAttachmentID", IsOutput = true)]
        public long SolutionAttachmentID { get; set; }
        [SqlParameter(Name = "SolutionID")]
        public long SolutionID { get; set; }
        [SqlParameter(Name = "FileName")]
        public string FileName { get; set; }
        [SqlParameter(Name = "DisplayName")]
        public string DisplayName { get; set; }
        [SqlParameter(Name = "Extension")]
        public string Extension { get; set; }
        [SqlParameter(Name = "FileSize")]
        public string FileSize { get; set; }
    }
    [SqlProcedure(Name = "SolutionAttachment_Delete")]
    public class SP_SolutionAttachment_Delete
    {
        [SqlParameter(Name = "SolutionAttachmentID")]
        public long SolutionAttachmentID { get; set; }
    }
    [SqlProcedure(Name = "Get_SolutionAttachment_ByID")]
    public class SP_Get_SolutionAttachment_ByID
    {
        [SqlParameter(Name = "SolutionID")]
        public long SolutionID { get; set; }
    }


    #endregion


    #region Requester
    #region Ticket
    [SqlProcedure(Name = "Ticket_Requester_Create")]
    public class SP_Ticket_Requester_Create
    {
        [SqlParameter(Name = "TicketID", IsOutput = true)]
        public long TicketID { get; set; }
        [SqlParameter(Name = "DisplayTicketID", IsOutput = true, Size = 5000)]
        public string DisplayTicketID { get; set; }
        [SqlParameter(Name = "Subject")]
        public string Subject { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "RequestTypeID")]
        public long RequestTypeID { get; set; }
        [SqlParameter(Name = "StatusID")]
        public long StatusID { get; set; }
        [SqlParameter(Name = "PriorityID")]
        public long PriorityID { get; set; }
        [SqlParameter(Name = "UrgencyID")]
        public long UrgencyID { get; set; }
        [SqlParameter(Name = "CategoryID")]
        public long CategoryID { get; set; }
        [SqlParameter(Name = "SubCategoryID")]
        public long SubCategoryID { get; set; }
        [SqlParameter(Name = "ItemID")]
        public long ItemID { get; set; }
        [SqlParameter(Name = "ImpactID")]
        public long ImpactID { get; set; }
        [SqlParameter(Name = "DepartmentID")]
        public long DepartmentID { get; set; }
        [SqlParameter(Name = "LevelID")]
        public long LevelID { get; set; }
        [SqlParameter(Name = "LocationID")]
        public long LocationID { get; set; }
        [SqlParameter(Name = "TicketModeID")]
        public long TicketModeID { get; set; }
        [SqlParameter(Name = "CreatedUser")]
        public long CreatedUser { get; set; }
        [SqlParameter(Name = "RequestedUser")]
        public long RequestedUser { get; set; }
        [SqlParameter(Name = "AssignedUser")]
        public long AssignedUser { get; set; }
        [SqlParameter(Name = "AssignedDate")]
        public DateTime? AssignedDate { get; set; }
        [SqlParameter(Name = "DueDate")]
        public DateTime? DueDate { get; set; }
        [SqlParameter(Name = "SolutionDescription")]
        public string SolutionDescription { get; set; }
        [SqlParameter(Name = "IPAddress")]
        public string IPAddress { get; set; }
        [SqlParameter(Name = "ClosedDate")]
        public DateTime? ClosedDate { get; set; }
        [SqlParameter(Name = "UpdatedUser")]
        public long UpdatedUser { get; set; }
        [SqlParameter(Name = "UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }
        [SqlParameter(Name = "CreatedDate")]
        public DateTime? CreatedDate { get; set; }
    }

    [SqlProcedure(Name = "Ticket_Requester_Update")]
    public class SP_Ticket_Requester_Update
    {
        [SqlParameter(Name = "TicketID", IsOutput = true)]
        public long TicketID { get; set; }
        [SqlParameter(Name = "DisplayTicketID", IsOutput = true, Size = 5000)]
        public string DisplayTicketID { get; set; }
        [SqlParameter(Name = "Subject")]
        public string Subject { get; set; }
        [SqlParameter(Name = "Description")]
        public string Description { get; set; }
        [SqlParameter(Name = "RequestTypeID")]
        public long RequestTypeID { get; set; }
        [SqlParameter(Name = "StatusID")]
        public long StatusID { get; set; }
        [SqlParameter(Name = "PriorityID")]
        public long PriorityID { get; set; }
        [SqlParameter(Name = "UrgencyID")]
        public long UrgencyID { get; set; }
        [SqlParameter(Name = "CategoryID")]
        public long CategoryID { get; set; }
        [SqlParameter(Name = "SubCategoryID")]
        public long SubCategoryID { get; set; }
        [SqlParameter(Name = "ItemID")]
        public long ItemID { get; set; }
        [SqlParameter(Name = "ImpactID")]
        public long ImpactID { get; set; }
        [SqlParameter(Name = "DepartmentID")]
        public long DepartmentID { get; set; }
        [SqlParameter(Name = "LevelID")]
        public long LevelID { get; set; }
        [SqlParameter(Name = "LocationID")]
        public long LocationID { get; set; }
        [SqlParameter(Name = "TicketModeID")]
        public long TicketModeID { get; set; }
        [SqlParameter(Name = "CreatedUser")]
        public long CreatedUser { get; set; }
        [SqlParameter(Name = "RequestedUser")]
        public long RequestedUser { get; set; }
        [SqlParameter(Name = "AssignedUser")]
        public long AssignedUser { get; set; }
        [SqlParameter(Name = "AssignedDate")]
        public DateTime? AssignedDate { get; set; }
        [SqlParameter(Name = "DueDate")]
        public DateTime? DueDate { get; set; }
        [SqlParameter(Name = "SolutionDescription")]
        public string SolutionDescription { get; set; }
        [SqlParameter(Name = "IPAddress")]
        public string IPAddress { get; set; }
        [SqlParameter(Name = "ClosedDate")]
        public DateTime? ClosedDate { get; set; }
        [SqlParameter(Name = "UpdatedUser")]
        public long UpdatedUser { get; set; }
        [SqlParameter(Name = "UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }
    }
    #endregion

    #endregion

    #endregion


    #region Summary
    [SqlProcedure(Name = "Get_TicketCount_ByType")]
    public class SP_Get_TicketCount_ByType
    {
        [SqlParameter(Name = "Is_Agent")]
        public bool Is_Agent { get; set; }
        [SqlParameter(Name = "Is_Client")]
        public bool Is_Client { get; set; }

        [SqlParameter(Name = "Type")]
        public string Type { get; set; }
        [SqlParameter(Name = "UserID")]
        public long UserID { get; set; }
        [SqlParameter(Name = "FromDate")]
        public string FromDate { get; set; }
        [SqlParameter(Name = "ToDate")]
        public string ToDate { get; set; }
    }
    [SqlProcedure(Name = "Get_TicketSummary_ByType")]
    public class SP_Get_TicketSummary_ByType
    {
        [SqlParameter(Name = "Is_Agent")]
        public bool Is_Agent { get; set; }
        [SqlParameter(Name = "Is_Client")]
        public bool Is_Client { get; set; }
        [SqlParameter(Name = "Type")]
        public string Type { get; set; }
        [SqlParameter(Name = "UserID")]
        public long UserID { get; set; }
    }
    [SqlProcedure(Name = "Get_TicketReceived_ByDays")]
    public class SP_Get_TicketReceived_ByDays
    {
        [SqlParameter(Name = "Is_Agent")]
        public bool Is_Agent { get; set; }
        [SqlParameter(Name = "Is_Client")]
        public bool Is_Client { get; set; }
        [SqlParameter(Name = "Type")]
        public string Type { get; set; }
        [SqlParameter(Name = "Days")]
        public int Days { get; set; }
        [SqlParameter(Name = "UserID")]
        public long UserID { get; set; }
    }
    [SqlProcedure(Name = "Get_OpenTicket_ByType")]
    public class SP_Get_OpenTicket_ByType
    {
        [SqlParameter(Name = "Is_Agent")]
        public bool Is_Agent { get; set; }
        [SqlParameter(Name = "Is_Client")]
        public bool Is_Client { get; set; }
        [SqlParameter(Name = "Type")]
        public string Type { get; set; }
        [SqlParameter(Name = "UserID")]
        public long UserID { get; set; }
        [SqlParameter(Name = "FromDate")]
        public string FromDate { get; set; }
        [SqlParameter(Name = "ToDate")]
        public string ToDate { get; set; }
    }
    #endregion

}

