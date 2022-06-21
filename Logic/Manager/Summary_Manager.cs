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
    public class Summary_Manager
    {

        public static List<TicketCount_ByType_Model> Get_TicketCount_ByType(bool Is_Agent, bool Is_Client, string Type, long UserID, string FromDate, string ToDate)
        {
            List<TicketCount_ByType_Model> res = new List<TicketCount_ByType_Model>();
            try
            {
                SP_Get_TicketCount_ByType sp = new SP_Get_TicketCount_ByType()
                {
                    Is_Agent = Is_Agent,
                    Is_Client = Is_Client,
                    Type = Type,
                    UserID = UserID,
                    FromDate = FromDate,
                    ToDate = ToDate,
                };
                res = DataManager.ExecuteSPGetList<TicketCount_ByType_Model, SP_Get_TicketCount_ByType>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static List<TicketCount_ByType_Model> Get_TicketSummary_ByType(bool Is_Agent, bool Is_Client, string Type, long UserID)
        {
            List<TicketCount_ByType_Model> res = new List<TicketCount_ByType_Model>();
            try
            {
                SP_Get_TicketSummary_ByType sp = new SP_Get_TicketSummary_ByType()
                {
                    Is_Agent = Is_Agent,
                    Is_Client = Is_Client,
                    Type = Type,
                    UserID = UserID
                };
                res = DataManager.ExecuteSPGetList<TicketCount_ByType_Model, SP_Get_TicketSummary_ByType>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static List<TicketReceived_ByDays_Model> Get_TicketReceived_ByDays(bool Is_Agent, bool Is_Client, string Type, int Days, long UserID)
        {
            List<TicketReceived_ByDays_Model> res = new List<TicketReceived_ByDays_Model>();
            try
            {
                SP_Get_TicketReceived_ByDays sp = new SP_Get_TicketReceived_ByDays()
                {
                    Is_Agent = Is_Agent,
                    Is_Client = Is_Client,
                    Type = Type,
                    Days = Days,
                    UserID = UserID
                };
                res = DataManager.ExecuteSPGetList<TicketReceived_ByDays_Model, SP_Get_TicketReceived_ByDays>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }

        public static List<TicketCount_ByType_Model> Get_OpenTicket_ByType(bool Is_Agent, bool Is_Client, string Type, long UserID, string FromDate, string ToDate)
        {
            List<TicketCount_ByType_Model> res = new List<TicketCount_ByType_Model>();
            try
            {
                SP_Get_OpenTicket_ByType sp = new SP_Get_OpenTicket_ByType()
                {
                    Is_Agent = Is_Agent,
                    Is_Client = Is_Client,
                    Type = Type,
                    UserID = UserID,
                    FromDate = FromDate,
                    ToDate = ToDate,
                };
                res = DataManager.ExecuteSPGetList<TicketCount_ByType_Model, SP_Get_OpenTicket_ByType>(sp);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return res;
        }


    }
}
