using Blog.Query.SiteEntities.DTOs;
using Common.Query;

namespace Blog.Query.SiteEntities.Sliders.GetById;

public record GetSliderByIdQuery(long SliderId) : IQuery<SliderDto>;
