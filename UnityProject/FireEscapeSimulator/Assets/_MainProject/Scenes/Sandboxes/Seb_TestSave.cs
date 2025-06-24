using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Seb_TestSave : MonoBehaviour
{
    private string _rootPath;
    private string _folderName;
    private string _fileName;
    private string _fileNumber;
    private string _fileExtension = ".json";
    private string _fullFilePath;
    private string _rootFullPath;
    private string _saveDocument;

    private int _numFile;
    private int _fileCount;
    private int _saveCount;
    private string _currentDate;

    private List<GameDebriefing> _gameDebriefings;

    public void InitBased()
    {
        _gameDebriefings = new List<GameDebriefing>(); // Initialize the list to hold game debriefings
        _currentDate = DateTime.Now.ToString("yyyy-MM-dd");
        _folderName = _currentDate.Replace("-", "_"); // Format the date as yyyy_mm_dd
        _rootPath = Application.persistentDataPath;
        _fileName = "Player_";
        _fileNumber = "01"; // Start with file number 01
        _fullFilePath = $"{_rootPath}/{_folderName}";
        CreateFolderIfNeeded();
        _saveDocument = $"{_fileName}{_fileNumber}{_fileExtension}";
        _rootFullPath = $"{_fullFilePath}/{_saveDocument}";
        if (File.Exists(_rootFullPath))
        {
            ReadOnFolder();

            if(_gameDebriefings == null || _gameDebriefings.Count == 0)
            {
                _numFile = 1; // Reset to 1 if no files exist
            }
            else
            {
                _fileCount = _gameDebriefings.Count; // Count existing saves
                _numFile = _fileCount + 1; // Increment for the next save
            }
        }
        else
        {
            _numFile = 1; // Reset to 1 if no files exist
        }
    }

    private void CreateFolderIfNeeded()
    {
        if(!ResearchToFolder())
            Directory.CreateDirectory(_fullFilePath); // Create the directory if it doesn't exist
    }

    private string ChangedName()
    {
        _fileNumber = _numFile.ToString("D2"); // Format the file number with leading zeros
        _saveDocument = $"{_fileName}{_fileNumber}{_fileExtension}"; // Create the new file name
        _rootFullPath = $"{_rootPath}/{_folderName}/{_saveDocument}"; // Update the full file path
        return $"File name changed to: {_saveDocument}";
    }

    private bool ResearchToFolder()
    {
        return Directory.Exists(_fullFilePath); // Check if the directory exists
    }

    private bool ResearchToFile()
    {
        return File.Exists(_rootFullPath); // Check if the file exists
    }

    public void SaveDocument(GameDebriefing saveFile)
    {
        if(!ResearchToFile())
        {
            ChangedName(); // Change the file name if it doesn't exist
        }

        string json = JsonUtility.ToJson(saveFile, true); // Convert the GameDebriefing object to JSON
        
        File.WriteAllText(_rootFullPath, json); // Write the JSON to the file
    }

    public List<GameDebriefing> ReadtoFile()
    {
        if(_rootFullPath == null)
            InitBased();

        string[] fileJson = Directory.GetFiles(_fullFilePath);

        if(fileJson.Length == 0 || fileJson == null)
            return new List<GameDebriefing>();

        GameDebriefing readSaved = new GameDebriefing();

        foreach (var file in fileJson)
        {
            string contenu = File.ReadAllText(file);
            readSaved = JsonUtility.FromJson<GameDebriefing>(contenu);
            _gameDebriefings.Add(readSaved);
        }

        return _gameDebriefings;
    }

    private void ReadOnFolder()
    {
        string[] fileJson = Directory.GetFiles(_fullFilePath);

        if (fileJson.Length == 0 || fileJson == null)
            _gameDebriefings = null;

        GameDebriefing readSaved = new GameDebriefing();

        foreach (var file in fileJson)
        {
            string contenu = File.ReadAllText(file);
            readSaved = JsonUtility.FromJson<GameDebriefing>(contenu);
            _gameDebriefings.Add(readSaved);
        }
    }
}
