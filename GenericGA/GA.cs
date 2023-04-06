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
    public enum OptimizationType
    {
        Maximize,
        Minimize
    }

    internal class GA<T> where T : BaseChromosome
    {
        public List<T> Population { get; set; }
        public int PopSize { get; set; }
        public double MutationProb { get; set; }
        public double CrossoverProb { get; set; }
        public ISelection Selection { get; set; }
        public IMutation<T> Mutation { get; set; }
        public ICrossover<T> Crossover { get; set; }
        public int MaxGenerations { get; set; }
        public double StoppingFitness { get; set; }
        public OptimizationType OptimizationType { get; set; }


        public GA(int popSize, double mutationProb, double crossoverProb)
        {
            Population = new List<T>();
            PopSize = popSize;
            MutationProb = mutationProb;
            CrossoverProb = crossoverProb;
            Selection = new RouletteWheel();
            Mutation = new SwapMutation<T>();
            Crossover = new SinglePoint<T>();
        }

        public void InitialisePop()
        {
            Population = new List<T>();

            // THOUGHT : user implements what a new T should look like
            for(int i = 0; i < PopSize; i++)
                Population.Add(new T);
        }

        public void Run()
        {
            InitialisePop();
            double bestFitness = OptimizationType == OptimizationType.Minimize
                ? double.MinValue
                : double.MaxValue;



            for (int i = 0; i < MaxGenerations && StoppingCondition(bestFitness); i++)
            {
                Population = Selection.Select(, PopSize, OptimizationType);
            }
        }


        public List<EvaluatedChromosome> EvaluatePop()
        {

            foreach (BaseChromosome individual in Population)
            {

            }

        }

        private bool StoppingCondition(double bestFitness)
        {
            return OptimizationType == OptimizationType.Maximize
                ? bestFitness >= StoppingFitness
                : bestFitness < StoppingFitness;
        }
    }
}