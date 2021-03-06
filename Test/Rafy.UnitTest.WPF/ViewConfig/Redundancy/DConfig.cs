﻿/*******************************************************
 * 
 * 作者：胡庆访
 * 创建日期：20130930
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 胡庆访 20130930 14:58
 * 
*******************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rafy.MetaModel;
using Rafy.MetaModel.View;
using Rafy.Web;
using UT;

namespace Rafy.UnitTest.WPF.ViewConfig
{
    internal class DConfig : WPFViewConfig<D>
    {
        protected override void ConfigView()
        {
            View.DomainName("D").HasDelegate(D.ANameProperty);

            using (View.OrderProperties())
            {
                View.Property(D.ANameProperty).HasLabel("名称").ShowIn(ShowInWhere.All);
            }
        }
    }
}