using Microsoft.AspNetCore.Mvc;
using CSProjeDemo1.Application.DTOs;
using CSProjeDemo1.Application.Interfaces;
using IMemberService = CSProjeDemo1.Application.Interfaces.IMemberService;

namespace CSProjeDemo1.WebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class MembersController : ControllerBase
{
    private readonly IMemberService _memberService;

    public MembersController(IMemberService memberService)
    {
        _memberService = memberService;
    }


    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<MemberDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllMembers()
    {
        var members = await _memberService.GetAllMembersAsync();
        return Ok(members);
    }

    [HttpGet("{memberNumber}")]
    [ProducesResponseType(typeof(MemberDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetMemberByNumber(string memberNumber)
    {
        var member = await _memberService.GetMemberByNumberAsync(memberNumber);
        if (member == null)
            return NotFound();
        return Ok(member);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateMember([FromBody] CreateMemberDto createMemberDto)
    {
        var result = await _memberService.CreateMemberAsync(createMemberDto);
        if (!result)
            return BadRequest("Member could not be created");
        return CreatedAtAction(nameof(GetMemberByNumber), new { memberNumber = createMemberDto.MemberNumber }, createMemberDto);
    }

    [HttpPut("{memberNumber}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateMember([FromBody] UpdateMemberDto updateMemberDto)
    {
        var result = await _memberService.UpdateMemberAsync(updateMemberDto);
        if (!result)
            return NotFound();
        return Ok();
    }

    [HttpGet("{memberNumber}/borrowed-books")]
    [ProducesResponseType(typeof(IEnumerable<BookDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetMemberBorrowedBooks(string memberNumber)
    {
        var books = await _memberService.GetMemberBorrowedBooksAsync(memberNumber);
        return Ok(books);
    }

    [HttpPost("{memberNumber}/borrow/{isbn}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> BorrowBook(string memberNumber, string isbn)
    {
        var result = await _memberService.BorrowBookAsync(memberNumber, isbn);
        if (!result)
            return BadRequest("Book could not be borrowed");
        return Ok();
    }

    
    [HttpPost("{memberNumber}/return/{isbn}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ReturnBook(string memberNumber, string isbn)
    {
        var result = await _memberService.ReturnBookAsync(memberNumber, isbn);
        if (!result)
            return BadRequest("Book could not be returned");
        return Ok();
    }
}
