using AnimalProcessingGarden.Business.Entities;
using AnimalProcessingGarden.Business.Entities.Entities;
using AnimalProcessingGarden.Business.Entities.Types;
using System.Collections.Generic;
namespace AnimalProcessingGarden.Business.RulesEngine.Specifications.Processor
{
    // Processed at the registered source.
    public class SourceSpecification : ISatisfiable
    {
        public Outcome IsSatisfiedBy(IPackable package, Workflow workflow)
        {
            Outcome outcome = new Outcome();
            ProcessAction processAction = (ProcessAction)package.Entity;
            
            outcome.Result = (processAction.Animal.Location == processAction.Owner.Location);
            return outcome;
        }
    }
}
