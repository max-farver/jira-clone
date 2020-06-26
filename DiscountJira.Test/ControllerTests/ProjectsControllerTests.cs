using System;
using System.Linq;
using DiscountJira.Core.Interfaces;
using Xunit;
using Moq;
using DiscountJira.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DiscountJira.Api.Dtos;
using System.Threading.Tasks;
using DiscountJira.Api.DataMappers;
using AutoMapper;
using Microsoft.AspNetCore.Routing;
using DiscountJira.Core.Services.ProjectService;
using DiscountJira.Persistence;
using DiscountJira.Core.Models;

namespace DiscountJira.Test.ControllerTests
{
    public class ProjectsControllerTests
    {
        [Fact]
        public async Task GetProjectsActionResult_ReturnsAListOfProjectDtos()
        {
            var mockProjectService = new Mock<IProjectService>();
            var profile = new ProjectProfile();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mockMapper = new Mock<Mapper>(mapperConfig);
            var mockLinkGen = new Mock<LinkGenerator>();

            var controller = new ProjectsController(mockProjectService.Object, mockMapper.Object, mockLinkGen.Object);

            // Act
            var result = await controller.GetProjects();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<ProjectDto>>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetProjectByIdActionResult_ReturnsAProjectDto()
        {
            IEnumerable<Project> projects = new List<Project> {
                    new Project
                    {
                        Id = 1,
                        Name = "value 101",
                        Version = 1.0
                    }
                };

            var mockProjectService = new Mock<IProjectService>();
            mockProjectService.Setup(x => x.GetProjects()).Returns(Task.FromResult(projects));
            var profile = new ProjectProfile();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mockMapper = new Mock<Mapper>(mapperConfig);
            var mockLinkGen = new Mock<LinkGenerator>();

            var controller = new ProjectsController(mockProjectService.Object, mockMapper.Object, mockLinkGen.Object);

            // Act
            var result = await controller.GetProjectById(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ProjectDto>>(result);
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetProjectByIdActionResult_ReturnsNotFound()
        {
            var mockProjectService = new Mock<IProjectService>();
            var profile = new ProjectProfile();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mockMapper = new Mock<Mapper>(mapperConfig);
            var mockLinkGen = new Mock<LinkGenerator>();

            var controller = new ProjectsController(mockProjectService.Object, mockMapper.Object, mockLinkGen.Object);

            // Act
            var result = await controller.GetProjectById(-1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ProjectDto>>(result);
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

    }
}

