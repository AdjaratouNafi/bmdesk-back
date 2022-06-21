using BMSDesk_CLI_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BMSDesk_CLI_API.Logic
{
    public class Admin_Basic_Manager
    {
        #region Admin Basic

        #region RequestType
        public static List<RequestType_Model> Get_RequestType_List()
        {
            List<RequestType_Model> res = new List<RequestType_Model>();
            try
            {
                SP_Get_RequestType_List sp = new SP_Get_RequestType_List();
                res = DataManager.ExecuteSPGetList<RequestType_Model, SP_Get_RequestType_List>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static RequestType_Model Get_RequestType_ByID(long RequestTypeID)
        {
            RequestType_Model res = new RequestType_Model();
            try
            {
                SP_Get_RequestType_ByID sp = new SP_Get_RequestType_ByID() { RequestTypeID = RequestTypeID };
                res = DataManager.ExecuteSPGetSingle<RequestType_Model, SP_Get_RequestType_ByID>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static long RequestType_Update(RequestType_Model model)
        {
            long res = 0;
            try
            {
                SP_RequestType_Update sp = new SP_RequestType_Update();
                ComUti.MapObject(model, sp);
                DataManager.ExecuteSPNonQeury(sp);
                res = sp.RequestTypeID;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static int RequestType_Delete(string RequestTypeIDs)
        {
            int res = 0;
            try
            {
                SP_RequestType_Delete sp = new SP_RequestType_Delete() { RequestTypeIDs = RequestTypeIDs };
                res = DataManager.ExecuteSPNonQeury(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        #endregion


        #region Category
        public static List<Category_Model> Get_Category_List()
        {
            List<Category_Model> res = new List<Category_Model>();
            try
            {
                SP_Get_Category_List sp = new SP_Get_Category_List();
                res = DataManager.ExecuteSPGetList<Category_Model, SP_Get_Category_List>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static List<KeyValue> Get_Category_List_KeyValue()
        {
            List<KeyValue> res = new List<KeyValue>();
            try
            {
                SP_Get_Category_List_KeyValue sp = new SP_Get_Category_List_KeyValue();
                res = DataManager.ExecuteSPGetList<KeyValue, SP_Get_Category_List_KeyValue>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static Category_Model Get_Category_ByID(long CategoryID)
        {
            Category_Model res = new Category_Model();
            try
            {
                SP_Get_Category_ByID sp = new SP_Get_Category_ByID() { CategoryID = CategoryID };
                res = DataManager.ExecuteSPGetSingle<Category_Model, SP_Get_Category_ByID>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static long Category_Update(Category_Model model)
        {
            long res = 0;
            try
            {
                SP_Category_Update sp = new SP_Category_Update();
                ComUti.MapObject(model, sp);
                DataManager.ExecuteSPNonQeury(sp);
                res = sp.CategoryID;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static int Category_Delete(string CategoryIDs)
        {
            int res = 0;
            try
            {
                SP_Category_Delete sp = new SP_Category_Delete() { CategoryIDs = CategoryIDs };
                res = DataManager.ExecuteSPNonQeury(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        #endregion

        #region Status
        public static List<Status_Model> Get_Status_List()
        {
            List<Status_Model> res = new List<Status_Model>();
            try
            {
                SP_Get_Status_List sp = new SP_Get_Status_List();
                res = DataManager.ExecuteSPGetList<Status_Model, SP_Get_Status_List>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static Status_Model Get_Status_ByID(long? StatusID)
        {
            Status_Model res = new Status_Model();
            try
            {
                SP_Get_Status_ByID sp = new SP_Get_Status_ByID() { StatusID = Convert.ToInt32(StatusID) };
                res = DataManager.ExecuteSPGetSingle<Status_Model, SP_Get_Status_ByID>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static long Status_Update(Status_Model model)
        {
            long res = 0;
            try
            {
                SP_Status_Update sp = new SP_Status_Update();
                ComUti.MapObject(model, sp);
                DataManager.ExecuteSPNonQeury(sp);
                res = sp.StatusID;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static int Status_Delete(string StatusIDs)
        {
            int res = 0;
            try
            {
                SP_Status_Delete sp = new SP_Status_Delete() { StatusIDs = StatusIDs };
                res = DataManager.ExecuteSPNonQeury(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        #endregion

        #region Department
        public static List<Department_Model> Get_Department_List()
        {
            List<Department_Model> res = new List<Department_Model>();
            try
            {
                SP_Get_Department_List sp = new SP_Get_Department_List();
                res = DataManager.ExecuteSPGetList<Department_Model, SP_Get_Department_List>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static Department_Model Get_Department_ByID(long DepartmentID)
        {
            Department_Model res = new Department_Model();
            try
            {
                SP_Get_Department_ByID sp = new SP_Get_Department_ByID() { DepartmentID = DepartmentID };
                res = DataManager.ExecuteSPGetSingle<Department_Model, SP_Get_Department_ByID>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static long Department_Update(Department_Model model)
        {
            long res = 0;
            try
            {
                SP_Department_Update sp = new SP_Department_Update();
                ComUti.MapObject(model, sp);
                DataManager.ExecuteSPNonQeury(sp);
                res = sp.DepartmentID;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static int Department_Delete(string DepartmentIDs)
        {
            int res = 0;
            try
            {
                SP_Department_Delete sp = new SP_Department_Delete() { DepartmentIDs = DepartmentIDs };
                res = DataManager.ExecuteSPNonQeury(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        #endregion

        #region Impact
        public static List<Impact_Model> Get_Impact_List()
        {
            List<Impact_Model> res = new List<Impact_Model>();
            try
            {
                SP_Get_Impact_List sp = new SP_Get_Impact_List();
                res = DataManager.ExecuteSPGetList<Impact_Model, SP_Get_Impact_List>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static Impact_Model Get_Impact_ByID(long ImpactID)
        {
            Impact_Model res = new Impact_Model();
            try
            {
                SP_Get_Impact_ByID sp = new SP_Get_Impact_ByID() { ImpactID = ImpactID };
                res = DataManager.ExecuteSPGetSingle<Impact_Model, SP_Get_Impact_ByID>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static long Impact_Update(Impact_Model model)
        {
            long res = 0;
            try
            {
                SP_Impact_Update sp = new SP_Impact_Update();
                ComUti.MapObject(model, sp);
                DataManager.ExecuteSPNonQeury(sp);
                res = sp.ImpactID;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static int Impact_Delete(string ImpactIDs)
        {
            int res = 0;
            try
            {
                SP_Impact_Delete sp = new SP_Impact_Delete() { ImpactIDs = ImpactIDs };
                res = DataManager.ExecuteSPNonQeury(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        #endregion

        #region Level
        public static List<Level_Model> Get_Level_List()
        {
            List<Level_Model> res = new List<Level_Model>();
            try
            {
                SP_Get_Level_List sp = new SP_Get_Level_List();
                res = DataManager.ExecuteSPGetList<Level_Model, SP_Get_Level_List>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static Level_Model Get_Level_ByID(long LevelID)
        {
            Level_Model res = new Level_Model();
            try
            {
                SP_Get_Level_ByID sp = new SP_Get_Level_ByID() { LevelID = LevelID };
                res = DataManager.ExecuteSPGetSingle<Level_Model, SP_Get_Level_ByID>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static long Level_Update(Level_Model model)
        {
            long res = 0;
            try
            {
                SP_Level_Update sp = new SP_Level_Update();
                ComUti.MapObject(model, sp);
                DataManager.ExecuteSPNonQeury(sp);
                res = sp.LevelID;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static int Level_Delete(string LevelIDs)
        {
            int res = 0;
            try
            {
                SP_Level_Delete sp = new SP_Level_Delete() { LevelIDs = LevelIDs };
                res = DataManager.ExecuteSPNonQeury(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        #endregion

        #region Priority
        public static List<Priority_Model> Get_Priority_List()
        {
            List<Priority_Model> res = new List<Priority_Model>();
            try
            {
                SP_Get_Priority_List sp = new SP_Get_Priority_List();
                res = DataManager.ExecuteSPGetList<Priority_Model, SP_Get_Priority_List>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static Priority_Model Get_Priority_ByID(long PriorityID)
        {
            Priority_Model res = new Priority_Model();
            try
            {
                SP_Get_Priority_ByID sp = new SP_Get_Priority_ByID() { PriorityID = PriorityID };
                res = DataManager.ExecuteSPGetSingle<Priority_Model, SP_Get_Priority_ByID>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static long Priority_Update(Priority_Model model)
        {
            long res = 0;
            try
            {
                SP_Priority_Update sp = new SP_Priority_Update();
                ComUti.MapObject(model, sp);
                DataManager.ExecuteSPNonQeury(sp);
                res = sp.PriorityID;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static int Priority_Delete(string PriorityIDs)
        {
            int res = 0;
            try
            {
                SP_Priority_Delete sp = new SP_Priority_Delete() { PriorityIDs = PriorityIDs };
                res = DataManager.ExecuteSPNonQeury(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        #endregion

        #region SubCategory
        public static List<SubCategory_Model> Get_SubCategory_List()
        {
            List<SubCategory_Model> res = new List<SubCategory_Model>();
            try
            {
                SP_Get_SubCategory_List sp = new SP_Get_SubCategory_List();
                res = DataManager.ExecuteSPGetList<SubCategory_Model, SP_Get_SubCategory_List>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static List<KeyValue> Get_SubCategory_List_KeyValue(bool Is_Admin = false)
        {
            List<KeyValue> res = new List<KeyValue>();
            try
            {
                SP_Get_SubCategory_List_KeyValue sp = new SP_Get_SubCategory_List_KeyValue() { Is_Admin = Is_Admin };
                res = DataManager.ExecuteSPGetList<KeyValue, SP_Get_SubCategory_List_KeyValue>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }


        public static SubCategory_Model Get_SubCategory_ByID(long SubCategoryID)
        {
            SubCategory_Model res = new SubCategory_Model();
            try
            {
                SP_Get_SubCategory_ByID sp = new SP_Get_SubCategory_ByID() { SubCategoryID = SubCategoryID };
                res = DataManager.ExecuteSPGetSingle<SubCategory_Model, SP_Get_SubCategory_ByID>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static long SubCategory_Update(SubCategory_Model model)
        {
            long res = 0;
            try
            {
                SP_SubCategory_Update sp = new SP_SubCategory_Update();
                ComUti.MapObject(model, sp);
                DataManager.ExecuteSPNonQeury(sp);
                res = sp.SubCategoryID;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static int SubCategory_Delete(string SubCategoryIDs)
        {
            int res = 0;
            try
            {
                SP_SubCategory_Delete sp = new SP_SubCategory_Delete() { SubCategoryIDs = SubCategoryIDs };
                res = DataManager.ExecuteSPNonQeury(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        #endregion

        #region Item
        public static List<Item_Model> Get_Item_List()
        {
            List<Item_Model> res = new List<Item_Model>();
            try
            {
                SP_Get_Item_List sp = new SP_Get_Item_List();
                res = DataManager.ExecuteSPGetList<Item_Model, SP_Get_Item_List>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static Item_Model Get_Item_ByID(long ItemID)
        {
            Item_Model res = new Item_Model();
            try
            {
                SP_Get_Item_ByID sp = new SP_Get_Item_ByID() { ItemID = ItemID };
                res = DataManager.ExecuteSPGetSingle<Item_Model, SP_Get_Item_ByID>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static long Item_Update(Item_Model model)
        {
            long res = 0;
            try
            {
                SP_Item_Update sp = new SP_Item_Update();
                ComUti.MapObject(model, sp);
                DataManager.ExecuteSPNonQeury(sp);
                res = sp.ItemID;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static int Item_Delete(string ItemIDs)
        {
            int res = 0;
            try
            {
                SP_Item_Delete sp = new SP_Item_Delete() { ItemIDs = ItemIDs };
                res = DataManager.ExecuteSPNonQeury(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        #endregion

        #region Location
        public static List<Location_Model> Get_Location_List()
        {
            List<Location_Model> res = new List<Location_Model>();
            try
            {
                SP_Get_Location_List sp = new SP_Get_Location_List();
                res = DataManager.ExecuteSPGetList<Location_Model, SP_Get_Location_List>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static Location_Model Get_Location_ByID(long LocationID)
        {
            Location_Model res = new Location_Model();
            try
            {
                SP_Get_Location_ByID sp = new SP_Get_Location_ByID() { LocationID = LocationID };
                res = DataManager.ExecuteSPGetSingle<Location_Model, SP_Get_Location_ByID>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static long Location_Update(Location_Model model)
        {
            long res = 0;
            try
            {
                SP_Location_Update sp = new SP_Location_Update();
                ComUti.MapObject(model, sp);
                DataManager.ExecuteSPNonQeury(sp);
                res = sp.LocationID;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static int Location_Delete(string LocationIDs)
        {
            int res = 0;
            try
            {
                SP_Location_Delete sp = new SP_Location_Delete() { LocationIDs = LocationIDs };
                res = DataManager.ExecuteSPNonQeury(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        #endregion

        #region Urgency
        public static List<Urgency_Model> Get_Urgency_List()
        {
            List<Urgency_Model> res = new List<Urgency_Model>();
            try
            {
                SP_Get_Urgency_List sp = new SP_Get_Urgency_List();
                res = DataManager.ExecuteSPGetList<Urgency_Model, SP_Get_Urgency_List>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static Urgency_Model Get_Urgency_ByID(long UrgencyID)
        {
            Urgency_Model res = new Urgency_Model();
            try
            {
                SP_Get_Urgency_ByID sp = new SP_Get_Urgency_ByID() { UrgencyID = UrgencyID };
                res = DataManager.ExecuteSPGetSingle<Urgency_Model, SP_Get_Urgency_ByID>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static long Urgency_Update(Urgency_Model model)
        {
            long res = 0;
            try
            {
                SP_Urgency_Update sp = new SP_Urgency_Update();
                ComUti.MapObject(model, sp);
                DataManager.ExecuteSPNonQeury(sp);
                res = sp.UrgencyID;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static int Urgency_Delete(string UrgencyIDs)
        {
            int res = 0;
            try
            {
                SP_Urgency_Delete sp = new SP_Urgency_Delete() { UrgencyIDs = UrgencyIDs };
                res = DataManager.ExecuteSPNonQeury(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        #endregion

        #region Notification
        public static List<Notification_Model> Get_Notification_List()
        {
            List<Notification_Model> res = new List<Notification_Model>();
            try
            {
                SP_Get_Notification_List sp = new SP_Get_Notification_List();
                res = DataManager.ExecuteSPGetList<Notification_Model, SP_Get_Notification_List>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static Notification_Model Get_Notification_ByID(long NotificationID)
        {
            Notification_Model res = new Notification_Model();
            try
            {
                SP_Get_Notification_ByID sp = new SP_Get_Notification_ByID() { NotificationID = NotificationID };
                res = DataManager.ExecuteSPGetSingle<Notification_Model, SP_Get_Notification_ByID>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static long Notification_Update(Notification_Model model)
        {
            long res = 0;
            try
            {
                SP_Notification_Update sp = new SP_Notification_Update();
                ComUti.MapObject(model, sp);
                sp.Description = WebUtility.HtmlDecode(model.Description);
                DataManager.ExecuteSPNonQeury(sp);
                res = sp.NotificationID;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static int Notification_Delete(string NotificationIDs)
        {
            int res = 0;
            try
            {
                SP_Notification_Delete sp = new SP_Notification_Delete() { NotificationIDs = NotificationIDs };
                res = DataManager.ExecuteSPNonQeury(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }


        public static List<Notification_Model> Get_AnnouncementList_Client(bool Is_Agent, bool Is_Client)
        {
            List<Notification_Model> res = new List<Notification_Model>();
            try
            {
                SP_Get_AnnouncementList_Client sp = new SP_Get_AnnouncementList_Client() { Is_Agent = Is_Agent, Is_Client = Is_Client };
                res = DataManager.ExecuteSPGetList<Notification_Model, SP_Get_AnnouncementList_Client>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        #endregion

        #region TicketMode
        public static long TicketMode_Update(TicketMode_Model model)
        {
            long res = 0;
            try
            {
                SP_TicketMode_Update sp = new SP_TicketMode_Update();
                ComUti.MapObject(model, sp);
                DataManager.ExecuteSPNonQeury(sp);
                res = sp.TicketModeID;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        #endregion

        #endregion

    }
}
