namespace DeliManager.Common
{
    /// <summary>
    /// W2uiSearchCondition
    /// </summary>
    public class GridSearchCondition
    {
        /// <summary>
        /// Field
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Operator
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Values
        /// </summary>
        public string[] Values { get; set; }
    }
}
