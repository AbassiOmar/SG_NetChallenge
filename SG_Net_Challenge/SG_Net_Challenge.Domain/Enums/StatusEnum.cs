﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SG_Net_Challenge.Domain.Enums
{
    public static class EnumExtensions
    {
        public static Enum GetRandomEnumValue(this Type t)
        {
            return Enum.GetValues(t)          // get values from Type provided
                .OfType<Enum>()               // casts to Enum
                .OrderBy(e => Guid.NewGuid()) // mess with order of results
                .FirstOrDefault();            // take first item in result
        }
    }
    public  enum StatusEnum
    {
        SUCESS,
        FAILED
    }

  
}
