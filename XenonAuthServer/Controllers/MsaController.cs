namespace Xenon.Auth.Server.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

public class MsaController : Controller
{
	[HttpGet]
	[Route("/msa")]
	public ActionResult GetMsaApplicationId()
	{
		if(String.IsNullOrWhiteSpace(XenonAuthServer.MsaApplicationId))
		{
			return this.NotFound();
		}

		if(!this.Request.Headers.TryGetValue("X-Client-Type", out StringValues vs))
		{
			return this.BadRequest();
		}

		else if(vs[0] != "Xenon")
		{
			return this.Forbid();
		}

		return this.Ok(XenonAuthServer.MsaApplicationId);
	}
}
