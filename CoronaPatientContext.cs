using System;
using System.Collections.Generic;
using CoronaManagement.Models;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace CoronaManagement.DAL;

public partial class CoronaPatientContext : DbContext
{
    public CoronaPatientContext()
    {
    }

    public CoronaPatientContext(DbContextOptions<CoronaPatientContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CoronaDetail> CoronaDetails { get; set; }

    public virtual DbSet<PersonalDetail> PersonalDetails { get; set; }

    public virtual DbSet<Vaccination> Vaccinations { get; set; }
    public virtual DbSet<Picture> Picture { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-B5S1T71;Initial Catalog=CoronaPatient;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoronaDetail>(entity =>
        {
            entity.HasKey(e => e.CoronaDetailsId).HasName("PK__CoronaDe__925F78C0526F5E20");

            entity.Property(e => e.CoronaDetailsId).HasColumnName("coronaDetailsId");
            entity.Property(e => e.NegativeDate)
                .HasColumnType("date")
                .HasColumnName("negativeDate");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.PositiveDate)
                .HasColumnType("date")
                .HasColumnName("positiveDate");

            entity.HasOne(d => d.Patient).WithMany(p => p.CoronaDetails)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CoronaDet__patie__286302EC");
        });

        modelBuilder.Entity<PersonalDetail>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Personal__EC7D7D4D7A8D6F08");

            entity.Property(e => e.PersonId).HasColumnName("personId");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("dateOfBirth");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("lastName");
            entity.Property(e => e.MobilePhone).HasMaxLength(50);
            entity.Property(e => e.NumOfBuilding).HasColumnName("numOfBuilding");
            entity.Property(e => e.PatientIdentity)
                .HasMaxLength(50)
                .HasColumnName("patientIdentity");
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .HasColumnName("street");
        });

        modelBuilder.Entity<Vaccination>(entity =>
        {
            entity.ToTable("vaccination");

            entity.Property(e => e.VaccinationId).HasColumnName("vaccinationId");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(50)
                .HasColumnName("manufacturer");
            entity.Property(e => e.PatientId).HasColumnName("patientId");

            entity.HasOne(d => d.Patient).WithMany(p => p.Vaccinations)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__vaccinati__patie__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
