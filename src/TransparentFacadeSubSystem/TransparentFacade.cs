using System;
using System.Text;
using TransparentFacadeSubSystem.Abstractions;

namespace TransparentFacadeSubSystem
{
    public class TransparentFacade : ITransparentFacade
    {
        private readonly IComponentA componentA;
        private readonly IComponentB componentB;
        private readonly IComponentC componentC;

        public TransparentFacade(IComponentA componentA, IComponentB componentB, IComponentC componentC)
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
