#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

namespace GameCustomEditor
{
    public class ScreenshotEditorMenu : EditorWindow
    {
        [MenuItem("Tools/Screenshot")]
        public static void TakeScreenshot()
        {
            string path = "GameScreenshots";
            
            Directory.CreateDirectory(path);

            int i = 0;

            while (File.Exists( $"{path}/Screenshot {i}.png"))
                i++;
            
            ScreenCapture.CaptureScreenshot($"{path}/Screenshot {i}.png");
        }
    }
}

#endif
