using akademija.EF.entities;
using Microsoft.EntityFrameworkCore;

namespace akademija.EF
{
    public partial class NrdAkademijaDbContext : DbContext
    {
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeInventory> EmployeeInventory { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<InventoryType> InventoryType { get; set; }
        public virtual DbSet<Post> Post { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV12;Database=NrdAkademijaDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.Url).IsRequired();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.Workplace).IsRequired();
            });

            modelBuilder.Entity<EmployeeInventory>(entity =>
            {
                entity.HasKey(e => new { e.InventoryId, e.EmployeeId });

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeInventory)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeI__Emplo__3D5E1FD2");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.EmployeeInventory)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeI__Inven__3E52440B");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK__Inventory__Type__38996AB5");
            });

            modelBuilder.Entity<InventoryType>(entity =>
            {
                entity.ToTable("Inventory_Type");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.BlogId);
            });
        }
    }
}
