using GenericGA.Chromosome;

namespace GenericGA.Mutation
{
    internal interface IMutation<T> where T : BaseChromosome
    {
        T Mutate(T chrom);
    }
}
