﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkFlow.Persistence.Context;

#nullable disable

namespace WorkFlow.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230410202422_linkingRequestWorkFlowMasterToFormControlConditions")]
    partial class linkingRequestWorkFlowMasterToFormControlConditions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WorkFlow.Domain.Entities.Positions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ArbName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("EngName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.RequestFormControlConditionUserLevels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFinal")
                        .HasColumnType("bit");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("RequestConditionId")
                        .HasColumnType("int");

                    b.Property<bool>("Required")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserPositionId")
                        .HasColumnType("int");

                    b.Property<int?>("UserTypeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestConditionId");

                    b.HasIndex("UserPositionId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("RequestFormControlConditionUserLevels");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.RequestFormControls", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ArbCaption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArbToolTip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ControlName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ControlType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("EngCaption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsHide")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsNumeric")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.Property<int>("RequestFormId")
                        .HasColumnType("int");

                    b.Property<string>("ToolTip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RequestFormId");

                    b.ToTable("RequestFormControls");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.RequestForms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ArbDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArbName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("EngDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rank")
                        .HasColumnType("int");

                    b.Property<int>("RequestTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RequestTypeId");

                    b.ToTable("RequestForms");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.RequestType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ArbName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("EngName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("RequestTypes");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.RequestWorkFlowMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("RequestFormId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WorkFlowName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RequestFormId");

                    b.ToTable("RequestWorkFlowMasters");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.RequstFormControlConditions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConditionOperator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("FormControlId")
                        .HasColumnType("int");

                    b.Property<int>("RequestWorkFlowMasterId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FormControlId");

                    b.HasIndex("RequestWorkFlowMasterId");

                    b.ToTable("RequstFormControlConditions");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.UserActions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ArbName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("EngName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("UserActions");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ArbName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("EngName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.RequestFormControlConditionUserLevels", b =>
                {
                    b.HasOne("WorkFlow.Domain.Entities.RequstFormControlConditions", "FormControlConditions")
                        .WithMany("FormControlConditionUserLevels")
                        .HasForeignKey("RequestConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkFlow.Domain.Entities.Positions", "Positions")
                        .WithMany("FormControlConditionUserLevels")
                        .HasForeignKey("UserPositionId");

                    b.HasOne("WorkFlow.Domain.Entities.UserType", "UserType")
                        .WithMany("FormControlConditionUserLevels")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormControlConditions");

                    b.Navigation("Positions");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.RequestFormControls", b =>
                {
                    b.HasOne("WorkFlow.Domain.Entities.RequestForms", "RequestForms")
                        .WithMany("FormControls")
                        .HasForeignKey("RequestFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestForms");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.RequestForms", b =>
                {
                    b.HasOne("WorkFlow.Domain.Entities.RequestType", "RequestType")
                        .WithMany("RequestForms")
                        .HasForeignKey("RequestTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestType");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.RequestWorkFlowMaster", b =>
                {
                    b.HasOne("WorkFlow.Domain.Entities.RequestForms", "RequestForms")
                        .WithMany("RequestWorkFlowMaster")
                        .HasForeignKey("RequestFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestForms");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.RequstFormControlConditions", b =>
                {
                    b.HasOne("WorkFlow.Domain.Entities.RequestFormControls", "FormControls")
                        .WithMany("ControlConditions")
                        .HasForeignKey("FormControlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkFlow.Domain.Entities.RequestWorkFlowMaster", "RequestWorkFlowMaster")
                        .WithMany("RequstFormControlConditions")
                        .HasForeignKey("RequestWorkFlowMasterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FormControls");

                    b.Navigation("RequestWorkFlowMaster");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.Positions", b =>
                {
                    b.Navigation("FormControlConditionUserLevels");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.RequestFormControls", b =>
                {
                    b.Navigation("ControlConditions");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.RequestForms", b =>
                {
                    b.Navigation("FormControls");

                    b.Navigation("RequestWorkFlowMaster");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.RequestType", b =>
                {
                    b.Navigation("RequestForms");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.RequestWorkFlowMaster", b =>
                {
                    b.Navigation("RequstFormControlConditions");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.RequstFormControlConditions", b =>
                {
                    b.Navigation("FormControlConditionUserLevels");
                });

            modelBuilder.Entity("WorkFlow.Domain.Entities.UserType", b =>
                {
                    b.Navigation("FormControlConditionUserLevels");
                });
#pragma warning restore 612, 618
        }
    }
}
