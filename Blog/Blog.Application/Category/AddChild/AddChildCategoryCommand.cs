﻿using Common.Application;
using Common.Domain.ValueObjects;

namespace Blog.Application.Category.AddChild
{
    public record AddChildCategoryCommand(long ParentId, string Title, string Slug, SeoData SeoData) 
        : IBaseCommand<long>;
}