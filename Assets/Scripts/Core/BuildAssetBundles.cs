///<summary>
/// 에셋 번들 빌드 스크립트 [진현, 21. 12. 26]
///</summary>

#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildAssetBundle : MonoBehaviour
{
    [MenuItem("Wanmok/AssetBundle/Build Bundles")]
    public static void BuildBundles()
    {
        string buildPath = "Assets/AssetPacks";

        if (!Directory.Exists(buildPath))
            Directory.CreateDirectory(buildPath);

        BuildPipeline.BuildAssetBundles(buildPath, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);
        AssetDatabase.Refresh();
    }
}
#endif