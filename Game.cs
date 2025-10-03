using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class Game
{
    public Statistics Stats { get; private set; }
    public string CurrentScene { get; private set; }

    public Game()
    {
        Stats = new Statistics();
        Reset();
    }

    public void Reset()
    {
        CurrentScene = "Start.txt";
        Stats.Reset();
    }

    // Все методы выборов
    public void OnForest1Choice1()
    {
        Stats.AddObservation();
        Stats.AddDecoration();
        CurrentScene = "Forest2.txt";
    }

    public void OnForest1Choice2()
    {
        CurrentScene = "Forest2.txt";
    }

    public void OnForest2Choice1()
    {
        CurrentScene = "Forest2.1.txt";
    }

    public void OnForest2Choice2()
    {
        CurrentScene = "Forest2.2.txt";
    }

    public void OnForest2Choice3()
    {
        CurrentScene = "Ruins.txt";
    }

    public void OnForest21Choice1()
    {
        Stats.AddBlood();
        CurrentScene = "Ruins.txt";
    }

    public void OnForest21Choice2()
    {
        CurrentScene = "Ruins.txt";
    }

    public void OnForest22Choice1()
    {
        Stats.AddBone();
        CurrentScene = "Ruins.txt";
    }

    public void OnForest22Choice2()
    {
        CurrentScene = "Ruins.txt";
    }

    public void OnLuisaFonsecaChoice1()
    {
        Stats.AddObservation();
        Stats.AddBlister();
        CurrentScene = "LuisaFonseca2.txt";
    }

    public void OnLuisaFonsecaChoice2()
    {
        CurrentScene = "LuisaFonseca2.txt";
    }

    public void OnBuildingChoice1()
    {
        if (Stats.Blister > 0)
        {
            Stats.AddObservation();
            Stats.AddSms();
            CurrentScene = "BuildingBlister.txt";
        }
        else
        {
            CurrentScene = "BuildingNOBlister.txt";
        }
    }

    public void OnBuildingChoice2()
    {
        CurrentScene = "Building1.3.txt";
    }

    public void OnFight1Choice1()
    {
        CurrentScene = "Fight1.1.txt";
    }

    public void OnFight1Choice2()
    {
        Stats.AddHealth(-1);
        CurrentScene = "Fight1.2.txt";
    }

    public void OnFight2Choice1()
    {
        Stats.AddHealth(-1);
        CurrentScene = "Fight2.1.txt";
    }

    public void OnFight2Choice2()
    {
        CurrentScene = "Fight2.2.txt";
    }

    public void OnFight3Choice1()
    {
        CurrentScene = "Fight3.1.txt";
    }

    public void OnFight3Choice2()
    {
        Stats.AddHealth(-1);
        CurrentScene = "Fight3.2.txt";
    }

    //Логика переходов
    private string GetNextSceneName()
    {
        var endingScenes = new HashSet<string>
        {
            "LowHP.txt",
            "AllEvidence.txt",
            "NOEvidence.txt"
        };

        if (endingScenes.Contains(CurrentScene))
        {
            return "End.txt";
        }

        switch (CurrentScene)
        {
            case "Start.txt": return "Cabinet.txt";
            case "Cabinet.txt": return "JermaineO'Malley1.txt";
            case "JermaineO'Malley1.txt": return "HelenSmith.txt";
            case "HelenSmith.txt": return "DukeFrancis.txt";
            case "DukeFrancis.txt": return "JermaineO'Malley2.txt";
            case "JermaineO'Malley2.txt": return "SeanParker.txt";
            case "SeanParker.txt": return "JessicaJohnson.txt";
            case "JessicaJohnson.txt": return "Forest1.txt";

            case "Forest2.1.txt":
            case "Forest2.2.txt":
                return "Ruins.txt";

            case "Ruins.txt": return "LuisaFonseca1.txt";
            case "LuisaFonseca1.txt": return "LuisaFonseca2.txt";
            case "LuisaFonseca2.txt": return "Building.txt";

            case "BuildingBlister.txt":
            case "BuildingNOBlister.txt":
            case "Building1.3.txt":
                return "Fight1.txt";

            case "Fight1.1.txt":
            case "Fight1.2.txt":
                return "Fight2.txt";

            case "Fight2.1.txt":
            case "Fight2.2.txt":
                return "Fight3.txt";

            case "Fight3.1.txt":
            case "Fight3.2.txt":
                return Stats.Health <= 2 ? "LowHP.txt" : "HighHP.txt";

            case "HighHP.txt":
                return DetermineEndingScene();

            case "End.txt":
                return null;

            default:
                return null;
        }
    }

    public string AdvanceToNextScene()
    {
        string next = GetNextSceneName();
        if (next != null)
        {
            CurrentScene = next;
        }
        return next;
    }

    private string DetermineEndingScene()
    {
        bool hasBoneOrBlood = (Stats.Bone > 0 || Stats.Blood > 0);
        bool hasBlisterAndSms = (Stats.Blister > 0 && Stats.Sms > 0);

        if (hasBoneOrBlood || hasBlisterAndSms)
        {
            return "AllEvidence.txt";
        }
        else
        {
            return "NOEvidence.txt";
        }
    }

    //Сохранение/загрузка
    private static string SaveFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "savegame.dat");

    public void Save()
    {
        try
        {
            var stream = File.Create(SaveFilePath);
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
        }
        catch (Exception ex) { }
    }

    public static Game Load()
    {
        if (!File.Exists(SaveFilePath))
            return null;

        try
        {
            var stream = File.OpenRead(SaveFilePath);
            var formatter = new BinaryFormatter();
            return (Game)formatter.Deserialize(stream);
        }
        catch
        {
            // Повреждённый файл — удаляем
            try { File.Delete(SaveFilePath); } catch { }
            return null;
        }
    }

    // Методы
    public string LoadSceneText(string sceneFile)
    {
        string scenePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scene");
        string filePath = Path.Combine(scenePath, sceneFile);

        if (File.Exists(filePath))
        {
            try
            {
                return File.ReadAllText(filePath, System.Text.Encoding.UTF8);
            }
            catch (Exception ex)
            {
                return $"Ошибка чтения файла: {ex.Message}";
            }
        }
        else
        {
            return $"Файл {sceneFile} не найден!\nПуть: {filePath}";
        }
    }

    public string GetImageFileName(string sceneFile)
    {
        return Path.GetFileNameWithoutExtension(sceneFile) + ".jpg";
    }

    public string GetStatisticsText() => Stats.GetDisplayText();
}