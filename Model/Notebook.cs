using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Evernote_Clone.Model
{
    public class Notebook
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
