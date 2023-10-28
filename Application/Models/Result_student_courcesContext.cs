using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Application.Models
{
    public partial class Result_student_courcesContext : DbContext
    {
        public Result_student_courcesContext()
        {
        }

        public Result_student_courcesContext(DbContextOptions<Result_student_courcesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cource> Cources { get; set; } = null!;
        public virtual DbSet<Result> Results { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cource>(entity =>
            {
                entity.HasKey(e => e.CourcesId)
                    .HasName("PK__Cources__4734F18ED40E813D");

                entity.ToTable("Cources", "about_Student");

                entity.Property(e => e.CourcesId).HasColumnName("Cources_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CourcesName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Cources_name");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.ToTable("result", "about_Student");

                entity.Property(e => e.ResultId).HasColumnName("result_id");

                entity.Property(e => e.CourceNo).HasColumnName("cource_no");

                entity.Property(e => e.ResultDegree)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("result_degree");

                entity.Property(e => e.StudentNo).HasColumnName("student_no");

                entity.HasOne(d => d.CourceNoNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.CourceNo)
                    .HasConstraintName("Result_Cources_FK");

                entity.HasOne(d => d.StudentNoNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.StudentNo)
                    .HasConstraintName("Result_Student_FK");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students", "about_Student");

                entity.HasIndex(e => e.Phone, "UQ__Students__5C7E359E6B0FFB68")
                    .IsUnique();

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.Phone)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.StudentAdress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("student_adress");

                entity.Property(e => e.StudentName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Student_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
