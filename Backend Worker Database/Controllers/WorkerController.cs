using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Worker_Database.Data;
using Backend_Worker_Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Worker_Database.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkerController : ControllerBase {
	private readonly WorkerDatabaseContext _context;

	public WorkerController(WorkerDatabaseContext context) => _context = context;

	[HttpGet]
	public IEnumerable<string> Get() {
		return new string[] { "value1", "value2" };
	}

	[HttpGet("{id}", Name = "Get")]
	public async Task<ActionResult<Worker>> GetWorker(long id) {
		Worker worker = await _context.Workers.FindAsync(id);
		if (worker == null)
			return NotFound();
		return worker;
	}

	[HttpPost]
	public async Task<ActionResult<Worker>> PostWorker(Worker worker) {
		_context.Workers.Add(worker);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetWorker), new { id = worker.id }, worker);
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteWorker(long id) {
		Worker worker = await _context.Workers.FindAsync(id);
		if (worker == null)
			return NotFound();
		_context.Workers.Remove(worker);
		await _context.SaveChangesAsync();
		return NoContent();
	}
}
