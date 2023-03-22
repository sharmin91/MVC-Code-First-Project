﻿namespace MVC_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        CandidateName = c.String(nullable: false, maxLength: 50),
                        BirthDate = c.DateTime(nullable: false),
                        AppliedFor = c.String(nullable: false, maxLength: 30),
                        ExpectedSalary = c.Decimal(nullable: false, storeType: "money"),
                        WorkFromHome = c.Boolean(nullable: false),
                        Picture = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.CandidateId);
            
            CreateTable(
                "dbo.Qualifications",
                c => new
                    {
                        QualificationId = c.Int(nullable: false, identity: true),
                        Degree = c.String(nullable: false, maxLength: 50),
                        PassingYear = c.Int(nullable: false),
                        Institute = c.String(nullable: false, maxLength: 50),
                        Result = c.String(nullable: false, maxLength: 20),
                        CandidateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QualificationId)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .Index(t => t.CandidateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Qualifications", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.Qualifications", new[] { "CandidateId" });
            DropTable("dbo.Qualifications");
            DropTable("dbo.Candidates");
        }
    }
}
