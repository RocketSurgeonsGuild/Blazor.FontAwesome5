using System.Runtime.CompilerServices;
using AngleSharp.Dom;
using DiffEngine;
using VerifyTests.AngleSharp;

namespace Rocket.Surgery.Blazor.FontAwesome6.Tests;

public class ModuleInitializer
{
    [ModuleInitializer]
    public static void Init()
    {
        VerifyPlaywright.Initialize(installPlaywright: true);
        VerifyAngleSharpDiffing.Initialize();
        HtmlPrettyPrint.All(
            list =>
            {
                list.ScrubAttributes(attr => attr.Name.StartsWith("b-") && attr.Name.Length == 12);
                foreach (var comment in list.DescendentsAndSelf<IComment>().Where(z => z.NodeValue == "!").ToArray())
                {
                    comment.Remove();
                }
            });
        VerifyImageMagick.Initialize();
        VerifyImageMagick.RegisterComparers(.05);
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
