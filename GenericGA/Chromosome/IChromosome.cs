namespace GenericGA.Chromosome
{
    internal interface IChromosome
    {
        IChromosome Clone();
        double Fitness();
        EvaluatedChromosome Evaluate();
    }
}
