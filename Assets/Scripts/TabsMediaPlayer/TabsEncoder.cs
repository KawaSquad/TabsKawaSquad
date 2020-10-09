using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;

public static class TabsEncoder
{
    public static string GetFilePath(string filename)
    {
        string folderPath = Application.persistentDataPath;
        string filePath = folderPath + "/Tabs/" + filename + ".txt";

        return filePath;
    }
    public static string GetFolderPath(string filename = "")
    {
        string folderPath = Application.persistentDataPath;
        string fileFolderPath = folderPath + "/Tabs/";

        return fileFolderPath;
    }

    public static string[] GetTabsFiles()
    {
        string folder = GetFolderPath();
        string[] files = Directory.GetFiles(folder);

        return files;
    }

    public static string ReadTabsFile(string filename)
    {
        string filePath = GetFilePath(filename);
        if (File.Exists(filePath))
        {
            byte[] buffer = File.ReadAllBytes(filePath);
            string content = Encoding.UTF8.GetString(buffer);

            Debug.Log(content);
            return content;
        }
        return string.Empty;
    }
    public static void WriteTabsFile(string filename, string content)
    {
        string filePath = GetFilePath(filename);
        string fileFolderPath = GetFolderPath(filename);

        if (!Directory.Exists(fileFolderPath))
        {
            Directory.CreateDirectory(fileFolderPath);
        }

        FileStream stream = null;
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        stream = File.Create(filePath);

        if (stream != null)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);

            stream.Write(buffer, 0, buffer.Length);
            stream.Close();
        }
    }
}
