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

        // assumes all genes have same constraints and types.
        public T Mutate(T chrom)
        {
            int i = rng.Next(chrom.Chromosome.Count);
            int j = rng.Next(chrom.Chromosome.Count);

            T? mutatedChrom = chrom.Clone() as T;

            if (mutatedChrom is null) 
                throw new Exception("cannot convert mutated chrom to type T");

            (mutatedChrom[j], mutatedChrom[i]) = (mutatedChrom[i], mutatedChrom[j]);

            return mutatedChrom;
        }
    }
}
