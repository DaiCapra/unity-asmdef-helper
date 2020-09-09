using System;

namespace AsmdefHelper.Editor
{
    [Serializable]
    public class AsmdefFile
    {
        public string name;
        public string[] references;
        public string[] includePlatforms;
        public string[] optionalUnityReferences;
        public string[] precompiledReferences;
        public string[]  defineConstraints;
        public bool overrideReferences;
        public bool autoReferenced;
    }
}