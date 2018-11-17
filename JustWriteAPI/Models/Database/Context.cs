using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JustWriteAPI.Models.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<AgeRestriction> AgeRestrictions { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<ArticleActivity> ArticleActivities { get; set; }
        public DbSet<CommentActivity> CommentActivities { get; set; }
        public DbSet<AuthorFollowing> AuthorFollowings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // PostgreSQL uses the public schema by default - not dbo.
            builder.HasDefaultSchema("dbo");
            base.OnModelCreating(builder);

            /* ArticleTags */
            builder.Entity<ArticleTag>()
                .HasKey(at => new { at.ArticleId, at.TagId });

            builder.Entity<ArticleTag>()
                .HasOne(at => at.Article)
                .WithMany(b => b.ArticleTags)
                .HasForeignKey(bc => bc.ArticleId);

            builder.Entity<ArticleTag>()
                .HasOne(at => at.Tag)
                .WithMany(c => c.ArticleTags)
                .HasForeignKey(bc => bc.TagId);


            /* ArticleActivities */
            builder.Entity<ArticleActivity>()
                .HasKey(at => new { at.ArticleId, at.AuthorId });

            builder.Entity<ArticleActivity>()
                .HasOne(x => x.Article)
                .WithMany(y => y.ArticleActivities)
                .HasForeignKey(z => z.ArticleId);

            builder.Entity<ArticleActivity>()
                .HasOne(x => x.Author)
                .WithMany(y => y.ArticleActivities)
                .HasForeignKey(z => z.AuthorId);

            /* CommentActivities */
            builder.Entity<CommentActivity>()
                .HasKey(at => new { at.CommentId, at.AuthorId });

            builder.Entity<CommentActivity>()
                .HasOne(x => x.Comment)
                .WithMany(y => y.CommentActivities)
                .HasForeignKey(z => z.CommentId);

            builder.Entity<CommentActivity>()
                .HasOne(x => x.Author)
                .WithMany(y => y.CommentActivities)
                .HasForeignKey(z => z.AuthorId);

            /* AuthorFollowings */
            builder.Entity<AuthorFollowing>()
                .HasKey(at => new { at.FollowingAuthorId, at.AuthorId });

            builder.Entity<AuthorFollowing>()
                .HasOne(x => x.Author)
                .WithMany(y => y.AuthorFollowings)
                .HasForeignKey(z => z.AuthorId);

        }
    }
}
