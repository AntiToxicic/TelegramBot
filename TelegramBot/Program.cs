
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

Thread task = new(BackgrundBot);
task.Start();

static void BackgrundBot()
{
    string token = File.ReadAllText(@"/Users/antitoxic/Pet_Projects/TelegramBot/token.txt");
        
    WebClient web = new() { Encoding = Encoding.UTF8 };

    int update_id = 0;
    string startUrl = $@"https://api.telegram.org/bot{token}/";

    while(true)
    {
        string url = $"{startUrl}getUpdates?offset={update_id}";
        var c = web.DownloadString(url);

         var msgs = JObject.Parse(c)["result"].ToArray();

        foreach(dynamic e in msgs)
        {
            update_id = Convert.ToInt32(e.update_id) + 1;

            string userMessage = e.message.text;
            string userId = e.message.from.id;
            string useFirstrName = e.message.from.first_name;

            string text = $"{useFirstrName} {userId} {userMessage}";

            if (userMessage == "hi")
            {
                string responseText = $"Вы написали, \"{userMessage}\"";
                url = $"{startUrl}sendMessage?chat_id={userId}&text={responseText}";
                web.DownloadString(url);
            }
        }

        Thread.Sleep(10);
    }
}