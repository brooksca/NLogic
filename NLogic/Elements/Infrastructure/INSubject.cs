using System;
using System.Collections.Generic;
using System.Text;

namespace NLogic.Elements.Infrastructure
{
    public interface INSubject
    {
        #region Properties

        string Path { get; }

        Type SubjectType { get; }

        #endregion Properties
    }
}