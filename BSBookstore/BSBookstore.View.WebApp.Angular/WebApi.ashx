<%@ WebHandler Language="C#" Class="WebApi" %>

using System.Configuration;
using System.Web;

public class WebApi : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write(ConfigurationManager.AppSettings["UrlWebApi"]);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}