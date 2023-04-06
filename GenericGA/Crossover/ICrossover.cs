using GenericGA.Chromosome;

namespace GenericGA.Crossover
{
    internal interface ICrossover<T> where T : IChromosome
    {
        (T,T) Crossover(T parent1, T parent2);
    }
}
