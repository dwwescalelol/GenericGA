namespace GenericGA.Chromosome
{
    internal class EvaluatedChromosome
    {
        public IChromosome Chromosome { get; set; }
        public double Fitness { get; private set; }

        public EvaluatedChromosome(IChromosome chromosome)
        {
            Chromosome = chromosome;
            Fitness = chromosome.Fitness();
        }
    }
}
