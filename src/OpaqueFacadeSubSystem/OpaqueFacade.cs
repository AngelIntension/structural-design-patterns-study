using OpaqueFacadeSubSystem.Abstractions;
using System;
using System.Text;

namespace OpaqueFacadeSubSystem
{
    public class OpaqueFacade : IOpaqueFacade
    {
        private readonly ComponentA componentA;
        private readonly ComponentB componentB;
        private readonly ComponentC componentC;

        internal OpaqueFacade(ComponentA componentA, ComponentB componentB, ComponentC componentC)
        {
            this.componentA = componentA ?? throw new ArgumentNullException(nameof(componentA));
            this.componentB = componentB ?? throw new ArgumentNullException(nameof(componentB));
            this.componentC = componentC ?? throw new ArgumentNullException(nameof(componentC));
        }

        public string ExecuteOperationA()
        {
            return new StringBuilder()
                .AppendLine(componentA.OperationA())
                .AppendLine(componentA.OperationB())
                .AppendLine(componentB.OperationD())
                .AppendLine(componentC.OperationE())
                .ToString();
        }

        public string ExecuteOperationB()
        {
            return new StringBuilder()
                .AppendLine(componentB.OperationC())
                .AppendLine(componentB.OperationD())
                .AppendLine(componentC.OperationF())
                .ToString();
        }
    }
}
