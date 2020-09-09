using System.IO;
using AsmdefHelper.Editor;
using NUnit.Framework;
using UnityEngine;

namespace AsmdefHelper.Tests
{
    public class TestAsmdef
    {
        private string _pathTest;

        [SetUp]
        public void Setup()
        {
            var pathData = Application.dataPath;
            _pathTest = $"{pathData}/AsmdefHelper/Tests/TestFolders/";
        }

        [Test]
        public void TestRoot()
        {
            Assert.True(Directory.Exists(_pathTest));
            var nameRoot = new DirectoryInfo(_pathTest).Name;
            Assert.NotNull(nameRoot);

            AsmdefTools.DeleteAsmdefFilesInPath(_pathTest);

            var s = $"{_pathTest}/{nameRoot}{AsmdefTools.Extension}";
            Assert.False(File.Exists(s));

            AsmdefTools.CreateAsmdefFile(_pathTest, new AsmdefFile()
            {
                name = nameRoot
            });
            Assert.True(File.Exists(s));
        }

        [Test]
        public void TestEditor()
        {
            Assert.True(Directory.Exists(_pathTest));
            var nameRoot = new DirectoryInfo(_pathTest).Name;
            Assert.NotNull(nameRoot);
            
            AsmdefTools.EnsureEditorAsmdef(_pathTest, nameRoot);
            
            var s = $"{_pathTest}/Editor/{nameRoot}.Editor{AsmdefTools.Extension}";
            Assert.True(File.Exists(s));
        }
    }
}