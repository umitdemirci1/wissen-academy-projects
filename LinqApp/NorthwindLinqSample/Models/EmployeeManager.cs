using System;
using System.Collections.Generic;

namespace NorthwindLinqSample.Models;

public partial class EmployeeManager
{
    public int ManagerId { get; set; }

    public string Manager { get; set; } = null!;

    public int EmployeeId { get; set; }

    public string EmployeeFullName { get; set; } = null!;
}
