﻿namespace Luban.Any.TypeVisitors;

class TypescriptBinSerializeVisitor : DecoratorFuncVisitor<string, string, string>
{
    public static TypescriptBinSerializeVisitor Ins { get; } = new();

    public override string DoAccept(TType type, string bytebufName, string fieldName)
    {
        if (type.IsNullable)
        {
            return $"if({bytebufName}.ReadBool()) {{{type.Apply(TypescriptBinUnderingSerializeVisitor.Ins, bytebufName, fieldName)} }} else {{ {fieldName} = null; }}";
        }
        else
        {
            return type.Apply(TypescriptBinUnderingSerializeVisitor.Ins, bytebufName, fieldName);
        }
    }
}