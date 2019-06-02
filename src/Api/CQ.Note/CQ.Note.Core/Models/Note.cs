using System;
using System.Collections.Generic;

namespace CQ.Note.Core.Models
{
    public class Note : EntityBase<Guid>, ICreateDateTime, IUpdateDateTime
    {
        /// <summary>
        /// 获取或设置 笔记标题。
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 获取或设置 笔记描述。
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// 获取或设置 笔记内容。
        /// </summary>
        public virtual ICollection<NoteContent> NoteContents { get; set; }

        /// <summary>
        /// 获取或设置 笔记附件。
        /// </summary>
        public virtual ICollection<NoteAttachment> NoteAttachments { get; set; }



        /// <summary>
        /// 获取或设置 创建时间。
        /// </summary>
        public DateTime CreateDateTime { get; set; }


        /// <summary>
        /// 获取或设置 最后更新时间。
        /// </summary>
        public DateTime UpdateDateTime { get; set; }




    }
}
