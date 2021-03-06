using System;
using System.Xml.Serialization;
using YSWL.TaoBao.Domain;

namespace YSWL.TaoBao.Response
{
    /// <summary>
    /// LogisticsAddressRemoveResponse.
    /// </summary>
    public class LogisticsAddressRemoveResponse : TopResponse
    {
        /// <summary>
        /// 只返回修改日期modify_date
        /// </summary>
        [XmlElement("address_result")]
        public AddressResult AddressResult { get; set; }
    }
}
