﻿using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;
public class UserController : ControllerBaseMVC
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Info()
    {
        return View();
    }
}
