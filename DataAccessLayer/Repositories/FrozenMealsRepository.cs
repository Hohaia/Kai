using DataAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Logging;

namespace DataAccessLayer.Repositories
{
    public class FrozenMealsRepository : IFrozenMealsRepository
    {
        public event Action<string> OnError;

        private void ErrorOccured(string errorMessage, Exception ex)
        {
            if (OnError != null)
                OnError.Invoke(errorMessage);

            Logger.Log(ex.Message, LogType.ERROR);
        }
    }
}
