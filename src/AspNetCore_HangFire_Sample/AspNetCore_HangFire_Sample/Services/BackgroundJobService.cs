using AspNetCore_HangFire_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SimpleExec.Command;

namespace AspNetCore_HangFire_Sample.Services
{
    internal class BackgroundJobService : IExecuteBackgroundJob
    {
        public void Execute(BackgroundJobParameters parameters)
        {
            Run(parameters.ExePath, parameters.Arguments, parameters.WorkingDirectory);
        }
    }
}
