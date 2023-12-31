using System.Data;
using OneOf;

namespace DmgScy;

public static class Run{
    
    public static void Main(){       
        Init.RequiredFiles(); 
        if(DataCleaner.ShouldRefresh()){
            DataCleaner.ClearTempData();
        }
        Server server = new Server(Constants.InternalUrls.indexUrls[0]);
        server.listener.Start();
        Console.WriteLine("Listening for connections on {0}", Constants.InternalUrls.indexUrls[0]);
        server.HandleIncomingConnections().GetAwaiter().GetResult();
        server.listener.Close();
    }
}