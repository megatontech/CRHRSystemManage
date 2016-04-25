/**
 * 杨林
 */
using System;
using System.Data;
using System.Configuration;
using System.IO;

/// <summary>
/// 关于文件的所有操作
/// </summary>
public class ManageAllFile
{
    public ManageAllFile()
    {
    }

    /// <summary>
    /// 创建文件夹
    /// </summary>
    /// <param name="path">文件夹路径</param>
    public void CreateDirectory(string path)
    {
        try
        {
            // 检查目录是否存在
            if (!Directory.Exists(path))
            {
                // 创建目录
                DirectoryInfo di = Directory.CreateDirectory(path);

                
            }
        }
        catch (Exception e)
        {
            Console.Write(e.Message.ToString());
        }
        finally { }
    }

    /// <summary>
    /// 删除文件夹
    /// </summary>
    /// <param name="path">文件夹路径</param>
    public void DeleteDirectory(string path)
    {
        try
        {
            // 检查目录是否存在
            if (Directory.Exists(path))
            {
                // 删除目录
                Directory.Delete(path, true);
            }
        }
        catch (Exception e)
        {
            Console.Write(e.Message.ToString());
        }
        finally { }
    }

    /// <summary>
    /// 删除文件
    /// </summary>
    /// <param name="path">文件路径</param>
    public void DeleteFile(string path)
    {
        try
        {
            File.Delete(path);//删除此文件
        }
        catch (Exception e)
        {
            Console.Write(e.Message.ToString());
        }
        finally { }
    }

    /// <summary>
    /// 创建文件
    /// </summary>
    /// <param name="path">文件路径</param>
    public void CreateFile(string path)
    {
        try
        {
            File.Create(path);
        }
        catch (Exception e)
        {
            Console.Write(e.Message.ToString());
        }
        finally { }
    }

    /// <summary>
    /// 重命名(移动)文件夹
    /// </summary>
    /// <param name="path">旧路径</param>
    /// <param name="newPath">新路径</param>
    public void ReNameDirectory(string path,string newPath)
    {
        try
        {
            Directory.Move(path, newPath);
        }
        catch (Exception e)
        {
            Console.Write(e.Message.ToString());
        }
        finally { }
    }

    /// <summary>
    /// 重命名(移动)文件
    /// </summary>
    /// <param name="path">旧路径</param>
    /// <param name="newPath">新路径</param>
    public void ReNameFile(string path, string newPath)
    {
        try
        {
            File.Move(path, newPath);
        }
        catch (Exception e)
        {
            Console.Write(e.Message.ToString());
        }
        finally { }
    }
}
