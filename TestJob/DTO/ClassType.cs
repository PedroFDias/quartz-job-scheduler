using System;
using TestJob.Job;

namespace TestJob.DTO
{
    public static class JobRegistry 
    {
        private static readonly Dictionary<string, Type> Jobs = new() {
            ["GetClimaJob"] = typeof(GetClimaJob)
        };

        public static Type GetType(string jobName)
        {
            if (!Jobs.TryGetValue(jobName, out var type))
                throw new InvalidOperationException($"Job {jobName} não encontrada!");

            return type;
        }
    }
}
