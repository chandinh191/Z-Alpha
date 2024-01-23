﻿using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC.Admin;
public class AdminController : ControllerBaseMVC
{
    public IActionResult Index()
    {
        return View("./AdminHome/Index");
    }

    public IActionResult Index2()
    {
        return View("./AdminHome/Index2");
    }

    public IActionResult ChartAmchart()
    {
        return View("./Chart/ChartAmchart");
    }

    public IActionResult ChartChartist()
    {
        return View("./Chart/ChartChartist");
    }

    public IActionResult ChartChartjs()
    {
        return View("./Chart/ChartChartjs");
    }

    public IActionResult ChartEchart()
    {
        return View("./Chart/ChartEchart");
    }

    public IActionResult ChartFlot()
    {
        return View("./Chart/ChartFlot");
    }

    public IActionResult ChartMorris()
    {
        return View("./Chart/ChartMorris");
    }

    public IActionResult ChartPeity()
    {
        return View("./Chart/ChartPeity");
    }

    public IActionResult ChartSparkline()
    {
        return View("./Chart/ChartSparkline");
    }

    public IActionResult EmailCompose()
    {
        return View("./Email/EmailCompose");
    }

    public IActionResult EmailInbox()
    {
        return View("./Email/EmailInbox");
    }

    public IActionResult EmailRead()
    {
           return View("./Email/EmailRead");
    }

    public IActionResult FormBasic()
    {
        return View("./Form/FormBasic");
    }

    public IActionResult FormDropzone()
    {
           return View("./Form/FormDropzone");
    }

    public IActionResult FormEditor()
    {
        return View("./Form/FormEditor");
    }

    public IActionResult FormLayout()
    {
        return View("./Form/FormLayout");
    }

    public IActionResult FormValidation()
    {
        return View("./Form/FormValidation");
    }

    public IActionResult LayoutBlank()
    {
        return View("./Layout/LayoutBlank");
    }

    public IActionResult LayoutBoxed()
    {
           return View("./Layout/LayoutBoxed");
    }

    public IActionResult LayoutFixHeader()
    {
        return View("./Layout/LayoutFixHeader");
    }

    public IActionResult LayoutFixSidebar()
    {
           return View("./Layout/LayoutFixSidebar");
    }

    public IActionResult MapGoogle()
    {
        return View("./Map/MapGoogle");
    }

    public IActionResult MapVector()
    {
        return View("./Map/MapVector");
    }

    public IActionResult PageError400()
    {
        return View("./PageError/PageError400");
    }

    public IActionResult PageError403()
    {
        return View("./PageError/PageError403");
    }

    public IActionResult PageError404()
    {
        return View("./PageError/PageError404");
    }

    public IActionResult PageError500()
    {
        return View("./PageError/PageError500");
    }

    public IActionResult PageError503()
    {
        return View("./PageError/PageError503");
    }

    public IActionResult TableBoostrap()
    {
        return View("./Table/TableBoostrap");
    }

    public IActionResult TableDatatable()
    {
        return View("./Table/TableDatatable");
    }

    public IActionResult UcCalender()
    {
        return View("./UC/UcCalender");
    }

    public IActionResult UcDatamap()
    {
        return View("./UC/UcDatamap");
    }

    public IActionResult UcNestedable()
    {
        return View("./UC/UcNestedable");
    }

    public IActionResult UcSweetalert()
    {
        return View("./UC/UcSweetalert");
    }

    public IActionResult UcToastr()
    {
        return View("./UC/UcToastr");
    }

    public IActionResult UcWeather()
    {
        return View("./UC/UcWeather");
    }

    public IActionResult UiAlert()
    {
        return View("./UI/UiAlert");
    }   

    public IActionResult UiButton()
    {
        return View("./UI/UiButton");
    }

    public IActionResult UiDropdown()
    {
        return View("./UI/UiDropdown");
    }

    public IActionResult UiProgressbar()
    {
        return View("./UI/UiProgressbar");
    }

    public IActionResult UiTab()
    {
        return View("./UI/UiTab");
    }

    public IActionResult UiTypography()
    {
        return View("./UI/UiTypography");
    }

    public IActionResult UiTypographt()
    {
        return View("./UI/UiTypographt");
    }

    public IActionResult AppProfile()
    {
        return View("./Admin/AppProfile");
    }
}
