﻿using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistance
{
    public interface IVideoRepository : IAsyncRepository<Video>
    {
        Task<Video> GetVideoByNombre(string nombre);
        Task<IEnumerable<Video>> GetVideosByUsername(string username);
    }
}
