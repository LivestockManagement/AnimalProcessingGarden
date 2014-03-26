using AnimalProcessingGarden.Business.Entities;
using AnimalProcessingGarden.Business.Entities.Types;
using System.Collections.Generic;
namespace AnimalProcessingGarden.Business.RulesEngine.Specifications.Processor
{
    // A Kill Record.
    public class YoungSpecification : ISatisfiable
    {
        public Outcome IsSatisfiedBy(IPackable package, Workflow workflow)
        {
            ProcessAction processAction = (ProcessAction)package.Entity;
            Outcome outcome = new Outcome(this.GetType());
            outcome.Result = (processAction.Animal.Age < 20);
            return outcome;
        }
    }
}
