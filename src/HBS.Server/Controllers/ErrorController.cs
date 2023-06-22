using HBS.Server.Controllers.Common;

using Microsoft.AspNetCore.Mvc;

namespace HBS.Server.Controllers;

[Route("/error")]
public class ErrorController : ApiController
{
    [HttpGet]
    public ActionResult Error()
    {
        return Problem();
    }
}