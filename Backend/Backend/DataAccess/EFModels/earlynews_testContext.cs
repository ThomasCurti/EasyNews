﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend.DataAccess.EFModels
{
    public partial class earlynews_testContext : DbContext
    {
        public string connectionString = "server=localhost;user=root;password=admin;database=earlynews_test";

        public earlynews_testContext()
        {
        }

        public earlynews_testContext(DbContextOptions<earlynews_testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<ArticleSource> ArticleSource { get; set; }
        public virtual DbSet<DubiousArticle> DubiousArticle { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Scenarios> Scenarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(connectionString, x => x.ServerVersion("10.1.44-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("article");

                entity.HasIndex(e => e.SourceId)
                    .HasName("source_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.FullArticle)
                    .HasColumnName("full_article")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.SourceId)
                    .HasColumnName("source_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("char(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.SourceId)
                    .HasConstraintName("article_ibfk_1");
            });

            modelBuilder.Entity<ArticleSource>(entity =>
            {
                entity.ToTable("article_source");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("char(16)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<DubiousArticle>(entity =>
            {
                entity.ToTable("dubious_article");

                entity.HasIndex(e => e.SourceId)
                    .HasName("source_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FullArticleSource)
                    .HasColumnName("full_article_source")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.KwFrequency)
                    .HasColumnName("kw_frequency")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.SourceId)
                    .HasColumnName("source_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("char(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.DubiousArticle)
                    .HasForeignKey(d => d.SourceId)
                    .HasConstraintName("dubious_article_ibfk_1");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.HasIndex(e => e.ArticleId)
                    .HasName("article_id");

                entity.HasIndex(e => e.TypeId)
                    .HasName("type_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArticleId)
                    .HasColumnName("article_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Published)
                    .HasColumnName("published")
                    .HasColumnType("date");

                entity.Property(e => e.TypeId)
                    .HasColumnName("type_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("event_ibfk_2");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("event_ibfk_1");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("event_type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("char(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.ToTable("logs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasColumnName("class")
                    .HasColumnType("char(128)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("char(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Scenarios>(entity =>
            {
                entity.ToTable("scenarios");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BeginDate)
                    .IsRequired()
                    .HasColumnName("begin_date")
                    .HasColumnType("char(128)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IllnesType)
                    .HasColumnName("illnes_type")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TownId)
                    .HasColumnName("town_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Virus)
                    .IsRequired()
                    .HasColumnName("virus")
                    .HasColumnType("char(128)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
