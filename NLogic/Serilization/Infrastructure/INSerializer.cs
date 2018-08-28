using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLogic.Serilization.Infrastructure
{
    public interface INSerializer
    {
        #region Methods

        Task Serialize();

        #endregion Methods
    }
}