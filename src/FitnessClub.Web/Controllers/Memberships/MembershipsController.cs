using FitnessClub.Application.Memberships;
using FitnessClub.Application.Memberships.Commands.AddMembership;
using FitnessClub.Application.Memberships.Commands.Delete;
using FitnessClub.Domain;
using FitnessClub.Infrastructure;
using FitnessClub.Web.Controllers.Memberships.Request;
using Microsoft.AspNetCore.Mvc;

namespace FitnessClub.Web.Controllers.Memberships;
[ApiController]
[Route("[controller]")]
public class MembershipsController : ControllerBase
{
    private readonly IMembershipRepository _membershipRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MembershipsController(IMembershipRepository membershipRepository, IUnitOfWork unitOfWork)
    {
        _membershipRepository = membershipRepository;
        _unitOfWork = unitOfWork;
    }
    [HttpPost]
    public async Task<ActionResult> Create(
        [FromServices] CreateMembershipHandler handler,
        [FromBody] CreateMembershipRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await handler.Handle(request.ToCommand(), cancellationToken);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        [FromServices] DeleteMembershipHandler handler,
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default
        )
    {
        var result = await handler.Handle(id, cancellationToken);
        if (result)
        {
            return Ok();
        }
        return BadRequest();
        
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateInfo(
        [FromRoute] Guid id,
        [FromBody] UpdateInfoRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var membership = await _membershipRepository.GetById(id,cancellationToken);
        if (membership is null)
        {
            return NotFound();
        }
        membership.Update(request.Name,request.Description,request.Price,request.Type,request.Days);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Ok();
    }
}