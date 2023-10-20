using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Backend_Worker_Database.Models;

public class Worker {
	public long id { get; set; }
	public string profileImage { get; set; }
	public string name { get; set; }
	public string position { get; set; }
}