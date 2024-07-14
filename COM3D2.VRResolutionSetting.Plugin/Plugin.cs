using BepInEx;
using BepInEx.Configuration;
using System;
using UnityEngine;
using UnityEngine.VR;

namespace COM3D2.VRResolutionSetting.Plugin;

[BepInPlugin("com.inorys.vrresolutionsetting", "COM3D2.VRResolutionSetting.Plugin", "1.0.0")]
public class VRResolutionSetting : BaseUnityPlugin
{
    private ConfigEntry<float> _renderScaleConfig;
    private ConfigEntry<int> _antiAliasingConfig;
    private ConfigEntry<bool> _useRecommendedMSAAConfig;

    void Awake()
    {
        // 创建配置项
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

        // 添加配置项变更事件处理
        _renderScaleConfig.SettingChanged += OnRenderScaleChanged;
        _antiAliasingConfig.SettingChanged += OnAntiAliasingChanged;
        _useRecommendedMSAAConfig.SettingChanged += OnUseRecommendedMSAAChanged;

        // 初始化配置项值
        UpdateRenderScale();
        UpdateAntiAliasing();
        UpdateUseRecommendedMSAA();
    }
    
    void OnDestroy()
    {
        // 移除配置项变更事件处理
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