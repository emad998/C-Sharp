using System;
using System.Collections.Generic;
using System.Linq;
using ForumDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumDemo.Controllers
{
    public class PostsController : Controller
    {
        private ForumContext db;
        public PostsController(ForumContext context)
        {
            db = context;
        }
        [HttpGet("/posts")]
        public IActionResult All()
        {
            List<Post> allPosts = db.Posts.ToList();
            return View("All", allPosts);
        }

        [HttpGet("/posts/new")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost("/posts/create")]
        public IActionResult Create(Post newPost)
        {
            if(ModelState.IsValid == false)
            {
                return View("New");
            }
            db.Posts.Add(newPost);
            db.SaveChanges();
            return RedirectToAction("All");
        }
        [HttpGet("/posts/{postId}")]
        public IActionResult Details(int postId)
        {
            Post selectedPost = db.Posts.FirstOrDefault(post => post.PostId == postId);
            if (selectedPost == null)
            {
                return RedirectToAction("All");
            }
            
            
            return View("Details", selectedPost);
        }
        [HttpPost("/posts/{postId}/delete")]
        public IActionResult Delete(int postId)
        {
            Post selectedPost = db.Posts.FirstOrDefault(post => post.PostId == postId);
            if (selectedPost == null)
            {
                return RedirectToAction("Details", new { postId = postId});
            }
            db.Posts.Remove(selectedPost);
            db.SaveChanges();
            return RedirectToAction("All");
        }
        [HttpGet("/posts/{postId}/edit")]
        public IActionResult Edit(int postId)
        {
             Post selectedPost = db.Posts.FirstOrDefault(post => post.PostId == postId);
            if (selectedPost == null)
            {
                return RedirectToAction("All");
            }
            return View("Edit", selectedPost);

        }
        [HttpPost("/posts/{postId}/update")]
        public IActionResult Update(Post editedPost, int postId)
        {
            if (ModelState.IsValid == false)
            {
                return View("Edit", editedPost);
            }

            Post selectedPost = db.Posts.FirstOrDefault(post => post.PostId == postId);
            if (selectedPost == null)
            {
                return RedirectToAction("All");
            }
            
            selectedPost.Topic = editedPost.Topic;
            selectedPost.Body = editedPost.Body;
            selectedPost.ImgUrl = editedPost.ImgUrl;
            selectedPost.UpdatedAt = DateTime.Now;

            db.Posts.Update(selectedPost);
            db.SaveChanges();

            return RedirectToAction("Details", new { postId = postId});

        }
    }
}