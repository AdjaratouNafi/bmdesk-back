using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSDesk_CLI_API.Model
{
    public class User_Account_Model
    {
        public long UserID { get; set; }
        public long RoleID { get; set; }
        public string RoleName { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string CellPhoneNo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public string JobTitle { get; set; }
        public string Address { get; set; }
        public int? TimeZoneID { get; set; }
        public string Organization { get; set; }
        public bool? Is_SendMail_Password { get; set; }
        public string Description { get; set; }
        public string ProfilePicture { get; set; }
        public string ProfilePictureName { get; set; }
        //public string ProfilePicture_base64 { get; set; }
        public bool Is_Active { get; set; }
        
        public bool Is_Agent { get; set; }
        public bool Is_Client { get; set; }
    }

    public class Main_Roles_Model {
        public Roles_Model Roles_Model { get; set; }
        public List<RolePermission_Model> RolePermission_Model { get; set; }
    }

    public class Roles_Model
    {
        public long RoleID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Is_Agent { get; set; }
        public bool Is_Client { get; set; }
        public bool Is_Active { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class RolePermission_Model
    {
        public long RolePermissionID { get; set; }
        public long RoleID { get; set; }
        public long MenuID { get; set; }
        public string MenuName { get; set; }
        public string Description { get; set; }
        public bool Is_Full { get; set; }
        public bool Is_View { get; set; }
        public bool Is_Add { get; set; }
        public bool Is_Edit { get; set; }
        public bool Is_Delete { get; set; }
        public bool Is_Active { get; set; }
        //public DateTime CreatedDate { get; set; }
    }

    public class Page_Permission_Model
    {
        public long UserID { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public bool Is_Agent_Original { get; set; }
        public bool Is_Agent { get; set; }
        public bool Is_Client { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyTitle { get; set; }
        public string DefaultLanguage { get; set; }
        public string DefaultPassword { get; set; }
        public bool Is_EasyAddOn_Visible { get; set; }
        public bool Is_Chat_Visible { get; set; }
        public bool Is_Admin_Search { get; set; }        
        public bool Is_Pickup { get; set; }
        public bool Is_AssignTo_Dropdown { get; set; }
        public bool Is_Close_Ticket { get; set; }
        public bool Is_Ticket_StartPage { get; set; }
        public bool Is_EditRow_On_DoubleClick { get; set; }


        public bool Is_Profile_Visible { get; set; }
        public bool Is_Profile_Visible_Client { get; set; }
        public bool Is_CommonSetting_Visible { get; set; }
        public bool Is_CommonSetting_Visible_Client { get; set; }
        public bool Is_Help_Visible { get; set; }
        public bool Is_Help_Visible_Client { get; set; }
        public bool Is_Solution_Visible { get; set; }
        public bool Is_Solution_Visible_Client { get; set; }
        public bool Is_ColumnChooser_Visible { get; set; }
        public bool Is_ColumnChooser_Visible_Client { get; set; }
        public int PageSize { get; set; }
        public int PageSize_Client { get; set; }
        public bool Is_Ticket_Visible_Client { get; set; }
        public bool Is_Search_Visible_Client { get; set; }


        public bool Is_Print { get; set; }
        public bool Is_Print_Client { get; set; }
        public bool Is_Export { get; set; }
        public bool Is_Export_Client { get; set; }
        public bool Is_Ticket_Search { get; set; }
        public bool Is_Ticket_Search_Client { get; set; }
        public bool Is_Solution_Search { get; set; }
        public bool Is_Solution_Search_Client { get; set; }
        public bool Is_Column_Filter_Ticket { get; set; }
        public bool Is_Column_Filter_Ticket_Client { get; set; }
        public bool Is_Column_Filter_Solution { get; set; }
        public bool Is_Column_Filter_Solution_Client { get; set; }
        public bool Is_Clone_Ticket { get; set; }
        public bool Is_Clone_Ticket_Client { get; set; }
        public bool Is_Clone_Solution { get; set; }
        public bool Is_Clone_Solution_Client { get; set; }

        public bool Is_Full_Ticket { get; set; }
        public bool Is_View_Ticket { get; set; }
        public bool Is_Add_Ticket { get; set; }
        public bool Is_Edit_Ticket { get; set; }
        public bool Is_Delete_Ticket { get; set; }

        public bool Is_Full_Ticket_Client { get; set; }
        public bool Is_View_Ticket_Client { get; set; }
        public bool Is_Add_Ticket_Client { get; set; }
        public bool Is_Edit_Ticket_Client { get; set; }
        public bool Is_Delete_Ticket_Client { get; set; }

        public bool Is_Full_Summary { get; set; }
        public bool Is_View_Summary { get; set; }
        public bool Is_Add_Summary { get; set; }
        public bool Is_Edit_Summary { get; set; }
        public bool Is_Delete_Summary { get; set; }

        public bool Is_Full_Solution { get; set; }
        public bool Is_View_Solution { get; set; }
        public bool Is_Add_Solution { get; set; }
        public bool Is_Edit_Solution { get; set; }
        public bool Is_Delete_Solution { get; set; }

        public bool Is_Full_Solution_Client { get; set; }
        public bool Is_View_Solution_Client { get; set; }
        public bool Is_Add_Solution_Client { get; set; }
        public bool Is_Edit_Solution_Client { get; set; }
        public bool Is_Delete_Solution_Client { get; set; }

        public bool Is_Full_Admin { get; set; }
        public bool Is_View_Admin { get; set; }
        public bool Is_Add_Admin { get; set; }
        public bool Is_Edit_Admin { get; set; }
        public bool Is_Delete_Admin { get; set; }

        public bool Is_DemoVersion { get; set; }
        public bool Is_Enable_SignalR { get; set; }
    }
}
