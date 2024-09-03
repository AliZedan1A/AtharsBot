using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace AtharsBot
{
    public class staticfunc
    {
        private readonly DiscordSocketClient _client;

        public staticfunc(DiscordSocketClient client)
        {
            _client = client;
        }

        public void StartS()
        {
            DataModules.Database db = new DataModules.Database();
            Console.WriteLine(db.ServersTable.Count());
            Thread.Sleep(5000);
            foreach (var item in db.ServersTable)
            {
                Console.WriteLine(item.ChannleID);
                 var Server= StaticValues.RunningServers.SingleOrDefault(x=>x.server.ServerID == item.ServerID);
                if(Server == null)
                {

                }else if(Server.server == item)
                {
                    goto D;
                }else if(Server.server !=item)
                {
                   // StaticValues.RunningServers.SingleOrDefault(x=>x.server.ID== Server.server.ID).Thread.Abort();
                    StaticValues.RunningServers.Remove(Server);

                }
                Thread Xthread = new Thread(() =>
                {
                    DataModules.Database db = new DataModules.Database();
                    var server = _client.Guilds.SingleOrDefault(x => x.Id == item.ServerID);
                    if (server == null)
                    {
                        return;
                    }
                    else
                    {
                        var Channel = server.GetTextChannel(item.ChannleID);
                        if (Channel == null)
                        {
                            return;
                        }
                        else
                        {

                            while (true)
                            {
                                if(StaticValues.RunningServers.SingleOrDefault(x=>x.server == item) !=null)
                                {
                                    Thread.Sleep(TimeSpan.FromHours(item.Time));
                                    Random random = new Random();
                                    int randomIndex = random.Next(db.AtherTable.Count());
                                    DataModules.AthrModel randomThikr = db.AtherTable.ToList()[randomIndex];
                                    Channel.SendMessageAsync(embed: staticfunc.GetEmbed(randomThikr.Isnad, randomThikr.Mtn, randomThikr.Sorce));
                                }
                                else
                                {
                                    break;

                                }
                              
                            }
                        }
                    }
                });

                // تشغيل الثريد
                Xthread.Start();

                StaticValues.RunningServers.Add(new ServerThread() { server = item, Thread = Xthread });

            D:;
            }
        }
        public static Embed GetEmbed(string isnad , string mtn , string sorce )
        {
            var embed = new EmbedBuilder()
          .WithTitle("🔹 أثر للسلف 🔹")
          .WithThumbnailUrl("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQw5tq0p_4E-GXPzQab1ozWWJoFWu2-fg_6pQ&s") // رابط صورة الأيقونة
          .WithDescription("📜 **الإسناد:**\n"
              + $"> *{isnad}*\n\n"
              + @$"""**{mtn}**""")
          .WithFooter(footer =>
          {
              footer.Text = $"📚 {sorce}";
              footer.WithIconUrl("https://media.discordapp.net/attachments/1274838790875386029/1274845615062520003/IMG_7818.jpg?ex=66c3bc00&is=66c26a80&hm=5a4d324f7082c8c0f477da9c2c391400ea46e15cf4a4b79a3338263ee96846c6&=&format=webp&width=717&height=676"); // إذا كنت تريد إضافة أيقونة للمصدر
          })
          .WithColor(new Color(47, 79, 79))  // Dark Slate Gray
          .WithTimestamp(System.DateTimeOffset.Now)
          .Build();

            return embed;
        }
        

    }
}
