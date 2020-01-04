﻿using BepInEx;
using Common;
using HarmonyLib;

namespace IllusionFixes
{
    [BepInProcess(Constants.StudioProcessName)]
    [BepInPlugin(GUID, PluginName, Metadata.PluginsVersion)]
    public class CameraTargetFix : CameraTargetFixCore
    {
        public const string GUID = "KK_Fix_CameraTarget";

        protected override void Awake()
        {
            base.Awake();

            Harmony.Patch(typeof(Studio.CameraControl).GetMethod("LateUpdate", AccessTools.all),
                          transpiler: new HarmonyMethod(typeof(CameraTargetFixCore).GetMethod(nameof(StudioPatch), AccessTools.all)));
        }
    }
}
