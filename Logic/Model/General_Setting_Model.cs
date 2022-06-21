using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSDesk_CLI_API.Model
{
    #region AgentSetting
    public class AgentSetting_Model
    {
        public long AgentSettingID { get; set; }
        public bool Is_Profile_Visible { get; set; }
        public bool Is_CommonSetting_Visible { get; set; }
        public bool Is_Help_Visible { get; set; }
        public bool Is_Solution_Visible { get; set; }
        public bool Is_ColumnChooser_Visible { get; set; }
        public int PageSize { get; set; }

        public bool Is_Print { get; set; }
        public bool Is_Export { get; set; }
        public bool Is_Ticket_Search { get; set; }
        public bool Is_Solution_Search { get; set; }
        public bool Is_Column_Filter_Ticket { get; set; }
        public bool Is_Column_Filter_Solution { get; set; }
        public bool Is_Clone_Ticket { get; set; }
        public bool Is_Clone_Solution { get; set; }
    }
    #endregion

    #region ClientSetting
    public class ClientSetting_Model
    {
        public long ClientSettingID { get; set; }
        public bool Is_Profile_Visible { get; set; }
        public bool Is_Ticket_Visible { get; set; }
        public bool Is_Help_Visible { get; set; }
        public bool Is_Solution_Visible { get; set; }
        public bool Is_ColumnChooser_Visible { get; set; }
        public bool Is_Search_Visible { get; set; }
        public int PageSize { get; set; }

        public bool Is_Print { get; set; }
        public bool Is_Export { get; set; }
        public bool Is_Ticket_Search { get; set; }
        public bool Is_Solution_Search { get; set; }
        public bool Is_Column_Filter_Ticket { get; set; }
        public bool Is_Column_Filter_Solution { get; set; }
        public bool Is_Clone_Ticket { get; set; }
        public bool Is_Clone_Solution { get; set; }
    }
    #endregion

    #region ApplicationSetting
    public class ApplicationSetting_Model
    {
        public long ApplicationSettingID { get; set; }
        public bool Is_EasyAddOn_Visible { get; set; }
        public string DefaultLanguage { get; set; }
        public string DefaultPassword { get; set; }
        public bool Is_Chat_Visible { get; set; }
        public bool Is_LockUser { get; set; }
        public string CompanyTitle { get; set; }
        public string CompanyLogo { get; set; }
        public IFormFile attachment { get; set; }
        public string LogoName { get; set; }
        public bool Is_Admin_Search { get; set; } //Commonn grid search in admin pages
        public bool Is_Pickup { get; set; }
        public bool Is_AssignTo_Dropdown { get; set; }
        public bool Is_Close_Ticket { get; set; }
        public bool Is_Ticket_StartPage { get; set; }
        public bool Is_EditRow_On_DoubleClick { get; set; }
    }
    #endregion

    #region Tech Autoassign
    public class Tech_Autoassign_Model
    {
        public int TechAutoAssignID { get; set; }
        public bool Is_Enable { get; set; }
        public string AutoAssign_Type { get; set; }
        public string Exclude_Users { get; set; }
    }
    #endregion

}
