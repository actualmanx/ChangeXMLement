class Program
{
    static void Main()
    {
        // Get the path to the user's Documents folder (OneDrive or local)
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Combine with the relative path to the XML file
        string xmlFilePath = Path.Combine(documentsPath, "My Games", "FarmingSimulator2025", "gameSettings.xml");

        // Check if the file exists
        if (!File.Exists(xmlFilePath))
        {
            Console.WriteLine("gameSettings.xml not found at expected location.");
            return;
        }

        // Load the XML document
        XmlDocument doc = new XmlDocument();
        try
        {
            doc.Load(xmlFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading XML file: {ex.Message}");
            return;
        }

        // Find the <onlinePresenceName> element
        XmlNode? node = doc.SelectSingleNode("//onlinePresenceName");

        if (node != null)
        {
            string newValue = "Dilligaf";
            if (node.InnerText != newValue)
            {
                node.InnerText = newValue;
                Console.WriteLine("Value updated.");

                try
                {
                    doc.Save(xmlFilePath);
                    Console.WriteLine("Property changed successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving XML file: {ex.Message}");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Value already set. No update needed.");
            }
        }
        else
        {
            Console.WriteLine("<onlinePresenceName> element not found.");
            return;
        }

        // Steam game ID
        string gameId = "2300320"; // Farming Simulator 2025

        // Open the Steam game URL
        string steamUrl = "steam://run/" + gameId;
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = steamUrl,
                UseShellExecute = true
            });
            Console.WriteLine("Steam game URL opened successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to launch Steam game: {ex.Message}");
        }
        for (int i = 5; i > 0; i--)
        {
            Console.Write($"\rExiting in {i} second{(i == 1 ? "" : "s")}…");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

