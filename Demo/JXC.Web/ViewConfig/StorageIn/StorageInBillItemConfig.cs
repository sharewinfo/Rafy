﻿/*******************************************************
 * 
 * 作者：胡庆访
 * 创建日期：20130821
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 胡庆访 20130821 15:29
 * 
*******************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rafy.MetaModel;
using Rafy.MetaModel.View;

namespace JXC.Web.ViewConfig.BasicData
{
    internal class StorageInBillItemConfig : WebViewConfig<StorageInBillItem>
    {
        protected override void ConfigView()
        {
            View.DomainName("入库单项").HasDelegate(StorageInBillItem.View_ProductNameProperty);

            using (View.OrderProperties())
            {
                View.Property(StorageInBillItem.View_ProductNameProperty).HasLabel("商品名称").ShowIn(ShowInWhere.All);
                View.Property(StorageInBillItem.View_ProductCategoryNameProperty).HasLabel("商品类别").ShowIn(ShowInWhere.List);
                View.Property(StorageInBillItem.View_SpecificationProperty).HasLabel("规格").ShowIn(ShowInWhere.List);
                View.Property(StorageInBillItem.UnitPriceProperty).HasLabel("单价*").ShowIn(ShowInWhere.List);
                View.Property(StorageInBillItem.AmountProperty).HasLabel("入库数量*").ShowIn(ShowInWhere.List);
                View.Property(StorageInBillItem.View_TotalPriceProperty).HasLabel("总价").ShowIn(ShowInWhere.List);
            }
        }
    }
}