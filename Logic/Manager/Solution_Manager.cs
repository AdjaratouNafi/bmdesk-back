using BMSDesk_CLI_API.Model;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace BMSDesk_CLI_API.Logic
{
    public class Solution_Manager
    {
        public static List<Solution_Model> Get_Solution_List(bool Is_Agent, long UserID)
        {
            List<Solution_Model> res = new List<Solution_Model>();
            try
            {
                SP_Get_Solution_List sp = new SP_Get_Solution_List() { Is_Agent = Is_Agent, UserID = UserID };
                res = DataManager.ExecuteSPGetList<Solution_Model, SP_Get_Solution_List>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static Solution_Model Get_Solution_ByID(long SolutionID, string DisplaySolutionID)
        {
            Solution_Model res = new Solution_Model();
            try
            {
                SP_Get_Solution_ByID sp = new SP_Get_Solution_ByID() { SolutionID = SolutionID, DisplaySolutionID = DisplaySolutionID };
                res = DataManager.ExecuteSPGetSingle<Solution_Model, SP_Get_Solution_ByID>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static Tuple<long, string> Solution_Update(Solution_Model model, List<File_Attachments> Attachments, long UserID)
        {
            Tuple<long, string> res = null;
            try
            {
                SP_Solution_Update sp = new SP_Solution_Update();
                ComUti.MapObject(model, sp);
                sp.CreatedUser = UserID;
                if (model.SolutionID > 0) { sp.UpdatedUser = UserID; sp.UpdatedDate = DateTime.Now; }

                if (!string.IsNullOrWhiteSpace(model.Description) && model.Description.Contains("form"))
                {
                    model.Description = HttpUtility.HtmlDecode(model.Description);
                    model.Description = Regex.Replace(model.Description, @"<[/]?(form)[^>]*?>", string.Empty, RegexOptions.IgnoreCase);
                }

                //sp.IPAddress = Get_IPAddress();
                DataManager.ExecuteSPNonQeury(sp);
                long SolutionID = sp.SolutionID;
                //res = sp.DisplaySolutionID;
                res = new Tuple<long, string>(SolutionID, sp.DisplaySolutionID);

                //Attachments
                //var folderPath = HostingEnvironment.MapPath("~/Attachments/Solution/");
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "Attachments/Solution/"));
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                if (SolutionID > 0)
                {
                    foreach (var item in Attachments)
                    {
                        var extension = Path.GetExtension(item.name);
                        string fileName = SolutionID.ToString() + DateTime.Now.Ticks.ToString() + extension;
                        var path = folderPath + fileName;

                        string data = item.value.Substring(item.value.IndexOf(',') + 1); //a,b,c,d
                        Byte[] bytes = Convert.FromBase64String(data);
                        File.WriteAllBytes(path, bytes);

                        SolutionAttachment_Model att_Model = new SolutionAttachment_Model();
                        att_Model.SolutionID = SolutionID;
                        att_Model.FileName = fileName;
                        att_Model.DisplayName = item.name;
                        att_Model.Extension = extension;
                        att_Model.FileSize = item.size;
                        SolutionAttachment_Insert(att_Model);
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static Tuple<long, string> Solution_Clone(long SolutionID_Old)
        {
            Tuple<long, string> res = null;
            try
            {
                var model = Get_Solution_ByID(SolutionID_Old, "");
                var objDesc = Ticket_Manager.Get_DescriptionByID(ModuleType.solution.ToString(), model.DisplaySolutionID);
                SP_Solution_Update sp = new SP_Solution_Update();
                ComUti.MapObject(model, sp);
                sp.SolutionID = 0;
                sp.Description = objDesc.Description;

                DataManager.ExecuteSPNonQeury(sp);//cloned Solution
                long SolutionID_New = sp.SolutionID;
                res = new Tuple<long, string>(SolutionID_New, sp.DisplaySolutionID);

                //var folderPath = HostingEnvironment.MapPath("~/Attachments/Solution/");
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "Attachments/Solution/"));
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                //Attachments
                var lstAtt = Get_SolutionAttachment_ByID(SolutionID_Old);
                foreach (var item in lstAtt)
                {
                    string fileName = SolutionID_New.ToString() + DateTime.Now.Ticks.ToString() + item.Extension;

                    var OldPath = folderPath + item.FileName;
                    var NewPath = folderPath + fileName;
                    File.Copy(OldPath, NewPath);

                    SolutionAttachment_Model att_Model = new SolutionAttachment_Model();
                    att_Model.SolutionID = SolutionID_New;
                    att_Model.FileName = fileName;
                    att_Model.DisplayName = item.DisplayName;
                    att_Model.Extension = item.Extension;
                    att_Model.FileSize = item.FileSize;
                    SolutionAttachment_Insert(att_Model);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static long Solution_Delete(string SolutionIDs)
        {
            long res = 0;
            try
            {
                SP_Solution_Delete sp = new SP_Solution_Delete() { SolutionIDs = SolutionIDs };
                res = DataManager.ExecuteSPNonQeury(sp);

                if (res > 0)
                {
                    var lst = Get_SolutionAttachment_ByID(res);
                    foreach (var item in lst)
                    {
                        SolutionAttachment_Delete(item.SolutionAttachmentID, item.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        //public static string Export_Solutions(List<Solution_Model_Export> model, List<string> resource, string Type)
        //{
        //    string res = "";

        //    if (Type == "excel")
        //    {
        //        res = ExportHelper.Export_Excel_String(model, resource, "Solution List");
        //    }
        //    else if (Type == "pdf")
        //    {
        //        res = ExportHelper.Export_PDF_String(model, resource);
        //    }
        //    else if (Type == "csv")
        //    {
        //        using (var ms = new MemoryStream())
        //        {
        //            ExportHelper.ToCsv(model, ms);
        //            res = Convert.ToBase64String(ms.ToArray());
        //        }
        //    }
        //    return res;
        //}

        public static Common_Solution_Detail_Model Get_Common_Solution_Detail_Data()
        {
            Common_Solution_Detail_Model res = new Common_Solution_Detail_Model();
            try
            {
                //category | subcategory | item 
                SP_Get_Solution_Detail_Data sp = new SP_Get_Solution_Detail_Data();
                var ds = DataManager.ExecuteSPDataSet(sp);
                if (ds != null && ds.Tables.Count > 0)
                {
                    res.CategoryList = ComUti.ConvertDataTable<KeyValueDefault>(ds.Tables[0]);
                    res.SubCategoryList = ComUti.ConvertDataTable<KeyValueDefault>(ds.Tables[1]);
                    res.ItemList = ComUti.ConvertDataTable<KeyValueDefault>(ds.Tables[2]);
                }

            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }


        #region Print
        public static List<Solution_Model> Get_Solution_Print(string SolutionIDs)
        {
            List<Solution_Model> res = new List<Solution_Model>();
            try
            {
                SP_Get_Print_ByModule sp = new SP_Get_Print_ByModule() { Ids = SolutionIDs, ModuleType = ModuleType.solution.ToString() };
                res = DataManager.ExecuteSPGetList<Solution_Model, SP_Get_Print_ByModule>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static List<SolutionAttachment_Model> Get_SolutionAttachments_Print(string SolutionIDs)
        {
            List<SolutionAttachment_Model> res = new List<SolutionAttachment_Model>();
            try
            {
                SP_Get_Attachment_List_ByModule sp = new SP_Get_Attachment_List_ByModule() { Ids = SolutionIDs, ModuleType = ModuleType.solution.ToString() };
                res = DataManager.ExecuteSPGetList<SolutionAttachment_Model, SP_Get_Attachment_List_ByModule>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        #endregion

        #region SolutionAttachment
        public static int SolutionAttachment_Delete(long SolutionAttachmentID, string FileName)
        {
            int res = 0;
            try
            {
                SP_SolutionAttachment_Delete sp = new SP_SolutionAttachment_Delete() { SolutionAttachmentID = SolutionAttachmentID };
                res = DataManager.ExecuteSPNonQeury(sp);
                if (res > 0)
                {
                    //var folderPath = HostingEnvironment.MapPath("~/Attachments/Solution/");
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "Attachments/Solution/"));
                    var path = folderPath + FileName;
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static List<SolutionAttachment_Model> Get_SolutionAttachment_ByID(long SolutionID)
        {
            List<SolutionAttachment_Model> res = new List<SolutionAttachment_Model>();
            try
            {
                SP_Get_SolutionAttachment_ByID sp = new SP_Get_SolutionAttachment_ByID() { SolutionID = SolutionID };
                res = DataManager.ExecuteSPGetList<SolutionAttachment_Model, SP_Get_SolutionAttachment_ByID>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static int SolutionAttachment_Insert(SolutionAttachment_Model model)
        {
            int res = 0;
            try
            {
                SP_SolutionAttachment_Insert sp = new SP_SolutionAttachment_Insert();
                ComUti.MapObject(model, sp);
                res = DataManager.ExecuteSPNonQeury(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        #endregion


    }

}
