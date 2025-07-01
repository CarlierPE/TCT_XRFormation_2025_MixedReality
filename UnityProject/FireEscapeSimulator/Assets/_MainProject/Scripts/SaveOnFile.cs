using System;
using System.Collections.Generic; // Assuming you are using TextMeshPro for UI text display
using System.IO;
using UnityEngine;
[Obsolete("on n'utilise pas pour le moment")]
public class SaveOnFile : MonoBehaviour
{
    private const string _extension = ".json";
    private const string _prefix = "Player_";

    private string _currentDate;
    private string _folderName;
    private string _fileName;
    private string _fileNumber;

    private string _rootPathSearch;
    private string _rootPathToSave;
    private string _PathCreatedFolder;

    private int _numFile = 1;
    private int _fileCount = 0;

    //private readonly List<GameDebriefing> _gameDebriefings;

    public void InitBased()
    {
        //_gameDebriefings.Clear();

        _currentDate = DateTime.Now.ToString("yyyy-MM-dd");
        _folderName = _currentDate.Replace("-", "_");
        _rootPathSearch = Application.persistentDataPath;
        _PathCreatedFolder = Path.Combine(_rootPathSearch, _folderName);

        if (!Directory.Exists(_PathCreatedFolder))
        {
            Directory.CreateDirectory(_PathCreatedFolder);
        }

        string[] fichiers = Directory.GetFiles(_PathCreatedFolder, "*.json");
        if (fichiers.Length > 0)
        {
            _fileCount = fichiers.Length;
            _numFile = _fileCount + 1;

        }
        else
        {
            _numFile = 1;
        }

        _rootPathToSave = GenerateFileName();
    }

    private string GenerateFileName()
    {
        _fileNumber = _numFile.ToString("D2");
        _fileName = $"{_prefix}{_fileNumber}{_extension}";
        return Path.Combine(_PathCreatedFolder, _fileName);

    }

    public void SaveDocument(GameDebriefing saveFile)
    {
        if (saveFile == null)
        {
            return;
        }

        string json = JsonUtility.ToJson(saveFile, true);

        if (File.Exists(_rootPathToSave))
        {
            _numFile++;
            _rootPathToSave = GenerateFileName();
        }

        File.WriteAllText(_rootPathToSave, json);

        _numFile++; // prêt pour la prochaine sauvegarde
        _rootPathToSave = GenerateFileName();
    }

    private void LoadAllFiles()
    {
        //_gameDebriefings.Clear();

        string[] fichiersJson = Directory.GetFiles(_PathCreatedFolder, "*.json");

        if (fichiersJson.Length > 0)
        {
            foreach (string fichier in fichiersJson)
            {
                string contenu = File.ReadAllText(fichier);
                GameDebriefing data = JsonUtility.FromJson<GameDebriefing>(contenu);

                if (data != null)
                {
                    //_gameDebriefings.Add(data);
                }
            }
        }
    }

    //public List<GameDebriefing> GetAllDebriefings()
    //{
    //    LoadAllFiles();

    //    return _gameDebriefings;
    //}
}
