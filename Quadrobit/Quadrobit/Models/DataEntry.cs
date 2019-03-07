#region Author

// Author ILYA GOLOVACH (aka IngweLand)
// http://ingweland.com
// ingweland@gmail.com
// Created: 07 03 2019

#endregion

#region

using SQLite;

#endregion

namespace Quadrobit.Models
{
    public class DataEntry
    {
        public string Date { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Subtitle { get; set; }
        public string Title { get; set; }
    }
}