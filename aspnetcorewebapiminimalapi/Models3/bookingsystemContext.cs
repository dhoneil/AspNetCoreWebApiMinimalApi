using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace aspnetcorewebapiminimalapi.Models3
{
    public partial class bookingsystemContext : DbContext
    {
        public bookingsystemContext()
        {
        }

        public bookingsystemContext(DbContextOptions<bookingsystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Beautician> Beauticians { get; set; } = null!;
        public virtual DbSet<BeauticianService> BeauticianServices { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<FailedJob> FailedJobs { get; set; } = null!;
        public virtual DbSet<Migration> Migrations { get; set; } = null!;
        public virtual DbSet<PasswordReset> PasswordResets { get; set; } = null!;
        public virtual DbSet<PersonalAccessToken> PersonalAccessTokens { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<RegistrationToken> RegistrationTokens { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserInformation> UserInformations { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;initial catalog=bookingsystem;persist security info=False;user id=root;connection timeout=30", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("appointments");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.AppointmentId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("appointment_id");

                entity.Property(e => e.AppointmentStatus)
                    .HasMaxLength(255)
                    .HasColumnName("appointment_status");

                entity.Property(e => e.BeauticianId)
                    .HasColumnType("int(11)")
                    .HasColumnName("beautician_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_id");

                entity.Property(e => e.Schedule)
                    .HasColumnType("datetime")
                    .HasColumnName("schedule");

                entity.Property(e => e.ServiceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("service_id");

                entity.Property(e => e.TotalAmount)
                    .HasPrecision(8, 2)
                    .HasColumnName("total_amount");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Beautician>(entity =>
            {
                entity.ToTable("beauticians");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.BeauticianId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("beautician_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(255)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .HasColumnName("lastname");

                entity.Property(e => e.Middlename)
                    .HasMaxLength(255)
                    .HasColumnName("middlename");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<BeauticianService>(entity =>
            {
                entity.ToTable("beautician_services");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.BeauticianServiceId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("beautician_service_id");

                entity.Property(e => e.BeauticianId)
                    .HasColumnType("int(11)")
                    .HasColumnName("beautician_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.ServiceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("service_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("customer_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(255)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .HasColumnName("lastname");

                entity.Property(e => e.Middlename)
                    .HasMaxLength(255)
                    .HasColumnName("middlename");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<FailedJob>(entity =>
            {
                entity.ToTable("failed_jobs");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Uuid, "failed_jobs_uuid_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Connection)
                    .HasColumnType("text")
                    .HasColumnName("connection");

                entity.Property(e => e.Exception).HasColumnName("exception");

                entity.Property(e => e.FailedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("failed_at")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Payload).HasColumnName("payload");

                entity.Property(e => e.Queue)
                    .HasColumnType("text")
                    .HasColumnName("queue");

                entity.Property(e => e.Uuid).HasColumnName("uuid");
            });

            modelBuilder.Entity<Migration>(entity =>
            {
                entity.ToTable("migrations");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Batch)
                    .HasColumnType("int(11)")
                    .HasColumnName("batch");

                entity.Property(e => e.Migration1)
                    .HasMaxLength(255)
                    .HasColumnName("migration");
            });

            modelBuilder.Entity<PasswordReset>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("password_resets");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Email, "password_resets_email_index");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Token)
                    .HasMaxLength(255)
                    .HasColumnName("token");
            });

            modelBuilder.Entity<PersonalAccessToken>(entity =>
            {
                entity.ToTable("personal_access_tokens");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Token, "personal_access_tokens_token_unique")
                    .IsUnique();

                entity.HasIndex(e => new { e.TokenableType, e.TokenableId }, "personal_access_tokens_tokenable_type_tokenable_id_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Abilities)
                    .HasColumnType("text")
                    .HasColumnName("abilities");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.LastUsedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("last_used_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Token)
                    .HasMaxLength(64)
                    .HasColumnName("token");

                entity.Property(e => e.TokenableId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("tokenable_id");

                entity.Property(e => e.TokenableType).HasColumnName("tokenable_type");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ProductId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("product_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductPrice)
                    .HasPrecision(8, 2)
                    .HasColumnName("product_price");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<RegistrationToken>(entity =>
            {
                entity.ToTable("registration_tokens");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.RegistrationTokenId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("registration_token_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Token)
                    .HasMaxLength(255)
                    .HasColumnName("token");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ServiceId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("service_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(255)
                    .HasColumnName("service_name");

                entity.Property(e => e.ServicePrice)
                    .HasPrecision(8, 2)
                    .HasColumnName("service_price");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Email, "users_email_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.EmailVerifiedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("email_verified_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.RememberToken)
                    .HasMaxLength(100)
                    .HasColumnName("remember_token");

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("role_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<UserInformation>(entity =>
            {
                entity.ToTable("user_information");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UserInformationId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_information_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(255)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .HasColumnName("lastname");

                entity.Property(e => e.Middlename)
                    .HasMaxLength(255)
                    .HasColumnName("middlename");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_roles");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UserRoleId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_role_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .HasColumnName("role_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
