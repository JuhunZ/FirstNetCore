using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using API.Controllers;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace API.User
{
    public class UserController : BaseController
    {
        private DbContext db;
        public UserController(DbContext dbcontext)
        {
            db = dbcontext;
        }

        [HttpGet]
        public async Task<List<v_user>> GetUserList(v_user user = null)
        {
            var result = from u in db.Set<TUser>()
                         join s in db.Set<TSchool>() on u.SchoolId equals s.SchoolId
                         into usobj
                         from us in usobj.DefaultIfEmpty()
                         where u.IsDel == false
                         select new v_user
                         {
                             UseId = u.UseId,
                             username = u.UserName,
                             address = u.Address,
                             age = u.Age,
                             qq = u.Qq,
                             SchoolId = u.SchoolId,
                             schoolname = us.SchoolName
                         };
            if (user != null && !string.IsNullOrWhiteSpace(user.username))
                result = result.Where(p => p.username.IndexOf(user.username) > 1);
            TUser user1 = new TUser();
            user1.UserName = "聂风";
            await db.AddAsync(user1);
            db.SaveChanges();
            return await result.ToListAsync();
        }
    }
}
