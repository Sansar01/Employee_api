namespace Employee_api.Models
{
    public interface IEmployeeStoreDatabaseSetting
    {
        public string EmployeeCollectionName { get; set; }

        public string UserCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
