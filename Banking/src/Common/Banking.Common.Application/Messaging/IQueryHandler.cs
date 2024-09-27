﻿using Banking.Common.Domain;
using MediatR;

namespace Banking.Common.Application.Messaging;
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
