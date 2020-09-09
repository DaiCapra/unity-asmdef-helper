using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace AsmdefHelper.Editor
{
    public static class AsmdefTools
    {
        public static string Extension = ".asmdef";

        public static string GetPathActiveSelection()
        {
            var obj = Selection.activeObject;
            var pathAssets = AssetDatabase.GetAssetPath(obj);
            var pathData = Application.dataPath;
            pathData = pathData.Remove(pathData.Length - 6);
            var pathFull = pathData + pathAssets;
            return pathFull;
        }

        public static string[] GetAsmdefFiles(string path)
        {
            return Directory.GetFiles(path, $"*{Extension}", SearchOption.AllDirectories);
        }

        public static void DeleteAsmdefFilesInPath(string path)
        {
            var files = GetAsmdefFiles(path);
            foreach (var f in files)
            {
                try
                {
                    File.Delete(f);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }

        public static void CreateAsmdefFile(string path, AsmdefFile file)
        {
            var json = JsonUtility.ToJson(file, true);
            var filePath = $"{path}/{file.name}{Extension}";
            try
            {
                File.WriteAllText(filePath, json);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        public static void EnsureRootAsmdef(string path, string name)
        {
            var s = $"{path}/{name}{Extension}";
            if (File.Exists(s))
            {
                return;
            }

            CreateAsmdefFile(path, new AsmdefFile()
            {
                name = name
            });
        }

        public static void EnsureEditorAsmdef(string path, string name)
        {
            EnsureRootAsmdef(path, name);
            var pathEditor = $"{path}/Editor/";
            EnsureDirectory(pathEditor);

            var files = GetAsmdefFiles(pathEditor);
            if (files.Length > 0)
            {
                return;
            }

            CreateAsmdefFile(pathEditor, new AsmdefFile()
            {
                name = $"{name}.Editor",
                includePlatforms = new[] {"Editor"},
                references = new[] {name},
            });
        }

        public static void EnsurePlayModeTestAsmdef(string path, string name)
        {
            EnsureRootAsmdef(path, name);
            var pathFolder = $"{path}/Tests/PlayMode/";
            EnsureDirectory(pathFolder);

            var files = GetAsmdefFiles(pathFolder);
            if (files.Length > 0)
            {
                return;
            }

            CreateAsmdefFile(pathFolder, new AsmdefFile()
            {
                name = $"{name}.Tests.PlayMode",
                includePlatforms = new[] {"Editor"},
                references = new[] {name},
            });
        }

        private static void EnsureDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                return;
            }

            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        public static void EnsureEditModeTestAsmdef(string path, string name)
        {
            EnsureRootAsmdef(path, name);
            var pathFolder = $"{path}/Tests/EditMode/";
            EnsureDirectory(pathFolder);

            var files = GetAsmdefFiles(pathFolder);
            if (files.Length > 0)
            {
                return;
            }

            CreateAsmdefFile(pathFolder, new AsmdefFile()
            {
                name = $"{name}.Tests.EditMode",
                includePlatforms = new[] {"Editor"},
                references = new[]
                {
                    "UnityEngine.TestRunner",
                    "UnityEditor.TestRunner",
                    name
                },
                precompiledReferences = new[] {"nunit.framework.dll"},
                overrideReferences = true,
                autoReferenced = false,
                defineConstraints = new []{"UNITY_INCLUDE_TESTS"}
            });
        }
    }
}