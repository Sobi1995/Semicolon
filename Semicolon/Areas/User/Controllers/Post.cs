﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.User.Controllers
{
    public class Post: UserBaseController
    {
        public Post()
        {

        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
