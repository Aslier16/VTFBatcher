using System;

namespace VTFBatcher.Enums;

[Flags]
public enum PresetSetting
{
    None = 0,
    // Preset general settings
    IfSaveVTFWithTheSameNameAsSource = 1 << 0,
    IfCreateSubfolders = 1 << 1,
    // Character VGUI settings
    IfGenerateLobbyIcon = 1 << 2,
    IfGenerateInCapIcon = 1 << 3,
    IfGenerateHUDIcon = 1 << 4,
}