using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobs.Logic
{
    public enum MobsErrorEnum
    {
        Exception = 0,
        General,
        // bl errors
        EmailAddressInUse,
        DataNotFound,
        DuplicateCategory,
        UserCategoryInUse,
        InvalidPassword,
    }
    public class MobsError
    {
        public string Context { get; set; }
        public string Error   { get; set; }
        public Exception Exception    { get; set; }
        public MobsErrorEnum ErrorCode { get; set; }

        public MobsError(string context, Exception e)
        {
            this.Context = context;
            this.Exception = e;
            ErrorCode = MobsErrorEnum.Exception;

        }

        public MobsError(string context, string error)
        {
            Context = context;
            Error = error;
            ErrorCode = MobsErrorEnum.General;

        }

        public MobsError(string context, MobsErrorEnum errorCode)
        {
            Context = context;
         
            ErrorCode = errorCode;

        }
        public override string ToString()
        {
            switch (ErrorCode) {
                case MobsErrorEnum.Exception:
                    return $"Error {Context} {Exception.ToString()}";
                case MobsErrorEnum.General:
                    return $"Error {Context} {ErrorCode}";

            }
         

            return $"Error {Context} {ErrorCode.ToString()}";
        }

    }
}
