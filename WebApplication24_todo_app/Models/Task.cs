using System;
using System.Collections.Generic;

namespace WebApplication24_todo_app.Models;

public partial class Task
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateOnly? Cdate { get; set; }
}
