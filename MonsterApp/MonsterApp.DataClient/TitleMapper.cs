using MonsterApp.DataAccess.Models;
using MonsterApp.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterApp.DataClient
{
    public class TitleMapper
    {
        public static TitleDAO MapToTitleDAO(Title title)
        {
            return new TitleDAO { Id = title.TitleId, Name = title.TitleName };
        }
    }
}