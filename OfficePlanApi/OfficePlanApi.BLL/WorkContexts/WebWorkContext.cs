using OfficePlanApi.Domain.Interfaces.WorkContexts;

namespace OfficePlanApi.BLL.WorkContexts
{
    public class WebWorkContext : IWebWorkContext
    {
        public int EmployeeId
        {
            get { return 0; }
        }

        public bool IsAuthenticated
        {
            get { return false; }
        }

        public string UserName
        {
            get { return null; }
        }
    }
}
