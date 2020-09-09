using System.IO;
using UnityEditor;

namespace AsmdefHelper.Editor
{
    public static class AsmdefEditor
    {
        // Create root
        // Create editor
        // Create play test
        // Create editor test
        [MenuItem("Assets/Asmdef Root")]
        public static void CreateAsmdefRoot()
        {
            var path = AsmdefTools.GetPathActiveSelection();
            var name = new DirectoryInfo(path).Name;
            AsmdefTools.EnsureRootAsmdef(path, name);
            AssetDatabase.Refresh();
        }

        [MenuItem("Assets/Asmdef Editor")]
        public static void CreateAsmdefEditor()
        {
            var path = AsmdefTools.GetPathActiveSelection();
            var name = new DirectoryInfo(path).Name;
            AsmdefTools.EnsureEditorAsmdef(path, name);
            AssetDatabase.Refresh();
        }
        [MenuItem("Assets/Asmdef Test EditMode")]
        public static void CreateAsmdefEditModeTest()
        {
            var path = AsmdefTools.GetPathActiveSelection();
            var name = new DirectoryInfo(path).Name;
            AsmdefTools.EnsureEditModeTestAsmdef(path, name);
            AssetDatabase.Refresh();
        }
        [MenuItem("Assets/Asmdef Test PlayMode")]
        public static void CreateAsmdefPlayModeTest()
        {
            var path = AsmdefTools.GetPathActiveSelection();
            var name = new DirectoryInfo(path).Name;
            AsmdefTools.EnsurePlayModeTestAsmdef(path, name);
            AssetDatabase.Refresh();
        }
    }
}