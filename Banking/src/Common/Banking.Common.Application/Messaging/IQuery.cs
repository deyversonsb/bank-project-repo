using Banking.Common.Domain;
using MediatR;

namespace Banking.Common.Application.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
