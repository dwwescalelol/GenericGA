using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericGA.Chromosome;

namespace GenericGA.Selection
{
    // THOUGHT : could have optimization type as a property of this class
    internal class RouletteWheel : ISelection
    {
        private readonly Random rng;

        public RouletteWheel()
        {
            rng = new Random();
        }

        /// <summary>
        /// Selects a specified number of individuals from the population using Roulette Wheel Selection.
        /// </summary>
        /// <param name="population">The population of chromosomes to select from.</param>
        /// <param name="numSelected">The number of individuals to select.</param>
        /// <returns>A list of selected individuals.</returns>
        public List<EvaluatedChromosome> Select(List<EvaluatedChromosome> population, int numSelected, OptimizationType optimizationType)
        {
            double totalFitness = optimizationType == OptimizationType.Maximize
                ? population.Sum(individual => individual.Fitness)
                : population.Sum(individual => 1 / individual.Fitness);

            List<EvaluatedChromosome> selection = new();
            double[] accumulatedFitness = NormaliseFitnessValues(population, optimizationType, totalFitness);

            for (int i = 0; i < numSelected; i++)
            {
                double targetFitness = rng.NextDouble() * totalFitness;
                selection.Add(population[Roulette(targetFitness, accumulatedFitness)]);
            }

            return selection;
        }

        private static double[] NormaliseFitnessValues(List<EvaluatedChromosome> population, OptimizationType optimizationType, double totalFitness)
        {
            double[] accumulatedFitness = new double[population.Count];

            if (optimizationType == OptimizationType.Maximize)
            {
                accumulatedFitness[0] = population[0].Fitness / totalFitness;
                for (int i = 1; i < accumulatedFitness.Length; i++)
                    accumulatedFitness[i] = (population[i].Fitness / totalFitness) + accumulatedFitness[i - 1];
            }
            else // OptimizationType.Minimize
            {
                accumulatedFitness[0] = (1 / population[0].Fitness) / totalFitness;
                for (int i = 1; i < accumulatedFitness.Length; i++)
                    accumulatedFitness[i] = ((1 / population[i].Fitness) / totalFitness) + accumulatedFitness[i - 1];
            }

            return accumulatedFitness;
        }

        // TODO make O(log N)
        private static int Roulette(double targetFitness, double[] accumulatedFitness)
        {
            for (int i = 0; i < accumulatedFitness.Length; i++)
                if (accumulatedFitness[i] >= targetFitness)
                    return i;
            throw new Exception("Supplied num greater than 1");
        }
    }
}
