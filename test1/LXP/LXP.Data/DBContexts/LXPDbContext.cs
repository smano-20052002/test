﻿using System;
using System.Collections.Generic;
using LXP.Data;
using LXP.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace LXP.Data.DBContexts;

public partial class LXPDbContext : DbContext
{
    public LXPDbContext()
    {
    }

    public LXPDbContext(DbContextOptions<LXPDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseCategory> CourseCategories { get; set; }

    public virtual DbSet<CourseLevel> CourseLevels { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<FeedbackQuestion> FeedbackQuestions { get; set; }

    public virtual DbSet<FeedbackQuestionOption> FeedbackQuestionOptions { get; set; }

    public virtual DbSet<FeedbackResponse> FeedbackResponses { get; set; }

    public virtual DbSet<Learner> Learners { get; set; }

    public virtual DbSet<LearnerAnswer> LearnerAnswers { get; set; }

    public virtual DbSet<LearnerAttempt> LearnerAttempts { get; set; }

    public virtual DbSet<LearnerProfile> LearnerProfiles { get; set; }

    public virtual DbSet<LearnerProgress> LearnerProgresses { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<PasswordHistory> PasswordHistories { get; set; }

    public virtual DbSet<QuestionOption> QuestionOptions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
     // => optionsBuilder.UseMySql("server=localhost;database=lxp;uid=root;pwd=Password@12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PRIMARY");

            entity.ToTable("course");

            entity.HasIndex(e => e.CatagoryId, "IX_course_catagory_id");

            entity.HasIndex(e => e.LevelId, "IX_course_level_id");

            entity.Property(e => e.CourseId)
                .HasColumnName("course_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CatagoryId)
                .HasColumnName("catagory_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsAvailable).HasColumnName("is_available");
            entity.Property(e => e.LevelId)
                .HasColumnName("level_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Thumbnail).HasColumnName("thumbnail");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.Catagory).WithMany(p => p.Courses).HasForeignKey(d => d.CatagoryId);

            entity.HasOne(d => d.Level).WithMany(p => p.Courses).HasForeignKey(d => d.LevelId);
        });

        modelBuilder.Entity<CourseCategory>(entity =>
        {
            entity.HasKey(e => e.CatagoryId).HasName("PRIMARY");

            entity.ToTable("course_category");

            entity.Property(e => e.CatagoryId)
                .HasColumnName("catagory_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .HasColumnName("category");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
        });

        modelBuilder.Entity<CourseLevel>(entity =>
        {
            entity.HasKey(e => e.LevelId).HasName("PRIMARY");

            entity.ToTable("course_levels");

            entity.Property(e => e.LevelId)
                .HasColumnName("level_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Level)
                .HasMaxLength(50)
                .HasColumnName("level");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PRIMARY");

            entity.ToTable("enrollments");

            entity.HasIndex(e => e.CourseId, "IX_enrollments_course_id");

            entity.HasIndex(e => e.LearnerId, "IX_enrollments_learner_id");

            entity.Property(e => e.EnrollmentId)
                .HasColumnName("enrollment_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CourseId)
                .HasColumnName("course_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EnrollRequestStatus).HasColumnName("enroll_request_status");
            entity.Property(e => e.EnrollStatus).HasColumnName("enroll_status");
            entity.Property(e => e.EnrollmentDate)
                .HasColumnType("datetime")
                .HasColumnName("enrollment_date");
            entity.Property(e => e.LearnerId)
                .HasColumnName("learner_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments).HasForeignKey(d => d.CourseId);

            entity.HasOne(d => d.Learner).WithMany(p => p.Enrollments).HasForeignKey(d => d.LearnerId);
        });

        modelBuilder.Entity<FeedbackQuestion>(entity =>
        {
            entity.HasKey(e => e.FeedbackQuestionId).HasName("PRIMARY");

            entity.ToTable("feedback_questions");

            entity.HasIndex(e => e.TopicId, "IX_feedback_questions_topic_id");

            entity.Property(e => e.FeedbackQuestionId)
                .HasColumnName("feedback_question_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.FeedbackType)
                .HasMaxLength(15)
                .HasColumnName("feedback_type");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Question).HasColumnName("question");
            entity.Property(e => e.QuestionNo).HasColumnName("question_no");
            entity.Property(e => e.QuestionType)
                .HasMaxLength(15)
                .HasColumnName("question_type");
            entity.Property(e => e.TopicId)
                .HasColumnName("topic_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");

            entity.HasOne(d => d.Topic).WithMany(p => p.FeedbackQuestions).HasForeignKey(d => d.TopicId);
        });

        modelBuilder.Entity<FeedbackQuestionOption>(entity =>
        {
            entity.HasKey(e => e.OptionId).HasName("PRIMARY");

            entity.ToTable("feedback_question_options");

            entity.HasIndex(e => e.FeedbackQuestionId, "IX_feedback_question_options_feedback_question_id");

            entity.Property(e => e.OptionId)
                .HasColumnName("option_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.FeedbackQuestionId)
                .HasColumnName("feedback_question_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Option).HasColumnName("option");

            entity.HasOne(d => d.FeedbackQuestion).WithMany(p => p.FeedbackQuestionOptions)
                .HasForeignKey(d => d.FeedbackQuestionId)
                .HasConstraintName("FK_feedback_question_options_feedback_questions_feedback_questi~");
        });

        modelBuilder.Entity<FeedbackResponse>(entity =>
        {
            entity.HasKey(e => e.FeedbackResponseId).HasName("PRIMARY");

            entity.ToTable("feedback_responses");

            entity.HasIndex(e => e.FeedbackQuestionId, "IX_feedback_responses_feedback_question_id");

            entity.HasIndex(e => e.FeedbackQuestionOptionoptionId, "IX_feedback_responses_feedback_question_optionoption_id");

            entity.HasIndex(e => e.LearnerId, "IX_feedback_responses_learner_id");

            entity.Property(e => e.FeedbackResponseId)
                .HasColumnName("feedback_response_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.FeedbackQuestionId)
                .HasColumnName("feedback_question_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.FeedbackQuestionOptionoptionId)
                .HasColumnName("feedback_question_optionoption_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.LearnerId)
                .HasColumnName("learner_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Response).HasColumnName("response");

            entity.HasOne(d => d.FeedbackQuestion).WithMany(p => p.FeedbackResponses).HasForeignKey(d => d.FeedbackQuestionId);

            entity.HasOne(d => d.FeedbackQuestionOptionoption).WithMany(p => p.FeedbackResponses)
                .HasForeignKey(d => d.FeedbackQuestionOptionoptionId)
                .HasConstraintName("FK_feedback_responses_feedback_question_options_feedback_questi~");

            entity.HasOne(d => d.Learner).WithMany(p => p.FeedbackResponses).HasForeignKey(d => d.LearnerId);
        });

        modelBuilder.Entity<Learner>(entity =>
        {
            entity.HasKey(e => e.LearnerId).HasName("PRIMARY");

            entity.ToTable("learners");

            entity.HasIndex(e => e.Email, "email_UNIQUE").IsUnique();

            entity.Property(e => e.LearnerId)
                .HasColumnName("learner_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.AccountStatus).HasColumnName("account_status");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .HasColumnName("role");
            entity.Property(e => e.UnblockRequest).HasColumnName("unblock_request");
            entity.Property(e => e.UserLastLogin)
                .HasColumnType("datetime")
                .HasColumnName("user_last_login");
        });

        modelBuilder.Entity<LearnerAnswer>(entity =>
        {
            entity.HasKey(e => e.LearnerAnswerId).HasName("PRIMARY");

            entity.ToTable("learner_answers");

            entity.HasIndex(e => e.LearnerAttemptId, "IX_learner_answers_learner_attempt_id");

            entity.HasIndex(e => e.QuestionOptionId, "IX_learner_answers_question_option_id");

            entity.HasIndex(e => e.QuizQuestionId, "IX_learner_answers_quiz_question_id");

            entity.Property(e => e.LearnerAnswerId)
                .HasColumnName("learner_answer_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.LearnerAttemptId)
                .HasColumnName("learner_attempt_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.QuestionOptionId)
                .HasColumnName("question_option_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.QuizQuestionId)
                .HasColumnName("quiz_question_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");

            entity.HasOne(d => d.LearnerAttempt).WithMany(p => p.LearnerAnswers).HasForeignKey(d => d.LearnerAttemptId);

            entity.HasOne(d => d.QuestionOption).WithMany(p => p.LearnerAnswers).HasForeignKey(d => d.QuestionOptionId);

            entity.HasOne(d => d.QuizQuestion).WithMany(p => p.LearnerAnswers).HasForeignKey(d => d.QuizQuestionId);
        });

        modelBuilder.Entity<LearnerAttempt>(entity =>
        {
            entity.HasKey(e => e.LearnerAttemptId).HasName("PRIMARY");

            entity.ToTable("learner_attempts");

            entity.HasIndex(e => e.LearnerId, "IX_learner_attempts_learner_id");

            entity.HasIndex(e => e.QuizId, "IX_learner_attempts_quiz_id");

            entity.Property(e => e.LearnerAttemptId)
                .HasColumnName("learner_attempt_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.AttemptCount).HasColumnName("attempt_count");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.LearnerId)
                .HasColumnName("learner_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.QuizId)
                .HasColumnName("quiz_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");

            entity.HasOne(d => d.Learner).WithMany(p => p.LearnerAttempts).HasForeignKey(d => d.LearnerId);

            entity.HasOne(d => d.Quiz).WithMany(p => p.LearnerAttempts).HasForeignKey(d => d.QuizId);
        });

        modelBuilder.Entity<LearnerProfile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PRIMARY");

            entity.ToTable("learner_profiles");

            entity.HasIndex(e => e.LearnerId, "IX_learner_profiles_learner_id");

            entity.Property(e => e.ProfileId)
                .HasColumnName("profile_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .HasColumnName("contact_number");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.LearnerId)
                .HasColumnName("learner_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ProfilePhoto).HasColumnName("profile_photo");
            entity.Property(e => e.Stream)
                .HasMaxLength(50)
                .HasColumnName("stream");

            entity.HasOne(d => d.Learner).WithMany(p => p.LearnerProfiles).HasForeignKey(d => d.LearnerId);
        });

        modelBuilder.Entity<LearnerProgress>(entity =>
        {
            entity.HasKey(e => e.LearnerProgressId).HasName("PRIMARY");

            entity.ToTable("learner_progress");

            entity.HasIndex(e => e.CourseId, "IX_learner_progress_course_id");

            entity.HasIndex(e => e.LearnerId, "IX_learner_progress_learner_id");

            entity.HasIndex(e => e.MaterialId, "IX_learner_progress_material_id");

            entity.HasIndex(e => e.TopicId, "IX_learner_progress_topic_id");

            entity.Property(e => e.LearnerProgressId)
                .HasColumnName("learner_progress_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CourseId)
                .HasColumnName("course_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.IsWatched).HasColumnName("is_watched");
            entity.Property(e => e.LearnerId)
                .HasColumnName("learner_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.MaterialId)
                .HasColumnName("material_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.TopicId)
                .HasColumnName("topic_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.TotalTime)
                .HasColumnType("time")
                .HasColumnName("total_time");
            entity.Property(e => e.WatchTime)
                .HasColumnType("time")
                .HasColumnName("watch_time");

            entity.HasOne(d => d.Course).WithMany(p => p.LearnerProgresses).HasForeignKey(d => d.CourseId);

            entity.HasOne(d => d.Learner).WithMany(p => p.LearnerProgresses).HasForeignKey(d => d.LearnerId);

            entity.HasOne(d => d.Material).WithMany(p => p.LearnerProgresses).HasForeignKey(d => d.MaterialId);

            entity.HasOne(d => d.Topic).WithMany(p => p.LearnerProgresses).HasForeignKey(d => d.TopicId);
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PRIMARY");

            entity.ToTable("materials");

            entity.HasIndex(e => e.MaterialTypeId, "IX_materials_material_type_id");

            entity.HasIndex(e => e.TopicId, "IX_materials_topic_id");

            entity.Property(e => e.MaterialId)
                .HasColumnName("material_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.FilePath).HasColumnName("file_path");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsAvailable).HasColumnName("is_available");
            entity.Property(e => e.MaterialTypeId)
                .HasColumnName("material_type_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.TopicId)
                .HasColumnName("topic_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");

            entity.HasOne(d => d.MaterialType).WithMany(p => p.Materials).HasForeignKey(d => d.MaterialTypeId);

            entity.HasOne(d => d.Topic).WithMany(p => p.Materials).HasForeignKey(d => d.TopicId);
        });

        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.MaterialTypeId).HasName("PRIMARY");

            entity.ToTable("material_types");

            entity.Property(e => e.MaterialTypeId)
                .HasColumnName("material_type_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasColumnName("type");
        });

        modelBuilder.Entity<PasswordHistory>(entity =>
        {
            entity.HasKey(e => e.PasswordId).HasName("PRIMARY");

            entity.ToTable("password_histories");

            entity.HasIndex(e => e.LearnerId, "IX_password_histories_learner_id");

            entity.Property(e => e.PasswordId)
                .HasColumnName("password_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.LearnerId)
                .HasColumnName("learner_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.NewPassword)
                .HasMaxLength(30)
                .HasColumnName("new_password");
            entity.Property(e => e.OldPassword)
                .HasMaxLength(30)
                .HasColumnName("old_password");

            entity.HasOne(d => d.Learner).WithMany(p => p.PasswordHistories).HasForeignKey(d => d.LearnerId);
        });

        modelBuilder.Entity<QuestionOption>(entity =>
        {
            entity.HasKey(e => e.QuestionOptionId).HasName("PRIMARY");

            entity.ToTable("question_options");

            entity.HasIndex(e => e.QuizQuestionId, "IX_question_options_quiz_question_id");

            entity.Property(e => e.QuestionOptionId)
                .HasColumnName("question_option_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.IsCorrect).HasColumnName("is_correct");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Option).HasColumnName("option");
            entity.Property(e => e.QuizQuestionId)
                .HasColumnName("quiz_question_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");

            entity.HasOne(d => d.QuizQuestion).WithMany(p => p.QuestionOptions).HasForeignKey(d => d.QuizQuestionId);
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.QuizId).HasName("PRIMARY");

            entity.ToTable("quizzes");

            entity.HasIndex(e => e.CourseId, "IX_quizzes_course_id");

            entity.HasIndex(e => e.TopicId, "IX_quizzes_topic_id").IsUnique();

            entity.Property(e => e.QuizId)
                .HasColumnName("quiz_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CourseId)
                .HasColumnName("course_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.NameOfQuiz).HasColumnName("name_of_quiz");
            entity.Property(e => e.PassMark).HasColumnName("pass_mark");
            entity.Property(e => e.TopicId)
                .HasColumnName("topic_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");

            entity.HasOne(d => d.Course).WithMany(p => p.Quizzes).HasForeignKey(d => d.CourseId);

            entity.HasOne(d => d.Topic).WithOne(p => p.Quiz).HasForeignKey<Quiz>(d => d.TopicId);
        });

        modelBuilder.Entity<QuizQuestion>(entity =>
        {
            entity.HasKey(e => e.QuizQuestionId).HasName("PRIMARY");

            entity.ToTable("quiz_questions");

            entity.HasIndex(e => e.QuizId, "IX_quiz_questions_quiz_id");

            entity.Property(e => e.QuizQuestionId)
                .HasColumnName("quiz_question_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Question).HasColumnName("question");
            entity.Property(e => e.QuestionNo).HasColumnName("question_no");
            entity.Property(e => e.QuestionType)
                .HasMaxLength(30)
                .HasColumnName("question_type");
            entity.Property(e => e.QuizId)
                .HasColumnName("quiz_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");

            entity.HasOne(d => d.Quiz).WithMany(p => p.QuizQuestions).HasForeignKey(d => d.QuizId);
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PRIMARY");

            entity.ToTable("topic");

            entity.HasIndex(e => e.CourseId, "IX_topic_course_id");

            entity.Property(e => e.TopicId)
                .HasColumnName("topic_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CourseId)
                .HasColumnName("course_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Course).WithMany(p => p.Topics).HasForeignKey(d => d.CourseId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
