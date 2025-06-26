using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Seb_TestSave : MonoBehaviour
{
    private const string _extension = ".json";
    private const string _prefix = "Player_";

    private string _rootPathSearch;
    private string _folderName;
    private string _fileName;
    private string _fileNumber;
    private string _PathCreatedFolder;
    private string _rootPathToSave;

    private int _numFile;
    private int _fileCount;
    private string _currentDate;

    private List<GameDebriefing> _gameDebriefings;

    public void InitBased()
    {
        _gameDebriefings = new List<GameDebriefing>(); // Initialize the list to hold game debriefings
        _currentDate = DateTime.Now.ToString("yyyy-MM-dd");
        _folderName = _currentDate.Replace("-", "_"); // Format the date as yyyy_mm_dd
        _rootPathSearch = Application.persistentDataPath;
        _fileNumber = "01"; // Start with file number 01
        _fileName = $"{_prefix}{_fileNumber}{_extension}";
        _PathCreatedFolder = $"{_rootPathSearch}/{_folderName}";
        CreateFolderIfNeeded();
        _rootPathToSave = $"{_PathCreatedFolder}/{_fileName}";
        if (File.Exists(_rootPathToSave))
        {
            ReadOnFolder();

            if(_gameDebriefings == null || _gameDebriefings.Count == 0)
            {
                _numFile = 2; // Reset to 1 if no files exist
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
        if(!Directory.Exists(_PathCreatedFolder))
            Directory.CreateDirectory(_PathCreatedFolder); // Create the directory if it doesn't exist
    }

    private string ChangedName()
    {
        _fileNumber = _numFile.ToString("D2"); // Format the file number with leading zeros
        _fileName = $"{_prefix}{_fileNumber}{_extension}"; // Create the new file name
        _rootPathToSave = $"{_PathCreatedFolder}/{_fileName}"; // Update the full file path
        _numFile++;
        return $"File name changed to: {_fileName}";
    }

    public void SaveDocument(GameDebriefing saveFile)
    {
        if(File.Exists(_rootPathToSave))
        {
            ChangedName(); // Change the file name if it doesn't exist
        }

        string json = JsonUtility.ToJson(saveFile, true); // Convert the GameDebriefing object to JSON
        
        File.WriteAllText(_rootPathToSave, json); // Write the JSON to the file
    }

    public List<GameDebriefing> ReadtoFile()
    {
        if(_PathCreatedFolder == null)
            InitBased();

        string[] fileJson = Directory.GetFiles(_PathCreatedFolder);

        if(fileJson.Length == 0 || fileJson == null)
            return new List<GameDebriefing>();

        foreach (var file in fileJson)
        {
            string contenu = File.ReadAllText(file);

            _gameDebriefings.Add(JsonUtility.FromJson<GameDebriefing>(contenu));
        }

        return _gameDebriefings;
    }

    private void ReadOnFolder()
    {
        string[] fileJson = Directory.GetFiles(_PathCreatedFolder);

        if (fileJson.Length == 0 || fileJson == null)
            _gameDebriefings = null;

        foreach (var file in fileJson)
        {
            string contenu = File.ReadAllText(file);

            _gameDebriefings.Add(JsonUtility.FromJson<GameDebriefing>(contenu));
        }
    }
}
