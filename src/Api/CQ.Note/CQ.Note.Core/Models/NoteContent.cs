using System;

namespace CQ.Note.Core.Models
{
    public class NoteContent : EntityBase<Guid>
    {

        /// <summary>
        /// 获取或设置 笔记内容。
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 获取或设置 笔记内容序号。
        /// </summary>
        public int Sort { get; set; }


        public Guid NoteId { get; set; }

        /// <summary>
        /// 获取或设置 笔记。
        /// </summary>
        public virtual Note Note { get; set; }
    }
}
