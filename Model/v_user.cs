using System;

namespace Model
{
    public class v_user
    {
        public int UseId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }
        public int? age { get; set; }
        public string qq { get; set; }
        public string address { get; set; }
        public int? SchoolId { get; set; }
        
        ///-----------------------------------
        public string schoolname { get; set; }
    }
}
