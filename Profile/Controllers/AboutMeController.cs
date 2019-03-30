using Profile.Models;
using Profile.Models.Dbcontext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Profile.Controllers
{
    public class AboutMeController : Controller
    {
        // GET: AboutMe
        Dbmodel dbmodel = new Dbmodel();

        [HttpPost]
        public string InsertAboutMe(AboutMeModel aboutMeModel)
        {
            try
            {
                var check = dbmodel.About_Me.FirstOrDefault();
                var id = 0;
                if (check != null)
                {
                    id = dbmodel.About_Me.Select(x => x.Id).Max();
                }
                var num = id + 1;
                string fname = "about" + num;
                fname = fname + "." + aboutMeModel.Image;
                About_Me obj = new About_Me();
                obj.Image = fname;
                obj.Introduction = aboutMeModel.Introduction;
                obj.Status = 0;

                dbmodel.About_Me.Add(obj);
                dbmodel.SaveChanges();
                var result = SaveToMainFolder(fname);
                if (result == "success")
                {
                    return "success";
                }
                else
                {
                    return "fail";
                }
            }
            catch (Exception e)
            {
                return "fail";
            }

        }

        [HttpPut]
        public string UpdateAboutMe(AboutMeModel aboutMeModel)
        {
            try
            {
                About_Me obj = (from ui in dbmodel.About_Me where ui.Id == aboutMeModel.Id select ui).FirstOrDefault();
                string fname = obj.Image;
                string check = aboutMeModel.Image;
                obj.Introduction = aboutMeModel.Introduction;
                dbmodel.SaveChanges();
                if (aboutMeModel.Image == "2")
                {
                    var result = SaveToMainFolderForEdit(fname,check);
                    if (result == "success")
                    {
                        return "success";
                    }
                    else
                    {
                        return "fail";
                    }
                }
                return "success";
            }
            catch (Exception ex)
            {
                return "fail";
            }
        }

        [HttpDelete]
        public string DeleteAboutMe(int id)
        {
            try
            {
                About_Me aboutMe = (from ui in dbmodel.About_Me where ui.Id == id select ui).FirstOrDefault();
                if (aboutMe.Status == 1)
                {
                    return "fail";
                }
                else
                {
                    dbmodel.About_Me.Remove(aboutMe);
                    dbmodel.SaveChanges();
                    return "success";
                }
            }
            catch (Exception e)
            {
                return "fail";
            }


        }

        [HttpPut]
        public string ActivateAboutMe(int id)
        {
            try
            {
                var previousActivate = (from ui in dbmodel.About_Me where ui.Status == 1 select ui).FirstOrDefault();
                var active = (from ui in dbmodel.About_Me where ui.Id == id select ui).FirstOrDefault();

                if (previousActivate != null)
                {
                    previousActivate.Status = 0;
                }
                active.Status = 1;

                dbmodel.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                return "fail";
            }
        }

        //Images related function
        [HttpPost]
        public string InsertImage()
        {
            try
            {
                var check = dbmodel.About_Me.FirstOrDefault();
                var id = 0;
                if (check != null)
                {
                    id = dbmodel.About_Me.Select(x => x.Id).Max();
                }
                var num = id + 1;
                string fname = "about" + num;
                if (Request.Files.Count > 0)
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            var cname = testfiles[testfiles.Length - 1];
                            var lname = cname.Split('.');
                            fname = fname + "." + lname[1];
                        }
                        else
                        {
                            var cname = file.FileName;
                            var lname = cname.Split('.');
                            fname = fname + "." + lname[1];
                        }

                        // Get the complete folder path and store the file inside it.  
                        var fullPath = Path.Combine(Server.MapPath("~/Images/TempImages"), fname);
                        file.SaveAs(fullPath);
                    }
                    //Blog blog = (from ui in dbmodel.Blog where ui.Id == id select ui).FirstOrDefault();
                    //blog.Image = fname;
                    //dbmodel.SaveChanges();
                    return "success";
                }
                else
                {
                    return "fail";
                }
            }
            catch (Exception e)
            {
                return "fail";
            }
        }

        public string SaveToMainFolder(string fname)
        {
            string fileName = "";
            string destFile = "";
            string sourcePath = Server.MapPath("~/Images/TempImages");
            string targetPath = Server.MapPath("~/Images/AboutMeImages");
            try
            {
                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);
                    // Copy the files. 
                    foreach (string file in files)
                    {
                        fileName = System.IO.Path.GetFileName(file);
                        destFile = System.IO.Path.Combine(targetPath, fname);
                        System.IO.File.Copy(file, destFile, true);
                    }
                    RemoveFiles();
                }
                return "success";
            }
            catch (Exception ex)
            {
                return "fail";
            }
        }

        public string SaveToMainFolderForEdit(string fname, string check)
        {
            string fileName = "";
            string destFile = "";
            string sourcePath = Server.MapPath("~/Images/TempImages");
            string targetPath = Server.MapPath("~/Images/AboutMeImages");
            try
            {
                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);
                    // Copy the files. 
                    foreach (string file in files)
                    {
                        var fnames = string.Empty;
                        if (check == "2")
                        {
                            fnames = fname;
                            fileName = System.IO.Path.GetFileName(file);
                            destFile = System.IO.Path.Combine(targetPath, fname);
                            System.IO.File.Copy(file, destFile, true);
                            check = "1";
                        }
                    }
                    RemoveFiles();
                }
                return "success";
            }
            catch (Exception ex)
            {
                return "fail";
            }
        }

        public void RemoveFiles()
        {
            string sourcePath = Server.MapPath("~/Images/TempImages");
            string[] files = System.IO.Directory.GetFiles(sourcePath);
            foreach (string file in files)
            {
                if (System.IO.File.Exists(System.IO.Path.Combine(sourcePath, file)))
                {
                    try
                    {
                        System.IO.File.Delete(file);
                    }
                    catch (System.IO.IOException e)
                    {
                        return;
                    }
                }
            }
        }
    }
}