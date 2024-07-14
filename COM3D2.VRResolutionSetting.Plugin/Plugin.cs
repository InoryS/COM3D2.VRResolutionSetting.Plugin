using BepInEx;
using BepInEx.Configuration;
using System;
using UnityEngine;
using UnityEngine.VR;

namespace COM3D2.VRResolutionSetting.Plugin
{
    [BepInPlugin("com.inorys.vrresolutionsetting", "COM3D2.VRResolutionSetting.Plugin", "1.0.0")]
    public class VRResolutionSetting : BaseUnityPlugin
    {
        private ConfigEntry<float> _renderScaleConfig;
        private ConfigEntry<int> _antiAliasingConfig;
        private ConfigEntry<bool> _useRecommendedMSAAConfig;

        void Awake()
        {
            // Creat config
            _renderScaleConfig = Config.Bind(
                "VR Settings",
                "Render Scale",
                VRSettings.renderScale,
                "Set the VR render scale"
            );

            _antiAliasingConfig = Config.Bind(
                "Quality Settings",
                "Anti Aliasing",
                QualitySettings.antiAliasing,
                "Set the anti-aliasing level"
            );

            _useRecommendedMSAAConfig = Config.Bind(
                "Quality Settings",
                "Use Recommended MSAA Level",
                false,
                "Use the recommended MSAA level"
            );

            // Add configuration item change event processing
            _renderScaleConfig.SettingChanged += OnRenderScaleChanged;
            _antiAliasingConfig.SettingChanged += OnAntiAliasingChanged;
            _useRecommendedMSAAConfig.SettingChanged += OnUseRecommendedMSAAChanged;

            // Initialize configuration item values
            UpdateRenderScale();
            UpdateAntiAliasing();
            UpdateUseRecommendedMSAA();
        }

        void OnDestroy()
        {
            // Remove configuration item change event processing
            _renderScaleConfig.SettingChanged -= OnRenderScaleChanged;
            _antiAliasingConfig.SettingChanged -= OnAntiAliasingChanged;
            _useRecommendedMSAAConfig.SettingChanged -= OnUseRecommendedMSAAChanged;
        }

        void OnRenderScaleChanged(object sender, EventArgs e)
        {
            UpdateRenderScale();
        }

        void OnAntiAliasingChanged(object sender, EventArgs e)
        {
            UpdateAntiAliasing();
        }

        void OnUseRecommendedMSAAChanged(object sender, EventArgs e)
        {
            UpdateUseRecommendedMSAA();
        }

        void UpdateRenderScale()
        {
            VRSettings.renderScale = _renderScaleConfig.Value;
            Logger.LogInfo($"Render Scale set to {VRSettings.renderScale}");
        }

        void UpdateAntiAliasing()
        {
            QualitySettings.antiAliasing = _antiAliasingConfig.Value;
            Logger.LogInfo($"Anti Aliasing set to {QualitySettings.antiAliasing}");
        }

        void UpdateUseRecommendedMSAA()
        {
            if (_useRecommendedMSAAConfig.Value && OVRManager.display != null)
            {
                QualitySettings.antiAliasing = OVRManager.display.recommendedMSAALevel;
                Logger.LogInfo($"Using recommended MSAA level: {QualitySettings.antiAliasing}");
            }
        }
    }
}