using System;

namespace Nasr.API.Core.Person
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public DateTime BirthDay { get; set; }
        public string Config { get; set; }
        public byte[] RowVer { get; set; }
    }
}