﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiaiNganAPI.Attribute
{
    public class HandlingExceptionError
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void OnException(Exception ex)
        {
            string message = string.Format("Message: {0}\n", ex.Message);
            message += string.Format("StackTrace: {0} \n", ex.StackTrace.Replace(Environment.NewLine, string.Empty));
            message += string.Format("Source: {0} \n", ex.Source.Replace(Environment.NewLine, string.Empty));
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString().Replace(Environment.NewLine, string.Empty));
            //ModelState.AddModelError(string.Empty, message);
            //log.Error(string.Empty, ex);
            log.Error(message);
        }
    }
}
