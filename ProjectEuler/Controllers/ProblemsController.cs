using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectEuler.Models;

namespace ProjectEuler.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemRepository _problemRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public ProblemsController()
            : this(new ProblemRepository())
        {
        }

        public ProblemsController(IProblemRepository problemRepository)
        {
            this._problemRepository = problemRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="problem"></param>
        /// <returns></returns>
        private Problem Solve(Problem problem)
        {
            if (problem != null)
            {
                var type = typeof(Solutions);
                var method = type.GetMethod(problem.FunctionName);
                var result = method.Invoke(this, null);

                problem.Answer = result.ToString();
                _problemRepository.InsertOrUpdate(problem);
                _problemRepository.Save();
            }

            return problem;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            return View(_problemRepository.All);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            Problem problem = _problemRepository.Find(id);

            if (problem == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (String.IsNullOrEmpty(problem.Answer))
            {
                problem = Solve(problem);
            }

            return View(problem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View(new Problem { Language = "C#" });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="problem"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Problem problem)
        {
            if (problem == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                problem = Solve(problem);

                return RedirectToAction("Index");
            }

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            Problem problem = _problemRepository.Find(id);

            if (problem == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(problem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="problem"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Problem problem)
        {
            if (problem == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                problem = Solve(problem);

                return RedirectToAction("Index");
            }

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            Problem problem = _problemRepository.Find(id);

            if (problem == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(problem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _problemRepository.Delete(id);
            _problemRepository.Save();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _problemRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Recalculate(int id)
        {
            Problem problem = _problemRepository.Find(id);

            if (problem == null)
            {
                return RedirectToAction("Index", "Home");
            }

            problem = Solve(problem);

            return RedirectToAction("Details", new { id = id });
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult RecalculateAll()
        //{
        //    foreach (var problem in _problemRepository.All)
        //    {
        //        var type = typeof(Solutions);
        //        var method = type.GetMethod(problem.FunctionName);
        //        var result = method.Invoke(this, null);

        //        problem.Answer = result.ToString();
        //        _problemRepository.InsertOrUpdate(problem);
        //    }

        //    _problemRepository.Save();

        //    return RedirectToAction("Index");
        //}
    }
}

