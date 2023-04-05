using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericGA.Chromosome;
using GenericGA.Crossover;
using GenericGA.Mutation;
using GenericGA.Selection;

namespace GenericGA
{
    internal class GA<T> where T : IChromosome
    {
        public List<T> Population { get; set; }
        public int PopSize { get; set; }
        public double MutationProb { get; set; }
        public double CrossoverProb { get; set; }
        public ISelection Selection { get; set; }
        public IMutation<T> Mutation { get; set; }
        public ICrossover<T> Crossover { get; set; }

        public GA(int popSize, double mutationProb, double crossoverProb)
        {
            Population = new List<T>();
            PopSize = popSize;
            MutationProb = mutationProb;
            CrossoverProb = crossoverProb;
            Selection = new RouletteWheel();
            Mutation = null;
            Crossover = null;
        }



    }
}