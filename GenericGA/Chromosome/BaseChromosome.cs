using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericGA.Chromosome
{
    internal abstract class BaseChromosome : IChromosome
    {
        public List<object> Chromosome { get; set; }
        public int Size { get; set; }
        public BaseChromosome(List<object> chromosome)
        {
            Chromosome = chromosome;
            Size = Chromosome.Count;
        }
        public object this[int index]
        {
            get => Chromosome[index];
            set => Chromosome[index] = value;
        }

        public abstract IChromosome Clone();

        public abstract EvaluatedChromosome Evaluate();

        public abstract double Fitness();
    }
}
