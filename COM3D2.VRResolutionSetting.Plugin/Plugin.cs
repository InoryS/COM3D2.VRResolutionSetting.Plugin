using BepInEx;
using BepInEx.Configuration;
using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.VR;

namespace COM3D2.VRResolutionSetting.Plugin
{
    [BepInPlugin("com.inorys.vrresolutionsetting", "COM3D2.VRResolutionSetting.Plugin", "1.0.4")]
    public class VRResolutionSetting : BaseUnityPlugin
    {
        private ConfigEntry<RenderScale> _renderScaleConfig;
        private ConfigEntry<float> _customRenderScaleConfig;
        private ConfigEntry<AntiAliasingLevel> _antiAliasingConfig;
        private ConfigEntry<bool> _useRecommendedMSAAConfig;

        void Awake()
        {
            // Creat config
            _renderScaleConfig = Config.Bind(
                "VR Settings",
                "Render Resolution Scale",
                RenderScale.Scale10,
                "Set the VR resolution render scale, Waring this is a multiplicative relationship, setting it too high to 1.7 may cause your game to freeze"
            );

            _customRenderScaleConfig = Config.Bind(
                "VR Settings",
                "Custom resolution Render Scale",
                1.0f,
                "Set a resolution custom VR render scale, set to 1.0f to use drop-down list"
            );

            _antiAliasingConfig = Config.Bind(
                "Quality Settings",
                "MSAA Anti Aliasing level",
                AntiAliasingLevel.Level4,
                "Set the MSAA anti-aliasing level"
            );

            _useRecommendedMSAAConfig = Config.Bind(
                "Quality Settings",
                "Use System Recommended MSAA Level",
                false,
                "Use the System recommended MSAA level"
            );

            // Add configuration item change event processing
            _renderScaleConfig.SettingChanged += OnRenderScaleChanged;
            _customRenderScaleConfig.SettingChanged += OnRenderScaleChanged;
            _antiAliasingConfig.SettingChanged += OnAntiAliasingChanged;
            _useRecommendedMSAAConfig.SettingChanged += OnUseRecommendedMSAAChanged;
            
            // Initial update
            UpdateRenderScale();
            UpdateAntiAliasing();
            UpdateUseRecommendedMSAA();
        }

        void OnDestroy()
        {
            // Remove configuration item change event processing
            _renderScaleConfig.SettingChanged -= OnRenderScaleChanged;
            _customRenderScaleConfig.SettingChanged -= OnRenderScaleChanged;
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
            float customScale = _customRenderScaleConfig.Value;
            float renderScale = !IsApproximatelyEqual(customScale, 1.0f)
                ? customScale
                : GetRenderScaleValue(_renderScaleConfig.Value);
            VRSettings.renderScale = renderScale;
            Logger.LogInfo($"Render Scale set to {VRSettings.renderScale = renderScale}");
        }

        void UpdateAntiAliasing()
        {
            QualitySettings.antiAliasing = (int)_antiAliasingConfig.Value;
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

        private enum RenderScale
        {
            [Description("0.5")] Scale05 = 0,
            [Description("0.6")] Scale06 = 1,
            [Description("0.7")] Scale07 = 2,
            [Description("0.8")] Scale08 = 3,
            [Description("0.9")] Scale09 = 4,
            [Description("1.0")] Scale10 = 5,
            [Description("1.1")] Scale11 = 6,
            [Description("1.2")] Scale12 = 7,
            [Description("1.3")] Scale13 = 8,
            [Description("1.4")] Scale14 = 9,
            [Description("1.5")] Scale15 = 10,
            [Description("1.6")] Scale16 = 11,
            [Description("1.7")] Scale17 = 12,
            [Description("1.8")] Scale18 = 13,
            [Description("1.9")] Scale19 = 14,
            [Description("2.0")] Scale20 = 15,
            [Description("2.2")] Scale22 = 16,
            [Description("2.5")] Scale25 = 17,
            [Description("2.7")] Scale27 = 18,
            [Description("3.0")] Scale30 = 19,
        }

        private enum AntiAliasingLevel
        {
            [Description("None")] Level0 = 0,
            [Description("2x")] Level2 = 2,
            [Description("4x")] Level4 = 4,
            [Description("8x")] Level8 = 8,
        }

        float GetRenderScaleValue(RenderScale scale)
        {
            return scale switch
            {
                RenderScale.Scale05 => 0.5f,
                RenderScale.Scale06 => 0.6f,
                RenderScale.Scale07 => 0.7f,
                RenderScale.Scale08 => 0.8f,
                RenderScale.Scale09 => 0.9f,
                RenderScale.Scale10 => 1.0f,
                RenderScale.Scale11 => 1.1f,
                RenderScale.Scale12 => 1.2f,
                RenderScale.Scale13 => 1.3f,
                RenderScale.Scale14 => 1.4f,
                RenderScale.Scale15 => 1.5f,
                RenderScale.Scale16 => 1.6f,
                RenderScale.Scale17 => 1.7f,
                RenderScale.Scale18 => 1.8f,
                RenderScale.Scale19 => 1.9f,
                RenderScale.Scale20 => 2.0f,
                RenderScale.Scale22 => 2.2f,
                RenderScale.Scale25 => 2.5f,
                RenderScale.Scale27 => 2.7f,
                RenderScale.Scale30 => 3.0f,
                _ => 1.0f,
            };
        }

        bool IsApproximatelyEqual(float a, float b, float tolerance = 0.001f)
        {
            return Math.Abs(a - b) < tolerance;
        }
    }
}