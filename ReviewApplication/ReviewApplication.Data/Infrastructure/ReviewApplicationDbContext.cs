using ReviewApplication.Core.Domain;
using ReviewApplication.Data.Migrations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ReviewApplication.Data.Infrastructure
{
    public class ReviewApplicationDbContext : DbContext
    {
        public ReviewApplicationDbContext() : base("ReviewApplication")
        {
            var ensureDllIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Company> Companies { get; set; }
        public IDbSet<InsuranceAgent> InsuranceAgents { get; set; }
        public IDbSet<InsuranceAgentIndustry> InsuranceAgentIndustries { get; set; }
        public IDbSet<CompanyIndustry> CompanyIndustries { get; set; }
        public IDbSet<LeadProduct> LeadProducts { get; set; }
        public IDbSet<LeadTransaction> LeadTransactions { get; set; }
        public IDbSet<ReviewPost> ReviewPosts { get; set; }
        public IDbSet<CompanyReviewPost> CompanyReviewPosts { get; set; }
        public IDbSet<LeadProductReviewPost> LeadProductReviewPosts { get; set; }
        public IDbSet<InsuranceAgentReviewPost> InsuranceAgentReviewPosts { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<ExternalLogin> ExternalLogins { get; set; }
        public IDbSet<Industry> Industries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


            modelBuilder.Entity<CompanyReviewPost>().HasKey(ci => new { ci.CompanyID, ci.ReviewPostID });
            modelBuilder.Entity<InsuranceAgentReviewPost>().HasKey(iai => new { iai.InsuranceAgentID, iai.ReviewPostID });
            modelBuilder.Entity<LeadProductReviewPost>().HasKey(ci => new { ci.LeadProductID, ci.ReviewPostID });


            //Map Company to ReviewPosts
            modelBuilder.Entity<ReviewPost>().HasKey(rp => rp.ReviewPostID);
            modelBuilder.Entity<ReviewPost>().HasMany(c => c.CompanyReviewPosts)
                                             .WithRequired(rp => rp.ReviewPost)
                                             .HasForeignKey(c => c.CompanyID)
                                             .WillCascadeOnDelete(false);

            //Map Company to LeadProducts
            modelBuilder.Entity<ReviewPost>().HasKey(rp => rp.ReviewPostID);
            modelBuilder.Entity<ReviewPost>().HasMany(c => c.LeadProductReviewPosts)
                                             .WithRequired(rp => rp.ReviewPost)
                                             .HasForeignKey(c => c.LeadProductID)
                                             .WillCascadeOnDelete(false);

            //Map Company to InsuranceAgents
            modelBuilder.Entity<ReviewPost>().HasKey(rp => rp.ReviewPostID);
            modelBuilder.Entity<ReviewPost>().HasMany(c => c.InsuranceAgentReviewPosts)
                                             .WithRequired(rp => rp.ReviewPost)
                                             .HasForeignKey(c => c.InsuranceAgentID)
                                             .WillCascadeOnDelete(false);



            //Map Review Post to Comments
            modelBuilder.Entity<ReviewPost>().HasMany(c => c.Comments)
                                             .WithRequired(c => c.ReviewPost)
                                             .HasForeignKey(rp => rp.ReviewID)
                                             .WillCascadeOnDelete(false);
            

            //Map Comments to Comments
            modelBuilder.Entity<Comment>().HasKey(c => c.CommentID);
            modelBuilder.Entity<Comment>().HasMany(c => c.Comments)
                                          .WithOptional(c => c.ParentComment)
                                          .HasForeignKey(c => c.ParentCommentID)
                                          .WillCascadeOnDelete(false);



            //Map CompanyProfile to Transactions
            modelBuilder.Entity<LeadTransaction>().HasKey(lt => lt.LeadTransactionID);
            modelBuilder.Entity<LeadTransaction>().HasRequired(c => c.Company)
                                                    .WithMany(lt => lt.Transactions)
                                                    .HasForeignKey(c => c.CompanyID)
                                                    .WillCascadeOnDelete(false);

            //Map InsuranceAgent to Transactions
            modelBuilder.Entity<LeadTransaction>().HasRequired(a => a.Agent)
                                                .WithMany(lt => lt.Transactions)
                                                .HasForeignKey(a => a.InsuranceAgentID)
                                                .WillCascadeOnDelete(false);

            //Map Company to LeadProduct
            modelBuilder.Entity<LeadProduct>().HasKey(lp => lp.LeadProductID);
            /*
            modelBuilder.Entity<Company>().HasMany(c => c.LeadProducts)
                                          .WithRequired(lp => lp.Company)
                                          .HasForeignKey(c => c.LeadProductID)
                                          .WillCascadeOnDelete(false);
                                          */
            modelBuilder.Entity<LeadProduct>().HasRequired(c => c.Company)
                                               .WithMany(lp => lp.LeadProducts)
                                               .HasForeignKey(lp => lp.CompanyID)
                                               .WillCascadeOnDelete(false);


            //Map UserProfile to CompanyProfile
            modelBuilder.Entity<User>().HasKey(up => up.Id);
            modelBuilder.Entity<User>().HasOptional(c => c.CompanyProfile)
                                       .WithRequired(cp => cp.UserProfile)
                                       .WillCascadeOnDelete(false);

            //Map UserProfule to InsuranceAgentPRofile
            modelBuilder.Entity<User>().HasOptional(ia => ia.InsuranceAgentProfile)
                                       .WithRequired(ia => ia.UserProfile)
                                       .WillCascadeOnDelete(false);

            //Map Company to comments
            modelBuilder.Entity<Comment>().HasKey(c => c.CommentID);
            modelBuilder.Entity<Company>().HasKey(cp => cp.CompanyID);
            modelBuilder.Entity<Company>().HasMany(c => c.Comments)
                                            .WithOptional(c => c.CompanyProfile)
                                            .HasForeignKey(cp => cp.CompanyID)
                                            .WillCascadeOnDelete(false);

            //Map InsuranceAgentProfile to Comments
            modelBuilder.Entity<InsuranceAgent>().HasKey(iap => iap.InsuranceAgentID);
            modelBuilder.Entity<InsuranceAgent>().HasMany(iap => iap.Comments)
                                                        .WithOptional(c => c.InsuranceAgentProfile)
                                                        .HasForeignKey(c => c.InsuranceAgentProfileID)
                                                        .WillCascadeOnDelete(false);

            //Map InsuranceAgentProfile to Industy        
            modelBuilder.Entity<InsuranceAgent>().HasMany(ia => ia.Industries)
                                     .WithRequired(iai => iai.InsuranceAgent)
                                     .HasForeignKey(iai => iai.InsuranceAgentID)
                                     .WillCascadeOnDelete(false);

            //Map CompanyProfile to Industry
            modelBuilder.Entity<Company>().HasMany(ia => ia.Industries)
                                    .WithRequired(iai => iai.Company)
                                    .HasForeignKey(iai => iai.CompanyID)
                                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Industry>().HasMany(i => i.InsuranceAgents)
                               .WithRequired(iai => iai.Industry)
                               .HasForeignKey(iai => iai.IndustryID)
                               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Industry>().HasMany(c => c.Companies)
                                            .WithRequired(ci => ci.Industry)
                                            .HasForeignKey(ci => ci.IndustryID)
                                            .WillCascadeOnDelete(false);

            

            modelBuilder.Entity<CompanyIndustry>().HasKey(ci => new { ci.CompanyID, ci.IndustryID });
            modelBuilder.Entity<InsuranceAgentIndustry>().HasKey(iai => new { iai.InsuranceAgentID, iai.IndustryID });

            //Map External Login
            modelBuilder.Entity<ExternalLogin>().HasKey(u => u.ExternalLoginID);

            //Map user to externalLogin
            modelBuilder.Entity<User>().HasMany(b => b.ExternalLogins)
                                       .WithRequired(el => el.User)
                                       .HasForeignKey(el => el.UserID)
                                       .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
