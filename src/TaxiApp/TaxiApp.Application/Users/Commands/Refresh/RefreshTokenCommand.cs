﻿using MediatR;
using TaxiApp.Application.Dtos;

namespace TaxiApp.Application.Users.Commands.Refresh
{
    public sealed record RefreshTokenCommand(string RefreshToken) : IRequest<TokensDto>;
}