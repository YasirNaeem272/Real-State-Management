﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RSM.GlobalMethods
{
    public class HelperMethods
    {
        public static List<SelectListItem> GetListFromEnum<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
            .Cast<T>()
            .Select(e => new SelectListItem
            {
                Value = (Convert.ToInt32(e)).ToString(),
                Text = e.ToString()
            }).ToList();
        }
    }
}