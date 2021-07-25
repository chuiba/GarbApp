using System;

namespace App1.Models
{
    public class Item : IComparable<Item>
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public int CompareTo(Item other)
        {
            return other.Id.CompareTo(Id);
        }
    }
}