using System;
using System.Xml.Serialization;
using YSWL.TaoBao.Domain;

namespace YSWL.TaoBao.Response
{
    /// <summary>
    /// TicketItemAddResponse.
    /// </summary>
    public class TicketItemAddResponse : TopResponse
    {
        /// <summary>
        /// 门票商品操作结果，具体请参见TicketItemProcessResult数据结构
        /// </summary>
        [XmlElement("ticket_item_process_result")]
        public TicketItemProcessResult TicketItemProcessResult { get; set; }
    }
}