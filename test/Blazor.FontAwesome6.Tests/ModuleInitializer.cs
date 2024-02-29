using System.Runtime.CompilerServices;
using DiffEngine;

namespace Rocket.Surgery.Blazor.FontAwesome6.Tests;

public class ModuleInitializer
{
    [ModuleInitializer]
    public static void Init()
    {
        DiffRunner.Disabled = true;
        DerivePathInfo(
            (sourceFile, _, type, method) =>
            {
                static string GetTypeName(Type type)
                {
                    // ReSharper disable once NullableWarningSuppressionIsUsed
                    return type.IsNested ? $"{type.ReflectedType!.Name}.{type.Name}" : type.Name;
                }

                var typeName = GetTypeName(type);

                // ReSharper disable once NullableWarningSuppressionIsUsed
                return new(Path.Combine(Path.GetDirectoryName(sourceFile)!, "snapshots"), typeName, method.Name);
            }
        );
    }
}
