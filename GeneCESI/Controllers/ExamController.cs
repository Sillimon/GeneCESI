using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeneCESI.Lib.Objects;

namespace GeneCESI.Controllers
{
    public class ExamController : Controller
    {
        Exam exam = new Exam("Mon premier examen", 5, 30, new DateTime(2020, 11, 21), 2, 0);
        List<Question> questions = new List<Question>();

        public ActionResult DisplayExam()
        {
            questions.Add(new Question("Est-ce que l'interface est belle ?", Lib.Helpers.EnumHelper.QuestionType.YesNo,
            new Answer("Yes", "Yes;No", 0), exam));
            questions.Add(new Question("Question à choix multiples ?", Lib.Helpers.EnumHelper.QuestionType.MultipleChoice,
                new Answer("reponse D", "reponse A;reponse B;reponse C;reponse D"),exam));
            return View(questions);
        }

        public void SendExam_OnButtonClick()
        {
            //Récuperer les données de la view
            //Envoyer les réponses a l'examen sur la BDD
            //Renvoyer une view qui indique que l'examen a bien été posté.
        }

        public ActionResult CreationExamen()
        {
            return View();
        }

    }
}
