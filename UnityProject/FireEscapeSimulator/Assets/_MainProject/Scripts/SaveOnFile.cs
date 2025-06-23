using System.Collections.Generic; // Assuming you are using TextMeshPro for UI text display
using System.IO;
using UnityEngine;

public class SaveOnFile : MonoBehaviour
{
    private List<GameDebriefing> _gameDebriefings = new(); // List to hold game debriefings

    private string _filePath; // Path to the file where data will be saved
    private string _numberFile; // Number of the file for versioning
    private static string _folderName = "yyyy_mm_dd"; // Folder name for saving files
    private static string _fileName = "Player_"; // Base file name
    private string _fileExtetion = ".json"; // File extension for saved files

    private string _fileFullName; // Full file name with extension
    private string _fullFilePath; // Full path to the directory where the file will be saved
    private string _fullFileDocument; // Full path to the file including the name and extension

    private int _numFile; // Counter for file versions

    public void InitBased()
    {
        string currentDate = System.DateTime.Now.ToString("yyyy-MM-dd");

        _folderName = currentDate; // Format the date as yyyy_mm_dd

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
            Directory.CreateDirectory(_fullFilePath); // Create the directory if it doesn't exist
        }
    }

    private void NumberFile(int numberFiles)
    {
        if (_gameDebriefings != null)
           {
            if (_gameDebriefings.Count > 0 && numberFiles <= _gameDebriefings.Count)
                _numFile = _gameDebriefings.Count + 1;
        }
        else
            _numFile = numberFiles++;
    }

    private void ChangedName(int numberFiles)
    {
        NumberFile(numberFiles);

        _numberFile = _numFile.ToString("D2"); // Format number with leading zero
        _fileFullName = $"{_fileName}{_numberFile}{_fileExtetion}"; // Update file name with new number
        _fullFileDocument = Path.Combine(_fullFilePath, _fileFullName); // Update full file path with new file name

        if (ResearchToFile(_fullFileDocument)) // Check if the file already exists
        {
            ChangedName(_numFile); // Recursively change the name until a unique one is found
        }
    }

    public void OnSave(GameDebriefing gameDebriefing)
    {
        SaveInFile(gameDebriefing, _fullFileDocument); // Save the game debriefing to file
    }

    public List<GameDebriefing> ReadOnFile(out string message)
    {
        _gameDebriefings = ReadFile(out message); // Read game debriefings from file

        return _gameDebriefings; // Return the list of game debriefings
    }


    private List<GameDebriefing> ReadFile(out string message)
    {
        InitBased(); // Initialize the file paths and names 
        
        string[] fichiersJson = Directory.GetFiles(_fullFilePath, "*.json", SearchOption.AllDirectories);

        if (fichiersJson.Length == 0 || fichiersJson == null) // Check if any JSON files are found
        {
            message = "Aucun fichier trouvé."; // Set the message if no file is found
            return new List<GameDebriefing>(); // Return an empty list on error
        }

        message = "Fichier(s) trouvé(s) : " + fichiersJson.Length;
        GameDebriefing saveFile = new();

        foreach (string fichier in fichiersJson)
        {
            string contenu = File.ReadAllText(fichier);
            message += $"\n- {fichier}"; // Append the file name to the message
            saveFile = JsonUtility.FromJson<GameDebriefing>(contenu); // Deserialize the JSON to GameDebriefing object
        }

        return new List<GameDebriefing> { saveFile }; // Return a list containing the debriefing
    }

    private void SaveInFile(GameDebriefing saveFile, string file)
    {
        // Method to save the game debriefing to file
        string json = JsonUtility.ToJson(saveFile, true); // Convert the game debriefing to JSON format

        if (ResearchToFile(file)) // Check if the file already exists
        {
            ChangedName(_numFile); // Change the file name if it already exists
        }

        File.WriteAllText(file, json); // Write the JSON to the file
    }

    public bool ResearchToFile(string fullFileToSave)
    {
        return File.Exists(fullFileToSave);
    }

    public bool ResearchToFolder()
    {
        return Directory.Exists(_fullFilePath); // Check if the directory exists
    }
    
}
