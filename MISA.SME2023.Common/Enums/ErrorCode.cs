namespace MISA.SME2023.Common
{
    public enum ErrorCode
    {
        Exception = 1,

        Invalid = 2,

        Duplicate = 3,

        Required = 4,

        TooLong = 5,

        DuplicatedAccountNumber = 1001,
        InvalidAccountNumberFormat = 1002,
        InvalidChildAccount = 1003,
        EmptyParentAccount = 1004,

        DuplicatedPaymentNumber = 2001,
        InvalidPostedDate = 2002
    }
}
