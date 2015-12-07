using ReviewApplication.CORE.Domain;
using System.Data.Entity;

namespace ReviewApplication.Data.Infrastructure
{
    public class ReviewApplicationDbContext : DbContext
    {
        public ReviewApplicationDbContext() : base("ReviewApplication")
        {

        }

        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<CompanyProfile> CompanyProfiles { get; set; }
        public IDbSet<InsuranceAgentProfile> InsuranceAgentProfiles { get; set; }
        public IDbSet<LeadProduct> LeadProducts { get; set; }
        public IDbSet<LeadTransaction> LeadTransactions { get; set; }
        public IDbSet<ReviewPost> ReviewPosts { get; set; }
        public IDbSet<User> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Map Review post to Comapny
            modelBuilder.Entity<ReviewPost>().HasKey(rp => rp.ReviewPostID);
            modelBuilder.Entity<ReviewPost>().HasRequired(c => c.Company)
                                                .WithMany(rp => rp.ReviewPosts)
                                                .HasForeignKey(c => c.CompanyID);

            //Map Review post to Agent
            modelBuilder.Entity<ReviewPost>().HasRequired(a => a.InsuranceAgent)
                                        .WithMany(rp => rp.ReviewPosts)
                                        .HasForeignKey(a => a.InsuranceAgentID);

            //Map Review Post to Comments
            modelBuilder.Entity<ReviewPost>().HasMany(c => c.Comments)
                                                .WithRequired(c => c.ReviewPost)
                                                .HasForeignKey(rp => rp.ReviewID);

            //Map Comments to Comments
            //Needs work?
            modelBuilder.Entity<Comment>().HasKey(c => c.CommentID);
            modelBuilder.Entity<Comment>().HasMany(c => c.Comments)
                                            .WithMany();


            //Map CompanyProfile to Transactions
            modelBuilder.Entity<LeadTransaction>().HasKey(lt => lt.LeadTransactionID);
            modelBuilder.Entity<LeadTransaction>().HasRequired(c => c.Company)
                                                    .WithMany(lt => lt.Transactions)
                                                    .HasForeignKey(c => c.CompanyID);

            //Map InsuranceAgent to Transactions
            modelBuilder.Entity<LeadTransaction>().HasRequired(a => a.Agent)
                                                .WithMany(lt => lt.Transactions)
                                                .HasForeignKey(a => a.InsuranceAgentProfileID);

            //Map UserProfile to CompanyProfile
            modelBuilder.Entity<User>().HasKey(up => up.Id);
            modelBuilder.Entity<User>().HasOptional(c => c.CompanyProfile)
                                            .WithRequired(cp => cp.UserProfile);

            //Map UserProfule to InsuranceAgentPRofile
            modelBuilder.Entity<User>().HasOptional(ia => ia.InsuranceAgentProfile)
                                                .WithRequired(ia => ia.UserProfile);

            /*
            //Map UserProfile to CompanyProfile ??
            modelBuilder.Entity<CompanyProfile>().HasKey(c => c.CompanyID);
            modelBuilder.Entity<CompanyProfile>().HasRequired(u => u.UserProfile)
                                        .WithOptional(cp => cp.CompanyProfile)
                                          .Map(m => m.MapKey("CompanyID"));

            //Map Userprofile to InsuranceAgentProfile ??
            modelBuilder.Entity<InsuranceAgentProfile>().HasKey(a => a.UserID);
            modelBuilder.Entity<UserProfile>().HasOptional(u => u.InsuranceAgentProfile)
                                        .WithRequired(ap => ap.UserProfile);

    */
            //Map Company to comments
            modelBuilder.Entity<Comment>().HasKey(c => c.CommentID);
            modelBuilder.Entity<CompanyProfile>().HasMany(c => c.Comments)
                                    .WithOptional(c => c.CompanyProfile)
                                    .HasForeignKey(cp => cp.CommentID);

            //Map InsuranceAgentProfile to Comments
            modelBuilder.Entity<InsuranceAgentProfile>().HasMany(c => c.Comments)
                                            .WithOptional(c => c.InsuranceAgentProfile)
                                            .HasForeignKey(c => c.CommentID);





            base.OnModelCreating(modelBuilder);
        }
    }
}
