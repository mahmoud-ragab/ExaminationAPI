using CrystalDecisions.CrystalReports.Engine;
using Data;
using Data.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Hosting;
using System.Web.Http;
 

namespace Examination.Controllers
{
    public class ExamController : ApiController
    {
        public ExamService ExamService = new ExamService();
        public ExaminationContext examinationContext = new ExaminationContext();

        // GET api/Customer
        [Route("api/solvedExams/{id}")]
       
        public IHttpActionResult GetSolvedExams(int id)
        {
            return Ok(ExamService.GetSlovedExams(id));
        }

        [Route("api/NotSolvedExams/{id}")]

        public IHttpActionResult GetNotSolvedExams(int id)
        {
            return Ok(ExamService.GetNotSlovedExams(id));
        }


        [Route("api/countsolvedExams/{id}")]
        public IHttpActionResult GetSolvedExamsCount(int id)
        {
            return Ok(ExamService.Get_CountOfSolvedExams(id));
        }

        [Route("api/countnotsolvedExams/{id}")]
        public IHttpActionResult GetNotSolvedExamsCount(int id)
        {
            return Ok(ExamService.Get_CountOfNotSolvedExams(id));
        }


        [Route("api/Report/{ExamID}/{StudentID}")]
         
        [HttpGet]
        public HttpResponseMessage getReport(int ExamID, int StudentID)
        {

            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            examinationContext.Configuration.ProxyCreationEnabled = false;
           

            var Exam_ID = new SqlParameter("@ExamID", ExamID);
            var Student_ID = new SqlParameter("@StudentID", StudentID);


            var data = examinationContext.Database.SqlQuery<ExamReport>("sp_ExamReport @ExamID,@StudentID", Exam_ID, Student_ID).ToList();

            ReportDocument report = new ReportDocument();
            report.Load(Path.Combine(HostingEnvironment.MapPath("~/Reports/rpt_ExamReport.rpt")));


            List<ExamReport> model = new List<ExamReport>();

           

            foreach (var details in data)
            {
                ExamReport obj = new ExamReport();
                obj.QuestionID = details.QuestionID;
                obj.Question = details.Question;
                obj.Exam_Id = details.Exam_Id;
                obj.CorrectAnswerID = details.CorrectAnswerID;
                obj.CorrectAnswer = details.CorrectAnswer;
                obj.StudentAnswerID = details.StudentAnswerID;
                obj.StudentAnswer = details.StudentAnswer;
                obj.Result = details.Result;
                obj.studentName = details.studentName;
                obj.studentAddress = details.studentAddress;
                obj.CourseName = details.CourseName;
                obj.InstructorName = details.InstructorName;
                obj.TopicName = details.TopicName;

                model.Add(obj);

            }

            /*
              ConnectionInfo connectInfo = new ConnectionInfo()
            {
                ServerName = @".\sqlexpress",
                DatabaseName = "Examination",
                UserID = "sa",
                Password = "P@ssw0rd"
            };

            report.SetDatabaseLogon("sa", "P@ssw0rd");
            foreach (CrystalDecisions.CrystalReports.Engine.Table tbl in report.Database.Tables)
            {
                tbl.LogOnInfo.ConnectionInfo = connectInfo;
                tbl.ApplyLogOnInfo(tbl.LogOnInfo);
            }
             */

            report.SetDataSource(model);


            Stream stream = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
         
            stream.Seek(0,SeekOrigin.Begin);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.Add("X.filename","Report.pdf");
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
            httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline"); // for download just write "attachment"
            httpResponseMessage.Content.Headers.ContentDisposition.FileName ="ExamReport.pdf" ;

            httpResponseMessage.StatusCode = HttpStatusCode.OK;
            return httpResponseMessage;

        }

 


    }
}
