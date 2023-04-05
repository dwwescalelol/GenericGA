using GenericGA.Chromosome;

namespace GenericGA.Selection
{
    internal interface ISelection
    {
        List<EvaluatedChromosome> Select(List<EvaluatedChromosome> population, int numSelected);
    }
}
