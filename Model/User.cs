﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Evernote_Clone.Model
{
    public class User
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
