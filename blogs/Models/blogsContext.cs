using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace blogs.Models
{
    public partial class blogsContext : DbContext
    {
        public blogsContext()
        {
        }

        public blogsContext(DbContextOptions<blogsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessToken> AccessToken { get; set; }
        public virtual DbSet<CommentLoves> CommentLoves { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<PostLoves> PostLoves { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        public virtual DbQuery<VIEW_POST> VIEW_POST { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<AccessToken>(entity =>
            {
                entity.ToTable("access_token");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasColumnType("text");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AccessToken)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__access_to__useri__160F4887");
            });

            modelBuilder.Entity<CommentLoves>(entity =>
            {
                entity.HasKey(e => new { e.Userid, e.Commentid })
                    .HasName("PK__comment___877B36EBF68ED062");

                entity.ToTable("comment_loves");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Commentid).HasColumnName("commentid");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentLoves)
                    .HasForeignKey(d => d.Commentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__comment_l__comme__59FA5E80");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CommentLoves)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__comment_l__useri__59063A47");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.ToTable("comments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("text");

                entity.Property(e => e.Cretime)
                    .HasColumnName("cretime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Postsid).HasColumnName("postsid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Posts)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Postsid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__comments__postsi__3F466844");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__comments__userid__3E52440B");
            });

            modelBuilder.Entity<PostLoves>(entity =>
            {
                entity.HasKey(e => new { e.Userid, e.Postid })
                    .HasName("PK__post_lov__F671A5AAFA610F92");

                entity.ToTable("post_loves");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Postid).HasColumnName("postid");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostLoves)
                    .HasForeignKey(d => d.Postid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__post_love__posti__5629CD9C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PostLoves)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__post_love__useri__5535A963");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.ToTable("posts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("text");

                entity.Property(e => e.Cretime)
                    .HasColumnName("cretime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__posts__userid__3A81B327");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__users__F3DBC57262977CD4")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("fname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Img)
                    .HasColumnName("img")
                    .HasColumnType("text");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('user')");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Query<VIEW_POST>(query =>
            {
                query.ToView("VIEW_POST");

                query.Property(e => e.Id).HasColumnName("id");
                query.Property(e => e.WriterID).HasColumnName("writerID");
                query.Property(e => e.WriterFName).HasColumnName("writerFname");
                query.Property(e => e.WriterLname).HasColumnName("writerLname");
                query.Property(e => e.LoginID).HasColumnName("loginID");
                query.Property(e => e.Title).HasColumnName("title");
                query.Property(e => e.Content).HasColumnName("content");
                query.Property(e => e.CountLove).HasColumnName("countLove");
                query.Property(e => e.Userlove).HasColumnName("userlove");
                query.Property(e => e.Cretime).HasColumnName("cretime");
            });
        }
    }
}
