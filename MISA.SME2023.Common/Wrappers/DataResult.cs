namespace MISA.SME2023.Common
{
    public class DataResult<T>
    {
        #region Properties

        public int TotalDisplay { get; set; }

        public int TotalRecord { get; set; }

        public IEnumerable<T> Data { get; set; }

        #endregion

        public DataResult(IEnumerable<T> data, int totalRecord)
        {
            TotalDisplay = data.Count();
            TotalRecord = totalRecord;
            Data = data;
        }
    }
}
