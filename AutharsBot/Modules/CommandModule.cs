using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using AtharsBot.DataModules;
using System.Text;

namespace AtharsBot.Modules
{
    public class CommandModule : InteractionModuleBase<SocketInteractionContext>
    {
        Database db = new Database();
        public CommandModule()
        {
            
        }
        [SlashCommand("attach", "Attach a file")]
        public async Task AttachCommand(Attachment f)//upload file
        {         
        }
        [SlashCommand("showall", "show all authrs")]
        public async Task ShowAll()
        {

            // بناء جدول في شكل نص
            
            var table = new StringBuilder();
            table.AppendLine("ID  |  Name");
            table.AppendLine("------------");
            foreach ( var item in db.AtherTable)
            {

                table.AppendLine($"{item.ID}  |  {item.Mtn}");
                if(table.Length > 1900 )
                {
                    var embed = new EmbedBuilder()
              .WithTitle("📊 جدول البيانات")
              .WithDescription($"```{table.ToString()}```")
              .WithColor(new Color(0, 123, 255))  // اللون الأزرق
               .WithFooter(footer =>
               {
                   footer.Text = $"{db.AtherTable.Count()}  عدد الاثار ";
                   footer.WithIconUrl("https://media.discordapp.net/attachments/1274838790875386029/1274845615062520003/IMG_7818.jpg?ex=66c3bc00&is=66c26a80&hm=5a4d324f7082c8c0f477da9c2c391400ea46e15cf4a4b79a3338263ee96846c6&=&format=webp&width=717&height=676"); // إذا كنت تريد إضافة أيقونة للمصدر
               })
              .WithTimestamp(System.DateTimeOffset.Now)
              .Build();
                    await Context.Channel.SendMessageAsync(embed:embed);
                    table.Clear();
                }
            }


            var embede = new EmbedBuilder()
                .WithTitle("📊 جدول البيانات")
                .WithDescription($"```{table.ToString()}```")
                .WithColor(new Color(0, 123, 255))  // اللون الأزرق
                 .WithFooter(footer =>
                 {
                     footer.Text = $"{db.AtherTable.Count()}  عدد الاثار ";
                     footer.WithIconUrl("https://media.discordapp.net/attachments/1274838790875386029/1274845615062520003/IMG_7818.jpg?ex=66c3bc00&is=66c26a80&hm=5a4d324f7082c8c0f477da9c2c391400ea46e15cf4a4b79a3338263ee96846c6&=&format=webp&width=717&height=676"); // إذا كنت تريد إضافة أيقونة للمصدر
                 })
                .WithTimestamp(System.DateTimeOffset.Now)
                .Build();

            await Context.Channel.SendMessageAsync(embed: embede);

        }
        [SlashCommand("showsetting", "عرض اعدادات السيرفر")]
        public async Task ShowSetting()
        {
            Console.WriteLine(StaticValues.RunningServers.Count);
        //start:
        //    var Server = db.ServersTable.SingleOrDefault(x => x.ServerID == Context.Guild.Id);
        //    if (Server is null)
        //    {
        //        db.ServersTable.Add(new ServerSetting() { ServerID = Context.Guild.Id, Time = 1 });
        //        db.SaveChanges();

        //        goto start;
        //    }
        //    await Context.Channel.SendMessageAsync(Server.ChannleID.ToString());

        }
        
        [SlashCommand("chat", "chat")]
        public async Task Chat(string text,SocketTextChannel ch = null)
        {
            await RespondAsync("لا تحاول", ephemeral: true);

            if (Context.User.Id != 519943222668296222)
            {
                await RespondAsync("لا تحاول",ephemeral: true);
            }

            if(ch ==null)
            {
                await Context.Channel.SendMessageAsync(text);
            }
            else
            {
                await Context.Guild.GetTextChannel(ch.Id).SendMessageAsync(text);
            }
        
        }
        
        [SlashCommand("setting", "تجهيز اعدادات السيرفر")]
        public async Task Setting(SocketTextChannel channleID=null , int timehours = 0)
        {
            if(Context.User != Context.Guild.Owner)
            {
            
                        await RespondAsync("غير مصرح لك باٍستخدام هذا الكوماند", ephemeral: true);
                        return;
                
            }
            start:
            var Server = db.ServersTable.SingleOrDefault(x => x.ServerID == Context.Guild.Id);
            if(Server is null)
            {
                db.ServersTable.Add(new ServerSetting() {ServerID = Context.Guild.Id ,Time=1});
                db.SaveChanges();
                staticfunc x = new staticfunc(Context.Client);
                Thread StartSAther = new Thread(new ThreadStart(x.StartS));
                StartSAther.Start();


                goto start;
            }
            if(channleID ==null && timehours ==0) {
                await RespondAsync("لم تضع اي بارمتر ",ephemeral:true);
            
            }
            else if(channleID !=null && timehours !=0)
            {
                if( Context.Guild.GetTextChannel(channleID.Id)!=null)
                {
                    Server.ChannleID = channleID.Id;
                    Server.Time = timehours;
                    db.SaveChanges();
                    staticfunc x = new staticfunc(Context.Client);
                    Thread StartSAther = new Thread(new ThreadStart(x.StartS));
                    StartSAther.Start();

                    await RespondAsync("تم تعديل الروم وتوقيت ارسال الرسائل", ephemeral: true);

                }
                else
                {
                    await RespondAsync("هذه الروم غير موجودة",ephemeral:true);
                }
            }else if(channleID != null)
            {
                if (Context.Guild.GetChannel(channleID.Id) != null)
                {
                    Server.ChannleID = channleID.Id;
                    db.SaveChanges();
                    staticfunc x = new staticfunc(Context.Client);
                    Thread StartSAther = new Thread(new ThreadStart(x.StartS));
                    StartSAther.Start();

                    await RespondAsync("تم تعديل الروم", ephemeral: true);
                }
                else
                {
                    await RespondAsync("هذه الروم غير موجودة", ephemeral: true);
                }
            }
            else
            {
                Server.Time = timehours;
                db.SaveChanges();
                staticfunc x = new staticfunc(Context.Client);
                Thread StartSAther = new Thread(new ThreadStart(x.StartS));
                StartSAther.Start();

                await RespondAsync("تم تعديل وقت ارسال الاثار", ephemeral: true);
            }


        }
        [SlashCommand("removeauther", "remoev")]
        public async Task RemoveAuther(int id)
        {
            var x= db.AtherTable.SingleOrDefault(x => x.ID == id);
          if(x != null)
            {
                db.AtherTable.Remove(x);
                db.SaveChanges();
                await RespondAsync($"{id}تم حذف الاثر صاحب الرقم التعريفي ");
            }
            else
            {
                await RespondAsync("الاثر غير موجود");
            }
        }
        [SlashCommand("showauther", "عرض اثر معين")]
        public async Task ShowAuther(int id=0, string mtn = null)
        {
            Console.WriteLine(id);
            if (id == 0 && mtn == null)
            {
                await RespondAsync("لم تضع اي بارمتر", ephemeral: true);
                return;
            }else if(id!=0)
            {
                var x = db.AtherTable.SingleOrDefault(x => x.ID == id);
                if(x != null)
                {
                    await RespondAsync(embed: staticfunc.GetEmbed(isnad: x.Isnad, x.Mtn, x.Sorce));
                }
                else
                {
                    await RespondAsync("الاثر غير موجود",ephemeral:true);
                }
                return;

            }else
            {
                var x = db.AtherTable.SingleOrDefault(x => x.Mtn == mtn);
                if(x != null)
                {
                    await RespondAsync(embed: staticfunc.GetEmbed(isnad: x.Isnad, x.Mtn, x.Sorce));

                }
                else
                {
                    await RespondAsync("الاثر غير موجود", ephemeral: true);

                }
                return;
            }

        }


        //    [SlashCommand("removerall", "remoev")]
        //public async Task RemoveAllAuthrs()
        //{
        //    foreach(var i in db.AtherTable)
        //    {
        //        Console.WriteLine(i.ID);
        //    }
        //    if(Context.User.Id == 519943222668296222)
        //    {
        //        foreach (var item in db.AtherTable)
        //        {
        //            db.AtherTable.Remove(item);
        //        }
        //        db.SaveChanges();
        //        await RespondAsync("تم حذف جميع الاثار");

        //    }
        //    else
        //    {
        //        await RespondAsync("غير مصرح لك باٍستخدام هذا  الامر");
        //    }

        //}
        [SlashCommand("add","add auther")]
        public async Task GetF(string isnad ,string mtn , string sorce)
        {
            if(db.AtherTable.SingleOrDefault(x=>x.Mtn == mtn) == null)
            {
                db.AtherTable.Add(new AthrModel() { Isnad = isnad, Mtn = mtn, Sorce = sorce });
                db.SaveChanges();
                var z = staticfunc.GetEmbed(isnad, mtn, sorce);
                await RespondAsync($"تم اضافة الاثر لقاعدة البيانات\n *** وهذا الاثر رقم {db.AtherTable.Count()}*** " ,embed:z);

            }
            else
            {
                await RespondAsync("هذا الاثر تم اضافته سابقا قد يكون باٍسناد مختلف");
            }
        }
      
           

        

    }
   
}
