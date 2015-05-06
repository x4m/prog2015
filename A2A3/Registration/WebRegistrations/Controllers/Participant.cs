using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApplication1
{

    public class Participant
    {
        public Participant()
        {
            Part = new List<ParticipantList>();
        }

        public string TeamName { get; set; }
        public string Town { get; set; }
        public string Fi { get; set; }

        public Gender Gender { get; set; }
        [XmlIgnore]
        public bool IsMale
        {
            get { return Gender == Gender.Male; }
        }
        [XmlIgnore]
        public bool IsFemale
        {
            get { return Gender == Gender.Female; }
        }
        public string GenderInRussian
        {
            get
            {
                if (IsMale)
                {
                    return "М";
                }
                return "Ж";
            }
        }
        [XmlIgnore]
        public bool Junior
        {
            get { return TeamAge == TeamAge.Junior; }
        }
        [XmlIgnore]
        public bool Varsity
        {
            get { return TeamAge == TeamAge.Varsity; }
        }
        [XmlIgnore]
        public bool Adult
        {
            get { return TeamAge == TeamAge.Adult; }
        }
        public string AgeGroup
        {
            get
            {
                if (Junior)
                {
                    return "Junior";
                }
                if (Varsity)
                {
                    return "Varsity";
                }
                if (Adult)
                {
                    return "Adult";
                }
                else return "";

            }
        }
        public int Size { get; set; }
        public string Email { get; set; }
        public string TelNumber { get; set; }
        public TeamAge TeamAge { get; set; }
        public List<ParticipantList> Part { get; set; }

    }

    public class ParticipantList
    {
        public string Name { get; set; }
        public string Age { get; set; }

        public override string ToString()
        {
            return Name + " (" + Age + ")";
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
    public enum TeamAge
    {
        Junior,
        Varsity,
        Adult
    }
}
