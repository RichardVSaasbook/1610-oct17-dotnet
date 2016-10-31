using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MonsterApp.DataClient.Models;
using MonsterApp.DataAccess;

namespace MonsterApp.DataClient
{
    public class MonsterService : IMonsterService
    {
        private AdoData data = new AdoData();

        public List<GenderDAO> GetGenders()
        {
            List<GenderDAO> genderDAOs = new List<GenderDAO>();

            foreach (DataAccess.Models.Gender gender in data.GetGenders())
            {
                genderDAOs.Add(GenderMapper.MapToGenderDAO(gender));
            }

            return genderDAOs;
        }

        public List<MonsterTypeDAO> GetMonsterTypes()
        {
            List<MonsterTypeDAO> monsterTypeDAOs = new List<MonsterTypeDAO>();

            foreach (DataAccess.Models.MonsterType monsterType in data.GetMonsterTypes())
            {
                monsterTypeDAOs.Add(MonsterTypeMapper.MapToMonsterTypeDAO(monsterType));
            }

            return monsterTypeDAOs;
        }

        public List<TitleDAO> GetTitles()
        {
            List<TitleDAO> titleDAOs = new List<TitleDAO>();

            foreach (DataAccess.Models.Title title in data.GetTitles())
            {
                titleDAOs.Add(TitleMapper.MapToTitleDAO(title));
            }

            return titleDAOs;
        }
    }
}
