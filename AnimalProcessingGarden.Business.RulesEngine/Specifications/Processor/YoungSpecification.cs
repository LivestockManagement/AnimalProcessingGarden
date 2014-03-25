﻿using AnimalProcessingGarden.Business.Entities;
using AnimalProcessingGarden.Business.Entities.Types;
using System.Collections.Generic;
namespace AnimalProcessingGarden.Business.RulesEngine.Specifications.Processor
{
    // Processed at the registered source.
    public class YoungSpecification : ISatisfiable
    {
        public Outcome IsSatisfiedBy(IPackable package, Workflow workflow)
        {
            ProcessAction processAction = (ProcessAction)package.Entity;
            Outcome outcome = new Outcome();
            outcome.Result = (processAction.Animal.Age < 20);
            return outcome;
        }
    }
}
