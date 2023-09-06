﻿using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistance;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteStreamerCommandHandler> _logger;

        public DeleteStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteStreamerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToDelete = await _unitOfWork.StreamerRepository.GetByIdAsync(request.Id);

            if (streamerToDelete == null)
            {
                _logger.LogError($"No se encontro el Streamer Id {request.Id}");

                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            _unitOfWork.StreamerRepository.DeleteEntity(streamerToDelete);

            await _unitOfWork.Complete();

            _logger.LogInformation($"La operacion fue exitosa borrando el streamer {request.Id}");

            return Unit.Value;
        }
    }
}