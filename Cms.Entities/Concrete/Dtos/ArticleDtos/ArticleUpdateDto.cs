﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete.Dtos.ArticleDtos
{
  public class ArticleUpdateDto
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }

    }
}
