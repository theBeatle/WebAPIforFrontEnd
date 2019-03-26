namespace ProjectAPI
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Factory : DbContext
    {
        // Your context has been configured to use a 'Factory' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ProjectAPI.Factory' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Factory' 
        // connection string in the application configuration file.
        public Factory()
            : base("name=Factory")
        {
            Database.SetInitializer<Factory>(new CustomInit<Factory>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Worker> Workers { get; set; }
    }

    /// <summary>
    /// Worker DB Model
    /// </summary>
    public class Worker
    {
        /// <summary>
        /// Worker Id, will be ignored while insertion
        /// </summary>
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string Gender { get; set; }
    }
}