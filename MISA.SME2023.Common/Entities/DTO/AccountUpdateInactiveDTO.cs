namespace MISA.SME2023.Common
{
    public class AccountUpdateInactiveDTO
    {
        public Guid id { get; set; }

        public bool inactive { get; set; }

        public bool force_child { get; set; }
    }
}
