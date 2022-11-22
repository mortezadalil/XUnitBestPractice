using AutoMapper;
using MediatR;
using TimeApp.Business.Features.LeaveTypes.Requests.Queries;
using TimeApp.Business.DTOs.LeaveType;
using TimeApp.Business.Gateway;

namespace TimeApp.Business.Features.LeaveTypes.Handlers.Queries;

public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
    {
        var leaveTypes = await _leaveTypeRepository.GetAll();
        return _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
    }
}
