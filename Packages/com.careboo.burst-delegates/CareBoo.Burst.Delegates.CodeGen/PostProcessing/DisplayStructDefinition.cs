using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

namespace CareBoo.Burst.Delegates.CodeGen
{
    public class DisplayStructDefinition
    {
        public TypeDefinition Definition { get; protected set; }
        public Dictionary<string, ValueDelegateStructDefinition> ValueDelegateStructs { get; protected set; }

        private readonly TypeDefinition displayClass;

        public DisplayStructDefinition(TypeDefinition displayClass)
        {
            this.displayClass = displayClass;

            Definition = InitDefinition();
            foreach (var field in displayClass.Fields)
                Definition.Fields.Add(field);

            ValueDelegateStructs = displayClass.Methods.ToDictionary(
                m => m.FullName,
                m => new ValueDelegateStructDefinition(Definition, m)
                );
        }

        private TypeDefinition InitDefinition()
        {
            return new TypeDefinition(
                @namespace: displayClass.Namespace,
                name: displayClass.Name.Replace("DisplayClass", "DisplayStruct"),
                attributes: displayClass.Attributes,
                displayClass.Module.ImportReference(typeof(ValueType))
                );
        }
    }
}
