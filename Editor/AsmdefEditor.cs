using System;
using System.IO;
using UnityEditor;

namespace AsmdefHelper.Editor
{
    public static class AsmdefEditor
    {
        [MenuItem("Assets/Asmdef/Root")]
        public static void CreateAsmdefRoot()
        {
            var path = AsmdefTools.GetPathActiveSelection();
            var name = new DirectoryInfo(path).Name;
            AsmdefTools.EnsureRootAsmdef(path, name);
            Refresh();
        }


        [MenuItem("Assets/Asmdef/Editor")]
        public static void CreateAsmdefEditor()
        {
            var path = AsmdefTools.GetPathActiveSelection();
            var name = new DirectoryInfo(path).Name;
            AsmdefTools.EnsureEditorAsmdef(path, name);
            Refresh();
        }

        [MenuItem("Assets/Asmdef/Test EditMode")]
        public static void CreateAsmdefEditModeTest()
        {
            var path = AsmdefTools.GetPathActiveSelection();
            var name = new DirectoryInfo(path).Name;
            AsmdefTools.EnsureEditModeTestAsmdef(path, name);
            Refresh();
        }

        [MenuItem("Assets/Asmdef/Test PlayMode")]
        public static void CreateAsmdefPlayModeTest()
        {
            var path = AsmdefTools.GetPathActiveSelection();
            var name = new DirectoryInfo(path).Name;
            AsmdefTools.EnsurePlayModeTestAsmdef(path, name);
            Refresh();
        }

        private static void Refresh()
        {
            try
            {
                AssetDatabase.Refresh();
            }
            catch (Exception e)
            {
                // ignored
            }
        }
    }
}