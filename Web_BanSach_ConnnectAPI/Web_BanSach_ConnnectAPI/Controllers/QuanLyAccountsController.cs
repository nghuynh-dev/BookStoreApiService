using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Web_BanSach_ConnnectAPI.Models;

namespace Web_BanSach_ConnnectAPI.Controllers
{
    public class QuanLyAccountsController : Controller
    {
        private AccountsAPI accounts = new AccountsAPI();
        // GET: QuanLyAccounts
        public ActionResult Index()
        {
            ViewBag.ds = accounts.GetData();

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection col)
        {
            string name = col["Username"].ToString();
            string MatKhau = col["MatKhau"].ToString();
            if (ModelState.IsValid)
            {
                var obj = accounts.GetData().Where(a => a.Username.Equals(name) && a.Password.Equals(MatKhau)).FirstOrDefault();
                if (obj != null)
                {
                    Session["UserEmail"] = obj.Email.ToString();
                    Session["UserName"] = obj.Username.ToString();
                    Session["IsAdmin"] = obj.IsAdmin;
                    Session["Id"] = obj.Id;

                    if (Session["IsAdmin"].Equals(true))
                    {
                        return RedirectToAction("Index", "QuanLySach");
                    }

                    else
                    {
                        return RedirectToAction("Index", "QuanLySachUser");
                    }
                }
                else
                {
                    ViewBag.Error = "Đăng nhập không thành công, Vui lòng kiểm tra lại!";
                    return RedirectToAction("Login");
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        // GET: Accounts/Edit/5
        public ActionResult ChinhSua()
        {
            int id = int.Parse(Session["Id"].ToString());
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = accounts.GetData().Where(a => a.Id == id).FirstOrDefault();
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChinhSua([Bind(Include = "Id,Username,Password,Email,Phone,Address,Fullname,IsAdmin,Avatar,Status")] Accounts account, HttpPostedFileBase fileUpLoad)
        {
            if (fileUpLoad == null)
            {
                ViewBag.ThongBao = "Vui lòng chọn ảnh!";
                return View();
            }

            else
            {
                if (ModelState.IsValid)
                {
                    var filename = Path.GetFileName(fileUpLoad.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/img/user/"), filename);
                    Session["anh"] = filename;
                    //account.Password = Web_KiemTra2.Models.User.EncodeSHA1(account.Password);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại!";
                    }
                    else
                    {
                        fileUpLoad.SaveAs(path);
                    }
                    account.Avatar = filename;
                    accounts.UpdateData(account.Id, account.Username, account.Password, account.Email, account.Phone, account.Address, account.Fullname, account.IsAdmin, account.Avatar, account.Status);
                    //return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index", "QuanLySachUser");
        }

        // GET: Accounts/Edit/5
        public ActionResult ChinhSuaTT()
        {
            int id = int.Parse(Session["Id"].ToString());
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = accounts.GetData().Where(a => a.Id == id).FirstOrDefault();
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChinhSuaTT([Bind(Include = "Id,Username,Password,Email,Phone,Address,Fullname,IsAdmin,Avatar,Status")] Accounts account, HttpPostedFileBase fileUpLoad)
        {
            if (fileUpLoad == null)
            {
                ViewBag.ThongBao = "Vui lòng chọn ảnh!";
                return View();
            }

            else
            {
                if (ModelState.IsValid)
                {
                    var filename = Path.GetFileName(fileUpLoad.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/img/user/"), filename);
                    Session["anh"] = filename;
                    //account.Password = Web_KiemTra2.Models.User.EncodeSHA1(account.Password);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại!";
                    }
                    else
                    {
                        fileUpLoad.SaveAs(path);
                    }
                    account.Avatar = filename;
                    accounts.UpdateData(account.Id, account.Username, account.Password, account.Email, account.Phone, account.Address, account.Fullname, account.IsAdmin, account.Avatar, account.Status);
                    //return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index", "QuanLySach");
        }

        public ActionResult Register()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Id,Username,Password,Email,Phone,Address,Fullname,IsAdmin,Avatar,Status")] Accounts account, HttpPostedFileBase fileUpload)
        {
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Vui lòng chọn ảnh!";
                return View();
            }

            else
            {
                if (ModelState.IsValid)
                {
                    var filename = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/img/user/"), filename);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại!";
                    }
                    else
                    {
                        fileUpload.SaveAs(path);
                    }

                    if (accounts.GetData().Any(s => s.Username == account.Username))
                    {
                        ViewBag.tb = "Đã tồn tại Username này!";
                    }
                    else
                    {
                        account.Avatar = filename;
                        accounts.PostData(account.Username, account.Password, account.Email, account.Phone, account.Address, account.Fullname, false, account.Avatar, true);
                        return RedirectToAction("Login", "QuanLyAccounts");
                    }
                }
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Password,Email,Phone,Address,Fullname,IsAdmin,Avatar,Status")] Accounts account, HttpPostedFileBase fileUpLoad)
        {
            if (fileUpLoad == null)
            {
                ViewBag.ThongBao = "Vui lòng chọn ảnh!";
                return View();
            }

            else
            {
                if (ModelState.IsValid)
                {
                    var filename = Path.GetFileName(fileUpLoad.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/img/user/"), filename);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại!";
                    }
                    else
                    {
                        fileUpLoad.SaveAs(path);
                    }

                    if (accounts.GetData().Any(s => s.Username == account.Username))
                    {
                        ViewBag.tb = "Đã tồn tại Username này!";
                    }
                    else
                    {
                        account.Avatar = filename;
                        accounts.PostData(account.Username, account.Password, account.Email, account.Phone, account.Address, account.Fullname, account.IsAdmin, account.Avatar, account.Status);
                        return RedirectToAction("Index", "QuanLyAccounts");
                    }
                }
            }
            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = accounts.GetData().Where(a => a.Id == id).FirstOrDefault();
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Password,Email,Phone,Address,Fullname,IsAdmin,Avatar,Status")] Accounts account, HttpPostedFileBase fileUpLoad)
        {

            if (fileUpLoad == null)
            {
                ViewBag.ThongBao = "Vui lòng chọn ảnh!";
                return View();
            }

            else
            {
                if (ModelState.IsValid)
                {
                    var filename = Path.GetFileName(fileUpLoad.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/img/user/"), filename);
                    Session["anh"] = filename;
                    //account.Password = Web_KiemTra2.Models.User.EncodeSHA1(account.Password);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại!";
                    }
                    else
                    {
                        fileUpLoad.SaveAs(path);
                    }
                    account.Avatar = filename;
                    accounts.UpdateData(account.Id, account.Username, account.Password, account.Email, account.Phone, account.Address, account.Fullname, account.IsAdmin, account.Avatar, account.Status);
                    //return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index", "QuanLyAccounts");
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = accounts.GetData().Where(a => a.Id == id).FirstOrDefault();
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accounts account = accounts.GetData().Where(a => a.Id == id).FirstOrDefault();
            accounts.DeleteData(id);
            return RedirectToAction("Index", "QuanLyAccounts");
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts account = accounts.GetData().Where(a => a.Id == id).FirstOrDefault();
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder sb = new StringBuilder();
            char c;
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(rand.Next(65, 87)));
                sb.Append(c);
            }
            if (lowerCase)
            {
                return sb.ToString().ToLower();
            }
            return sb.ToString();
        }

        public bool sendMail(string to, string subject, string body)
        {
            var Email = System.Configuration.ConfigurationManager.AppSettings["Gmail"].ToString();
            MailMessage obj = new MailMessage(Email, to);
            obj.Subject = subject;
            obj.Body = body;
            obj.IsBodyHtml = true;
            string Message = null;

            MailAddress bcc = new MailAddress("fcphanavn@gmail.com");
            obj.Bcc.Add(bcc);

            //attach file
            //HttpPostedFileBase file = Request.Files["file"];
            //if (file.ContentLength > 0)
            //{
            //    string fileName = System.IO.Path.GetFileName(file.FileName);
            //    obj.Attachments.Add(new System.Net.Mail.Attachment(file.InputStream, fileName));
            //}

            using (SmtpClient smtp = new SmtpClient())
            {
                var Password = System.Configuration.ConfigurationManager.AppSettings["PasswordGmail"].ToString();

                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(Email, Password);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;

                try
                {
                    smtp.Send(obj);
                    Message = "Gửi mail thành công";
                    return true;
                }
                catch (Exception ex)
                {
                    Message = "Err:" + ex.ToString();
                    return false;
                }
            }
        }

        [HttpGet]
        public ActionResult QuenMatKhau()
        {
            return View();
        }

        [HttpPost]
        public ActionResult QuenMatKhau(FormCollection col)
        {
            string email = col["Email"];
            string subject = "Thay đổi mật khẩu tài khoản";
            try
            {
                Accounts account = accounts.GetData().Where(s => s.Email == email).FirstOrDefault();
                account.Password = RandomString(8, true);
                accounts.UpdateData(account.Id, account.Username, account.Password, account.Email, account.Phone, account.Address, account.Fullname, account.IsAdmin, account.Avatar, account.Status);
                Accounts acc = accounts.GetData().Where(s => s.Email == email).FirstOrDefault();
                string body = "Đây là mật khẩu của bạn sau khi yêu cầu thay đổi: " + acc.Password + ", Vui lòng thay đổi mật khẩu sau khi đăng nhập lại!";
                sendMail(acc.Email, subject, body);
                ViewBag.tb = "Yêu cầu lấy lại mật khẩu thành công, vui lòng quay lại trang đăng nhập";
            }
            catch
            {
                ViewBag.tb = "Không thể yêu cầu lấy lại mật khẩu, vui lòng kiểm tra lại";
            }
            return View();
        }

        [HttpGet]
        public ActionResult DoiMatKhau()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoiMatKhau(FormCollection col)
        {
            string MatKhauCu = col["MatKhauCu"];
            string MatKhauMoi = col["MatKhauMoi"];
            string XacNhanMK = col["XacNhanMatKhau"];
            string email = Session["Email"].ToString();
            try
            {
                Accounts account = accounts.GetData().Where(s => s.Email == email && s.Password == MatKhauCu).FirstOrDefault();
                account.Password = MatKhauMoi;
                accounts.UpdateData(account.Id, account.Username, account.Password, account.Email, account.Phone, account.Address, account.Fullname, account.IsAdmin, account.Avatar, account.Status);
                ViewBag.tb = "Đã thay đổi mật khẩu thành công!";
                return RedirectToAction("Index", "QuanLySachUser");
            }
            catch
            {
                ViewBag.tb = "Không thể thay đổi mật khẩu!";
            }
            return View();
        }
    }
}