using Microsoft.AspNetCore.Mvc;
using DemoListQuestions.Models;

namespace DemoListQuestions.Controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public Status Get()
    {
        return new Status() { status = "OK" };
    }
}