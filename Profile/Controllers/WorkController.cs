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
    public class WorkController : Controller
    {
        Dbmodel dbmodel = new Dbmodel();

        public static int counter = 0;

        [HttpPost]
        public string InsertWork(WorkModel WorkModel)
        {
            try
            {
                Random rnd = new Random();
                var num1 = rnd.Next();
                var num2 = rnd.Next();
                var num3 = rnd.Next();
                var num4 = rnd.Next();
                var num5 = rnd.Next();

                string fname1 = "image" + num1;
                fname1 = fname1 + "." + WorkModel.Image1;

                string fname2 = "image" + num2;
                fname2 = fname2 + "." + WorkModel.Image2;

                string fname3 = "image" + num3;
                fname3 = fname3 + "." + WorkModel.Image3;

                string fname4 = "image" + num4;
                fname4 = fname4 + "." + WorkModel.Image4;

                string fname5 = "image" + num5;
                fname5 = fname5 + "." + WorkModel.Image5;

                Work obj = new Work();
                obj.Image1 = fname1;
                obj.Image2 = fname2;
                obj.Image3 = fname3;
                obj.Image4 = fname4;
                obj.Image5 = fname5;
                obj.Title1 = WorkModel.Title1;
                obj.Title2 = WorkModel.Title2;
                obj.Title3 = WorkModel.Title3;
                obj.Title4 = WorkModel.Title4;
                obj.Title5 = WorkModel.Title5;
                obj.Status = 0;

                var result = SaveToMainFolder(fname1, fname2, fname3, fname4, fname5);
                if (result == "success")
                {
                    dbmodel.Work.Add(obj);
                    dbmodel.SaveChanges();
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

        [HttpPost]
        public string InsertWorkImage()
        {
            try
            {
                counter++;
                string fname = "Work" + counter;
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
                    //about_us aboutUs = (from ui in dbmodel.about_us where ui.Id == id select ui).FirstOrDefault();
                    //aboutUs.Image = fname;
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

        public string SaveToMainFolder(string fname1, string fname2, string fname3, string fname4, string fname5)
        {
            string fileName = "";
            string destFile = "";
            string sourcePath = Server.MapPath("~/Images/TempImages");
            string targetPath = Server.MapPath("~/Images/WorkImages");
            try
            {
                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);
                    var count = 0;
                    // Copy the files. 
                    foreach (string file in files)
                    {
                        var fname = string.Empty;
                        if (count == 0)
                        {
                            fname = fname1;
                        }
                        if (count == 1)
                        {
                            fname = fname2;
                        }
                        if (count == 2)
                        {
                            fname = fname3;
                        }
                        if (count == 3)
                        {
                            fname = fname4;
                        }
                        if (count == 4)
                        {
                            fname = fname5;
                        }

                        //    fileName = System.IO.Path.GetFileName(file);

                        destFile = System.IO.Path.Combine(targetPath, fname);
                        System.IO.File.Copy(file, destFile, true);
                        count++;
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

        [HttpPut]
        public string UpdateWork(WorkModel WorkModel)
        {
            try
            {
                Work Work = (from ui in dbmodel.Work where ui.Id == WorkModel.Id select ui).FirstOrDefault();
                string fname1 = Work.Image1;
                string fname2 = Work.Image2;
                string fname3 = Work.Image3;
                string fname4 = Work.Image4;
                string fname5 = Work.Image5;
              
                string check1 = WorkModel.Image1;
                string check2 = WorkModel.Image2;
                string check3 = WorkModel.Image3;
                string check4 = WorkModel.Image4;
                string check5 = WorkModel.Image5;

                Work.Title1 = WorkModel.Title1;
                Work.Title2 = WorkModel.Title2;
                Work.Title3 = WorkModel.Title3;
                Work.Title4 = WorkModel.Title4;
                Work.Title5 = WorkModel.Title5;



                var result = SaveToMainFolderForEdit(fname1, fname2, fname3,
                                                    fname4, fname5, 
                                                    check1, check2, check3,
                                                    check4, check5);

                if (result == "success")
                {
                    dbmodel.SaveChanges();
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

        public string SaveToMainFolderForEdit(string fname1, string fname2, string fname3,
                                              string fname4, string fname5, 
                                              string check1, string check2, string check3,
                                              string check4, string check5)
        {
            string fileName = "";
            string destFile = "";
            string sourcePath = Server.MapPath("~/Images/TempImages");
            string targetPath = Server.MapPath("~/Images/WorkImages");
            try
            {
                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);
                    // Copy the files. 
                    foreach (string file in files)
                    {
                        var fname = string.Empty;
                        if (check1 == "2")
                        {
                            fname = fname1;
                            fileName = System.IO.Path.GetFileName(file);
                            destFile = System.IO.Path.Combine(targetPath, fname);
                            System.IO.File.Copy(file, destFile, true);
                            check1 = "1";
                        }
                        else if (check2 == "2")
                        {
                            fname = fname2;
                            fileName = System.IO.Path.GetFileName(file);
                            destFile = System.IO.Path.Combine(targetPath, fname);
                            System.IO.File.Copy(file, destFile, true);
                            check2 = "1";
                        }
                        else if (check3 == "2")
                        {
                            fname = fname3;
                            fileName = System.IO.Path.GetFileName(file);
                            destFile = System.IO.Path.Combine(targetPath, fname);
                            System.IO.File.Copy(file, destFile, true);
                            check3 = "1";
                        }
                        else if (check4 == "2")
                        {
                            fname = fname4;
                            fileName = System.IO.Path.GetFileName(file);
                            destFile = System.IO.Path.Combine(targetPath, fname);
                            System.IO.File.Copy(file, destFile, true);
                            check4 = "1";
                        }
                        else if (check5 == "2")
                        {
                            fname = fname5;
                            fileName = System.IO.Path.GetFileName(file);
                            destFile = System.IO.Path.Combine(targetPath, fname);
                            System.IO.File.Copy(file, destFile, true);
                            check5 = "1";
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

        [HttpDelete]
        public string DeleteWork(int id)
        {
            try
            {
                Work work = (from ui in dbmodel.Work where ui.Id == id select ui).FirstOrDefault();
                if (work.Status == 1)
                {
                    return "fail";
                }
                else
                {
                    dbmodel.Work.Remove(work);
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
        public string ActivateWork(int id)
        {
            try
            {
                var previousActivate = (from ui in dbmodel.Work where ui.Status == 1 select ui).FirstOrDefault();
                var active = (from ui in dbmodel.Work where ui.Id == id select ui).FirstOrDefault();

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