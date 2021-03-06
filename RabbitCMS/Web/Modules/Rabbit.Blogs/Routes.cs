﻿using Rabbit.Web;
using Rabbit.Web.Routes;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Rabbit.Blogs
{
    internal sealed class Routes : IRouteProvider
    {
        #region Implementation of IRouteProvider

        /// <summary>
        /// 获取路由信息。
        /// </summary>
        /// <param name="routes">路由集合。</param>
        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            const string area = "Rabbit.Blogs";

            routes.Add(new HttpRouteDescriptor
            {
                Name = "Rabbit.Blogs_CommentsApi",
                RouteTemplate = "blogs/api/comments/{id}",
                Defaults = new { area, controller = "Comment", pageIndex = 1, pageSize = 10 }
            });

            routes.Add(new HttpRouteDescriptor
            {
                Name = "Rabbit.Blogs_PostCommentsApi",
                RouteTemplate = "blogs/api/post/{postId}/comments/{pageIndex}/{pageSize}",
                Defaults = new { area, controller = "Comment", pageIndex = 1, pageSize = 10 }
            });

            routes.MapRabbitRoute("Rabbit.Blogs_Categorys", "category/{RoutePath}",
                area, new { controller = "Post", action = "ListCategorys", pageIndex = 1 });

            routes.MapRabbitRoute("Rabbit.Blogs_Categorys", "category/{RoutePath}/page/{pageIndex}",
                area, new { controller = "Post", action = "ListCategorys" });

            routes.MapRabbitRoute("Rabbit.Blogs_Home", "page/{pageIndex}",
                area, new { controller = "Post", action = "ListHome" });

            routes.MapRabbitRoute("Rabbit.Blogs_Authors", "author/{author}",
                area, new { controller = "Post", action = "ListAuthor", pageIndex = 1 });

            routes.MapRabbitRoute("Rabbit.Blogs_Authors", "author/{author}/page/{pageIndex}",
                area, new { controller = "Post", action = "ListAuthor" });

            routes.MapRabbitRoute("Rabbit.Blogs_Tags", "tag/{tag}",
                area, new { controller = "Post", action = "ListTags", pageIndex = 1 });

            routes.MapRabbitRoute("Rabbit.Blogs_Tags", "tag/{tag}/page/{pageIndex}",
                area, new { controller = "Post", action = "ListTags" });

            routes.MapRabbitRoute("Rabbit.Blogs_Search", "search/{titleKeywords}",
                area, new { controller = "Post", action = "ListSearch", pageIndex = 1 });

            routes.MapRabbitRoute("Rabbit.Blogs_Search", "search/{titleKeywords}/page/{pageIndex}",
                area, new { controller = "Post", action = "ListSearch" });

            routes.MapRabbitRoute("Rabbit.Blogs_Home", "feed",
                area, new { controller = "Feed", action = "Index" });

            routes.MapRabbitRoute("Rabbit.Blogs_PostDetailed", "{CategoryRoutePath}/{RoutePath}",
                area, new { controller = "Post", action = "Detailed" });

            routes.MapRabbitRoute("Rabbit.Blogs_Home", string.Empty,
                area, new { controller = "Post", action = "ListHome", pageIndex = 1 });

            routes.MapRabbitRoute("Rabbit.Blogs_Default", "Admin/Blogs/{controller}/{action}/{id}",
                area, new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }

        #endregion Implementation of IRouteProvider
    }
}