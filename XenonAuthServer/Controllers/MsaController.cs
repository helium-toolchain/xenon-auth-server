namespace Xenon.Auth.Server.Controllers;

using Microsoft.AspNetCore.Mvc;

public class MsaController : Controller
{
	[HttpGet]
	[Route("/msa")]
	public ActionResult GetMsaApplicationId()
	{
		if (String.IsNullOrWhiteSpace(XenonAuthServer.MsaApplicationId))
		{
			return this.NotFound();
		}

		return this.Ok(XenonAuthServer.MsaApplicationId);
	}
}
