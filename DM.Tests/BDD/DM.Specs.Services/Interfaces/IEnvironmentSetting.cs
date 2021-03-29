using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DM.Specs.Services.Implementation;

namespace DM.Specs.Services.Interfaces
{
    public interface IEnvironmentSetting
    {
        EnvironmentSetting GetEnvironmentSettings();
    }
}
