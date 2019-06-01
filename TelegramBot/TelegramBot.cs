using AIMLbot;
using Telegram.Bot;

namespace TelegramBot
{
    public class TelegramBot
    {
        private TelegramBotClient bot = new TelegramBotClient("899627781:AAHP8Wl8eEP_rZ_rLiz5RB3JQv-zyIWE7yY");

        public TelegramBot()
        {
            bot.OnMessage += BotOnMessage;
            bot.OnMessageEdited += BotOnMessage;
        }

        public void Open()
        {
            bot.StartReceiving();
        }

        public void Close()
        {
            bot.StopReceiving();
        }

        private void BotOnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                Bot AI = new Bot();
                AI.loadSettings(); //It will Load Settings from its Config Folder with this code
                AI.loadAIMLFromFiles(); //With this Code It Will Load AIML Files from its AIML Folder
                AI.isAcceptingUserInput = false; //With this Code it will Disable UserInput For Now
                User myuser = new User("Username Here", AI); //With This Code We Will Add The User Through AI/Bot
                AI.isAcceptingUserInput = true; //Now The User Input is Enabled Again with this Code
                Request r = new Request(e.Message.Text, myuser, AI); //With This Code it will Request The Response From AIML Folders
                Result res = AI.Chat(r); //With This Code It Will Get Result

                bot.SendTextMessageAsync(e.Message.Chat.Id, res.Output);
            }
        }
    }
}
