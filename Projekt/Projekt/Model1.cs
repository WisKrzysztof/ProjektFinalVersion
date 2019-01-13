namespace Projekt
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    ///<summary>
    /// Your context has been configured to use a 'Model1' connection string from your application's 
    /// configuration file (App.config or Web.config). By default, this connection string targets the 
    /// 'Projekt.Model1' database on your LocalDb instance. 
    /// If you wish to target a different database and/or database provider, modify the 'Model1' 
    /// connection string in the application configuration file.</summary>
    ///<remarks> Add a DbSet for each entity type that you want to include in your model. For more information 
    /// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109. </remarks>
    public class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        { }
        /// <summary>Gets or sets the station list baza.</summary>
        /// <value>The station list baza.</value>
        public virtual DbSet<StationList> StationListBaza { get; set; }
        
    }

  

    // public virtual DbSet<MyEntity> MyEntities { get; set; }
}

//public class MyEntity
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//}
