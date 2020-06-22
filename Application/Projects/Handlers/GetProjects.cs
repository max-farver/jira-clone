using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Projects.DTOs;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Projects.Handlers {
    public class GetProjects {
        public class Query : IRequest<IEnumerable<ProjectGetDto>> { }

        public class Handler : IRequestHandler<Query, IEnumerable<ProjectGetDto>> {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IProjectRepository Projects;
            private readonly IMapper _mapper;
            public Handler(IUnitOfWork unitOfWork, IMapper mapper) {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
                Projects = unitOfWork.Projects;
            }

            public async Task<IEnumerable<ProjectGetDto>> Handle(Query request, CancellationToken cancellationToken) {
                var projects = await Projects.GetAll();
                var projectsToReturn = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectGetDto>>(projects);
                return projectsToReturn;
            }

        }
    }
}