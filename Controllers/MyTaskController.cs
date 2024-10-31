using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

public enum Priority
{
    High,
    Medium,
    Low
}

public class MyTaskController : Controller
{
    private readonly AppDbContext _context;

    public MyTaskController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string titleFilter, string priorityFilter, string statusFilter, DateTime? dateFrom, DateTime? dateTo, string descriptionFilter, int pageNumber = 1)
    {
        int pageSize = 3; 
        var tasks = await _context.MyTasks.ToListAsync();

        if (!string.IsNullOrEmpty(titleFilter))
        {
            tasks = tasks.Where(t => t.Title.Contains(titleFilter)).ToList();
        }
        if (!string.IsNullOrEmpty(descriptionFilter))
        {
            tasks = tasks.Where(t => t.Description.Contains(descriptionFilter)).ToList();
        }
        if (!string.IsNullOrEmpty(priorityFilter))
        {
            if (Enum.TryParse(priorityFilter, true, out PriorityLevel priorityLevel))
            {
                tasks = tasks.Where(t => t.Priority == priorityLevel).ToList();
            }
        }
        if (statusFilter == "true")
        {
            tasks = tasks.Where(t => t.IsOpen).ToList();
        }
        else if (statusFilter == "false")
        {
            tasks = tasks.Where(t => !t.IsOpen).ToList();
        }
        if (dateFrom.HasValue)
        {
            tasks = tasks.Where(t => t.CreatedAt >= dateFrom.Value).ToList();
        }
        if (dateTo.HasValue)
        {
            tasks = tasks.Where(t => t.CreatedAt <= dateTo.Value).ToList();
        }

        var totalCount = tasks.Count();

        var pagedTasks = tasks.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        ViewData["TitleFilter"] = titleFilter;
        ViewData["PriorityFilter"] = priorityFilter;
        ViewData["StatusFilter"] = statusFilter;
        ViewData["DateFrom"] = dateFrom;
        ViewData["DateTo"] = dateTo;
        ViewData["DescriptionFilter"] = descriptionFilter;

        ViewData["CurrentPage"] = pageNumber;
        ViewData["TotalPages"] = (int)Math.Ceiling(totalCount / (double)pageSize);

        return View(pagedTasks);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(MyTask myTask)
    {
        if (ModelState.IsValid)
        {
            myTask.CreatedAt = DateTime.Now;
            myTask.IsOpen = true; 
            _context.MyTasks.Add(myTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(myTask);
    }

    [HttpPost]
    public async Task<IActionResult> Close(int id)
    {
        var task = await _context.MyTasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        task.IsOpen = false;
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
