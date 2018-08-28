using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLogic.Serilization.Infrastructure
{
    public interface INParser
    {
        #region Methods

        Task Parse(object data);

        #endregion Methods
    }
}