﻿using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Post.Queries.GetAllPost;
using ZAlpha.Application.Post.Queries.GetPostById;
using ZAlpha.Application.Tag.Queries.GetTagById;
using ZAlpha.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Comment.Queries.GetCommentById;
using ZAlpha.Application.Comment.Commands.CreateComment;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.InteractWithComments.Commands.CreateInteractWithComment;
using ZAlpha.Domain.Enums;
using ZAlpha.Application.InteractWithPost.Commands.CreateInteractWithPost;
using ZAlpha.Application.InteractWithComments.Queries.GetInteractWithComment;

namespace WebUI.Controllers.MVC;
public class PostController : ControllerBaseMVC
{

    /* public async Task<IActionResult> Index(Guid postID)
     {
         var post = await Mediator.Send(new GetPostByIdQueries() { Id = postID });
         var listComment = await Mediator.Send(new GetCommentByPostIdQueries() { PostId = postID, Page = 1, Size = 100 });
         ViewBag.listComment = listComment;
         return View(post);
     }*/
    private readonly IIdentityService _identityService;

    public PostController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<IActionResult> Index(string userAccountId, Guid postId, string description)
    {
        
        var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
        if (User.Identity.IsAuthenticated && description != null)
        {
            var commentId = Mediator.Send(new CreateCommentCommands() { PostId = postId, Description = description }).Result;
            var interactWithCommentId = Mediator.Send(new CreateInteractWithCommentCommand() 
                    { UserAccountId = user.Id, CommentId = commentId, InteractCommentStatus= InteractCommentStatus.Create }).Result;

            TempData["Message"] = "Bạn đã đăng bình luận thành công";
        } else if (!User.Identity.IsAuthenticated && description != null)
        {
            return Redirect("~/Login");
        }
        var post = await Mediator.Send(new GetPostByIdQueries() { Id = postId });
        var interactedPost = post.InteractWithPosts?.FirstOrDefault(i => i.UserAccountId == user.Id);
        if (interactedPost != null)
        {
            if (interactedPost.InteractPostStatus == InteractPostStatus.Create)
            {
                ViewBag.interactedPostStatus = "Create";
            }
            else if (interactedPost.InteractPostStatus == InteractPostStatus.Like)
            {
                ViewBag.interactedPostStatus = "Like";
            }
            else
            {
                ViewBag.interactedPostStatus = "Dislike";
            }
        }
        var listComment = await Mediator.Send(new GetCommentByPostIdQueries() { PostId = postId, Page = 1, Size = 100 });
        ViewBag.listComment = listComment;
        return View(post);
    }

    [HttpPost]
    public async Task<IActionResult> AddComment(string postId, string description)
    {
        if (User.Identity.IsAuthenticated && description != null)
        {
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
            var commentId = await Mediator.Send(new CreateCommentCommands() { PostId = Guid.Parse(postId), Description = description });
            var interactWithCommentId = Mediator.Send(new CreateInteractWithCommentCommand()
                { UserAccountId = user.Id, CommentId = commentId, InteractCommentStatus = InteractCommentStatus.Create }).Result;


            //var listComment = await Mediator.Send(new GetCommentByPostIdQueries() { PostId = Guid.Parse(postId), Page = 1, Size = 100 });
            //return PartialView("_CommentListPartial", listComment.Items);
            //return Json(new { success = true, message = "Bạn đã đăng bình luận thành công", commentId = commentId, listComment });
            return Json(new { success = true, message = "Bạn đã đăng bình luận thành công", commentId = commentId });
        }
        else
        {
            return Json(new { success = false, message = "Đăng nhập để bình luận" });
        }
    }

    [HttpPost]
    public async Task<IActionResult> InteractWithPost(string postId, InteractPostStatus status)
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
            var interactWithPostId = await Mediator.Send(new CreateInteractWithPostCommands() { PostId  = Guid.Parse(postId), UserAccountId = user.Id, InteractPostStatus = status });


            //var listComment = await Mediator.Send(new GetCommentByPostIdQueries() { PostId = Guid.Parse(postId), Page = 1, Size = 100 });
            //return PartialView("_CommentListPartial", listComment.Items);
            return Json(new { success = true, message = "Bạn đã đánh giá bài viết", interactWithPostId = interactWithPostId});
        }
        else
        {
            return Json(new { success = false, message = "Đăng nhập để đánh giá" });
        }
    }

    [HttpPost]
    public async Task<IActionResult> InteractWithComment(string commentId, InteractCommentStatus status)
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
            var interactWithCommentId = await Mediator.Send(new CreateInteractWithCommentCommand() { CommentId = Guid.Parse(commentId), UserAccountId = user.Id, InteractCommentStatus = status });
            var checkComment = await Mediator.Send(new GetInteractWithCommentByIdQueries() { Id = interactWithCommentId });
            if (checkComment.InteractCommentStatus == InteractCommentStatus.Create)
            {
                return Json(new { success = true, message = "Bạn không thể tự đánh giá bình luận của bản thân", interactWithCommentId = interactWithCommentId });
            }
            //var listComment = await Mediator.Send(new GetCommentByPostIdQueries() { PostId = Guid.Parse(postId), Page = 1, Size = 100 });
            //return PartialView("_CommentListPartial", listComment.Items);
            return Json(new { success = true, message = "Bạn đã đánh giá bình luận", interactWithCommentId = interactWithCommentId });
        }
        else
        {
            return Json(new { success = false, message = "Đăng nhập để đánh giá" });
        }
    }
}
