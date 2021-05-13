using Checkout.PaymentGateway.Models;
using Checkout.PaymentGateway.Models.Contexts;
using Checkout.PaymentGateway.Services.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ConcurrentDictionary<string, Transaction> _transList;

        public TransactionService()
        {
            _transList = new ConcurrentDictionary<string, Transaction>();
        }

        public async Task<Transaction> InitialiseTransactionAsync(CardPaymentContext cardContext)
        {
            var transactionId = Guid.NewGuid().ToString();

            var transaction = new Transaction()
            {
                TransactionId = transactionId,
                Amount = cardContext.Amount,
                CardDetail = cardContext.CardDetail,
                MerchantId = cardContext.MerchantId,
                MerchantReference = cardContext.MerchantReference,
                Status = TransactionStatus.Pending,
                RequestedOn = DateTime.UtcNow
            };

            await Task.Run(() => _transList[transactionId] = transaction);

            return transaction;
        }

        public async Task<Transaction> UpdateTransactionAsync(string transactionId, BankResponse bankResponse)
        {
            return await Task.Run(() =>
                {
                    var transaction = _transList[transactionId];
                    
                    transaction.ProcessedOn = DateTime.UtcNow;
                    transaction.BankReference = bankResponse.Id;
                    transaction.BankDetails = bankResponse.Details;

                    if (bankResponse.Status == BankResponseStatus.Success)
                    {
                        transaction.Status = TransactionStatus.Fulfilled;
                    }
                    else
                    {
                        transaction.Status = TransactionStatus.Declined;
                    }

                    _transList[transaction.TransactionId] = transaction;

                    return transaction;
                }
            );
        }

        public async Task<Transaction> GetTransaction(string id)
        {
            return await Task.Run(() => {
                if (_transList.TryGetValue(id, out Transaction transaction))
                    return transaction;
                else
                    return null;
            } );
        }
    }
}
