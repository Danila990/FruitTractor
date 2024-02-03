
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

namespace GameEditor
{
    public class ScreenshotHelper : EditorWindow
    {
        [MenuItem("Tools/Screenshot")]
        public static void TakeScreenshot()
        {
            string path = "GameScreenshots";
            
            Directory.CreateDirectory(path);

            int i = 0;

            while (File.Exists( $"{path}/{i}.png"))
                i++;
            
            ScreenCapture.CaptureScreenshot($"{path}/Screenshot {i}.png");
        }
    }
}