using System.Diagnostics;
using System.Xml;
using System.IO;

// Get the path to the user's folder
string userFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

// Combine the user's folder path with the relative path to the XML file
string xmlFilePath = Path.Combine(userFolderPath, "OneDrive", "Documents", "My Games", "FarmingSimulator2025", "gameSettings.xml");

// Load the XML document
XmlDocument doc = new XmlDocument();
doc.Load(xmlFilePath);

// Find the <onlinePresenceName> element
XmlNode? node = doc.SelectSingleNode("//onlinePresenceName");

// Check if the node is found and change its value
if (node != null)
{
    node.InnerText = "Dilligaf"; // Change NEW_VALUE to the desired value
}
else
{
    Console.WriteLine("<onlinePresenceName> element not found.");
    return;
}

// Save the modified XML back to the file
doc.Save(xmlFilePath);

Console.WriteLine("Property changed successfully.");

// Steam game ID
string gameId = "2300320"; // Replace with your actual Steam game ID

// Open the Steam game URL
string steamUrl = "steam://run/" + gameId;
Process.Start(new ProcessStartInfo
{
    FileName = steamUrl,
    UseShellExecute = true
});

Console.WriteLine("Steam game URL opened successfully.");