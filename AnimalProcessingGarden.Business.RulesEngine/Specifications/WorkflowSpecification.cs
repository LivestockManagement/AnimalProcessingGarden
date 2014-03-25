using AnimalProcessingGarden.Business.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
namespace AnimalProcessingGarden.Business.RulesEngine.Specifications
{
    // Killed: Type is set to Kill.
    public class WorkflowSpecification : ISatisfiable
    {
        public Outcome IsSatisfiedBy(IPackable Package, Workflow Workflow)
        {

            Outcome outcome = new Outcome();
            outcome.Outcomes = new List<Outcome>();

            foreach (var workflow in Workflow.Workflows)
            {
                ISatisfiable childSpecification = SpecificationFactory.GetSpecification(workflow);
                Outcome childOutcome = childSpecification.IsSatisfiedBy(Package, workflow);
                outcome.Outcomes.Add(childOutcome);
            }

            Outcome resolvedOutcome = ResolveOutcome(outcome, Workflow.GroupCondition);

            return resolvedOutcome;
        }

        private Outcome ResolveOutcome(Outcome Outcome, string GroupCondition)
        {
            if (GroupCondition == "Or")
            {
                if (Outcome.Outcomes.Exists(x => x.Result == true))
                {
                    Outcome.Result = true;
                }
            }
            else if (Outcome.Outcomes.Exists(x => x.Result == false))
            {
                Outcome.Result = false;
            }

            if (GroupCondition == "Not")
            {
                Outcome.Result = !Outcome.Result;
            }

            return Outcome;
        }
    }
}
