using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProcessingGarden.Business.RulesEngine.Specifications
{
    public static class SpecificationFactory
    {
        public static ISatisfiable GetSpecification(Workflow workflow)
        {
            string nSpace = workflow.GetType().Namespace;
            Assembly assembly = typeof(WorkflowSpecification).Assembly;

            Type specificationType = assembly.GetType(string.Format("{0}.{1}", nSpace, workflow.SpecificationName));

            if (specificationType == null)
            {
                throw new Exception(string.Format("Unable to resolve type {0}.", specificationType));
            }

            ISatisfiable specification = (ISatisfiable)Activator.CreateInstance(specificationType);

            return specification;
        }
    }
}
