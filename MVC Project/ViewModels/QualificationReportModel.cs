﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Project.ViewModels
{
    public class QualificationReportModel
    {
        public int QualificationId { get; set; }

        public string Degree { get; set; }

        public int PassingYear { get; set; }

        public string Institute { get; set; }

        public string Result { get; set; }

        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
    }
}