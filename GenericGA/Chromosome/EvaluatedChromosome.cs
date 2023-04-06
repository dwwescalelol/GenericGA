namespace GenericGA.Chromosome
{
    internal class EvaluatedChromosome
    {
        public BaseChromosome Chromosome { get; set; }
        public double Fitness { get; private set; }

        public EvaluatedChromosome(BaseChromosome chromosome)
        {
            Chromosome = chromosome;
            Fitness = chromosome.Fitness();
        }
    }
}
