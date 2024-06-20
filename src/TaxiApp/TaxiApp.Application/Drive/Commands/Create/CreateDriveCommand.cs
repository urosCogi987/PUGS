﻿using MediatR;
using TaxiApp.Application.Dtos;

namespace TaxiApp.Application.Drive.Commands.Create
{
    public sealed record CreateDriveCommand(string FromAddress,
                                            double FromLatitude,
                                            double FromLongitude,
                                            string ToAddress,
                                            double ToLatitude,
                                            double ToLongitude) : IRequest<CreatedDriveDto>;
}