using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LingoFlow.Core.Models;
using System.Diagnostics;
namespace LingoFlow.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=lingoflow_db ;Trusted_Connection=True ");
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
        //public DataContext(DbContextOptions<DataContext> options): base(options) { }
    }
}

//using LingoFlow.Core.Models;
//using LingoFlow.Core.Models;  // או הנתיב המתאים שבו המחלקות שלך נמצאות
//using LingoFlow.Data.Repositories