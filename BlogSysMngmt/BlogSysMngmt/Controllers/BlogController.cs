using AutoMapper;
using BlogSysMngmt.DTOs;
using BlogSysMngmt.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSysMngmt.Controllers
{
    public class BlogController : Controller
    {
        BlogSystemEntities db = new BlogSystemEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PProfile()
        {
            var uu1 = ((User)Session["user"]).user_id;

            var data3 = (from uu in db.UserProfiles
                        where uu.user_id == uu1
                        select uu).SingleOrDefault();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserProfile, ProfileDTO>();
            });
            var mapper = new Mapper(config);
            var kk = mapper.Map<ProfileDTO>(data3);
            return View(kk);
        }

        [HttpPost]
        public ActionResult PProfile(ProfileDTO p, HttpPostedFileBase imgupload)
        {
            if (ModelState.IsValid)
            {
                var uu4 = ((User)Session["user"]).user_id;

                var existingProfile = db.UserProfiles.FirstOrDefault(up => up.user_id == uu4);
                /*
                    up.user_id == uu4 , we want to find a UserProfile where the user_id matches uu4.
                    then FirstOrDefault() , retrieves the first UserProfile from db where user_id matches uu4.
                */
                if (existingProfile != null)
                {
                    existingProfile.fullname = p.fullname;
                    existingProfile.address = p.address;
                    existingProfile.education = p.education;
                    existingProfile.gender = p.gender;
                    existingProfile.phone = p.phone;
                    existingProfile.hobbies = p.hobbies;
                    existingProfile.social_link = p.social_link;

                    if (imgupload != null && imgupload.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(imgupload.FileName);
                        var path = Path.Combine(Server.MapPath("~/Resources/Profile/"), fileName);
                        imgupload.SaveAs(path);
                        existingProfile.img_name = fileName;
                    }

                    var entry = db.Entry(existingProfile);
                    var en = entry.State.ToString();
                    var originalValue = entry.OriginalValues.GetValue<string>("fullname");
                    var relatedUser = ((User)entry.Reference("User").CurrentValue).user_id;
                    /*
                        To get the Previous Value and Current Value of the Entity Class,
                        var entry = db.Entry(existingProfile);
                        var currentValue = entry.CurrentValues.GetValue<string>("fullname"); // fullname is the property
                        var originalValue = entry.OriginalValues.GetValue<string>("fullname");

                        To access the navigation property,
                        var relatedUser = ((User)entry.Reference("User").CurrentValue).user_id;
                        User is nav property in UserProfile EF class, then typecasting to its own class to accessa the data
                    */
                    db.SaveChanges();

                    TempData["Msg5"] = $"Profile {en}. Related User Id is: {relatedUser}. Previous Full Name: {originalValue}.";

                    return RedirectToAction("PProfile");
                }
                else
                {
                    TempData["Msg4"] = "Profile Not Found...";
                    return RedirectToAction("PProfile");
                }
            }

            TempData["Msg4"] = "Validation Error...";
            return View(p);
        }


        public ActionResult ViewBlogs()
        {
            var data2 = db.Posts
              .Include(p => p.Comments) // ensuring to load the navigation data fastly
              .Include(p => p.Likes)
              .Include(p => p.PostTags)
              .ToList();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<Like, LikeDTO>();
                cfg.CreateMap<Comment, CommentDTO>();
                cfg.CreateMap<PostTag, PostTagDTO>();
            });
            var mapper = new Mapper(config);
            var pd = mapper.Map<List<PostDTO>>(data2);
            return View(pd);
        }

        [HttpPost]
        public ActionResult Search(string Search)
        {
            var data6 = db.Posts
                      .Where(p => p.title.Contains(Search))
                      .Include(p => p.Comments)
                      .Include(p => p.Likes)
                      .Include(p => p.PostTags)
                      .ToList();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<Like, LikeDTO>();
                cfg.CreateMap<Comment, CommentDTO>();
                cfg.CreateMap<PostTag, PostTagDTO>();
            });
            var mapper = new Mapper(config);
            var posst = mapper.Map<List<PostDTO>>(data6);

            return View("ViewBlogs", posst);
        }


        public ActionResult ManageBlogs()
        {
            var uu8 = ((User)Session["user"]).user_id;

            var data7 = db.Posts
                .Where(p => p.user_id == uu8)
              .Include(p => p.Comments) // ensuring to load the navigation data fastly
              .Include(p => p.Likes)
              .Include(p => p.PostTags)
              .ToList();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<Like, LikeDTO>();
                cfg.CreateMap<Comment, CommentDTO>();
                cfg.CreateMap<PostTag, PostTagDTO>();
            });
            var mapper = new Mapper(config);
            var asd = mapper.Map<List<PostDTO>>(data7);
            return View(asd);
        }
    }
}