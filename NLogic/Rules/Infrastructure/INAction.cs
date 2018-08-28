using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLogic.Rules.Infrastructure
{
    public interface INAction
    {
        #region Methods

        Task ExecuteAsync();

        #endregion Methods
    }
}