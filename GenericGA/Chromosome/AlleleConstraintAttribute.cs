using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericGA.Mutation
{
    [AttributeUsage(AttributeTargets.All)]
    internal class AlleleConstraintAttribute : Attribute
    {
        public object? MinValue { get; set; }
        public object? MaxValue { get; set; }
        public Type? TypeType { get; set; }
    }
}
