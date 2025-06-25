using System;
using System.Collections.Generic; // Assuming you are using TextMeshPro for UI text display
using System.IO;
using UnityEngine;

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
    private List<GameDebriefing> _gameDebriefings = new(); // List to hold game debriefings
    private List<GameDebriefing> _gameDebriefings = new(); // List to hold game debriefings

    private string _currentDate;
    private string _folderName;
    private string _fileName;
    private string _fileNumber;

    private string _currentDate;
    private string _folderName;
    private string _fileName;
    private string _fileNumber;

    private int _numFile = 1;
    private int _fileCount = 0;

    private List<GameDebriefing> _gameDebriefings;
    private int _numFile; // Counter for file versions
    private string _rootPathSearch;
    private string _rootPathToSave;
    private string _PathCreatedFolder;

    private int _numFile = 1;
    private int _fileCount = 0;

    private List<GameDebriefing> _gameDebriefings;
    private string _rootPathSearch;
    private string _rootPathToSave;
    private string _PathCreatedFolder;

    private string _currentDate;
    private string _folderName;
    private string _fileName;
    private string _fileNumber;

    private int _numFile = 1;
    private int _fileCount = 0;

    private List<GameDebriefing> _gameDebriefings;
    private int _numFile; // Counter for file versions
    private string _rootPathSearch;
    private string _rootPathToSave;
    private string _PathCreatedFolder;

    private int _numFile = 1;
    private int _fileCount = 0;

    private List<GameDebriefing> _gameDebriefings;

    public void InitBased()
    {
        _gameDebriefings = new List<GameDebriefing>();

        _currentDate = DateTime.Now.ToString("yyyy-MM-dd");
        _folderName = _currentDate.Replace("-", "_");
        _rootPathSearch = Application.persistentDataPath;
        _PathCreatedFolder = Path.Combine(_rootPathSearch, _folderName);

        if (!Directory.Exists(_PathCreatedFolder))
        _filePath = Application.persistentDataPath;

        _numFile = 1; // Initialize file number to 1
        _numberFile = _numFile.ToString("D2");
        _fileFullName = $"{_fileName}{_numberFile}{_fileExtetion}"; // Combine file name and number
        _fullFilePath = Path.Combine(_filePath, _folderName);
    
        CreatedFolder(); // Ensure the folder exists or create it

        _fullFileDocument = Path.Combine(_fullFilePath, _fileFullName); // Set the full file path for saving

    }

    public void CreatedFolder()
    {
        if (!ResearchToFolder()) // Check if the directory exists
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

    private void NumberFile(int numberFiles)
    {
        if (_gameDebriefings != null)
           {
            if (_gameDebriefings.Count > 0 && numberFiles <= _gameDebriefings.Count)
                _numFile = _gameDebriefings.Count + 1;
        {
            Directory.CreateDirectory(_PathCreatedFolder);
        }

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

    private void NumberFile(int numberFiles)
    {
        if (_gameDebriefings != null)
           {
            if (_gameDebriefings.Count > 0 && numberFiles <= _gameDebriefings.Count)
                _numFile = _gameDebriefings.Count + 1;
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
            message = "Aucun fichier trouv�."; // Set the message if no file is found
            return new List<GameDebriefing>(); // Return an empty list on error
        }

        message = "Fichier(s) trouv�(s) : " + fichiersJson.Length;
        GameDebriefing saveFile = new();
            return;
        }

        _rootPathToSave = GenerateFileName();

        string json = JsonUtility.ToJson(saveFile, true);

        File.WriteAllText(_rootPathToSave, json);

        _numFile++; // pr�t pour la prochaine sauvegarde
    }

    private void LoadAllFiles()
    {
        _gameDebriefings.Clear();

        string[] fichiersJson = Directory.GetFiles(_PathCreatedFolder, "*.json");

        if (fichiersJson.Length > 0)
        {
            foreach (string fichier in fichiersJson)
            {
                string contenu = File.ReadAllText(fichier);
                GameDebriefing data = JsonUtility.FromJson<GameDebriefing>(contenu);

                if (data != null)
                {
                    _gameDebriefings.Add(data);
                }
            }
        }
    }

    public void SaveDocument(GameDebriefing saveFile)
    {
        if (saveFile == null)
        {
            message = "Aucun fichier trouv�."; // Set the message if no file is found
            return new List<GameDebriefing>(); // Return an empty list on error
        }

        message = "Fichier(s) trouv�(s) : " + fichiersJson.Length;
        GameDebriefing saveFile = new();
            return;
        }

        _rootPathToSave = GenerateFileName();

        string json = JsonUtility.ToJson(saveFile, true);

        File.WriteAllText(_rootPathToSave, json);

        _numFile++; // pr�t pour la prochaine sauvegarde
    private void NumberFile(int numberFiles)
    {
        if (_gameDebriefings != null)
           {
            if (_gameDebriefings.Count > 0 && numberFiles <= _gameDebriefings.Count)
                _numFile = _gameDebriefings.Count + 1;
    private string GenerateFileName()
        }
        else
        {
            _numFile = 1;
        }
        
        _rootPathToSave = GenerateFileName();
    }

    {
        _fileNumber = _numFile.ToString("D2");
        _fileName = $"{_prefix}{_fileNumber}{_extension}";
        return Path.Combine(_PathCreatedFolder, _fileName);

    }

    public void SaveDocument(GameDebriefing saveFile)
    {
        if (saveFile == null)
        {
            message = "Aucun fichier trouv�."; // Set the message if no file is found
            return new List<GameDebriefing>(); // Return an empty list on error
        }

        message = "Fichier(s) trouv�(s) : " + fichiersJson.Length;
        GameDebriefing saveFile = new();
            return;
        }

        _rootPathToSave = GenerateFileName();

        string json = JsonUtility.ToJson(saveFile, true);

        File.WriteAllText(_rootPathToSave, json);

        _numFile++; // pr�t pour la prochaine sauvegarde
    }

    private void LoadAllFiles()
    {
        _gameDebriefings.Clear();

        string[] fichiersJson = Directory.GetFiles(_PathCreatedFolder, "*.json");

        if (fichiersJson.Length > 0)
        {
            foreach (string fichier in fichiersJson)
            {
                string contenu = File.ReadAllText(fichier);
                GameDebriefing data = JsonUtility.FromJson<GameDebriefing>(contenu);

                if (data != null)
                {
                    _gameDebriefings.Add(data);
                }
            }
        // Method to save the game debriefing to file
        string json = JsonUtility.ToJson(saveFile, true); // Convert the game debriefing to JSON format
    public List<GameDebriefing> GetAllDebriefings()
    {
        LoadAllFiles();

        return _gameDebriefings;
    }

    private void LoadAllFiles()
    {
        _gameDebriefings.Clear();

        string[] fichiersJson = Directory.GetFiles(_PathCreatedFolder, "*.json");

        if (fichiersJson.Length > 0)
        {
            foreach (string fichier in fichiersJson)
            {
                string contenu = File.ReadAllText(fichier);
                GameDebriefing data = JsonUtility.FromJson<GameDebriefing>(contenu);

                if (data != null)
                {
                    _gameDebriefings.Add(data);
                }
            }
        }
    }

    public void SaveDocument(GameDebriefing saveFile)
    {
        if (saveFile == null)
        {
            return;
        }

        _rootPathToSave = GenerateFileName();

        string json = JsonUtility.ToJson(saveFile, true);

        File.WriteAllText(_rootPathToSave, json);

        _numFile++; // pr�t pour la prochaine sauvegarde
    }

    private void LoadAllFiles()
    {
        _gameDebriefings.Clear();

        string[] fichiersJson = Directory.GetFiles(_PathCreatedFolder, "*.json");

        if (fichiersJson.Length > 0)
        {
            foreach (string fichier in fichiersJson)
            {
                string contenu = File.ReadAllText(fichier);
                GameDebriefing data = JsonUtility.FromJson<GameDebriefing>(contenu);

                if (data != null)
                {
                    _gameDebriefings.Add(data);
                }
            }
        // Method to save the game debriefing to file
        string json = JsonUtility.ToJson(saveFile, true); // Convert the game debriefing to JSON format
    public List<GameDebriefing> GetAllDebriefings()
    public List<GameDebriefing> GetAllDebriefings()
    {
        LoadAllFiles();

        return _gameDebriefings;
    public bool ResearchToFolder()
    {
        return Directory.Exists(_fullFilePath); // Check if the directory exists
    }

    public bool ResearchToFile(string fullFileToSave)
    {
        LoadAllFiles();

        return _gameDebriefings;
    }

    public List<GameDebriefing> GetAllDebriefings()
    {
        LoadAllFiles();

        return _gameDebriefings;
    public bool ResearchToFolder()
    {
        return Directory.Exists(_fullFilePath); // Check if the directory exists
    }
    
}
