using MediatR;
using TimeApp.Business.DTOs.LeaveType;
using TimeApp.Business.Responses;

namespace TimeApp.Business.Features.LeaveTypes.Requests.Commands;

public class CreateLeaveTypeCommand : IRequest<BaseCommandResponse>
{
    public CreateLeaveTypeDto LeaveTypeDto { get; set; }

}
