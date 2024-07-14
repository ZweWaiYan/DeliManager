
namespace DeliManager.Common
{
    using System;
    using System.Collections.Generic;

    public class SearchResultObject<TSearchResultRecord>
    {
        
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<string> TableColumn { get; set;}
        public int TotalCount { get; set; }      
        public List<TSearchResultRecord> Records { get; set; }

        public SearchResultObject()
        {
            Status = true;
            TableColumn =  new List<string>();
            Message = "";
            TotalCount = 0;
            Records = new List<TSearchResultRecord>();
        }
    }
    
}
