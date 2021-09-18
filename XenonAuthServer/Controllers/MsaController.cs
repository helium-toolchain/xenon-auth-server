namespace Xenon.Auth.Server.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

public class MsaController : Controller
{
	[HttpGet]
	[Route("/msa")]
	public ActionResult GetMsaApplicationId(
		[FromHeader]
		String XClientType)
	{
		if(String.IsNullOrWhiteSpace(XenonAuthServer.MsaApplicationId))
		{
			return this.NotFound();
		}

		else if(XClientType != "Xenon")
		{
			return this.StatusCode(StatusCodes.Status403Forbidden);
		}

		return this.Ok(XenonAuthServer.MsaApplicationId);
	}
}
