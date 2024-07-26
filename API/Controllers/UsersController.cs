using API.Contracts.User;
using Application.Users.Commands.ChangeUserEmail;
using Application.Users.Commands.ChangeUserName;
using Application.Users.Commands.ChangeUserPassword;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetAllOrders;
using Application.Users.Queries.GetAllProducts;
using Application.Users.Queries.GetAllUsers;
using Application.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public sealed class UsersController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest request) => 
        Ok(await sender.Send(
            new CreateUserCommand(
                request.FirstName, 
                request.LastName,
                request.Email, 
                request.Password)));

    [HttpPut("ChangeName")]
    public async Task<IActionResult> ChangeName(ChangeUserNameRequest request) => 
        Ok(await sender.Send(
            new ChangeUserNameCommand(
                request.UserId, 
                request.FirstName, 
                request.LastName)));

    [HttpPut("ChangeEmail")]
    public async Task<IActionResult> ChangeEmail(ChangeUserEmailRequest request) => 
        Ok(await sender.Send(
            new ChangeUserEmailCommand(
                request.UserId,
                request.Email)));

    [HttpPut("ChangePassword")]
    public async Task<IActionResult> ChangePassword(ChangeUserPasswordRequest request) => 
        Ok(await sender.Send(
            new ChangeUserPasswordCommand(
                request.UserId,
                request.Password)));

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await sender.Send(new GetAllUsersQuery()));

    [HttpGet("id")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await sender.Send(new GetUserByIdQuery(id)));

    [HttpGet("products")]
    public async Task<IActionResult> GetAllProductsOfUser(Guid UserId) => Ok(await sender.Send(new GetAllProductsOfUserQuery(UserId)));

    [HttpGet("orders")]
    public async Task<IActionResult> GetAllOrdersOfUser(Guid UserId) => Ok(await sender.Send(new GetAllOrdersOfUserQuery(UserId)));
}
