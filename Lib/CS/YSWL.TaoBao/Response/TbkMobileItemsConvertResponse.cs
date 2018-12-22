using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using YSWL.TaoBao.Domain;

namespace YSWL.TaoBao.Response
{
    /// <summary>
    /// TbkMobileItemsConvertResponse.
    /// </summary>
    public class TbkMobileItemsConvertResponse : TopResponse
    {
        /// <summary>
        /// 淘宝客商品对象列表
        /// </summary>
        [XmlArray("tbk_items")]
        [XmlArrayItem("tbk_item")]
        public List<TbkItem> TbkItems { get; set; }

        /// <summary>
        /// 返回的结果总数
        /// </summary>
        [XmlElement("total_results")]
        public long TotalResults { get; set; }
    }
}