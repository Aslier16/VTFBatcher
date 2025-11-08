using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using VTFBatcher.Enums;

namespace VTFBatcher.Models;

public static class PresetOpreation
{
    public static Dictionary<PresetEnum, Action<string, PresetSetting>> PresetActions = new()
    {
        { PresetEnum.Nick, ApplyNickPreset },
        { PresetEnum.Ellis, ApplyEllisPreset },
        { PresetEnum.Rochelle, ApplyRochellePreset },
        { PresetEnum.Coach, ApplyCoachPreset },
        { PresetEnum.Bill, ApplyBillPreset },
        { PresetEnum.Louis, ApplyLouisPreset },
        { PresetEnum.Zoey, ApplyZoeyPreset },
        { PresetEnum.Francis, ApplyFrancisPreset },
    };

    private static void ApplyNickPreset(string filePath, PresetSetting presetSetting)
    {
        CreateCharacterVGUI(filePath, "s_panel_gambler", "s_panel_gambler_incap", "s_panel_lobby_gambler",
            presetSetting);
    }

    private static void ApplyEllisPreset(string filePath, PresetSetting presetSetting)
    {
        CreateCharacterVGUI(filePath, "s_panel_mechanic", "s_panel_mechanic_incap", "s_panel_lobby_mechanic",
            presetSetting);
    }

    private static void ApplyRochellePreset(string filePath, PresetSetting presetSetting)
    {
        CreateCharacterVGUI(filePath, "s_panel_producer", "s_panel_producer_incap", "s_panel_lobby_producer",
            presetSetting);
    }

    private static void ApplyCoachPreset(string filePath, PresetSetting presetSetting)
    {
        CreateCharacterVGUI(filePath, "s_panel_coach", "s_panel_coach_incap", "s_panel_lobby_coach", presetSetting);
    }

    private static void ApplyBillPreset(string filePath, PresetSetting presetSetting)
    {
        CreateCharacterVGUI(filePath, "s_panel_namvet", "s_panel_namvet_incap", "select_bill", presetSetting);
    }

    private static void ApplyLouisPreset(string filePath, PresetSetting presetSetting)
    {
        CreateCharacterVGUI(filePath, "s_panel_manager", "s_panel_manager_incap", "select_louis", presetSetting);
    }

    private static void ApplyZoeyPreset(string filePath, PresetSetting presetSetting)
    {
        CreateCharacterVGUI(filePath, "s_panel_teenangst", "s_panel_teenangst_incap", "select_zoey", presetSetting);
    }

    private static void ApplyFrancisPreset(string filePath, PresetSetting presetSetting)
    {
        CreateCharacterVGUI(filePath, "s_panel_biker", "s_panel_biker_incap", "select_francis", presetSetting);
    }

    // ReSharper disable once InconsistentNaming
    private static void CreateCharacterVGUI(string vtffile, string vgui1, string vgui2, string vgui3,
        PresetSetting presetSetting = PresetSetting.None)
    {
        if (!File.Exists(vtffile)) throw new FileNotFoundException("VTF file not found.", vtffile);

        var dir = Path.GetDirectoryName(vtffile);
        if (dir == null) throw new DirectoryNotFoundException("Directory not found for the given VTF file.");

        if (presetSetting.HasFlag(PresetSetting.IfCreateSubfolders))
        {
            dir = Path.Combine(dir, "materials/vgui/");
            Directory.CreateDirectory(dir);
        }

        if (presetSetting.HasFlag(PresetSetting.IfGenerateHUDIcon))
            File.Copy(vtffile, Path.Combine(dir, vgui1 + ".vtf"), true);
        if (presetSetting.HasFlag(PresetSetting.IfGenerateInCapIcon))
            File.Copy(vtffile, Path.Combine(dir, vgui2 + ".vtf"), true);
        if (presetSetting.HasFlag(PresetSetting.IfGenerateLobbyIcon))
            File.Copy(vtffile, Path.Combine(dir, vgui3 + ".vtf"), true);

        // IfSaveVTFWithTheSameNameAsSource设置的执行交由VM处理，这里删除会让其他预设没有源文件可用
        // if (!presetSetting.HasFlag(PresetSetting.IfSaveVTFWithTheSameNameAsSource))
        // {
        //     File.Delete(vtffile);
        // }
    }
}