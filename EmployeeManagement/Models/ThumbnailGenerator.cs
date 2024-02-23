using System.Web;
//using Microsoft.AspNetCore.Http.HttpContext context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System.Linq;

namespace EmployeeManagement.Models
{                                   //IWebHostEnvironment
    public class ThumbnailGenerator : IHttpContextFactory
    {
        // Override the ProcessRequest method.
        public void ProcessRequest(HttpContext context)
        {
            context.Response.WriteAsync("<H1>This is an HttpHandler Test.</H1>");
            context.Response.WriteAsync("<p>Your Browser:</p>");
            //var userAgent = context.Request.Headers?.FirstOrDefault(s => s.Key.ToLower() == "user-agent").Value;
            var userAgent = context.Request.Headers["User-Agent"].ToString();
            context.Response.WriteAsync("Type: " + userAgent + "<br>");
            //context.Response.WriteAsync("Type: " + context.Request.Browser.Type + "<br>");
            //context.Response.WriteAsync("Version: " + context.Request.Browser.Version);
    
        }

        public HttpContext Create(IFeatureCollection featureCollection)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose(HttpContext httpContext)
        {
            throw new System.NotImplementedException();
        }

        // Override the IsReusable property.
        public bool IsReusable
        {
            get { return true; }
        }
    }
}
