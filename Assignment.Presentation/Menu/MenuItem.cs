namespace Assignment.Presentation
{
    public class MenuItem
    { 

        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        /// <summary>
        /// In the future EngItemDisplayText and FRItemDisplayText could be replaced by a ListOfLanguages
        /// </summary>        
        public string EngItemDisplayText { get; set; }
        public string FRItemDisplayText { get; set; }

        
    }
}
