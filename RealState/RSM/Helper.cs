using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSM
{
    public class Helper
    {
        public static List<SelectListItem> GetEnumSelectList<T>() where T : Enum
        {
            var enumList = Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString()
                })
                .ToList();

            // Add placeholder
            enumList.Insert(0, new SelectListItem { Value = "", Text = "Select Size" });

            return enumList;
        }
    }
}