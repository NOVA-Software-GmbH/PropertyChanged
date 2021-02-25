using System;
using System.Collections.Generic;
using Mono.Cecil;

public partial class ModuleWeaver
{
    const string WeaveINotifyPropertyChangedName = "IWeaveINotifyPropertyChanged";
    Dictionary<string, bool> typesImplementingIWeaveINotifyPropertyChanged = new Dictionary<string, bool>();

    public bool HierarchyImplementsIWeaveINotifyPropertyChanged(TypeReference typeReference)
    {
        var fullName = typeReference.FullName;
        if (typesImplementingIWeaveINotifyPropertyChanged.TryGetValue(fullName, out var implementsIWeaveINotifyPropertyChanged))
        {
            return implementsIWeaveINotifyPropertyChanged;
        }

        TypeDefinition typeDefinition;
        if (typeReference.IsDefinition)
        {
            typeDefinition = (TypeDefinition)typeReference;
        }
        else
        {
            try
            {
                typeDefinition = Resolve(typeReference);
            }
            catch (Exception ex)
            {
                EmitWarning($"Ignoring type {fullName} in type hierarchy => {ex.Message}");
                return false;
            }
        }

        foreach (var interfaceImplementation in typeDefinition.Interfaces)
        {
            if (interfaceImplementation.InterfaceType.Name == WeaveINotifyPropertyChangedName)
            {
                typesImplementingIWeaveINotifyPropertyChanged[fullName] = true;
                return true;
            }
        }

        var baseType = typeDefinition.BaseType;
        if (baseType == null)
        {
            typesImplementingIWeaveINotifyPropertyChanged[fullName] = false;
            return false;
        }

        var baseTypeImplementsIWeaveINotifyPropertyChanged = HierarchyImplementsINotify(baseType);
        typesImplementingIWeaveINotifyPropertyChanged[fullName] = baseTypeImplementsIWeaveINotifyPropertyChanged;
        return baseTypeImplementsIWeaveINotifyPropertyChanged;
    }
}
