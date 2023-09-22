using System;
using System.Drawing;
using System.IO;
using System.Reflection;

Image imgFile = Image.FromFile(MergePath(@"\Images\cat.png"));
imgFile.Save(MergePath(@"\Images\cat2.png"), System.Drawing.Imaging.ImageFormat.Jpeg);

Console.WriteLine("Hello world!");


static string MergePath(string path)
{
    string ret = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path);

    return ret;
}