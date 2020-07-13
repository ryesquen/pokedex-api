using System.Collections.Generic;

namespace Models
{
    public class Base
    {
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAttack { get; set; }
        public int SpDefense { get; set; }
        public int Speed { get; set; }
    }

    public class Name
    {
        public string English { get; set; }
        public string Japanese { get; set; }
        public string Chinese { get; set; }
        public string French { get; set; }
    }

    public class Pokemon
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public List<string> Type { get; set; }
        public Base Base { get; set; }
        public string Image { get; set; }
    }
}
