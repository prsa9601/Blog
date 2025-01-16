﻿using Common.Domain.ValueObjects;
using Common.Query;

namespace Blog.Query.Category.DTOs;

public class SecondaryChildCategoryDto : BaseDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public long ParentId { get; set; }
}