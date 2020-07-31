using AspNetCore_HangFire_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_HangFire_Sample.Services
{
    public interface IExecuteBackgroundJob
    {
        void Execute(BackgroundJobParameters parameters);
    }
}
