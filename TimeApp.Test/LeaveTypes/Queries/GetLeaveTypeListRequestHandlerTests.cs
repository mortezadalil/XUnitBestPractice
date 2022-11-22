using AutoMapper;
using Moq;
using Shouldly;
using TimeApp.Business.DTOs.LeaveType;
using TimeApp.Business.Features.LeaveTypes.Handlers.Queries;
using TimeApp.Business.Features.LeaveTypes.Requests.Queries;
using TimeApp.Business.Gateway;
using TimeApp.Business.Profiles;
using TimeApp.Test.Mocks;

namespace TimeApp.Test.LeaveTypes.Queries
{
    /// <summary>
    /// 3. Test Handler
    /// 
    /// </summary>
    public class GetLeaveTypeListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        public GetLeaveTypeListRequestHandlerTests()
        {
            //Make Mock Repository
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

            //Make Mapper With Config
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveTypeDto>>();

            result.Count.ShouldBe(3);
        }
    }
}
