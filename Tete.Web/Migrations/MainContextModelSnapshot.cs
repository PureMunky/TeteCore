﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tete.Api.Contexts;

namespace Tete.Web.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tete.Models.Authentication.AccessRole", b =>
                {
                    b.Property<Guid>("AccessRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AccessRoleId");

                    b.ToTable("AccessRoles");
                });

            modelBuilder.Entity("Tete.Models.Authentication.Login", b =>
                {
                    b.Property<Guid>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastAccessed")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginId");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("Tete.Models.Authentication.Session", b =>
                {
                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUsed")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Token");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Tete.Models.Authentication.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Tete.Models.Authentication.UserBlock", b =>
                {
                    b.Property<Guid>("UserBlockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PrivateComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserBlockId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBlocks");
                });

            modelBuilder.Entity("Tete.Models.Config.Flag", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Value")
                        .HasColumnType("bit");

                    b.HasKey("Key");

                    b.ToTable("Flags");
                });

            modelBuilder.Entity("Tete.Models.Config.Setting", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LastUpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Key");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Tete.Models.Content.Keyword", b =>
                {
                    b.Property<Guid>("KeywordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Restricted")
                        .HasColumnType("bit");

                    b.HasKey("KeywordId");

                    b.ToTable("Keywords");
                });

            modelBuilder.Entity("Tete.Models.Content.Link", b =>
                {
                    b.Property<Guid>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Reviewed")
                        .HasColumnType("bit");

                    b.HasKey("LinkId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("Tete.Models.Content.Topic", b =>
                {
                    b.Property<Guid>("TopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Elligible")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TopicId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Tete.Models.Content.TopicKeyword", b =>
                {
                    b.Property<Guid>("TopicKeywordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("KeywordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TopicKeywordId");

                    b.HasIndex("KeywordId");

                    b.HasIndex("TopicId");

                    b.ToTable("TopicKeywords");
                });

            modelBuilder.Entity("Tete.Models.Content.TopicLink", b =>
                {
                    b.Property<Guid>("TopicLinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LinkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TopicLinkId");

                    b.HasIndex("LinkId");

                    b.HasIndex("TopicId");

                    b.ToTable("TopicLinks");
                });

            modelBuilder.Entity("Tete.Models.Localization.Element", b =>
                {
                    b.Property<Guid>("ElementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ElementId");

                    b.HasIndex("LanguageId");

                    b.ToTable("Elements");
                });

            modelBuilder.Entity("Tete.Models.Localization.Language", b =>
                {
                    b.Property<Guid>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Tete.Models.Localization.UserLanguage", b =>
                {
                    b.Property<Guid>("UserLanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<bool>("Read")
                        .HasColumnType("bit");

                    b.Property<bool>("Speak")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserLanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("UserLanguages");
                });

            modelBuilder.Entity("Tete.Models.Logging.Log", b =>
                {
                    b.Property<Guid>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MachineName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Occured")
                        .HasColumnType("datetime2");

                    b.Property<string>("StackTrace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LogId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Tete.Models.Relationships.Assessment", b =>
                {
                    b.Property<Guid>("AssessmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("AssessmentResult")
                        .HasColumnType("bit");

                    b.Property<string>("AssessorComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssessorDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("AssessorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CompletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LearnerDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LearnerUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MentorshipId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AssessmentId");

                    b.HasIndex("AssessorUserId");

                    b.HasIndex("LearnerUserId");

                    b.HasIndex("TopicId");

                    b.ToTable("Assessments");
                });

            modelBuilder.Entity("Tete.Models.Relationships.Mentorship", b =>
                {
                    b.Property<Guid>("MentorshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LearnerClosed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LearnerClosedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LearnerContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LearnerUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("MentorClosed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("MentorClosedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MentorContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MentorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MentorshipId");

                    b.ToTable("Mentorships");
                });

            modelBuilder.Entity("Tete.Models.Relationships.UserTopic", b =>
                {
                    b.Property<Guid>("UserTopicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserTopicID");

                    b.HasIndex("TopicId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTopics");
                });

            modelBuilder.Entity("Tete.Models.Users.Evaluation", b =>
                {
                    b.Property<Guid>("EvaluationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MentorshipId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("EvaluationId");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("Tete.Models.Users.Profile", b =>
                {
                    b.Property<Guid>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrivateAbout")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProfileId");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Tete.Models.Authentication.UserBlock", b =>
                {
                    b.HasOne("Tete.Models.Authentication.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tete.Models.Content.TopicKeyword", b =>
                {
                    b.HasOne("Tete.Models.Content.Keyword", "Keyword")
                        .WithMany()
                        .HasForeignKey("KeywordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tete.Models.Content.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tete.Models.Content.TopicLink", b =>
                {
                    b.HasOne("Tete.Models.Content.Link", "Link")
                        .WithMany()
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tete.Models.Content.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tete.Models.Localization.Element", b =>
                {
                    b.HasOne("Tete.Models.Localization.Language", null)
                        .WithMany("Elements")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tete.Models.Localization.UserLanguage", b =>
                {
                    b.HasOne("Tete.Models.Localization.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tete.Models.Relationships.Assessment", b =>
                {
                    b.HasOne("Tete.Models.Authentication.User", "AssessorUser")
                        .WithMany()
                        .HasForeignKey("AssessorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tete.Models.Authentication.User", "LearnerUser")
                        .WithMany()
                        .HasForeignKey("LearnerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tete.Models.Content.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tete.Models.Relationships.UserTopic", b =>
                {
                    b.HasOne("Tete.Models.Content.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tete.Models.Authentication.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
