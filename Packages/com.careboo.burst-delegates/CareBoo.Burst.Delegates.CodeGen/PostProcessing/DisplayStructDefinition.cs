using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

namespace CareBoo.Burst.Delegates.CodeGen
{
    public class DisplayStructDefinition
    {
        public TypeDefinition DisplayClass { get; }
        public TypeDefinition Definition { get; protected set; }
        public Dictionary<string, ValueDelegateStructDefinition> ValueDelegateStructs { get; protected set; }

        public DisplayStructDefinition(TypeDefinition displayClass)
        {
            DisplayClass = displayClass;

            Definition = InitDefinition();
            foreach (var field in displayClass.Fields)
                Definition.Fields.Add(field);

            ValueDelegateStructs = displayClass.Methods.ToDictionary(
                m => m.FullName,
                m => new ValueDelegateStructDefinition(this, m)
                );
        }

        private TypeDefinition InitDefinition()
        {
            return new TypeDefinition(
                @namespace: DisplayClass.Namespace,
                name: DisplayClass.Name.Replace("DisplayClass", "DisplayStruct"),
                attributes: DisplayClass.Attributes,
                DisplayClass.Module.ImportReference(typeof(ValueType))
                );
        }
    }
}
