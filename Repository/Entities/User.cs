using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class User
    {
        /// <summary>
        /// 使用者ID
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// 使用者帳號
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Account { get; set; }

        /// <summary>
        /// 顯示用名稱
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        /// <summary>
        /// 使用者密碼
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }




        /// <summary>
        /// 使用Email
        /// </summary>
        [Required]
        public string Email { get; set; }


        /// <summary>
        /// 使用者創建時間
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedTime { get; set; }





        #region 外鍵欄位
        /// <summary>
        /// 使用者角色Id(權限角色)
        /// </summary>
        [Required] 
        public Guid RoleId { get; set; }//外鍵ID 
        #endregion



        #region 外鍵Class
        [ForeignKey("RoleId")]
        public Role Role { get; set; }//外鍵ID
        #endregion


        #region 讓該表知道 要跑到那些資料表當外鍵
        //public ICollection<LoginLog> LoginLog { get; set; }
        //public ICollection<UserLog> UserLog { get; set; }
        //public ICollection<FileLog> FileLog { get; set; }
        //public ICollection<UploadFile> UploadFile { get; set; }
        #endregion

    }
}
