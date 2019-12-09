using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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




        public IHttpActionResult ExamReport(int ExamID ,int StudentID)
        {


            var Exam_ID = new SqlParameter("@ExamID", ExamID);
            var Student_ID = new SqlParameter("@StudentID", StudentID);


            var data = examinationContext.Database.SqlQuery<ExamReport>("sp_ExamReport @ExamID,@StudentID", Exam_ID, StudentID).ToList();



            return Ok();
             





            /*

           // List<Customer> allCustomer = new List<Customer>();
           // allCustomer = context.Customers.ToList();


           ReportDocument rd = new ReportDocument();

           //rd.Load(Path.Combine(Server.MapPath("~/Reports"), "RPT_Student_Report.rpt"));
           // rd.Load(System.IO.Path.Combine("~/Reports", "RPT_Student_Report.rpt"));
           rd.Load(HttpContext.Current.Server.MapPath("~/Reports/RPT_Student_Report.rpt"));

           rd.SetDataSource(data);

           Response.Buffer = false;
           Response.ClearContent();
           Response.ClearHeaders();


           Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
           stream.Seek(0, SeekOrigin.Begin);
           return File(stream, "application/pdf", "ExamReport.pdf");
           */

        }




        [Route("api/Report/")]
        [HttpGet]
        //HttpResponseMessage
        public IHttpActionResult ExportReport()
        {


            var Exam_ID = new SqlParameter("@ExamID", 1);
            var Student_ID = new SqlParameter("@StudentID", 1);


            var data = examinationContext.Database.SqlQuery<ExamReport>("sp_ExamReport @ExamID,@StudentID", Exam_ID, Student_ID).ToList();
            
            List<ExamReport> model = new List<ExamReport>();

            ReportDocument rd = new ReportDocument();

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

            rd.Load(Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Reports"), "RPT_Student_Report.rpt"));
            ConnectionInfo connectInfo = new ConnectionInfo()
            {
                ServerName = @".\sqlexpress",
                DatabaseName = "Examination",
                UserID = "sa",
                Password = "P@ssw0rd"
            };
            rd.SetDatabaseLogon("sa", "P@ssw0rd");
            foreach (CrystalDecisions.CrystalReports.Engine.Table tbl in rd.Database.Tables)
            {
                tbl.LogOnInfo.ConnectionInfo = connectInfo;
                tbl.ApplyLogOnInfo(tbl.LogOnInfo);
            }
            rd.SetDataSource(model);

             
           /* Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();*/

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelWorkbook);
            stream.Seek(0, SeekOrigin.Begin);


           // return File(stream, "application/pdf", "examReport.pdf");

            /* var path = @"E:\GPITI\ExaminationAPI\Examination\Reports\RPT_Student_Report.rpt";
             HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
              stream = new FileStream(path, FileMode.Open, FileAccess.Read);
             result.Content = new StreamContent(stream);
             result.Content.Headers.ContentType =
                 new MediaTypeHeaderValue("application/pdf");
             return result;*/

           return Ok(data);

        }


    }
}
