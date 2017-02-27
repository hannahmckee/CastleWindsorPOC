using System;
using CastleWindsorPOC.Domain.Interfaces;

namespace CastleWindsorPOC.Domain
{
    public class WatchService : IWatchService
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
