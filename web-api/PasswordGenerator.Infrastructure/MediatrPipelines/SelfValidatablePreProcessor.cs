﻿using MediatR.Pipeline;
using System.ComponentModel.DataAnnotations;

namespace PasswordGenerator.Infrastructure.MediatrPipelines
{
    internal class SelfValidatablePreProcessor<TRquest> : IRequestPreProcessor<TRquest> where TRquest : notnull
    {
        public Task Process(TRquest request, CancellationToken cancellationToken)
        {
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(request, new ValidationContext(request), validationResults, true);

            if (!isValid)
            {
                throw new ValidationException(validationResults.First().ErrorMessage);
            }
            return Task.CompletedTask;
        }
    }
}