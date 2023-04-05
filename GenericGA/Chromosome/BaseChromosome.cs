using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericGA.Chromosome
{
    internal abstract class BaseChromosome
    {
        public List<object> Chromosome { get; set; }

        public BaseChromosome(List<object> chromosome)
        {
            Chromosome = chromosome;
        }
        public object this[int index]
        {
            get => Chromosome[index];
            set => Chromosome[index] = value;
        }

        public abstract List<object> Clone();

        public abstract EvaluatedChromosome Evaluate();

        public abstract double Fitness();
    }
}
