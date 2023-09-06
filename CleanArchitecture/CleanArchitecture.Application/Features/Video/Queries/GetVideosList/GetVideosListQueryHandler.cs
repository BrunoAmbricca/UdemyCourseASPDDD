using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistance;
using MediatR;

namespace CleanArchitecture.Application.Features.Video.Queries.GetVideosList
{
    public class GetVideosListQueryHandler : IRequestHandler<GetVideosListQuery, List<VideosVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetVideosListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<VideosVm>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            var videosList = await _unitOfWork.VideoRepository.GetVideosByUsername(request._Username);

            return _mapper.Map<List<VideosVm>>(videosList);
        }
    }
}
