﻿using Examination.Models;
using Examination.Models.RequestModels;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Examination.Controllers
{
    public class QuestionController : ApiController
    {
        QuestionService questionService = new QuestionService();

        // GET api/Question
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<QuestionAnswersModel> res = questionService.GetAll()
                .Select(q => new QuestionAnswersModel
                {
                    Question = new QuestionModel { Id = q.Id, Content = q.Content },
                    Answers = q.Answers.Select(a => new AnswerModel { Id = a.Id, Content = a.Content }).ToList()
                }).ToList();

            return Ok(res);
        }

        [HttpPost]
        public IHttpActionResult generateExam([FromBody] GenerateExamModel model)
        {
            var createdExamQuestions =  questionService.generateExam(model.courseID, model.numberOfMCQ, model.numberOfTRUE_FALSE , model.InstructorID);
            return Ok(createdExamQuestions);
        }
    }
}
