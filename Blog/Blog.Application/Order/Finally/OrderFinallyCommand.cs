using Common.Application;
using MediatR;

namespace Blog.Application.Order.Finally;

public record OrderFinallyCommand(long OrderId) : IBaseCommand;