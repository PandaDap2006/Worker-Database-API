using Backend_Worker_Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_Worker_Database.Data;

public class WorkerDatabaseContext : DbContext {
	public WorkerDatabaseContext(DbContextOptions<WorkerDatabaseContext> options) : base(options) {
	}

	public DbSet<Worker> Workers { get; set; } = null!;
}