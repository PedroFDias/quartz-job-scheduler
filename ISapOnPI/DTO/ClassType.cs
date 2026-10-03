using System;
using SAPIntegration.Job;

namespace SAPIntegration.DTO
{
    public static class JobRegistry 
    {
        private static readonly Dictionary<string, Type> Jobs = new() {
            ["GetNotasSap"] = typeof(GetNotasSap)
        };

        public static Type GetType(string jobName)
        {
            if (!Jobs.TryGetValue(jobName, out var type))
                throw new InvalidOperationException($"Job {jobName} não encontrada!");

            return type;
        }
    }
}
