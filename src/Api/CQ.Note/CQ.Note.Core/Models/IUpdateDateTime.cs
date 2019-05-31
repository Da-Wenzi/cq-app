using System;

namespace CQ.Note.Core.Models
{
    public interface IUpdateDateTime
    {
        /// <summary>
        /// 获取或设置 最后更新时间。
        /// </summary>
        DateTime UpdateDateTime { get; set; }
    }
}
