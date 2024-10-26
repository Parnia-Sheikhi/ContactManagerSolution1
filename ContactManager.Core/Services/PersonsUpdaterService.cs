﻿using System;
using Entities;
using ServiceContracts.DTO;
using ServiceContracts;
using Services.Helpers;
using RepositoryContracts;
using Microsoft.Extensions.Logging;
using Serilog;
using SerilogTimings;
using Exceptions;

namespace Services
{
 public class PersonsUpdaterService : IPersonsUpdaterService
 {
  private readonly IPersonsRepository _personsRepository;
  private readonly ILogger<PersonsGetterService> _logger;
  private readonly IDiagnosticContext _diagnosticContext;

  public PersonsUpdaterService(IPersonsRepository personsRepository, ILogger<PersonsGetterService> logger, IDiagnosticContext diagnosticContext)
  {
   _personsRepository = personsRepository;
   _logger = logger;
   _diagnosticContext = diagnosticContext;
  }


  public async Task<PersonResponse> UpdatePerson(PersonUpdateRequest? personUpdateRequest)
  {
   if (personUpdateRequest == null)
    throw new ArgumentNullException(nameof(personUpdateRequest));

   //validation
   ValidationHelper.ModelValidation(personUpdateRequest);

   Person? matchingPerson = await _personsRepository.GetPersonByPersonID(personUpdateRequest.PersonID);
   if (matchingPerson == null)
   {
    throw new InvalidPersonIDException("Given person id doesn't exist");
   }

   //update all details
   matchingPerson.PersonName = personUpdateRequest.PersonName;
   matchingPerson.Email = personUpdateRequest.Email;
   matchingPerson.DateOfBirth = personUpdateRequest.DateOfBirth;
   matchingPerson.Gender = personUpdateRequest.Gender.ToString();
   matchingPerson.CountryID = personUpdateRequest.CountryID;
   matchingPerson.Address = personUpdateRequest.Address;
   matchingPerson.ReceiveNewsLetters = personUpdateRequest.ReceiveNewsLetters;

   await _personsRepository.UpdatePerson(matchingPerson); 

   return matchingPerson.ToPersonResponse();
  }
 }
}
