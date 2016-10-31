using MonsterApp.DataAccess.Models;
using MonsterApp.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterApp.DataClient
{
    public class GenderMapper
    {
        public static GenderDAO MapToGenderDAO(Gender gender)
        {
            return new GenderDAO { Id = gender.GenderId, Name = gender.GenderName };
        }

        public static Gender MapToGender(GenderDAO gender)
        {
            throw new NotImplementedException();
        }

        /*public static object MapTo(object o)
        {
            var properties = o.GetType().GetProperties();
            var ob = new object();

            foreach (var property in properties)
            {
                ob.GetType().GetProperty(property.Name).SetValue(ob, property.GetValue(property));
            }

            return ob;
        }*/
    }
}