using Common.Application;

namespace Blog.Application.SiteEntities.ShippingMethods.Delete;

public record DeleteShippingMethodCommand(long Id):IBaseCommand;