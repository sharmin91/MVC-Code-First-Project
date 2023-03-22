﻿using MVC_Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVC_Project.ViewModels;
using CrystalDecisions.CrystalReports.Engine;

namespace MVC_Project.Controllers
{
    public class CrystalController : Controller
    {
        CandidateDbContext db = new CandidateDbContext();
        // GET: Reports
        public ActionResult Index()
        {

            return View(db.Candidates.ToList()); ;
        }
        public ActionResult QualificationReport()
        {
            var data = db.Qualifications.Include(x => x.Candidate).Select(x => new QualificationReportModel
            {
                CandidateName = x.Candidate.CandidateName,
                CandidateId = x.CandidateId,
                Degree = x.Degree,
                PassingYear = x.PassingYear,
                Result = x.Result,
                Institute = x.Institute
            }).ToList();
            return View(data);
        }
        public ActionResult CandidatePDF()
        {
            var data = db.Candidates.AsEnumerable().Select(x => new CandidateViewModel
            {
                CandidateId = x.CandidateId,
                CandidateName = x.CandidateName,
                AppliedFor = x.AppliedFor,
                BirthDate = x.BirthDate,
                ExpectedSalary = x.ExpectedSalary,
                Picture = x.Picture,
                Image = System.IO.File.ReadAllBytes(System.IO.Path.Combine(Server.MapPath("~/Pictures"), x.Picture))
            })
                .ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport1.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "Candidates.pdf");

        }
        public ActionResult CandidateExcel()
        {
            var data = db.Candidates.AsEnumerable().Select(x => new CandidateViewModel
            {
                CandidateId = x.CandidateId,
                CandidateName = x.CandidateName,
                AppliedFor = x.AppliedFor,
                BirthDate = x.BirthDate,
                ExpectedSalary = x.ExpectedSalary,
                Picture = x.Picture,
                Image = System.IO.File.ReadAllBytes(System.IO.Path.Combine(Server.MapPath("~/Pictures"), x.Picture))
            })
                .ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport1.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/vnd.ms-excel", "CandidateExcel.xls");

        }
        public ActionResult QualificationPDF()
        {
            var data = db.Qualifications.Include(x => x.Candidate).Select(x => new QualificationReportModel
            {
                CandidateName = x.Candidate.CandidateName,
                CandidateId = x.CandidateId,
                Degree = x.Degree,
                PassingYear = x.PassingYear,
                Result = x.Result,
                Institute = x.Institute
            }).ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport2.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "Qualifaction.pdf");
        }
        public ActionResult QualificationExcel()
        {
            var data = db.Qualifications.Include(x => x.Candidate).Select(x => new QualificationReportModel
            {
                CandidateName = x.Candidate.CandidateName,
                CandidateId = x.CandidateId,
                Degree = x.Degree,
                PassingYear = x.PassingYear,
                Result = x.Result,
                Institute = x.Institute
            }).ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport2.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/vnd.ms-excel", "QualificationExcelFile.xls");
        }
    }


}