using System.Collections.Generic;
using System.ComponentModel;

#nullable enable

namespace gv3kServerFibuLohn.Api.Data.MasterData
{
    public class SelectCustomersResult : BaseResult
    {
        public SelectCustomersResult()
        {
            Customers = new List<DataCustomer>();
        }

        public new SelectCustomersResult Error(eErrorCode errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        [Description("List der Mandanten, auf welche ein Zugriff besteht.")]
        public List<DataCustomer> Customers { set; get; }
    }
}
