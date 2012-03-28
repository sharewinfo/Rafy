﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace hxy.Common.Data.Providers
{
    internal class OracleProvider : ISqlProvider
    {
        #region ISqlConverter Members

        public string ConvertToSpecialDbSql(string commonSql)
        {
            return ConverterFactory.ReParameterName.Replace(commonSql, ":param${number}");
        }

        public string GetParameterName(int number)
        {
            return ":param" + number;
        }

        public string ProcudureReturnParameterName
        {
            get { return "ReturnValue"; }
        }

        #endregion
    }
}
