using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Komodo_Claims_Repository
{
    //first repo made, #1 to write on
    public class ClaimContent
    {
        public int ClaimId { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public double ClaimAmount { get; set; }
        public bool Valid { get; set; }


        public ClaimContent () { }

        public ClaimContent(int claimId, string claimType, string description, DateTime dateOfIncident, DateTime dateOfClaim, double claimAmount, bool valid)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            Description = description;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            ClaimAmount = claimAmount;
            Valid = valid;
        }



    }
}
