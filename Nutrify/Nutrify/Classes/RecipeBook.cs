using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Nutrify.Classes
{
    class RecipeBook
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Label { get; set; }

        public string Image { get; set; }

        public string Url { get; set; }

        public double Calories { get; set; }

        public double TotalTime { get; set; }

        public RecipeBook()
        {

        }
    }
}