using NLogic.Elements.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLogic.Elements
{
    internal class NOperators
    {
        #region Fields

        public static INOperator ContainsCaseSensitive = new NOperator(
            "Contains (case sensitive)",
            new string[]
            {
                "contains-sensitive",
                "in-sensitive",
                "has-sensitive"
            },
            new Type[] {
                typeof(string)
            });

        public static INOperator Equal = new NOperator(
                    "Equal",
            new string[]{
                "=",
                "==",
                "===",
                "eq",
                "equals"
            },
            new Type[] {
                typeof(string),
                typeof(short),
                typeof(int),
                typeof(long),
                typeof(bool),
                typeof(char)
            });

        public static INOperator NotContainsCaseSensitive = new NOperator(
                    "Does Not Contain (case sensitive)",
            new string[]
            {
                "!contains-sensitive",
                "not-contains-sensitive",
                "!in-sensitive",
                "not-in-sensitive",
                "!has-sensitive",
                "not-has-sensitive"
            },
            new Type[] {
                typeof(string)
            });

        public static INOperator NotEqual = new NOperator(
            "NotEqual",
            new string[]{
                "!=",
                "!==",
                "ne",
                "notequals"
            },
            new Type[] {
                typeof(string),
                typeof(short),
                typeof(int),
                typeof(long),
                typeof(bool),
                typeof(char)
            });

        #endregion Fields
    }
}