using System;

namespace Nasr.API.Core.Person
{
    public class PersonCreateModel
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Config { get; set; }
    }
}