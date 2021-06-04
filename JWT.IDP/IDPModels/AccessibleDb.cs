using Microsoft.EntityFrameworkCore;

namespace JWT.IDP.IDPModels
{
    [Owned]
    public class AccessibleDb
    {
        public string Database { get; set; }
        public string ConnectionString { get; set; }
    }
}
