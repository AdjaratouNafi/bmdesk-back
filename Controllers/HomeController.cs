using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BMSDesk_CLI_API.Web.Helpers;
using BMSDesk_CLI_API.Logic;
using BMSDesk_CLI_API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Extensions.Configuration;

//using System.DirectoryServices;
using Newtonsoft.Json;

namespace BMSDesk_CLI_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private static IConfiguration _config;
        protected ICompositeViewEngine viewEngine;
        public HomeController(ICompositeViewEngine viewEngine, IHttpContextAccessor accessor, IConfiguration config)
        {
            _config = config;
            var helper = new HtmlHelpers.ClaimsModelService(accessor, config);

            this.viewEngine = viewEngine;
            directoryBrowser = new DirectoryBrowser();
            thumbnailCreator = new ThumbnailCreator();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("");
        }

        public IActionResult Get_Translate(string lang)
        {
            var jsondata = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents/Resources", lang + ".json")));
            var res = JsonConvert.DeserializeObject<dynamic>(jsondata);
            return Ok(res);
        }
        [HttpPost]
        public List<KeyValueString> Get_Languages()
        {
            var res = User_Manager.Get_Languages();
            return res;
        }
        [HttpPost]
        public IActionResult Get_DefaultLang()
        {
            var res = General_Setting_Manager.Get_DefaultLang();
            return Ok(ComUti.Get_ApiResponse(res));
        }
        public IActionResult Print(string ids, string type, string lang)
        {
            var model = new Print_Model();
            model.lang = lang.ToUpper();
            try
            {
                model.TicketList = new List<Ticket_Model>();
                model.SolutionList = new List<Solution_Model>();
                if (type == ModuleType.ticket.ToString())
                {
                    model.TicketList = Ticket_Manager.Get_Ticket_Print(ids);
                    model.TicketAttachment = Ticket_Manager.Get_TicketAttachments_Print(ids);
                }
                else if (type == ModuleType.solution.ToString())
                {
                    model.SolutionList = Solution_Manager.Get_Solution_Print(ids);
                    model.SolutionAttachment = Solution_Manager.Get_SolutionAttachments_Print(ids);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return View(model);
        }

        public IActionResult Get_Tooltip(string lang, string ModuleType, string ID, string Subject, string Category, string Status = "")
        {
            Tooltip_Model model = new Tooltip_Model();
            model.lang = lang.ToUpper();
            try
            {
                model.ModuleType = ModuleType;
                var res = Ticket_Manager.Get_DescriptionByID(ModuleType, ID);
                model.Description = res.Description;
                model.ID = ID;
                model.Subject = Subject;
                model.CategoryName = Category;
                model.StatusName = Status;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            var html = RenderRazorViewToString("Tooltip", model);
            return Ok(html);
            //return PartialView("Tooltip", model);
        }

        public string RenderRazorViewToString(string viewName, object model)
        {
            viewName = viewName ?? ControllerContext.ActionDescriptor.ActionName;
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                IView view = viewEngine.FindView(ControllerContext, viewName, true).View;
                ViewContext viewContext = new ViewContext(ControllerContext, view, ViewData, TempData, sw, new HtmlHelperOptions());

                view.RenderAsync(viewContext).Wait();
                return sw.GetStringBuilder().ToString();
            }
        }

        [HttpPost]
        public int ForgotPassword(dynamic obj)
        {
            var res = User_Manager.ForgotPassword((string)obj.UserName, (string)obj.site_url);
            return res;
        }
        [HttpPost]
        public IActionResult Decrypt_ForgotPassword(dynamic obj)
        {
            var res = User_Manager.Decrypt_ForgotPassword((string)obj.Key);
            return Ok(ComUti.Get_ApiResponse(res));
        }
        [HttpPost]
        public int ResetPassword(dynamic obj)
        {
            var res = User_Manager.ResetPassword((string)obj.UserName, (string)obj.Email, (string)obj.Password);
            return res;
        }


        //[HttpPost]
        //public void testAD()
        //{
        //    using (DirectoryEntry dr = new DirectoryEntry("LDAP://ldap.forumsys.com", null, null, AuthenticationTypes.Anonymous))
        //    {
        //        //dr.AuthenticationType = AuthenticationTypes.Anonymous;
        //        //dr.Username = "ro_admin";
        //        //dr.Password = "zflexpass";
        //        using (DirectorySearcher ds = new DirectorySearcher(dr))
        //        {
        //            //ds.SearchScope = SearchScope.Subtree;
        //            //ds.Filter = "(|(objectCategory=person)(objectClass=user)(objectClass=inetOrgPerson))";
        //            ds.PageSize = 100;
        //            var res = ds.FindAll();
        //            var ss = res;
        //        }
        //    }

        //}


        #region Kendo Editor Image 
        public DirectoryBrowser directoryBrowser;
        public ThumbnailCreator thumbnailCreator;

        //public HomeController()
        //{
        //    directoryBrowser = new DirectoryBrowser();
        //    thumbnailCreator = new ThumbnailCreator();
        //}
        public const string DefaultFilter = "*.png,*.gif,*.jpg,*.jpeg,*.bmp";
        public const string contentFolderRoot = "/Documents";//"~/";
        public const string prettyName = "/Documents/ImageBrowser/";//"ImageBrowser/";
        public const int ThumbnailHeight = 80;
        public const int ThumbnailWidth = 80;
        public IActionResult Read(string path)
        {
            var folder_path = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "ImageBrowser/"));
            var result = directoryBrowser.GetContent(folder_path, DefaultFilter).Select(f => new
            {
                name = f.Name,
                type = f.Type == EntryType.File ? "f" : "d",
                size = f.Size
            });
            return Ok(result);
        }

        public IActionResult Thumbnail(string path)
        {
            var file_path = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "ImageBrowser/" + path));
            if (System.IO.File.Exists(file_path)) { return CreateThumbnail(file_path); }
            else { return null; }
        }
        public FileContentResult CreateThumbnail(string physicalPath)
        {
            using (var fileStream = System.IO.File.OpenRead(physicalPath))
            {
                var desiredSize = new ImageSize { Width = ThumbnailWidth, Height = ThumbnailHeight };
                const string contentType = "image/png";
                return File(thumbnailCreator.Create(fileStream, desiredSize, contentType), contentType);
            }
        }

        [HttpPost]
        //public IActionResult Destroy(string name, string type, string path)
        public IActionResult Destroy([FromForm] Kendo_File_Model obj)
        {
            if (obj != null)
            {
                var file_path = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "ImageBrowser/" + obj.name));
                if (obj.type.ToLowerInvariant() == "f")
                {
                    if (System.IO.File.Exists(file_path)) { System.IO.File.Delete(file_path); }
                }
                else
                {
                    if (Directory.Exists(file_path)) { Directory.Delete(file_path, true); }
                }
                return Ok();
            }
            return null;
        }
        [HttpPost]
        public IActionResult Create([FromForm] Kendo_File_Model obj)
        {
            if (obj != null)
            {
                var folder_path = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "ImageBrowser/" + obj.name));
                if (!Directory.Exists(folder_path)) { Directory.CreateDirectory(folder_path); }
                return Ok();
            }
            return null;
        }
        public bool IsValidFile(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            var allowedExtensions = DefaultFilter.Split(',');
            return allowedExtensions.Any(e => e.EndsWith(extension, StringComparison.InvariantCultureIgnoreCase));
        }

        [HttpPost]
        public IActionResult Upload(string path, IFormFile file)
        {
            if (file != null && IsValidFile(file.FileName))
            {
                var flname = Path.GetFileName(file.FileName);
                var file_path = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Documents", "ImageBrowser/" + flname));

                using (var stream = new FileStream(file_path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    return Ok(new { size = file.Length, name = flname, type = "f" });
                }
            }
            return null;
        }
        #endregion


    }
}