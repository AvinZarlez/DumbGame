using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;
using System.Collections;
using System.Collections.Generic;
using System;

public class Builder : ScriptableObject {
        static string[] SCENES = FindEnabledEditorScenes();

	// Use real app name here
        static string APP_NAME = "DumbGame";
        static string TARGET_DIR = "Builds";
	
        [MenuItem ("Custom/CI/Build Windows Desktop")]
        public static void PerformStandaloneWindowsBuild ()
        {
                 string app_target = APP_NAME + ".exe";
                 GenericBuild(SCENES, TARGET_DIR + "/" + app_target, BuildTarget.StandaloneWindows,BuildOptions.None);
        }

        [MenuItem ("Custom/CI/Build Android")]
        public static void PerformAndroidBuild ()
        {
                 string app_target = APP_NAME + ".apk";
                 GenericBuild(SCENES, TARGET_DIR + "/" + app_target, BuildTarget.Android,BuildOptions.None);
        }
        
        [MenuItem ("Custom/CI/Build Windows Store")]
        static void PerformWSABuild ()
        {
                 string app_target = "WSA";
                 GenericBuild(SCENES, TARGET_DIR + "/" + app_target, BuildTarget.WSAPlayer,BuildOptions.None);
        }

	private static string[] FindEnabledEditorScenes() {
		List<string> EditorScenes = new List<string>();
		foreach(EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
			if (!scene.enabled) continue;
			EditorScenes.Add(scene.path);
		}
		return EditorScenes.ToArray();
	}

        static void GenericBuild(string[] scenes, string app_target, BuildTarget build_target, BuildOptions build_options)
        {
                EditorUserBuildSettings.SwitchActiveBuildTarget(build_target);
                BuildReport res = BuildPipeline.BuildPlayer(scenes,app_target,build_target,build_options);
                if (res != null) {
                        throw new Exception("BuildPlayer failure: " + res);
                }
        }
}
