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
    public class Ticket_Manager
    {
        public static Dashboard_Summary_Model Get_Dashboard_Summary(bool Is_Agent, bool Is_Client, long UserID)
        {
            Dashboard_Summary_Model res = new Dashboard_Summary_Model();
            try
            {
                SP_Get_Dashboard_Summary sp = new SP_Get_Dashboard_Summary() { Is_Agent = Is_Agent, Is_Client = Is_Client, UserID = UserID };
                res = DataManager.ExecuteSPGetSingle<Dashboard_Summary_Model, SP_Get_Dashboard_Summary>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }


        public static List<Ticket_Model> Get_Ticket_List(bool Is_Agent, bool Is_Client, long UserID)
        {
            List<Ticket_Model> res = new List<Ticket_Model>();
            try
            {
                SP_Get_Ticket_List sp = new SP_Get_Ticket_List() { Is_Agent = Is_Agent, Is_Client = Is_Client, UserID = UserID };
                res = DataManager.ExecuteSPGetList<Ticket_Model, SP_Get_Ticket_List>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static Ticket_Model Get_Ticket_ByID(long TicketID, string DisplayTicketID)
        {
            Ticket_Model res = new Ticket_Model();
            try
            {
                SP_Get_Ticket_ByID sp = new SP_Get_Ticket_ByID() { TicketID = TicketID, DisplayTicketID = DisplayTicketID };
                res = DataManager.ExecuteSPGetSingle<Ticket_Model, SP_Get_Ticket_ByID>(sp);

                res.OldStatusID = res.StatusID;
                res.OldAssignedUser = res.AssignedUser;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static Tuple<long, string> Ticket_Create(Ticket_Model model, List<File_Attachments> Attachments, long UserID)
        {
            Tuple<long, string> res = null;
            try
            {
                SP_Ticket_Create sp = new SP_Ticket_Create();
                ComUti.MapObject(model, sp); //Assign model to sp class
                sp.CreatedDate = DateTime.Now;
                sp.CreatedUser = UserID;
                sp.UpdatedUser = UserID;
                sp.UpdatedDate = DateTime.Now;
                sp.RequestedUser = model.RequestedUser > 0 ? model.RequestedUser : UserID;

                var objStatus = Admin_Basic_Manager.Get_Status_ByID(model.StatusID);
                if (objStatus.Is_Closed == 1) { sp.ClosedDate = DateTime.Now; }

                if (model.AssignedUser > 0) { sp.AssignedDate = DateTime.Now; }
                else
                {
                    //Technician Auto Assign User Rule
                    var objAssignedUser = General_Setting_Manager.GetUser_ForTechAutoAssign();
                    if (objAssignedUser != null)
                    {
                        model.AssignedUserEmail = objAssignedUser.Email;
                        model.AssignedUser = (long)objAssignedUser.UserID;
                        sp.AssignedUser = objAssignedUser.UserID;
                        sp.AssignedDate = DateTime.Now;
                    }
                }


                if (!string.IsNullOrWhiteSpace(model.Description) && model.Description.Contains("form"))
                {
                    model.Description = HttpUtility.HtmlDecode(model.Description);
                    sp.Description = Regex.Replace(model.Description, @"<[/]?(form)[^>]*?>", string.Empty, RegexOptions.IgnoreCase);
                }
                if (!string.IsNullOrWhiteSpace(model.SolutionDescription) && model.SolutionDescription.Contains("form"))
                {
                    model.SolutionDescription = HttpUtility.HtmlDecode(model.SolutionDescription);
                    sp.SolutionDescription = Regex.Replace(model.SolutionDescription, @"<[/]?(form)[^>]*?>", string.Empty, RegexOptions.IgnoreCase);
                }


                //sp.IPAddress = Get_IPAddress();
                DataManager.ExecuteSPNonQeury(sp); //Call SP
                long TicketID = sp.TicketID;
                //res = sp.DisplayTicketID;
                res = new Tuple<long, string>(TicketID, sp.DisplayTicketID);

                if (TicketID > 0 && Attachments.Count > 0)
                {
                    //Attachments
                    SaveTicket_Attachments(TicketID, Attachments);
                    #region comment
                    //var folderPath = HostingEnvironment.MapPath("~/Attachments/Ticket/");
                    //if (!Directory.Exists(folderPath))
                    //{
                    //    Directory.CreateDirectory(folderPath);
                    //}

                    //foreach (var item in Attachments)
                    //{
                    //    var extension = Path.GetExtension(item.name);
                    //    string fileName = TicketID.ToString() + DateTime.Now.Ticks.ToString() + extension;
                    //    var path = folderPath + fileName;

                    //    string data = item.value.Substring(item.value.IndexOf(',') + 1); //a,b,c,d
                    //    Byte[] bytes = Convert.FromBase64String(data);
                    //    File.WriteAllBytes(path, bytes);

                    //    TicketAttachment_Model att_Model = new TicketAttachment_Model();
                    //    att_Model.TicketID = TicketID;
                    //    att_Model.FileName = fileName;
                    //    att_Model.DisplayName = item.name;
                    //    att_Model.Extension = extension;
                    //    att_Model.FileSize = item.size;
                    //    TicketAttachment_Insert(att_Model);
                    //}
                    #endregion
                }

                //Send Mail                
                //New Ticket Mail
                if (!string.IsNullOrEmpty(model.RequestedUserEmail))
                {
                    //string body = File.ReadAllText(HostingEnvironment.MapPath("~/Template/NewTicket_Email.html"));
                    string body = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "Template/NewTicket_Email.html")));
                    body = body.Replace("##USERNAME##", model.RequestedName).Replace("##TicketID##", sp.DisplayTicketID).Replace("##Description##", sp.Description);

                    var sub = "Your Ticket: #" + sp.DisplayTicketID + " - " + model.Subject;
                    var result = MailSender.SendMail(sub, body, model.RequestedUserEmail);
                }

                //Assign Ticket Mail
                if (!string.IsNullOrEmpty(model.AssignedUserEmail))
                {
                    //string body = File.ReadAllText(HostingEnvironment.MapPath("~/Template/TicketAssign_Email.html"));
                    string body = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "Template/TicketAssign_Email.html")));
                    body = body.Replace("##USERNAME##", model.AssignedName).Replace("##TicketID##", sp.DisplayTicketID).Replace("##Description##", sp.Description);

                    var sub = "Your Assign Ticket: #" + sp.DisplayTicketID + " - " + model.Subject;
                    var result = MailSender.SendMail(sub, body, model.AssignedUserEmail);
                }

            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static Tuple<long, string> Ticket_Update(Ticket_Model model, List<File_Attachments> Attachments, long UserID)
        {
            Tuple<long, string> res = null;
            try
            {
                SP_Ticket_Update sp = new SP_Ticket_Update();
                ComUti.MapObject(model, sp); //Assign model to sp class
                sp.CreatedUser = UserID;
                if (model.AssignedUser > 0 && sp.AssignedDate == null) { sp.AssignedDate = DateTime.Now; }
                sp.UpdatedUser = UserID;
                sp.UpdatedDate = DateTime.Now;

                var objStatus = Admin_Basic_Manager.Get_Status_ByID(model.StatusID);
                if (model.OldStatusID != model.StatusID)
                {
                    if (objStatus.Is_Closed == 1) { sp.ClosedDate = DateTime.Now; }
                }

                if (!string.IsNullOrWhiteSpace(model.Description) && model.Description.Contains("form"))
                {
                    model.Description = HttpUtility.HtmlDecode(model.Description);
                    sp.Description = Regex.Replace(model.Description, @"<[/]?(form)[^>]*?>", string.Empty, RegexOptions.IgnoreCase);
                }
                if (!string.IsNullOrWhiteSpace(model.SolutionDescription) && model.SolutionDescription.Contains("form"))
                {
                    model.SolutionDescription = HttpUtility.HtmlDecode(model.SolutionDescription);
                    sp.SolutionDescription = Regex.Replace(model.SolutionDescription, @"<[/]?(form)[^>]*?>", string.Empty, RegexOptions.IgnoreCase);
                }


                //sp.IPAddress = Get_IPAddress();
                DataManager.ExecuteSPNonQeury(sp); //Call SP
                long TicketID = sp.TicketID;
                //res = sp.DisplayTicketID;
                res = new Tuple<long, string>(TicketID, sp.DisplayTicketID);

                ////Update Ticket ClosedDate
                //if (model.TicketID > 0 && TicketID > 0)
                //{
                //    if (model.OldStatusID != model.StatusID)
                //    {
                //        var status = Admin_Basic_Manager.Get_Status_ByID(model.StatusID);
                //        if (status.Is_Closed == 1)
                //        {
                //            SP_Ticket_ClosedDate_Update sp1 = new SP_Ticket_ClosedDate_Update { TicketID = TicketID, ClosedDate = DateTime.Now };
                //            DataManager.ExecuteSP(sp1);
                //        }
                //    }
                //}


                if (TicketID > 0 && Attachments.Count > 0)
                {
                    //Attachments
                    SaveTicket_Attachments(TicketID, Attachments);
                    #region comment
                    //var folderPath = HostingEnvironment.MapPath("~/Attachments/Ticket/");
                    //if (!Directory.Exists(folderPath))
                    //{
                    //    Directory.CreateDirectory(folderPath);
                    //}

                    //foreach (var item in Attachments)
                    //{
                    //    var extension = Path.GetExtension(item.name);
                    //    string fileName = TicketID.ToString() + DateTime.Now.Ticks.ToString() + extension;
                    //    var path = folderPath + fileName;

                    //    string data = item.value.Substring(item.value.IndexOf(',') + 1); //a,b,c,d
                    //    Byte[] bytes = Convert.FromBase64String(data);
                    //    File.WriteAllBytes(path, bytes);

                    //    TicketAttachment_Model att_Model = new TicketAttachment_Model();
                    //    att_Model.TicketID = TicketID;
                    //    att_Model.FileName = fileName;
                    //    att_Model.DisplayName = item.name;
                    //    att_Model.Extension = extension;
                    //    att_Model.FileSize = item.size;
                    //    TicketAttachment_Insert(att_Model);
                    //}
                    #endregion
                }

                //Send Mail
                //Assign Ticket Mail
                if (model.OldAssignedUser != model.AssignedUser && model.AssignedUser > 0)
                {
                    if (!string.IsNullOrEmpty(model.AssignedUserEmail))
                    {
                        //string body = File.ReadAllText(HostingEnvironment.MapPath("~/Template/TicketAssign_Email.html"));
                        string body = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "Template/TicketAssign_Email.html")));
                        body = body.Replace("##USERNAME##", model.AssignedName).Replace("##TicketID##", sp.DisplayTicketID).Replace("##Description##", sp.Description);

                        var sub = "Your Assign Ticket: #" + sp.DisplayTicketID + " - " + model.Subject;
                        var result = MailSender.SendMail(sub, body, model.AssignedUserEmail);
                    }
                }

                //Closed Ticket Mail
                if (model.OldStatusID != model.StatusID && objStatus.Is_Closed == 1)
                {
                    if (!string.IsNullOrEmpty(model.RequestedUserEmail))
                    {
                        //string body = File.ReadAllText(HostingEnvironment.MapPath("~/Template/TicketClosed_Email.html"));
                        string body = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "Template/TicketClosed_Email.html")));
                        body = body.Replace("##USERNAME##", model.RequestedName).Replace("##TicketID##", sp.DisplayTicketID).Replace("##Description##", sp.Description).Replace("##Resolution##", sp.SolutionDescription);

                        var sub = "Your Closed Ticket: #" + sp.DisplayTicketID + " - " + model.Subject;
                        var result = MailSender.SendMail(sub, body, model.RequestedUserEmail);
                    }
                }


            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static void SaveTicket_Attachments(long TicketID, List<File_Attachments> Attachments)
        {
            //Attachments
            //var folderPath = HostingEnvironment.MapPath("~/Attachments/Ticket/");
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "Attachments/Ticket/"));
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            foreach (var item in Attachments)
            {
                var extension = Path.GetExtension(item.name);
                string fileName = TicketID.ToString() + DateTime.Now.Ticks.ToString() + extension;
                var path = folderPath + fileName;

                string data = item.value.Substring(item.value.IndexOf(',') + 1); //a,b,c,d
                Byte[] bytes = Convert.FromBase64String(data);
                File.WriteAllBytes(path, bytes);

                TicketAttachment_Model att_Model = new TicketAttachment_Model();
                att_Model.TicketID = TicketID;
                att_Model.FileName = fileName;
                att_Model.DisplayName = item.name;
                att_Model.Extension = extension;
                att_Model.FileSize = item.size;
                TicketAttachment_Insert(att_Model);
            }
        }

        public static Tuple<long, string> Ticket_Clone(long TicketID_Old)
        {
            Tuple<long, string> res = null;
            try
            {
                var model = Get_Ticket_ByID(TicketID_Old, "");
                var objDesc = Get_DescriptionByID(ModuleType.ticket.ToString(), model.DisplayTicketID);
                SP_Ticket_Clone sp = new SP_Ticket_Clone();
                ComUti.MapObject(model, sp);
                sp.TicketID = 0;
                sp.Description = objDesc.Description;
                sp.SolutionDescription = objDesc.SolutionDescription;

                int resSP = DataManager.ExecuteSPNonQeury(sp);//cloned ticket
                if (resSP > 0)
                {
                    long TicketID_New = sp.TicketID;
                    res = new Tuple<long, string>(TicketID_New, sp.DisplayTicketID);

                    //var folderPath = HostingEnvironment.MapPath("~/Attachments/Ticket/");
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "Attachments/Ticket/"));
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    //Attachments
                    if (TicketID_New > 0)
                    {
                        var lstAtt = Get_TicketAttachment_ByID(TicketID_Old);
                        foreach (var item in lstAtt)
                        {
                            string fileName = TicketID_New.ToString() + DateTime.Now.Ticks.ToString() + item.Extension;

                            var OldPath = folderPath + item.FileName;
                            var NewPath = folderPath + fileName;
                            File.Copy(OldPath, NewPath);

                            TicketAttachment_Model att_Model = new TicketAttachment_Model();
                            att_Model.TicketID = TicketID_New;
                            att_Model.FileName = fileName;
                            att_Model.DisplayName = item.DisplayName;
                            att_Model.Extension = item.Extension;
                            att_Model.FileSize = item.FileSize;
                            TicketAttachment_Insert(att_Model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }


        public static long Ticket_Delete(string TicketIDs)
        {
            long res = 0;
            try
            {
                SP_Ticket_Delete sp = new SP_Ticket_Delete() { TicketIDs = TicketIDs };
                res = DataManager.ExecuteSPNonQeury(sp);

                if (res > 0)
                {
                    var lst = Get_TicketAttachment_ByID(res);
                    foreach (var item in lst)
                    {
                        TicketAttachment_Delete(item.TicketAttachmentID, item.FileName);
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        //public static int Ticket_AssignTo_Update(string TicketIDs, long UserID)
        public static int Ticket_AssignTo_Update(List<Ticket_Model> lstTicket, AssignUser_Model objUser)
        {
            int res = 0;
            try
            {
                var TicketIDs = string.Join(",", lstTicket.Select(d => d.TicketID));
                SP_Ticket_AssignTo_Update sp = new SP_Ticket_AssignTo_Update() { TicketIDs = TicketIDs, UserID = objUser.UserID, AssignedDate = DateTime.Now };
                res = DataManager.ExecuteSPNonQeury(sp);

                if (res > 0)
                {
                    //Send Mail
                    //Assign Ticket Mail
                    foreach (var model in lstTicket)
                    {
                        if (model.AssignedUser != objUser.UserID && objUser.UserID > 0)
                        {
                            if (!string.IsNullOrEmpty(objUser.Email))
                            {
                                var desc = Get_DescriptionByID(ModuleType.ticket.ToString(), model.DisplayTicketID).Description;

                                //string body = File.ReadAllText(HostingEnvironment.MapPath("~/Template/TicketAssign_Email.html"));
                                string body = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "Template/TicketAssign_Email.html")));
                                body = body.Replace("##USERNAME##", objUser.DisplayName).Replace("##TicketID##", model.DisplayTicketID).Replace("##Description##", desc);

                                var sub = "Your Assign Ticket: #" + model.DisplayTicketID + " - " + model.Subject;
                                var result = MailSender.SendMail(sub, body, objUser.Email);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static int Ticket_Status_Update(List<Ticket_Model> lstTicket, long StatusID, long TicketCloseModeID, string StatusCloseReason)
        {
            int res = 0;
            try
            {
                var TicketIDs = string.Join(",", lstTicket.Select(d => d.TicketID));
                SP_Ticket_Status_Update sp = new SP_Ticket_Status_Update()
                {
                    TicketIDs = TicketIDs,
                    StatusID = StatusID,
                    TicketCloseModeID = TicketCloseModeID,
                    StatusCloseReason = StatusCloseReason
                };
                res = DataManager.ExecuteSPNonQeury(sp);

                if (res > 0)
                {
                    //Send Mail
                    //Closed Ticket Mail
                    foreach (var model in lstTicket)
                    {
                        //Closed Ticket Mail
                        if (model.StatusID != StatusID && !model.Is_Closed_Status)
                        {
                            if (!string.IsNullOrEmpty(model.RequestedUserEmail))
                            {
                                var objDesc = Get_DescriptionByID(ModuleType.ticket.ToString(), model.DisplayTicketID);

                                //string body = File.ReadAllText(HostingEnvironment.MapPath("~/Template/TicketClosed_Email.html"));
                                string body = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "Template/TicketClosed_Email.html")));
                                body = body.Replace("##USERNAME##", model.RequestedName).Replace("##TicketID##", model.DisplayTicketID).Replace("##Description##", objDesc.Description).Replace("##Resolution##", objDesc.SolutionDescription);

                                var sub = "Your Closed Ticket: #" + model.DisplayTicketID + " - " + model.Subject;
                                var result = MailSender.SendMail(sub, body, model.RequestedUserEmail);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static List<KeyValue> Get_TicketCloseMode_List()
        {
            List<KeyValue> res = new List<KeyValue>();
            try
            {
                SP_Get_TicketCloseMode_List sp = new SP_Get_TicketCloseMode_List();
                res = DataManager.ExecuteSPGetList<KeyValue, SP_Get_TicketCloseMode_List>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        //public static string Export_Tickets(List<Ticket_Model_Export> model, List<string> resource, string Type)
        //{
        //    string res = "";

        //    if (Type == "excel")
        //    {
        //        res = ExportHelper.Export_Excel_String(model, resource, "Ticket List");
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

        public static Common_Ticket_Detail_Model Get_Common_Ticket_Detail_Data(bool Is_Agent)
        {
            Common_Ticket_Detail_Model res = new Common_Ticket_Detail_Model();
            try
            {
                //status | priority | category | subcategory | item | urgency | impact | department | level | location | ticketmode | requesttype	
                SP_Get_Ticket_Detail_Data sp = new SP_Get_Ticket_Detail_Data() { Is_Agent = Is_Agent };
                var ds = DataManager.ExecuteSPDataSet(sp);
                if (ds != null && ds.Tables.Count > 0)
                {
                    res.StatusList = ComUti.ConvertDataTable<KeyValueDefault>(ds.Tables[0]);
                    res.PriorityList = ComUti.ConvertDataTable<KeyValueDefault>(ds.Tables[1]);
                    res.CategoryList = ComUti.ConvertDataTable<KeyValueDefault>(ds.Tables[2]);
                    res.SubCategoryList = ComUti.ConvertDataTable<KeyValueDefault>(ds.Tables[3]);
                    res.ItemList = ComUti.ConvertDataTable<KeyValueDefault>(ds.Tables[4]);
                    res.UrgencyList = ComUti.ConvertDataTable<KeyValueDefault>(ds.Tables[5]);
                    res.ImpactList = ComUti.ConvertDataTable<KeyValueDefault>(ds.Tables[6]);
                    res.DepartmentList = ComUti.ConvertDataTable<KeyValueDefault>(ds.Tables[7]);
                    res.LevelList = ComUti.ConvertDataTable<KeyValueDefault>(ds.Tables[8]);
                    res.LocationList = ComUti.ConvertDataTable<KeyValueDefault>(ds.Tables[9]);
                    res.TicketModeList = ComUti.ConvertDataTable<KeyValueDefault>(ds.Tables[10]);
                    res.RequestTypeList = ComUti.ConvertDataTable<KeyValueDefault>(ds.Tables[11]);
                }

            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static long Set_Ticket_FCR(long TicketID, bool Is_FCR)
        {
            long res = 0;
            try
            {
                SP_Set_Ticket_FCR sp = new SP_Set_Ticket_FCR() { TicketID = TicketID, Is_FCR = Is_FCR };
                res = DataManager.ExecuteSPNonQeury(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static Description_Model Get_DescriptionByID(string ModuleType, string DisplayID) //ID = DisplayTicketID OR DisplaySolutionID
        {
            Description_Model res = new Description_Model();
            try
            {
                SP_Get_DescriptionByID sp = new SP_Get_DescriptionByID() { ModuleType = ModuleType, ID = DisplayID };
                res = DataManager.ExecuteSPGetSingle<Description_Model, SP_Get_DescriptionByID>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }


        #region Print
        public static List<Ticket_Model> Get_Ticket_Print(string TicketIds)
        {
            List<Ticket_Model> res = new List<Ticket_Model>();
            try
            {
                SP_Get_Print_ByModule sp = new SP_Get_Print_ByModule() { Ids = TicketIds, ModuleType = ModuleType.ticket.ToString() };
                res = DataManager.ExecuteSPGetList<Ticket_Model, SP_Get_Print_ByModule>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static List<TicketAttachment_Model> Get_TicketAttachments_Print(string TicketIds)
        {
            List<TicketAttachment_Model> res = new List<TicketAttachment_Model>();
            try
            {
                SP_Get_Attachment_List_ByModule sp = new SP_Get_Attachment_List_ByModule() { Ids = TicketIds, ModuleType = ModuleType.ticket.ToString() };
                res = DataManager.ExecuteSPGetList<TicketAttachment_Model, SP_Get_Attachment_List_ByModule>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        #endregion

        #region TicketAttachment
        public static int TicketAttachment_Delete(long TicketAttachmentID, string FileName)
        {
            int res = 0;
            try
            {
                SP_TicketAttachment_Delete sp = new SP_TicketAttachment_Delete() { TicketAttachmentID = TicketAttachmentID };
                res = DataManager.ExecuteSPNonQeury(sp);
                if (res > 0)
                {
                    //var folderPath = HostingEnvironment.MapPath("~/Attachments/Ticket/");
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "Attachments/Ticket/"));
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
        public static List<TicketAttachment_Model> Get_TicketAttachment_ByID(long TicketID)
        {
            List<TicketAttachment_Model> res = new List<TicketAttachment_Model>();
            try
            {
                SP_Get_TicketAttachment_ByID sp = new SP_Get_TicketAttachment_ByID() { TicketID = TicketID };
                res = DataManager.ExecuteSPGetList<TicketAttachment_Model, SP_Get_TicketAttachment_ByID>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static int TicketAttachment_Insert(TicketAttachment_Model model)
        {
            int res = 0;
            try
            {
                SP_TicketAttachment_Insert sp = new SP_TicketAttachment_Insert();
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

        #region Ticket Chat
        public static List<TicketChat_Model> Get_TicketChat(long TicketID)
        {
            List<TicketChat_Model> res = new List<TicketChat_Model>();
            try
            {
                SP_TicketChat_CRUD sp = new SP_TicketChat_CRUD()
                {
                    action = SP_Action_Type.list.ToString(),
                    TicketID = TicketID
                };
                sp.action = SP_Action_Type.list.ToString();
                res = DataManager.ExecuteSPGetList<TicketChat_Model, SP_TicketChat_CRUD>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static TicketChat_Model Get_TicketChat_ByID(long TicketChatID)
        {
            TicketChat_Model res = new TicketChat_Model();
            try
            {
                SP_TicketChat_CRUD sp = new SP_TicketChat_CRUD() { TicketChatID = TicketChatID };
                sp.action = SP_Action_Type.get.ToString();
                res = DataManager.ExecuteSPGetSingle<TicketChat_Model, SP_TicketChat_CRUD>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static long TicketChat_Update(TicketChat_Model model)
        {
            long res = 0;
            try
            {
                SP_TicketChat_CRUD sp = new SP_TicketChat_CRUD();
                ComUti.MapObject(model, sp);
                sp.action = SP_Action_Type.update.ToString();
                sp.UserID = ClaimsModel.UserId;
                DataManager.ExecuteSPNonQeury(sp);
                res = sp.TicketChatID;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        public static long TicketChat_Delete(long TicketChatID)
        {
            long res = 0;
            try
            {
                SP_TicketChat_CRUD sp = new SP_TicketChat_CRUD() { TicketChatID = TicketChatID };
                sp.action = SP_Action_Type.delete.ToString();
                res = DataManager.ExecuteSPNonQeury(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }
        #endregion


        #region Requester
        public static Tuple<long, string> Ticket_Requester_Create(Ticket_Model model, List<File_Attachments> Attachments, long UserID, string RequestedName, string RequestedUserEmail)
        {
            Tuple<long, string> res = null;
            try
            {
                SP_Ticket_Requester_Create sp = new SP_Ticket_Requester_Create();
                ComUti.MapObject(model, sp);
                sp.CreatedUser = UserID;
                sp.CreatedDate = DateTime.Now;
                sp.UpdatedUser = UserID; sp.UpdatedDate = DateTime.Now;
                sp.RequestedUser = model.RequestedUser > 0 ? model.RequestedUser : UserID;

                var objStatus = Admin_Basic_Manager.Get_Status_ByID(model.StatusID);
                if (objStatus.Is_Closed == 1) { sp.ClosedDate = DateTime.Now; }

                if (model.AssignedUser > 0) { sp.AssignedDate = DateTime.Now; }
                else
                {
                    //Technician Auto Assign User Rule
                    var objAssignedUser = General_Setting_Manager.GetUser_ForTechAutoAssign();
                    if (objAssignedUser != null)
                    {
                        model.AssignedUserEmail = objAssignedUser.Email;
                        model.AssignedUser = (long)objAssignedUser.UserID;
                        sp.AssignedUser = objAssignedUser.UserID;
                        sp.AssignedDate = DateTime.Now;
                    }
                }


                if (!string.IsNullOrWhiteSpace(model.Description) && model.Description.Contains("form"))
                {
                    model.Description = HttpUtility.HtmlDecode(model.Description);
                    sp.Description = Regex.Replace(model.Description, @"<[/]?(form)[^>]*?>", string.Empty, RegexOptions.IgnoreCase);
                }
                if (!string.IsNullOrWhiteSpace(model.SolutionDescription) && model.SolutionDescription.Contains("form"))
                {
                    model.SolutionDescription = HttpUtility.HtmlDecode(model.SolutionDescription);
                    sp.SolutionDescription = Regex.Replace(model.SolutionDescription, @"<[/]?(form)[^>]*?>", string.Empty, RegexOptions.IgnoreCase);
                }

                //sp.IPAddress = Get_IPAddress();
                DataManager.ExecuteSPNonQeury(sp); //Call sp 
                long TicketID = sp.TicketID;
                //res = sp.DisplayTicketID;
                res = new Tuple<long, string>(TicketID, sp.DisplayTicketID);

                if (TicketID > 0 && Attachments.Count > 0)
                {
                    //Attachments
                    SaveTicket_Attachments(TicketID, Attachments);
                    #region comment
                    //var folderPath = HostingEnvironment.MapPath("~/Attachments/Ticket/");
                    //if (!Directory.Exists(folderPath))
                    //{
                    //    Directory.CreateDirectory(folderPath);
                    //}
                    //foreach (var item in Attachments)
                    //{
                    //    var extension = Path.GetExtension(item.name);
                    //    string fileName = TicketID.ToString() + DateTime.Now.Ticks.ToString() + extension;
                    //    var path = folderPath + fileName;

                    //    string data = item.value.Substring(item.value.IndexOf(',') + 1); //a,b,c,d
                    //    Byte[] bytes = Convert.FromBase64String(data);
                    //    File.WriteAllBytes(path, bytes);

                    //    TicketAttachment_Model att_Model = new TicketAttachment_Model();
                    //    att_Model.TicketID = TicketID;
                    //    att_Model.FileName = fileName;
                    //    att_Model.DisplayName = item.name;
                    //    att_Model.Extension = extension;
                    //    att_Model.FileSize = item.size;
                    //    TicketAttachment_Insert(att_Model);
                    //}
                    #endregion
                }

                //Send Mail                
                //New Ticket Mail
                model.RequestedUserEmail = RequestedUserEmail;
                model.RequestedName = RequestedName;
                if (!string.IsNullOrEmpty(model.RequestedUserEmail))
                {
                    //string body = File.ReadAllText(HostingEnvironment.MapPath("~/Template/NewTicket_Email.html"));
                    string body = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "Template/NewTicket_Email.html")));
                    body = body.Replace("##USERNAME##", model.RequestedName).Replace("##TicketID##", sp.DisplayTicketID).Replace("##Description##", sp.Description);

                    var sub = "Your Ticket: #" + sp.DisplayTicketID + " - " + model.Subject;
                    var result = MailSender.SendMail(sub, body, model.RequestedUserEmail);
                }
                //Assign Ticket Mail
                if (!string.IsNullOrEmpty(model.AssignedUserEmail))
                {
                    //string body = File.ReadAllText(HostingEnvironment.MapPath("~/Template/TicketAssign_Email.html"));
                    string body = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "Template/TicketAssign_Email.html")));
                    body = body.Replace("##USERNAME##", model.AssignedName).Replace("##TicketID##", sp.DisplayTicketID).Replace("##Description##", sp.Description);

                    var sub = "Your Assign Ticket: #" + sp.DisplayTicketID + " - " + model.Subject;
                    var result = MailSender.SendMail(sub, body, model.AssignedUserEmail);
                }

            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static Tuple<long, string> Ticket_Requester_Update(Ticket_Model model, List<File_Attachments> Attachments, long UserID)
        {
            Tuple<long, string> res = null;
            try
            {
                SP_Ticket_Requester_Update sp = new SP_Ticket_Requester_Update();
                ComUti.MapObject(model, sp);
                sp.CreatedUser = UserID;
                if (model.AssignedUser > 0 && sp.AssignedDate == null) { sp.AssignedDate = DateTime.Now; }
                sp.UpdatedUser = UserID;
                sp.UpdatedDate = DateTime.Now;

                if (!string.IsNullOrWhiteSpace(model.Description) && model.Description.Contains("form"))
                {
                    model.Description = HttpUtility.HtmlDecode(model.Description);
                    sp.Description = Regex.Replace(model.Description, @"<[/]?(form)[^>]*?>", string.Empty, RegexOptions.IgnoreCase);
                }
                if (!string.IsNullOrWhiteSpace(model.SolutionDescription) && model.SolutionDescription.Contains("form"))
                {
                    model.SolutionDescription = HttpUtility.HtmlDecode(model.SolutionDescription);
                    sp.SolutionDescription = Regex.Replace(model.SolutionDescription, @"<[/]?(form)[^>]*?>", string.Empty, RegexOptions.IgnoreCase);
                }

                //sp.IPAddress = Get_IPAddress();
                DataManager.ExecuteSPNonQeury(sp);
                long TicketID = sp.TicketID;
                //res = sp.DisplayTicketID;
                res = new Tuple<long, string>(TicketID, sp.DisplayTicketID);


                if (TicketID > 0 && Attachments.Count > 0)
                {
                    //Attachments
                    SaveTicket_Attachments(TicketID, Attachments);
                    #region comment
                    //var folderPath = HostingEnvironment.MapPath("~/Attachments/Ticket/");
                    //if (!Directory.Exists(folderPath))
                    //{
                    //    Directory.CreateDirectory(folderPath);
                    //}

                    //foreach (var item in Attachments)
                    //{
                    //    var extension = Path.GetExtension(item.name);
                    //    string fileName = TicketID.ToString() + DateTime.Now.Ticks.ToString() + extension;
                    //    var path = folderPath + fileName;

                    //    string data = item.value.Substring(item.value.IndexOf(',') + 1); //a,b,c,d
                    //    Byte[] bytes = Convert.FromBase64String(data);
                    //    File.WriteAllBytes(path, bytes);

                    //    TicketAttachment_Model att_Model = new TicketAttachment_Model();
                    //    att_Model.TicketID = TicketID;
                    //    att_Model.FileName = fileName;
                    //    att_Model.DisplayName = item.name;
                    //    att_Model.Extension = extension;
                    //    att_Model.FileSize = item.size;
                    //    TicketAttachment_Insert(att_Model);
                    //}
                    #endregion
                }


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
