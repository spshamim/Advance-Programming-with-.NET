using AutoMapper;
using BlogSysMngmt.DTOs;
using BlogSysMngmt.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSysMngmt.Controllers
{
    public class UserController : Controller
    {
        BlogSystemEntities db = new BlogSystemEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View(new UserDTO());
        }

        [HttpPost]
        public ActionResult Index(UserDTO l)
        {
            if (ModelState.IsValid)
            {
                var data = (from s in db.Users
                            where (s.name.Equals(l.Uname)) && (s.password.Equals(l.Password))
                            select s).SingleOrDefault();
                if (data == null)
                {
                    TempData["Msg"] = "Username and Password not found...";
                    return RedirectToAction("Index");
                }
                else
                {
                    Session["user"] = data;
                    TempData["Msg"] = "Login Successfull...";
                    return RedirectToAction("Index", "Blog");
                }
            }

            return View(l);
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View(new SignUpDTO()); 
        }

        [HttpPost]
        public ActionResult SignUp(SignUpDTO s)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<SignUpDTO, User>();
                });
                var mapper = new Mapper(config);
                var aa = mapper.Map<User> (s);

                db.Users.Add(aa);
                db.SaveChanges();

                var up = new UserProfile();
                up.user_id = aa.user_id;
                db.UserProfiles.Add(up);
                db.SaveChanges();

                TempData["Msg2"] = "Sign Up Successfull..";
                return RedirectToAction("Index");
            }

            return View(s);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new BlogPostDTO());
        }
        [HttpPost]
        public ActionResult Create(BlogPostDTO bg)
        {
            if (ModelState.IsValid)
            {
                var uuid = ((User)Session["user"]).user_id; 

                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<BlogPostDTO, Post>();
                });
                var mapper = new Mapper(config);
                var post = mapper.Map<Post>(bg);

                post.title = bg.title;
                post.p_content = bg.p_content;
                post.user_id = uuid;
                post.pub_date = DateTime.Now;

                db.Posts.Add(post);
                db.SaveChanges();

                var pst = new PostTag();

                pst.post_id = post.post_id;
                pst.tag_name = bg.tag_name;
                var obb = db.Tags.FirstOrDefault(t => t.tag_name.Equals(bg.tag_name));
                pst.tag_id = obb.tag_id;
                
                db.PostTags.Add(pst);
                db.SaveChanges();

                TempData["Msg7"] = "Blog Posted Successfully..";
                return RedirectToAction("ManageBlogs","Blog");
            }
            TempData["Msg6"] = "Validation Failed!..";
            return View(bg);
        }
        
        public ActionResult Logout()
        {
            Session["user"] = null;
            TempData["Msg"] = "Logout Successfull...";
            return RedirectToAction("Index");
        }

    }
}