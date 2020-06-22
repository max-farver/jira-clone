using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Projects.DTOs;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Projects.Handlers {
    public class GetProjectById {
        public class Query : IRequest<ProjectGetDto> {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ProjectGetDto> {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IProjectRepository Projects;
            private readonly IMapper _mapper;
            public Handler(IUnitOfWork unitOfWork, IMapper mapper) {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
                Projects = unitOfWork.Projects;
            }

            // called when MediatR.send calls a query, uses the Query class above
            public async Task<ProjectGetDto> Handle(Query request, CancellationToken cancellationToken) {
                var project = await Projects.Get(request.Id);
                var projectToReturn = _mapper.Map<Project, ProjectGetDto>(project);
                return projectToReturn;
            }

        }
    }
}