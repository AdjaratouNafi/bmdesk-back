using BMSDesk_CLI_API.Logic;
using BMSDesk_CLI_API.Model;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BMSDesk_CLI_API.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using BMSDesk_CLI_API.Web.Helpers;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;

namespace BMSDesk_CLI_API.Web.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private IHubContext<AppHub> HubContext;
		private static IConfiguration _config;
		private static IWebHostEnvironment _env;
		public AdminController(IHttpContextAccessor accessor, IConfiguration config, IHubContext<AppHub> hubcontext, IWebHostEnvironment env)
		{
			_config = config;
			var helper = new HtmlHelpers.ClaimsModelService(accessor, config);
			HubContext = hubcontext;
			_env = env;
		}


		[HttpPost]
		public Page_Permission_Model Get_Account_Detail()
		{
			var res = User_Manager.Page_Permission(ClaimsModel.UserId);
			var Is_DemoVersion = HtmlHelpers.ClaimsModelService.GetAppSetting("Is_DemoVersion");
			if (!string.IsNullOrEmpty(Is_DemoVersion)) { res.Is_DemoVersion = Convert.ToBoolean(Is_DemoVersion); } else { res.Is_DemoVersion = false; }

			var Is_Enable_SignalR = HtmlHelpers.ClaimsModelService.GetAppSetting("Is_Enable_SignalR");
			if (!string.IsNullOrEmpty(Is_Enable_SignalR)) { res.Is_Enable_SignalR = Convert.ToBoolean(Is_Enable_SignalR); } else { res.Is_Enable_SignalR = true; }
			return res;
		}


		[HttpPost]
		public IActionResult Set_Current_Languages(dynamic obj)
		{
			CacheManager.AddToLocal(ClaimsModel.UserId.ToString(), CacheKeys.lang, (string)obj.lang, DateTime.Now.AddYears(1));
			Update_Language_Refresh((string)obj.lang, ClaimsModel.UserId);//Refresh language selection

			var jsondata = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents/Resources", (string)obj.lang + ".json")));
			var res = JsonConvert.DeserializeObject<dynamic>(jsondata);
			return Ok(res);
		}


		#region Admin Basic

		#region RequestType
		[HttpPost]
		public List<RequestType_Model> Get_RequestType_List()
		{
			var res = Admin_Basic_Manager.Get_RequestType_List();
			return res;
		}
		[HttpPost]
		public RequestType_Model Get_RequestType_ByID(dynamic obj)
		{
			var res = Admin_Basic_Manager.Get_RequestType_ByID((long)obj.RequestTypeID);
			return res;
		}
		[HttpPost]
		public long RequestType_Update(RequestType_Model model)
		{
			var res = Admin_Basic_Manager.RequestType_Update(model);
			return res;
		}
		[HttpPost]
		public long RequestType_Delete(dynamic obj)
		{
			var res = Admin_Basic_Manager.RequestType_Delete((string)obj.RequestTypeIDs);
			return res;
		}
		#endregion

		#region Category
		[HttpPost]
		public List<Category_Model> Get_Category_List()
		{
			var res = Admin_Basic_Manager.Get_Category_List();
			return res;
		}
		[HttpPost]
		public List<KeyValue> Get_Category_List_KeyValue()
		{
			var res = Admin_Basic_Manager.Get_Category_List_KeyValue();
			return res;
		}
		[HttpPost]
		public Category_Model Get_Category_ByID(dynamic obj)
		{
			var res = Admin_Basic_Manager.Get_Category_ByID((long)obj.CategoryID);
			return res;
		}
		[HttpPost]
		public long Category_Update(Category_Model model)
		{
			var res = Admin_Basic_Manager.Category_Update(model);
			return res;
		}
		[HttpPost]
		public long Category_Delete(dynamic obj)
		{
			var res = Admin_Basic_Manager.Category_Delete((string)obj.CategoryIDs);
			return res;
		}
		#endregion

		#region Status
		[HttpPost]
		public List<Status_Model> Get_Status_List()
		{
			var res = Admin_Basic_Manager.Get_Status_List();
			return res;
		}
		[HttpPost]
		public Status_Model Get_Status_ByID(dynamic obj)
		{
			var res = Admin_Basic_Manager.Get_Status_ByID((long)obj.StatusID);
			return res;
		}
		[HttpPost]
		public long Status_Update(Status_Model model)
		{
			var res = Admin_Basic_Manager.Status_Update(model);
			return res;
		}
		[HttpPost]
		public long Status_Delete(dynamic obj)
		{
			var res = Admin_Basic_Manager.Status_Delete((string)obj.StatusIDs);
			return res;
		}
		#endregion

		#region Department
		[HttpPost]
		public List<Department_Model> Get_Department_List()
		{
			var res = Admin_Basic_Manager.Get_Department_List();
			return res;
		}
		[HttpPost]
		public Department_Model Get_Department_ByID(dynamic obj)
		{
			var res = Admin_Basic_Manager.Get_Department_ByID((long)obj.DepartmentID);
			return res;
		}
		[HttpPost]
		public long Department_Update(Department_Model model)
		{
			var res = Admin_Basic_Manager.Department_Update(model);
			return res;
		}
		[HttpPost]
		public long Department_Delete(dynamic obj)
		{
			var res = Admin_Basic_Manager.Department_Delete((string)obj.DepartmentIDs);
			return res;
		}
		#endregion

		#region Impact
		[HttpPost]
		public List<Impact_Model> Get_Impact_List()
		{
			var res = Admin_Basic_Manager.Get_Impact_List();
			return res;
		}
		[HttpPost]
		public Impact_Model Get_Impact_ByID(dynamic obj)
		{
			var res = Admin_Basic_Manager.Get_Impact_ByID((long)obj.ImpactID);
			return res;
		}
		[HttpPost]
		public long Impact_Update(Impact_Model model)
		{
			var res = Admin_Basic_Manager.Impact_Update(model);
			return res;
		}
		[HttpPost]
		public long Impact_Delete(dynamic obj)
		{
			var res = Admin_Basic_Manager.Impact_Delete((string)obj.ImpactIDs);
			return res;
		}
		#endregion

		#region Level
		[HttpPost]
		public List<Level_Model> Get_Level_List()
		{
			var res = Admin_Basic_Manager.Get_Level_List();
			return res;
		}
		[HttpPost]
		public Level_Model Get_Level_ByID(dynamic obj)
		{
			var res = Admin_Basic_Manager.Get_Level_ByID((long)obj.LevelID);
			return res;
		}
		[HttpPost]
		public long Level_Update(Level_Model model)
		{
			var res = Admin_Basic_Manager.Level_Update(model);
			return res;
		}
		[HttpPost]
		public long Level_Delete(dynamic obj)
		{
			var res = Admin_Basic_Manager.Level_Delete((string)obj.LevelIDs);
			return res;
		}
		#endregion

		#region Priority
		[HttpPost]
		public List<Priority_Model> Get_Priority_List()
		{
			var res = Admin_Basic_Manager.Get_Priority_List();
			return res;
		}
		[HttpPost]
		public Priority_Model Get_Priority_ByID(dynamic obj)
		{
			var res = Admin_Basic_Manager.Get_Priority_ByID((long)obj.PriorityID);
			return res;
		}
		[HttpPost]
		public long Priority_Update(Priority_Model model)
		{
			var res = Admin_Basic_Manager.Priority_Update(model);
			return res;
		}
		[HttpPost]
		public long Priority_Delete(dynamic obj)
		{
			var res = Admin_Basic_Manager.Priority_Delete((string)obj.PriorityIDs);
			return res;
		}
		#endregion

		#region SubCategory
		[HttpPost]
		public List<SubCategory_Model> Get_SubCategory_List()
		{
			var res = Admin_Basic_Manager.Get_SubCategory_List();
			return res;
		}
		[HttpPost]
		public List<KeyValue> Get_SubCategory_List_KeyValue()
		{
			var res = Admin_Basic_Manager.Get_SubCategory_List_KeyValue(true);
			return res;
		}
		[HttpPost]
		public SubCategory_Model Get_SubCategory_ByID(dynamic obj)
		{
			var res = Admin_Basic_Manager.Get_SubCategory_ByID((long)obj.SubCategoryID);
			return res;
		}
		[HttpPost]
		public long SubCategory_Update(SubCategory_Model model)
		{
			var res = Admin_Basic_Manager.SubCategory_Update(model);
			return res;
		}
		[HttpPost]
		public long SubCategory_Delete(dynamic obj)
		{
			var res = Admin_Basic_Manager.SubCategory_Delete((string)obj.SubCategoryIDs);
			return res;
		}
		#endregion

		#region Item
		[HttpPost]
		public List<Item_Model> Get_Item_List()
		{
			var res = Admin_Basic_Manager.Get_Item_List();
			return res;
		}
		[HttpPost]
		public Item_Model Get_Item_ByID(dynamic obj)
		{
			var res = Admin_Basic_Manager.Get_Item_ByID((long)obj.ItemID);
			return res;
		}
		[HttpPost]
		public long Item_Update(Item_Model model)
		{
			var res = Admin_Basic_Manager.Item_Update(model);
			return res;
		}
		[HttpPost]
		public long Item_Delete(dynamic obj)
		{
			var res = Admin_Basic_Manager.Item_Delete((string)obj.ItemIDs);
			return res;
		}
		#endregion

		#region Location
		[HttpPost]
		public List<Location_Model> Get_Location_List()
		{
			var res = Admin_Basic_Manager.Get_Location_List();
			return res;
		}
		[HttpPost]
		public Location_Model Get_Location_ByID(dynamic obj)
		{
			var res = Admin_Basic_Manager.Get_Location_ByID((long)obj.LocationID);
			return res;
		}
		[HttpPost]
		public long Location_Update(Location_Model model)
		{
			var res = Admin_Basic_Manager.Location_Update(model);
			return res;
		}
		[HttpPost]
		public long Location_Delete(dynamic obj)
		{
			var res = Admin_Basic_Manager.Location_Delete((string)obj.LocationIDs);
			return res;
		}
		#endregion

		#region Urgency
		[HttpPost]
		public List<Urgency_Model> Get_Urgency_List()
		{
			var res = Admin_Basic_Manager.Get_Urgency_List();
			return res;
		}
		[HttpPost]
		public Urgency_Model Get_Urgency_ByID(dynamic obj)
		{
			var res = Admin_Basic_Manager.Get_Urgency_ByID((long)obj.UrgencyID);
			return res;
		}
		[HttpPost]
		public long Urgency_Update(Urgency_Model model)
		{
			var res = Admin_Basic_Manager.Urgency_Update(model);
			return res;
		}
		[HttpPost]
		public long Urgency_Delete(dynamic obj)
		{
			var res = Admin_Basic_Manager.Urgency_Delete((string)obj.UrgencyIDs);
			return res;
		}
		#endregion

		#region Notification
		[HttpPost]
		public List<Notification_Model> Get_Notification_List()
		{
			var res = Admin_Basic_Manager.Get_Notification_List();
			return res;
		}
		[HttpPost]
		public Notification_Model Get_Notification_ByID(dynamic obj)
		{
			var res = Admin_Basic_Manager.Get_Notification_ByID((long)obj.NotificationID);
			return res;
		}
		[HttpPost]
		public long Notification_Update(Notification_Model model)
		{
			var res = Admin_Basic_Manager.Notification_Update(model);
			Update_Notification_Refresh();//Refresh announcement in all login
			return res;
		}

		[HttpPost]
		public long Notification_Delete(dynamic obj)
		{
			var res = Admin_Basic_Manager.Notification_Delete((string)obj.NotificationIDs);
			Update_Notification_Refresh();//Refresh announcement in all login
			return res;
		}

		[HttpPost]
		public List<Notification_Model> Get_AnnouncementList_Client(dynamic obj)
		{
			var res = Admin_Basic_Manager.Get_AnnouncementList_Client((bool)obj.Is_Agent, (bool)obj.Is_Client);
			return res;
		}
		#endregion

		#region TicketMode       
		[HttpPost]
		public long TicketMode_Update(TicketMode_Model model)
		{
			var res = Admin_Basic_Manager.TicketMode_Update(model);
			return res;
		}
		#endregion

		[HttpPost]
		public List<KeyValue> Get_TicketCloseMode_List()
		{
			var res = Ticket_Manager.Get_TicketCloseMode_List();
			return res;
		}

		#endregion

		#region Admin Common Setting

		#region AgentSetting
		[HttpPost]
		public AgentSetting_Model Get_AgentSetting()
		{
			var res = General_Setting_Manager.Get_AgentSetting();
			return res;
		}
		[HttpPost]
		public long AgentSetting_Update(AgentSetting_Model model)
		{
			var res = General_Setting_Manager.AgentSetting_Update(model);
			Update_Page_Permission_Refresh(); //Refresh page permission in all login
			return res;
		}
		#endregion

		#region ClientSetting
		[HttpPost]
		public ClientSetting_Model Get_ClientSetting()
		{
			var res = General_Setting_Manager.Get_ClientSetting();
			return res;
		}
		[HttpPost]
		public long ClientSetting_Update(ClientSetting_Model model)
		{
			var res = General_Setting_Manager.ClientSetting_Update(model);
			Update_Page_Permission_Refresh(); //Refresh page permission in all login
			return res;
		}
		#endregion

		#region ApplicationSetting               
		[HttpPost]
		public ApplicationSetting_Model Get_ApplicationSetting()
		{
			var res = General_Setting_Manager.Get_ApplicationSetting();
			return res;
		}
		[HttpPost]
		public long ApplicationSetting_Update(ApplicationSetting_Model model)
		{
			var res = General_Setting_Manager.ApplicationSetting_Update(model);
			Update_Page_Permission_Refresh(); //Refresh page permission in all login
			Update_Language_Refresh(model.DefaultLanguage, ClaimsModel.UserId);//Refresh language selection
			return res;
		}
		[HttpPost]
		public long Logo_Update(ApplicationSetting_Model model)
		{
			var res = General_Setting_Manager.Logo_Update(model);
			Update_Page_Permission_Refresh(); //Refresh page permission in all login
			return res;
		}
		#endregion

		#region Mail Settings
		[HttpPost]
		public Outgoing_Server_Model Get_Outgoing_Server()
		{
			var res = Mail_Setting_Manager.Get_Outgoing_Server();
			return res;
		}
		[HttpPost]
		public int Update_Outgoing_Server(Outgoing_Server_Model model)
		{
			var file_name = "appsettings.json";
			if (_env.EnvironmentName.ToLower() != "development")
			{
				file_name = "appsettings." + _env.EnvironmentName + ".json";
			}
			var res = Mail_Setting_Manager.Update_Outgoing_Server(model, file_name);
			return res;
		}
		[HttpPost]
		public int Test_Outgoing_Server(Outgoing_Server_Model model)
		{
			var res = Mail_Setting_Manager.Test_Outgoing_Server(model);
			return res;
		}
		#endregion

		#region Tech Autoassign
		[HttpPost]
		public Tech_Autoassign_Model Get_TechAutoAssign()
		{
			var res = General_Setting_Manager.Get_TechAutoAssign();
			return res;
		}
		[HttpPost]
		public int Update_TechAutoAssign(Tech_Autoassign_Model model)
		{
			var res = General_Setting_Manager.Update_TechAutoAssign(model);
			return res;
		}
		#endregion


		#endregion

		#region UserManagement

		#region User

		[HttpPost]
		public int ChangePassword(dynamic obj)
		{
			var res = User_Manager.ChangePassword(ClaimsModel.UserId, (string)obj.Password);
			return res;
		}
		[HttpPost]
		public int Check_UserName_Available(dynamic obj)
		{
			var res = User_Manager.Check_UserName_Available((long)obj.UserID, (string)obj.UserName);
			return res;
		}

		[HttpPost]
		public List<User_Account_Model> Get_UserManagement_List(dynamic obj)
		{
			var res = User_Manager.Get_UserManagement_List((bool)obj.Is_Agent, (bool)obj.Is_Client);
			return res;
		}
		//[HttpPost]
		//public List<User_Account_Model> Get_Agent_Client_List(dynamic obj)
		//{
		//    var res = User_Manager.Get_UserManagement_List((bool)obj.Is_Agent, (bool)obj.Is_Active);
		//    return res;
		//}

		[HttpPost]
		public List<User_Account_Model> Get_UserSelection_List(dynamic obj)
		{
			var res = User_Manager.Get_UserSelection_List((bool)obj.Is_Agent);
			return res;
		}
		[HttpPost]
		public User_Account_Model Get_UserManagement_ByID(dynamic obj)
		{
			var res = User_Manager.Get_UserManagement_ByID((long)obj.UserID);
			return res;
		}
		[HttpPost]
		public long UserManagement_Update(User_Account_Model model)
		{
			var res = User_Manager.UserManagement_Update(model);
			Update_Page_Permission_Refresh(); //Refresh page permission in all login
			return res;
		}
		[HttpPost]
		public int UserManagement_Delete(dynamic obj)
		{
			var res = User_Manager.UserManagement_Delete((string)obj.UserIDs);
			Update_Page_Permission_Refresh(); //Refresh page permission in all login
			return res;
		}
		[HttpPost]
		public int ActiveDeActive_User(List<KeyValue> lstUsers)
		{
			var res = User_Manager.ActiveDeActive_User(lstUsers);
			Update_Page_Permission_Refresh(); //Refresh page permission in all login
			return res;
		}
		[HttpPost]
		public int ResetDefaultPassword_User(dynamic obj)
		{
			var res = User_Manager.ResetDefaultPassword_User((string)obj.UserIDs, (string)obj.DefaultPassword);
			return res;
		}

		#region Requester Profile
		[HttpPost]
		public long Requester_UserManagement_Update(User_Account_Model model)
		{
			var res = User_Manager.Requester_UserManagement_Update(model);
			Update_Page_Permission_Refresh(); //Refresh page permission in all login
			return res;
		}
		#endregion

		#endregion


		#region Roles
		[HttpPost]
		public List<KeyValue> Get_Role_List_KeyValue()
		{
			var res = User_Manager.Get_Role_List_KeyValue();
			return res;
		}
		[HttpPost]
		public List<Roles_Model> Get_Roles_List()
		{
			var res = User_Manager.Get_Roles_List();
			return res;
		}
		[HttpPost]
		public Main_Roles_Model Get_Roles_ByID(dynamic obj)
		{
			var res = User_Manager.Get_Roles_ByID((long)obj.RoleID);
			return res;
		}
		[HttpPost]
		public long Roles_Update(dynamic obj)
		{
			var res = User_Manager.Roles_Update(obj.model.ToObject<Roles_Model>(), obj.Permission_List.ToObject<List<RolePermission_Model>>());
			Update_Page_Permission_Refresh(); //Refresh page permission in all login
			return res;
		}
		[HttpPost]
		public int Roles_Delete(dynamic obj)
		{
			var res = User_Manager.Roles_Delete((string)obj.RoleIDs);
			return res;
		}
		#endregion


		#endregion

		public void Update_Page_Permission_Refresh()
		{
			try
			{
				object obj = new { UserID = ClaimsModel.UserId };
				this.HubContext.Clients.All.SendAsync("Get_Page_Permission_Refresh", obj);
			}
			catch (Exception) { }
		}
		public void Update_Language_Refresh(string lang, long UserID)
		{
			try
			{
				object obj = new { UserID = UserID, keyval = new KeyValueString { Key = lang, Value = lang } };
				this.HubContext.Clients.All.SendAsync("Get_Language_Refresh", obj);
			}
			catch (Exception) { }
		}
		public void Update_Notification_Refresh()
		{
			try
			{
				this.HubContext.Clients.All.SendAsync("Get_Notification_Refresh");
			}
			catch (Exception) { }
		}

		#region Common Export
		[HttpPost]
		public IActionResult Export_Data(dynamic obj)
		{
			PDF_Table model = new PDF_Table();
			model.list = obj.model.ToObject<List<dynamic>>();
			model.Columns = obj.Columns.ToObject<List<GridFilter>>();
			model.lstTotal = obj.lstTotal == null ? new List<dynamic>() : obj.lstTotal.ToObject<List<dynamic>>();
			model.CompanyName = obj.CompanyName != null ? (string)obj.CompanyName : "";
			model.Type = (string)obj.Type;

			string res = ComUti.Export_Data(model);
			return Ok(ComUti.Get_ApiResponse(res));
		}
		#endregion


	}

}