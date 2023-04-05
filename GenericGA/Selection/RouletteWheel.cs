using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericGA.Chromosome;

namespace GenericGA.Selection
{
    internal class RouletteWheel : ISelection
    {
        private readonly Random rng;

        public RouletteWheel()
        {
            rng = new Random();
        }

        public List<EvaluatedChromosome> Select(List<EvaluatedChromosome> population, int numSelected)
        {
            double totalFitness = population.Sum(individual => individual.Fitness);
            List<EvaluatedChromosome> selection = new();

            for (int i = 0; i < numSelected; i++)
            {
                double targetFitness = rng.NextDouble() * totalFitness;
                double accumulatedFitness = 0.0;

                foreach (EvaluatedChromosome individual in population)
                {
                    accumulatedFitness += individual.Fitness;
                    if (accumulatedFitness >= targetFitness)
                    {
                        selection.Add(individual);
                    }
                }
            }
            return selection;
        }
    }
}
