﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5Calculator.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Configuration;

namespace Mvc5Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        private CalculatorDBContext db = new CalculatorDBContext();

        // GET: Calculator
        public ActionResult Index()
        {
            //var calculations = from calc in db.Calulator
            //                   select new Calculator
            //                   {
            //                       Operand1 = calc.Operand1,
            //                       Operand2 = calc.Operand2,
            //                       Result = calc.Result,
            //                       Operator = calc.Operator
            //                   };
            //return View(calculations);
            return View();
        }

        public JsonResult Evaluate(float a, float b, char operation)
        {
            double result = 0;

            switch (operation)
            {
                case '+':
                    result = a + b;
                    break;
                case '-':
                    result = a - b;
                    break;
                case '×':
                    result = a * b;
                    break;
                case '÷':
                    result = a / b;
                    break;
                case '^':
                    result = Math.Pow(a, b);
                    break;
            }
            // TempData["key"] = value;
            //TempData["Operand1"] = a;
            //System.Diagnostics.Debug.WriteLine("RESULT IS " + result + " a:" + a + " b:" + b);
            //System.Diagnostics.Debug.WriteLine(TempData["Operator"]);
            return Json(result);
        }

        [HttpPost]
        public ActionResult AddCalc(float Operand1, float Operand2, string Operator, float Result)
        {
            System.Diagnostics.Debug.WriteLine(TempData["Operand1"]); // this works!!!
            try
            {
                Calculator calcObj = new Calculator();
                calcObj.Operand1 = Operand1;
                calcObj.Operand2 = Operand2;
                calcObj.Operator = Operator;
                calcObj.Result = Result;
                
                db.Calulator.Add(calcObj);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error occured");
            }
            return RedirectToAction("Index") ;
        }

        public ActionResult Delete()
        {


            return RedirectToAction("Index");
        }
                
    }
}