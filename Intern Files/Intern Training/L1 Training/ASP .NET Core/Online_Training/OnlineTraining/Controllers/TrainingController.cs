

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OnlineTraining.Models;
namespace OnlineTraining.Controllers {

    public class TrainingController : Controller
    {
        private static List<Training> trainings = new List<Training>();
        private static int nextId = 1;

        public ActionResult Index()
        {
            return View(trainings);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Training training)
        {
            training.Id = nextId++;
            trainings.Add(training);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var training = trainings.FirstOrDefault(t => t.Id == id);
            return View(training);
        }

        [HttpPost]
        public ActionResult Edit(Training updated)
        {
            var training = trainings.FirstOrDefault(t => t.Id == updated.Id);
            if (training != null)
            {
                training.Title = updated.Title;
                training.Description = updated.Description;
                training.Date = updated.Date;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var training = trainings.FirstOrDefault(t => t.Id == id);
            return View(training);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var training = trainings.FirstOrDefault(t => t.Id == id);
            if (training != null)
            {
                trainings.Remove(training);
            }
            return RedirectToAction("Index");
        }
    }
}
