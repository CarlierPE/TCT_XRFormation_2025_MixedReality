using System;
using System.Collections.Generic; // Assuming you are using TextMeshPro for UI text display
using System.IO;
using System.Web;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem; // Assuming the SaveOnFile class is in this namespace

public class SaveOnFile : MonoBehaviour
{
    private bool _isStarted = true; // Flag to check if the test has started
    private bool _isReaded = false; // Flag to check if the data has been read
    private bool _isSaved = false; // Flag to check if the data has been saved

    private List<GameDebriefing> _gameDebriefings = new List<GameDebriefing>(); // List to hold game debriefings

    private string _filePath; // Path to the file where data will be saved
    private string _nameFile; // Name of the file without path and extension
    private string _numberFile; // Number of the file for versioning
    private static string _folderName = "yyyy_mm_dd"; // Folder name for saving files
    private static string _fileName = "Player_"; // Base file name
    private string _fileExtetion = ".json"; // File extension for saved files

    private string _fileFullName; // Full file name with extension
    private string _fullFilePath; // Full path to the directory where the file will be saved
    private string _fullFileDocument; // Full path to the file including the name and extension

    private int _numFile = 1; // Counter for file versions


    private void Awake()
    {
        string currentDate = System.DateTime.Now.ToString("yyyy-MM-dd");

        _folderName = currentDate; // Format the date as yyyy_mm_dd

        _filePath = Application.persistentDataPath;

        _fileFullName = $""; // Combine file name and number
        _nameFile = _fileFullName; // Set the name of the file
        _fullFilePath = Path.Combine(_filePath, _folderName);

        CreatedFolder(); // Ensure the folder exists or create it

        _fullFileDocument = Path.Combine(_fullFilePath, _fileFullName); // Set the full file path for saving

        _isReaded = false;
        _isSaved = false;

}

    public void CreatedFolder()
    {
        if (!ResearchToFolder(_fullFilePath)) // Check if the directory exists
        {
            Directory.CreateDirectory(_fullFilePath); // Create the directory if it doesn't exist
        }
    }

    private void ChangedName()
    {
        // This method is called before the transform parent changes, useful for cleanup or state management
        _numFile++;
        _numberFile = _numFile.ToString("D2"); // Format number with leading zero
        _fileFullName = $"{_fileName}{_numberFile}{_fileExtetion}"; // Update file name with new number
        _fullFileDocument = Path.Combine(_fullFilePath, _fileFullName); // Update full file path with new file name
    }

    public void OnSave()
    {
        if (_isStarted && !_isSaved)
        {
            GameDebriefing gameDebriefing = TestGame(); // Create a test game debriefing
            SaveInFile(gameDebriefing, _fullFileDocument); // Save the game debriefing to file
            _isSaved = true; // Set saved flag to true
        }
    }

    private void OnPressSecondaryKey()
    {
        if (_isStarted && !_isReaded)
        {
            _gameDebriefings = ReadFile(); // Read game debriefings from file
            _isReaded = true; // Set read flag to true
        }
    }

    private GameDebriefing TestGame()
    {
        GameDebriefing gameDebriefing = new GameDebriefing
        {
            startGame = UnityEngine.Random.Range(100f, 900f), // Random start game time
            scoreEnd = UnityEngine.Random.Range(100, 2000), // Random end score
            scoreLogs = new List<ScoreLog>() // Initialize score logs list
        };
        
        for (int i = 0; i < 5; i++)
        {
            gameDebriefing.scoreLogs.Add(new ScoreLog
            {
                scoreValid = UnityEngine.Random.Range(10, 100), // Random valid score
                action = eMonitoredAction.WalkIntoFire, // Example action
                timeAction = UnityEngine.Random.Range(10, 100) // Random action time
            });
        }
        
        return gameDebriefing; // Return the created game debriefing
    }

    private List<GameDebriefing> ReadFile()
    {
        if (!File.Exists(_fullFileDocument)) // Check if the file exists
        {
            return new List<GameDebriefing>(); // Return an empty list if file does not exist
        }
        try
        {
            string json = File.ReadAllText(_fullFileDocument); // Read the JSON content from the file
            GameDebriefing saveFile = JsonUtility.FromJson<GameDebriefing>(json); // Deserialize the JSON to GameDebriefing object
            return new List<GameDebriefing> { saveFile }; // Return a list containing the debriefing
        }
        catch (Exception)
        {
            return new List<GameDebriefing>(); // Return an empty list on error
        }
    }

    private void SaveInFile(GameDebriefing saveFile, string file)
    {
        // Method to save the game debriefing to file
        string json = JsonUtility.ToJson(saveFile, true); // Convert the game debriefing to JSON format
        try
        {
            if (ResearchToFile(file)) // Check if the file already exists
            {
                ChangedName(); // Change the file name if it already exists
            }
            File.WriteAllText(_fullFileDocument, json); // Write the JSON to the file
        }
        catch (Exception)
        {
            
        }
    }

    public bool ResearchToFile(string fullFileToSave)
    {
        return File.Exists(fullFileToSave);
    }

    public bool ResearchToFolder(string fullFilePath)
    {
        return Directory.Exists(fullFilePath); // Check if the directory exists
    }

    public bool ResearchToFolder()
    {
        return Directory.Exists(_fullFilePath); // Check if the directory exists
    }
}
