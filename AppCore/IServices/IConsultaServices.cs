﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.IServices
{
    public interface IConsultaServices
    {
        Root getWeather(string city, string APIKey);
        string GetImageLocation(Root info);
        DateTime convertDateTime(long sec);
        string GetTempinC(Root info);
    }
}
