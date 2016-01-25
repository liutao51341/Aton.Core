using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace Aton.Core.Library.Reflection
{
    /// <summary>
    /// Assembly related reflection utils.
    /// </summary>
    public class AssemblyUtils
    {
        /// <summary>
        /// Get the internal template content from the commonlibrary assembly.
        /// </summary>
        /// <param name="assemblyFolderPath">"CommonLibrary.Notifications.Templates."</param>
        /// <param name="fileName">"welcome.html"</param>
        /// <returns>String with internal template content.</returns>
        public static string GetInternalFileContent(string assemblyFolderPath, string fileName)
        {
            Assembly current = Assembly.GetExecutingAssembly();

            Stream stream = current.GetManifestResourceStream(assemblyFolderPath + fileName);
            if (stream == null)
            {
                return string.Empty;
            }
            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();
            return content;
        }

        /// <summary>
        /// 根据路径反射创建对象
        /// </summary>
        /// <param name="assemblyPath"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static object CreateInstanceFromAssembly(string assemblyPath, string typeName)
        {
            Assembly asm = System.Reflection.Assembly.LoadFrom(assemblyPath);
            return  asm.CreateInstance(typeName, true);
        }
    }
}
