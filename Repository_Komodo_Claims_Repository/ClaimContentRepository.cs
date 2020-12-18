using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Komodo_Claims_Repository
{
    //second to make,  second in repo, #2 to write in
    public class ClaimContentRepository
    {
        private Queue<ClaimContent> _listOfContent = new Queue<ClaimContent>();
    
        public void AddContentToQueue (ClaimContent content)
        {
            _listOfContent.Enqueue(content);
        }

        public Queue<ClaimContent> GetContentQueue()
        {
            return _listOfContent;
        }
        
        public bool UpdateExistingContent(int OriginalNumber, ClaimContent newContent)
        {
            ClaimContent oldContent = GetContentByNumber(OriginalNumber);

            if (oldContent != null)
            {
                oldContent.ClaimId = newContent.ClaimId;
                oldContent.ClaimType = newContent.ClaimType;
                oldContent.Description = newContent.Description;
                oldContent.DateOfIncident = newContent.DateOfIncident;
                oldContent.DateOfClaim = newContent.DateOfClaim;
                oldContent.ClaimAmount = newContent.ClaimAmount;
                oldContent.Valid = newContent.Valid;

                return true;

            }
            else
            {
                return false;
            }

        }


        public bool RemoveContentFromQueue(int ClaimId)
        {
            ClaimContent content = GetContentByNumber(ClaimId);

            if(content == null)
            {
                return false;
            }

            int initialCount = _listOfContent.Count;
            //_listOfContent.Dequeue<ClaimContent>;

            if(initialCount > _listOfContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        public ClaimContent GetContentByNumber(int ClaimId)
        {
            foreach(ClaimContent content in _listOfContent)
            {
                if (content.ClaimId == ClaimId)
                {
                    return content;

                }
            }
            return null;
        }
    
    }
}
