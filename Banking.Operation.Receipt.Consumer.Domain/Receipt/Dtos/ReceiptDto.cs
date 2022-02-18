﻿using System;

namespace Banking.Operation.Receipt.Consumer.Domain.Receipt.Dtos
{
    public class ReceiptDto
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public Guid ContactId { get; set; }
        public string ContactName { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}