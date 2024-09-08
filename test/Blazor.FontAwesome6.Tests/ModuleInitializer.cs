using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using AngleSharp.Dom;
using DiffEngine;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;
using VerifyTests.AngleSharp;

namespace Rocket.Surgery.Blazor.FontAwesome6.Tests;

public class ModuleInitializer
{
    [ModuleInitializer]
    public static void Init()
    {
        VerifyBunit.Initialize();
//        VerifyPlaywright.Initialize(true);
        VerifyAngleSharpDiffing.Initialize();
        HtmlPrettyPrint.All(
            list =>
            {
                list.ScrubAttributes(attr => attr.Name.StartsWith("b-") && attr.Name.Length == 12);
                foreach (var comment in list.DescendentsAndSelf<IComment>().Where(z => z.NodeValue == "!").ToArray())
                {
                    comment.Remove();
                }
            }
        );
        var regex = new Regex(@"id=""(.*?)""", RegexOptions.Compiled);
        VerifierSettings.ScrubLinesWithReplace(
            s =>
            {
                if (regex.Matches(s) is { Count: > 0, } matches)

                {
                    foreach (var match in matches.OfType<Match>())
                    {
                        s = s.Replace(match.Groups[1].Value, "[id]");
                    }
                }

                return s;
            }
        );
        VerifierSettings.IgnoreMember(typeof(IconModel), nameof(IconModel.Categories));
        VerifierSettings.IgnoreMember(typeof(IconModel), nameof(IconModel.PathData));
        VerifierSettings.IgnoreMember(typeof(IconModel), nameof(IconModel.RawFamily));
        VerifierSettings.IgnoreMember(typeof(IconModel), nameof(IconModel.RawStyle));
        VerifierSettings.IgnoreMember(typeof(IconModel), nameof(IconModel.Unicode));
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