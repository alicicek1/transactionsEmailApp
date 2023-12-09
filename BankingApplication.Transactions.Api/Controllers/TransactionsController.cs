using BankingApplication.Application.Models;
using BankingApplication.Application.Services.Transaction;
using BankingApplication.Transactions.Api.Request;
using Microsoft.AspNetCore.Mvc;

namespace BankingApplication.Transactions.Api.Controllers;

public class TransactionsController : BaseController
{
    private readonly ITransactionsService _transactionsService;

    public TransactionsController(ITransactionsService transactionsService)
    {
        _transactionsService = transactionsService;
    }

    [HttpPost]
    public IActionResult SendTransactionsToEmailAddress(
        [FromBody] SendTransactionsToEmailAddressRequestModel sendTransactionsToEmailAddressRequestModel)
    {
        return Ok(_transactionsService.SendTransactionsToEmailAddress(new SendTransactionsToEmailAddressModel
        {
            StartDate = sendTransactionsToEmailAddressRequestModel.StartDate,
            EndDate = sendTransactionsToEmailAddressRequestModel.EndDate,
            UserEmailId = sendTransactionsToEmailAddressRequestModel.UserEmailId
        }));
    }
}