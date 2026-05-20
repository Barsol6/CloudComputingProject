using Microsoft.AspNetCore.Identity;

namespace CloudComputingProject.Modules;

public class LogService
{
    public string Author { get; set; } = "Bartosz Solyga";
    public DateTime Date { get; set; } = DateTime.UtcNow; 
    private static string? Port { get; set; } = Environment.GetEnvironmentVariable("ASPNETCORE_URLS");
    public List<string> PortList = GetPort(Port);

    private static List<string> GetPort(string? ports)
    {
        var portList = new List<string>();

        if (string.IsNullOrEmpty(ports))
        {
            return portList;
        }

        var adresses = ports.Split(";", StringSplitOptions.RemoveEmptyEntries);

        foreach (var adress in adresses)
        {
            var normalAdress = adress.Replace("+", "localhost").Replace("*", "localhost");

            if (Uri.TryCreate(normalAdress, UriKind.Absolute, out var uri))
            {
                portList.Add(uri.Port.ToString());
            }
        }
        
        return portList;
    }
  
}