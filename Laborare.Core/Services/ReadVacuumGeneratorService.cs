using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborare.Core.Services
{
    public static class ReadVacuumGeneratorService
    {
        public static int _NumOfGenerators = 0;

        static ReadVacuumGeneratorService()
        {
            // detect how many vacuum generators are set in the handler
            foreach (KeyValuePair<string, string[]> entry in MainHandlerService.IoDevices)
            {
                if (entry.Key.Contains("VACUUM_GENERATOR_SENSOR"))
                    _NumOfGenerators++;
            }
        }

    }
}
