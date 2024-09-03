﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtharsBot
{
    public class ServerThread
    {
        public Thread Thread { get; set; }
        public DataModules.ServerSetting server { get; set; }

    }
    public class StaticValues
    {
        public static List<ServerThread> RunningServers = new List<ServerThread>();
       public static List<string> athkar = new List<string>
        {
            "سبحان الله",
            "الحمد لله",
            "لا إله إلا الله",
            "الله أكبر",
            "لا حول ولا قوة إلا بالله",
            "أستغفر الله",
            "اللهم صلِّ على محمد",
            "سبحان الله وبحمده",
            "سبحان الله العظيم",
            "لا إله إلا أنت سبحانك إني كنت من الظالمين",
            "اللهم لك الحمد كما ينبغي لجلال وجهك وعظيم سلطانك",
            "اللهم اغفر لي",
            "اللهم ارزقني الجنة",
            "اللهم أعذني من النار",
            "حسبي الله لا إله إلا هو عليه توكلت وهو رب العرش العظيم",
            "رب اغفر لي ولوالدي",
            "اللهم إني أسألك العفو والعافية",
            "اللهم إني أسألك علماً نافعاً",
            "اللهم إني أعوذ بك من الهم والحزن",
            "اللهم إني أعوذ بك من العجز والكسل",
            "اللهم إني أعوذ بك من الجبن والبخل",
            "اللهم إني أعوذ بك من غلبة الدين وقهر الرجال",
            "ربنا آتنا في الدنيا حسنة وفي الآخرة حسنة وقنا عذاب النار",
            "اللهم إني أسألك الهدى والتقى والعفاف والغنى",
            "اللهم أصلح لي ديني الذي هو عصمة أمري",
            "اللهم أصلح لي دنياي التي فيها معاشي",
            "اللهم أصلح لي آخرتي التي فيها معادي",
            "اللهم اجعل الحياة زيادة لي في كل خير",
            "اللهم اجعل الموت راحة لي من كل شر",
            "اللهم أعني على ذكرك وشكرك وحسن عبادتك",
            "اللهم ارحمني برحمتك التي وسعت كل شيء",
            "اللهم اشرح لي صدري ويسر لي أمري",
            "اللهم ارزقني حسن الخاتمة",
            "اللهم اجعلني من التوابين واجعلني من المتطهرين",
            "اللهم تقبل مني إنك أنت السميع العليم",
            "اللهم أعني على نفسي",
            "اللهم أعني على الشيطان",
            "اللهم اهدني واهدِ بي",
            "اللهم استر عوراتي وآمن روعاتي",
            "اللهم احفظني من بين يدي ومن خلفي",
            "اللهم احفظني من فوقي ومن تحتي",
            "اللهم اجعلني من عبادك الصالحين",
            "اللهم اجعلني من المتقين",
            "اللهم اجعلني من المحسنين",
            "اللهم اجعلني من الصابرين",
            "اللهم اجعلني من الذاكرين",
            "اللهم اجعلني من الشاكرين",
            "اللهم اجعلني من المؤمنين",
            "اللهم اجعلني من الصالحين",
            "اللهم اجعلني من المتقين",
            "اللهم اجعلني من المحسنين",
            "اللهم اجعلني من المتوكلين عليك",
            "اللهم اجعلني من الراجين لرحمتك",
            "اللهم اجعلني من الخاشعين",
            "اللهم اجعلني من الراجين لعفوك",
            "اللهم اجعلني من المخلصين",
            "اللهم اجعلني من المستغفرين",
            "اللهم اجعلني من المتفكرين في آياتك",
            "اللهم اجعلني من الواصلين لرحمك",
            "اللهم اجعلني من المتوكلين على رحمتك"
        };
    }
}
