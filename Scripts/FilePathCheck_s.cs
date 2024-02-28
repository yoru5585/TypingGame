using System.IO;
using UnityEngine;

public static class FileEx
{
    //パス調べるのに使ったやつ
    public static string FindPath(string name)
    {
        var paths = Directory.GetFiles(Application.dataPath, name, SearchOption.AllDirectories);

        if (paths != null && paths.Length > 0)
        {
            return paths[0].Replace("\\", "/").Replace(Application.dataPath, "Assets");
        }
        return null;
    }
}