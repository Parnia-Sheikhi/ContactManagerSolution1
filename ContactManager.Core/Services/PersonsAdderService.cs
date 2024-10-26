using System;
using Entities;
using ServiceContracts.DTO;
using ServiceContracts;
using Services.Helpers;
using RepositoryContracts;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Services
{
 public class PersonsAdderService : IPersonsAdderService
 {
  private readonly IPersonsRepository _personsRepository;
  private readonly ILogger<PersonsGetterService> _logger;
  private readonly IDiagnosticContext _diagnosticContext;

  public PersonsAdderService(IPersonsRepository personsRepository, ILogger<PersonsGetterService> logger, IDiagnosticContext diagnosticContext)
  {
   _personsRepository = personsRepository;
   _logger = logger;
   _diagnosticContext = diagnosticContext;
  }


  public async Task<PersonResponse> AddPerson(PersonAddRequest? personAddRequest)
  {
   if (personAddRequest == null)
   {
    throw new ArgumentNullException(nameof(personAddRequest));
   }

   //Model validation
   ValidationHelper.ModelValidation(personAddRequest);

   Person person = personAddRequest.ToPerson();

   person.PersonID = Guid.NewGuid();

   await _personsRepository.AddPerson(person);

   return person.ToPersonResponse();
  }

 }
}
