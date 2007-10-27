using System;
using System.Web;

namespace Example
{
	/// <summary>
	/// An HttpHandler that just throws exceptions.
	/// </summary>
	public class ExceptionThrowingHandler : IHttpHandler
	{
    public void ProcessRequest(HttpContext context) {
      //context.Response.Write("foo");
      throw new Exception("My custom exception.");
    }

    public bool IsReusable {
      get {
        return true;
      }
    }
  }
}
