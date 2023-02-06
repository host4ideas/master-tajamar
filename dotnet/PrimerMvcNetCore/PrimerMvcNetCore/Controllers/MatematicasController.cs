using Microsoft.AspNetCore.Mvc;
using PrimerMvcNetCore.Models;
using System;
using System.Diagnostics;
using PrimerMvcNetCore.Models;

namespace PrimerMvcNetCore.Controllers
{
    public class MatematicasController : Controller
    {
        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult SumarNumerosGet(int num1, int num2)
        {
            ViewData["RESULTADO"] = num1 + num2;
            return View();
        }

        public IActionResult SumarNumerosPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SumarNumerosPost(int num1, int num2)
        {
            ViewData["RESULTADO"] = num1 + num2;
            return View();
        }

        public IActionResult ConjeturaCollatz()
        {
            return View();
            //return View(new List<int>());
        }

        [HttpPost]
        public IActionResult ConjeturaCollatz(int num)
        {
            var result = new List<int>();

            Thread thr1 = new(() => result = CalcularCollatz(num));
            thr1.Start();
            thr1.Join(10000); // 10s time live

            return View(result);
        }

        private static List<int> CalcularCollatz(int num)
        {
            List<int> ints = new();
            try
            {
                while (num != 1)
                {
                    if (num % 2 == 0)
                        num /= 2;
                    else
                        num = num * 3 + 1;
                    ints.Add(num);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Thread expception: " + ex.Message);
            }
            return ints;
        }

        public IActionResult TablaMultiplicar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TablaMultiplicar(int num)
        {
            List<ResultMultiplicarModel> results = new();

            for (int i = 0; i <= 10; i++)
            {
                results.Add(new ResultMultiplicarModel(num * i, num + " X " + i));
            }

            return View(results);
        }
    }
}