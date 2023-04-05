using GenericGA.Chromosome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericGA.Mutation
{
    internal class SwapMutation<T> : IMutation<T> where T : BaseChromosome
    {
        private readonly Random rng;

        public SwapMutation()
        {
            rng = new Random();
        }

        public T Mutate(T chrom)
        {
            int i = rng.Next(chrom.Chromosome.Count);
            int j = rng.Next(chrom.Chromosome.Count);

            List<object> mutatedChrom = chrom.Clone();

            (mutatedChrom[j], mutatedChrom[i]) = (mutatedChrom[i], mutatedChrom[j]);

            T c = new(mutatedChrom);

            return c;
        }
    }
}
