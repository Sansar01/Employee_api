namespace Employee_api.Models
{
    public class EmployeeStoreDatabaseSettings:IEmployeeStoreDatabaseSetting
    {
        public string EmployeeCollectionName { get; set; } = string.Empty;

        public string UserCollectionName { get; set; } = string.Empty;

        public string ConnectionString { get; set; } = string.Empty;

        public string DatabaseName { get; set; } = string.Empty;
    }
}
