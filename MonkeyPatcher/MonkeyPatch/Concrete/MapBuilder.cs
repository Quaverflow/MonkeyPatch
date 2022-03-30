using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using Utilities.ExtensionMethods;

namespace MonkeyPatch.MonkeyPatch.Concrete;


internal static class MapBuilder
{
    private static int _index;
    private static int _maxDepth;
    internal static List<MethodStructure> BuildMap(this MethodInfo caller, int maxDepth)
    {
        _maxDepth = maxDepth;
        var map = new List<MethodStructure>();
        var depth = 0;
        var structure = new MethodStructure(caller.GetKey(), depth, 0)
        {
            Owner = caller.DeclaringType?.FullName,
            ReturnType = caller.ReturnType.FullName,
            Signature = caller.GetSignature()
        };
        map.Add(structure);
        GoDeeperAndBuild(caller, structure, depth, map);
        return map.ToList();
    }

    private static void GoDeeperAndBuild(this MethodInfo method, MethodStructure structure, int depth, List<MethodStructure> structures)
    {
        depth++;
        if (depth > _maxDepth)
        {
            return;
        }
        if (method.IsAsync())
        {
            method.ExtractInnerMethodsFromAsyncMethod().Build(structure, depth, structures);
        }
        else
        {
            method.GetLocalMethods().Build(structure, depth, structures);
        }
    }

    private static void Build(this MethodInfo[]? methods, MethodStructure parent, int depth, List<MethodStructure> structures)
    {
        for (var i = 0; i < methods?.Length; i++)
        {
            _index++;
            var key = methods[i].GetKey();
            if (structures.All(x => x.Key != key))
            {
                var structure = new MethodStructure(key, depth, i)
                {
                    Owner = methods[i].DeclaringType?.FullName,
                    ReturnType = methods[i].ReturnType.FullName,
                    Signature = methods[i].GetSignature(),
                    SuperNodes = new List<MethodStructure> {parent},
                };
                structure.Indexes.Add(_index);
                structures.Add(structure);
                parent.SubNodes.Add(structure);
                GoDeeperAndBuild(methods[i], structure, depth, structures);
            }
            else
            {
                var method = structures.First(x => x.Key == key);
                if (parent.Key != method.Key)
                {
                    method.Indexes.Add(_index);

                    if (method.SuperNodes.All(x => x.Key != parent.Key))
                    {
                        method.SuperNodes.Add(parent);

                    }
                }
            }
        }
    }
}