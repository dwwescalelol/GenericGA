using GenericGA.Chromosome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericGA.Crossover
{
    internal class SinglePoint<C> : ICrossover<C> where C : BaseChromosome
    {
        private readonly Random rng;

        public SinglePoint()
        {
            rng = new Random();
        }

        public (C,C) Crossover(C parent1, C parent2)
        {
            C child1 = (C)parent1.Clone();
            C child2 = (C)parent2.Clone();

            int crossPoint = rng.Next(0, parent1.Size - 1);

            for (int i = 0; i < crossPoint; i++)
                    child1[i] = parent2[i];

            for (int i = crossPoint; i < parent1.Size; i++)
                child2[i] = parent1[i];

            return (child1,child2);
        }
    }
}
