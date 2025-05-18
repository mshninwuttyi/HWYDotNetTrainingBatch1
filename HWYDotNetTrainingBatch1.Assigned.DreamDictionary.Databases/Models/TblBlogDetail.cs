using System;
using System.Collections.Generic;

namespace HWYDotNetTrainingBatch1.Assigned.DreamDictionary.Databases.Models;

public partial class TblBlogDetail
{
    public int BlogDetailId { get; set; }

    public int BlogId { get; set; }

    public string BlogContent { get; set; } = null!;
}
