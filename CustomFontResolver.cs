using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using System;
using System.IO;
using System.Reflection;

public class CustomFontResolver : IFontResolver
{
    public byte[] GetFont(string faceName)
    {
        if (faceName == "Arial")
            return LoadFontData("arial.ttf");

        throw new InvalidOperationException("Font not found.");
    }

    public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
    {
        if (familyName.Equals("Arial", StringComparison.OrdinalIgnoreCase))
            return new FontResolverInfo("Arial");

        return new FontResolverInfo("Arial");
    }

    private byte[] LoadFontData(string fontFileName)
    {
        string fontPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
            fontFileName
        );

        return File.ReadAllBytes(fontPath);
    }
}
