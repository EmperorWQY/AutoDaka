using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sign.Models
{
    public partial class db_signContext : DbContext
    {
        public db_signContext()
        {
        }

        public db_signContext(DbContextOptions<db_signContext> options)
            : base(options)
        {
        }

        public virtual DbSet<J> Js { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("persist security info=True;data source=rm-bp10zo4yzj78ie97yfo.mysql.rds.aliyuncs.com;port=3306;initial catalog=db_sign;user id=wqy;password=wqy15706036031;character set=utf8;allow zero datetime=true;convert zero datetime=true;pooling=true;maximumpoolsize=3000", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.35-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<J>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("js");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("uid");

                entity.Property(e => e.Pwd)
                    .HasMaxLength(255)
                    .HasColumnName("pwd");

                entity.Property(e => e.Usr)
                    .HasMaxLength(255)
                    .HasColumnName("usr");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
