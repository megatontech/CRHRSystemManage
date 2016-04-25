using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOA.Model;

namespace FineOA.Web.Helper
{
    public class PowerHelper
    {
        private static List<t_Power> _powers;

        public static List<t_Power> Powers
        {
            get
            {
                if (_powers == null)
                {
                    InitPowers();
                }
                return _powers;
            }
        }

        public static void Reload()
        {
            _powers = null;
        }

        private static void InitPowers()
        {
            BLL.t_Power bll = new BLL.t_Power();
            _powers = bll.GetModelList("");
        }
    }
}