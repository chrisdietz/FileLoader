using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoader.Domain.Entities
{
    class VoterStage
    {
        public string CountyCode { get; set; }
        public int VoterId { get; set; }
        public string LastName { get; set; }
        public string SuffixName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SuppressAddress { get; set; }
        public string ResidenceAddress1 { get; set; }
        public string ResidenceAddress2 { get; set; }
        public string ResidenceCity { get; set; }
        public string ResidenceState { get; set; }
        public string ResidenceZipCode { get; set; }
        public string MailingAddress1 { get; set; }
        public string MailingAddress2 { get; set; }
        public string MailingAddress3 { get; set; }
        public string MailingCity { get; set; }
        public string MailingState { get; set; }
        public string MailingZipCode { get; set; }
        public string MailingCountry { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string PartyAffiliation { get; set; }
        public string Precinct { get; set; }
        public string PrecinctGroup { get; set; }
        public string PrecinctSplit { get; set; }
        public string PrecinctSuffix { get; set; }
        public string VoterStatus { get; set; }
        public string CongressionalDistrict { get; set; }
        public string HouseDistrict { get; set; }
        public string SenateDistrict { get; set; }
        public string CountyCommissionDistrict { get; set; }
        public string SchoolBoardDistrict { get; set; }
        public string DaytimeAreaCode { get; set; }
        public string DaytimePhoneNumber { get; set; }
        public string DaytimePhoneExtension { get; set; }
        public string EmailAddress { get; set; }

    }
}
